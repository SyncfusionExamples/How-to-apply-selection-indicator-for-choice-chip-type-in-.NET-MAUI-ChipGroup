using Syncfusion.Maui.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipGroupSample
{
    public class ChipViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<ChipModel> dataList;
        public ObservableCollection<ChipModel> DataList
        {
            get { return dataList; }
            set
            { dataList = value;
                OnPropertyChanged(nameof(DataList));
            }
        }
        public ChipViewModel()
        {
            DataList = new ObservableCollection<ChipModel>()
               {
                new ChipModel(){Name ="Joseph",ID=100,SelectedColor=Colors.Black,FontAttributes=FontAttributes.None},
                new ChipModel(){Name ="Anne Joseph",ID=101,SelectedColor=Colors.Black,FontAttributes=FontAttributes.None},
                new ChipModel(){Name ="Andrew Fuller",ID=102,SelectedColor=Colors.Black,FontAttributes=FontAttributes.None},
               };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
