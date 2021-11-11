using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.AssembleMerchItems
{
    public class AssembleMerchItemsCommand : IRequest<Unit>
    {
        public long RequestNumber { get; set; }
    }
}