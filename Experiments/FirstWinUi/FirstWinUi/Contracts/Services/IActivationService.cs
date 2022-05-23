using System.Threading.Tasks;

namespace FirstWinUi.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
