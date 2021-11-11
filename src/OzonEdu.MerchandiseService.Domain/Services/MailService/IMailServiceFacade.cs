using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;

namespace OzonEdu.MerchandiseService.Domain.Services.MailService
{
    public interface IMailServiceFacade
    {
        Task SendMail(Email employeeEmail, string emailText);
    }
}