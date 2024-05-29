using Syncfusion.Maui.Core;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace ChipGroupSample
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            
        }

        private void chipgroup_SelectionChanged(object sender, Syncfusion.Maui.Core.Chips.SelectionChangedEventArgs e)
        {
            var addedChip = e.AddedItem;
            var removedChip = e.RemovedItem;
            if (viewModel != null)
            {
                if(addedChip != null)
                {
                    foreach (var item in viewModel.DataList)
                    {
                        if (addedChip.Equals(item))
                        {
                            item.ShowSelectionIndicator = true;
                            item.SelectedColor = Colors.White;
                            item.FontAttributes = FontAttributes.Bold;
                        }
                    }
                }
                if(removedChip != null)
                {
                    foreach (var item in viewModel.DataList)
                    {
                        if (removedChip.Equals(item))
                        {
                            item.ShowSelectionIndicator = false;
                            item.SelectedColor = Colors.Black;
                            item.FontAttributes = FontAttributes.None;
                        }
                    }
                }
            }            
        }
    }

}