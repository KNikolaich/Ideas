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
        IRepository _repository;

        public IRepository Repository
        {
            get => _repository ?? (_repository = new FakeRepository());
            set => _repository = value;
        }

    }
}