using System.Threading.Tasks;

namespace FirstWinUi.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
