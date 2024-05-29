using Syncfusion.Maui.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipGroupSample
{
    public class ChipModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool showSelectionIndicator;

        public bool ShowSelectionIndicator
        {
            get
            {
                return showSelectionIndicator;
            }
            set
            {
                showSelectionIndicator = value;
                OnPropertyChanged(nameof(ShowSelectionIndicator));
            }
        }
        private Color selectedColor;

        public Color SelectedColor
        {
            get
            {
                return selectedColor;
            }
            set
            {
                selectedColor = value;
                OnPropertyChanged(nameof(SelectedColor));
            }
        }

        private FontAttributes _fontAttributes;

        public FontAttributes FontAttributes
        {
            get
            {
                return _fontAttributes;
            }
            set
            {
                _fontAttributes = value;
                OnPropertyChanged(nameof(FontAttributes));
            }
        }
        public string Name { get; set; }
        public int ID { get; set; }
    }
}
