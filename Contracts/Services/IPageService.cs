using System;
using System.Windows.Controls;

namespace SF_DataGrid.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);

        Page GetPage(string key);
    }
}
