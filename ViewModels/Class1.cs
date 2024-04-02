using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_DataGrid.ViewModels
{
    public class LengthItemSelector : IItemsSourceSelector
    {
        public IEnumerable GetItemsSource(object record, object dataContext)
        {
            if (record == null)
                return null;

            var rectangleItem = record as CustomerInfo;
            if (rectangleItem != null)
            {
                ObservableCollection<CustomerInfo> lengthItems = new ObservableCollection<CustomerInfo>();
                for(int i = 1; i <= 100; i++) 
                {
                }

                return lengthItems.ToList();
            }
            return null;
        }
    }
}
