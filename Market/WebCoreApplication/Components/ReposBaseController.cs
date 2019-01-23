using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreApplication.Models;

namespace WebCoreApplication.Components
{
    /// <summary>
    /// Некий базовый абстрактный контроллер, содержащий ссылку на репозиторий
    /// </summary>
    public abstract class ReposBaseController : Controller
    {
        IProductRepository _repository;

        public IProductRepository ProductRepository
        {
            get => _repository;
            set => _repository = value;
        }

    }
}