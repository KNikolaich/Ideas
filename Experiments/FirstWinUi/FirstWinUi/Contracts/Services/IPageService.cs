using System;

namespace FirstWinUi.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
