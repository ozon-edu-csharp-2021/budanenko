using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;

namespace OzonEdu.MerchandiseService.Domain.Services.MailService
{
    public class MailServiceFacade : IMailServiceFacade
    {
        public Task SendMail(Email employeeEmail, string emailText)
        {
            throw new System.NotImplementedException();
        }
    }
}