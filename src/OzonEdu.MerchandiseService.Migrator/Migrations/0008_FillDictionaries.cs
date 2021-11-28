using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(8)]
    public class FillDictionaries:ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"
                INSERT INTO merch_pack_request_status (mpr_status_id, mpr_status_name)
                VALUES 
                    (1, 'New'),
                    (2, 'In work'),
                    (3, 'Agreeded'),
                    (4, 'Requested'),
                    (5, 'Waiting delivery'),
                    (6, 'Отказано в выдаче'),
                    (7, 'Done')
                ON CONFLICT DO NOTHING
            ");

            Execute.Sql(@"
                INSERT INTO merch_pack_type (merch_pack_type_id, merch_pack_type_name)
                VALUES 
                    (1,  'Starter'),
                    (2,  'AfterProbation'),
                    (3,  'ConferenceSpeaker'),
                    (4,  'ConferenceListener'),
                    (5,  'Veteran')
                ON CONFLICT DO NOTHING
            ");

            Execute.Sql(@"
                INSERT INTO merch_item_type (merch_item_type_id, merch_item_type_name)
                VALUES 
                    (1,  'TShirtStarter'),
                    (2,  'NotepadStarter'),
                    (3,  'PenStarter'),
                    (4,  'SocksStarter'),
                    (5,  'TShirtAfterProbation'),
                    (6,  'SweatshirtAfterProbation'),
                    (7,  'SweatshirtConferenceSpeaker'),
                    (8,  'NotepadConferenceSpeaker'),
                    (9,  'PenConferenceSpeaker'),
                    (10, 'TShirtConferenceListener'),
                    (11, 'NotepadConferenceListener'),
                    (12, 'PenConferenceListener'),
                    (13, 'TShirtVeteran'),
                    (14, 'SweatshirtVeteran'),
                    (15, 'NotepadVeteran'),
                    (16, 'PenVeteran'),
                    (17, 'CardHolderVeteran')
                ON CONFLICT DO NOTHING
            ");

            Execute.Sql(@"
                INSERT INTO merch_pack_items_map (merch_pack_type_id, merch_item_type_id)
                VALUES 
                    (1, 1),
                    (1, 2),
                    (1, 3),
                    (1, 4),
                    (2, 5),
                    (2, 6),
                    (3, 7),
                    (3, 8),
                    (3, 9),
                    (4, 10),
                    (4, 11),
                    (4, 12),
                    (5, 13),
                    (5, 14),
                    (5, 15),
                    (5, 16),
                    (5, 17)
                ON CONFLICT DO NOTHING
            ");
            
            Execute.Sql(@"
                INSERT INTO clothing_sizes (clothing_size_id, clothing_size_name)
                VALUES 
                    (1, 'XS'),
                    (2, 'S'),
                    (3, 'M'),
                    (4, 'L'),
                    (5, 'XL'),
                    (6, 'XXL')
                ON CONFLICT DO NOTHING
            ");
        }
    }
}