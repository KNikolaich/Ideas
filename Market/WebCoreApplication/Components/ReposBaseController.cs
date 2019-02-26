using Microsoft.AspNetCore.Mvc;
using WebCoreApplication.Models;

namespace WebCoreApplication.Components
{
    /// <summary>
    /// Некий базовый абстрактный контроллер, содержащий ссылку на репозиторий
    /// </summary>
    public abstract class ReposBaseController : Controller
    {
        protected IProductRepository _repository;
    }
}