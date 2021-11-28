using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Implementation
{
    public class MerchPackRequestRepository : IMerchPackRequestRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IQueryExecutor _queryExecutor;
        private const int Timeout = 5;

        public MerchPackRequestRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory, IQueryExecutor queryExecutor)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _queryExecutor = queryExecutor;
        }

        public async Task<MerchPackRequest> CreateAsync(MerchPackRequest recordToCreate, CancellationToken cancellationToken)
        {
            const string sql = @"
                INSERT INTO merch_pack_request (
                    mpr_status_id, merch_pack_type_id, employee_id, 
                    employee_clothing_size_id, employee_email, mpr_create_date
                )
                VALUES (
                    @RequestStatusId, @MerchPackTypeId, @EmployeeId, @ClothingSizeId, @Email, NOW()
                )
                RETURNING mpr_id;";

            var parameters = new
            {
                // MerchPackRequestId = itemToCreate.MerchPackRequestId?.Value,
                MerchPackTypeId = recordToCreate.MerchPackType.Id,
                RequestStatusId = recordToCreate.RequestStatus.Id,
                EmployeeId = recordToCreate.EmployeeId.Value,
                ClothingSizeId = recordToCreate.ClothingSize?.Id,
                Email = recordToCreate.Email.Value
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            return await _queryExecutor.Execute(recordToCreate, async () =>
            {
                var merchPackRequestId = await connection.QuerySingleAsync<long>(commandDefinition);
                if (merchPackRequestId != default)
                    recordToCreate.SetMerchPackRequestId(merchPackRequestId);
            });
        }

        public async Task<MerchPackRequest> UpdateStatusAsync(MerchPackRequest recordToUpdate, CancellationToken cancellationToken)
        {
            const string sql = @"
                UPDATE merch_pack_request SET
                    mpr_status_id   = @RequestStatusId, 
                    mpr_change_date = NOW()
                WHERE
                    mpr_id = @MerchPackRequestId;";

            var parameters = new
            {
                MerchPackRequestId = recordToUpdate.MerchPackRequestId?.Value,
                RequestStatusId = recordToUpdate.RequestStatus.Id
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            return await _queryExecutor.Execute(recordToUpdate, () => connection.ExecuteAsync(commandDefinition));
        }

        public async Task<List<MerchPackRequest>> GetMerchPackRequestForAssembly(CancellationToken cancellationToken = default)
        {
            const string sql = @"
                SELECT
                    mpr.mpr_id, mpr.mpr_status_id, MPRS.mpr_status_name, mpr.merch_pack_type_id, mpt.merch_pack_type_name,
                    mpr.employee_id, mpr.employee_clothing_size_id, cs.clothing_size_name, mpr.employee_email
                FROM
                    merch_pack_request mpr
                    INNER JOIN merch_pack_request_status mprs ON
                        mpr.mpr_status_id = mprs.mpr_status_id
                    INNER JOIN merch_pack_type mpt ON
                        mpr.merch_pack_type_id = mpt.merch_pack_type_id
                    LEFT JOIN clothing_sizes cs on
                        mpr.employee_clothing_size_id = cs.clothing_size_id
                WHERE
                    mpr.mpr_status_id IN (1,2);";
            
            var commandDefinition = new CommandDefinition(
                sql,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var result = await _queryExecutor.Execute(
                () => connection.QueryAsync<
                    Models.MerchPackRequest, Models.MerchPackRequestStatus, Models.MerchPackType, Models.ClothingSize, MerchPackRequest>(commandDefinition,
                    (merchPackRequest, merchPackRequestStatus, merchPackType, clothingSize) => new MerchPackRequest(
                        new MerchPackRequestId(merchPackRequest.MerchPackRequestId),
                        new RequestStatus(merchPackRequestStatus.MerchPackRequestStatusId, merchPackRequestStatus.MerchPackRequestStatusName),
                        new MerchPackType(merchPackType.MerchPackTypeId, merchPackType.MerchPackTypeName),
                        new EmployeeId(merchPackRequest.EmployeeId),
                        clothingSize?.Id is not null ? new ClothingSize(clothingSize.Id.Value, clothingSize.Name) : null,
                        new Email(merchPackRequest.Email))));
            return result.ToList();
        }
        
/*
        public async Task<StockItem> FindBySkuAsync(Sku sku, CancellationToken cancellationToken)
        {
            const string sql = @"
                SELECT skus.id, skus.name, skus.item_type_id, skus.clothing_size,
                       stocks.id, stocks.sku_id, stocks.quantity, stocks.minimal_quantity,
                       item_types.id, item_types.name,
                       clothing_sizes.id, clothing_sizes.name
                FROM skus
                INNER JOIN stocks on stocks.sku_id = skus.id
                INNER JOIN item_types on item_types.id = skus.item_type_id
                LEFT JOIN clothing_sizes on clothing_sizes.id = skus.clothing_size
                WHERE skus.id = @SkuId;";
            
            var parameters = new
            {
                SkuId = sku.Value,
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            return await _queryExecutor.Execute(
                async () =>
                {
                    var stockItems = await connection.QueryAsync<
                        Models.Sku, Models.StockItem, Models.ItemType, Models.ClothingSize, StockItem>(
                        commandDefinition,
                        (skuModel, stock, itemType, clothingSize) => new StockItem(
                            new Sku(skuModel.Id),
                            new Name(skuModel.Name),
                            new Item(new ItemType(itemType.Id, itemType.Name)),
                            clothingSize?.Id is not null ? new ClothingSize(clothingSize.Id.Value, clothingSize.Name) : null,
                            new Quantity(stock.Quantity),
                            new QuantityValue(stock.MinimalQuantity)));
                    return stockItems.First();
                });
        }

        public async Task<IReadOnlyList<StockItem>> FindBySkusAsync(IReadOnlyList<Sku> skus, CancellationToken cancellationToken)
        {
            const string sql = @"
                SELECT skus.id, skus.name, skus.item_type_id, skus.clothing_size,
                       stocks.id, stocks.sku_id, stocks.quantity, stocks.minimal_quantity,
                       item_types.id, item_types.name,
                       clothing_sizes.id, clothing_sizes.name
                FROM skus
                INNER JOIN stocks on stocks.sku_id = skus.id
                INNER JOIN item_types on item_types.id = skus.item_type_id
                LEFT JOIN clothing_sizes on clothing_sizes.id = skus.clothing_size
                WHERE skus.id = ANY(@SkuIds);";

            var parameters = new
            {
                SkuIds = skus.Select(x => x.Value).ToArray(),
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var result = await _queryExecutor.Execute(
                () =>
                    connection.QueryAsync<
                        Models.Sku, Models.StockItem, Models.ItemType, Models.ClothingSize, StockItem>(
                        commandDefinition,
                        (skuModel, stock, itemType, clothingSize) => new StockItem(
                            new Sku(skuModel.Id),
                            new Name(skuModel.Name),
                            new Item(new ItemType(itemType.Id, itemType.Name)),
                            clothingSize?.Id is not null ? new ClothingSize(clothingSize.Id.Value, clothingSize.Name) : null,
                            new Quantity(stock.Quantity),
                            new QuantityValue(stock.MinimalQuantity))));
            return result.ToList();
        }

        public async Task<IReadOnlyList<StockItem>> GetAllAsync(CancellationToken cancellationToken)
        {
            const string sql = @"
                SELECT skus.id, skus.name, skus.item_type_id, skus.clothing_size,
                       stocks.id, stocks.sku_id, stocks.quantity, stocks.minimal_quantity,
                       item_types.id, item_types.name,
                       clothing_sizes.id, clothing_sizes.name
                FROM skus
                INNER JOIN stocks on stocks.sku_id = skus.id
                INNER JOIN item_types on item_types.id = skus.item_type_id
                LEFT JOIN clothing_sizes on clothing_sizes.id = skus.clothing_size;";
            
            var commandDefinition = new CommandDefinition(
                sql,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var result = await _queryExecutor.Execute(
                () => connection.QueryAsync<
                    Models.Sku, Models.StockItem, Models.ItemType, Models.ClothingSize, StockItem>(commandDefinition,
                    (sku, stock, itemType, clothingSize) => new StockItem(
                        new Sku(sku.Id),
                        new Name(sku.Name),
                        new Item(new ItemType(itemType.Id, itemType.Name)),
                        clothingSize?.Id is not null ? new ClothingSize(clothingSize.Id.Value, clothingSize.Name) : null,
                        new Quantity(stock.Quantity),
                        new QuantityValue(stock.MinimalQuantity))));
            return result.ToList();
        }

        public async Task<IReadOnlyList<StockItem>> FindByItemTypeAsync(long itemTypeId,
            CancellationToken cancellationToken)
        {
            const string sql = @"
                SELECT skus.id, skus.name, skus.item_type_id, skus.clothing_size,
                       stocks.id, stocks.sku_id, stocks.quantity, stocks.minimal_quantity,
                       item_types.id, item_types.name,
                       clothing_sizes.id, clothing_sizes.name
                FROM skus
                INNER JOIN stocks on stocks.sku_id = skus.id
                INNER JOIN item_types on item_types.id = skus.item_type_id
                LEFT JOIN clothing_sizes on clothing_sizes.id = skus.clothing_size
                WHERE item_types.id = @ItemTypeId;";
            
            var parameters = new
            {
                ItemTypeId = itemTypeId,
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var stockItems = await _queryExecutor.Execute( () => connection.QueryAsync<
                Models.Sku, Models.StockItem, Models.ItemType, Models.ClothingSize, StockItem>(commandDefinition,
                (skuModel, stock, itemType, clothingSize) => new StockItem(
                    new Sku(skuModel.Id),
                    new Name(skuModel.Name),
                    new Item(new ItemType(itemType.Id, itemType.Name)),
                    clothingSize?.Id is not null ? new ClothingSize(clothingSize.Id.Value, clothingSize.Name) : null,
                    new Quantity(stock.Quantity),
                    new QuantityValue(stock.MinimalQuantity))));
            
            return stockItems.ToList();
        }
*/
    }
}