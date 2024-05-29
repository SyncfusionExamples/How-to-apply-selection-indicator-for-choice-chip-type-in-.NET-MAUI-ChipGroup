**Overview**

This article covers implementing a selection indicator for the [.NET MAUI ChipGroup](https://www.syncfusion.com/maui-controls/maui-chips)  when the chip type is `Choice`. The steps involve setting up the model and the view model and managing the selection behavior with the appropriate event handler to indicate the selected chip.

**Model Definition**

The `ChipModel` class should implement the `INotifyPropertyChanged` interface to notify the UI of property changes. Here's an example of how to define the model:

```csharp
public class ChipModel: INotifyPropertyChanged
{
    //Declare method and event for PropertyChanged

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

    public string Name { get; set; }
    public int ID { get; set; }
}
```

**ViewModel Setup**

```csharp
public class ChipViewModel: INotifyPropertyChanged
{
    //Declare method and event for PropertyChanged
    
    private ObservableCollection<ChipModel> dataList;
    public ObservableCollection<ChipModel> DataList
    {
        get { return dataList; }
        set
        {
            dataList= value;
            OnPropertyChanged(nameof(DataList));
        }
    }

    public ChipViewModel()
    {
        // Initialize DataList with sample data
    }
}
```

**XAML Layout**

Define the `SfChipGroup` in XAML:

```xml
<chip:SfChipGroup x:Name="chipgroup" HeightRequest="40" HorizontalOptions="Center"
               ChipType="Choice" SelectedChipBackground="#00B0FF"
               SelectionChanged="chipgroup_SelectionChanged"
               ItemsSource="{Binding DataList}">
    <chip:SfChipGroup.ItemTemplate>
        <DataTemplate>
            <chip:SfChip Text="{Binding Name}" 
                         TextColor="{Binding SelectedColor}"
                         SelectionIndicatorColor="Red" 
                         FontAttributes="{Binding FontAttributes}"
                         ShowSelectionIndicator="{Binding ShowSelectionIndicator}">
            </chip:SfChip>
        </DataTemplate>
    </chip:SfChipGroup.ItemTemplate>
</chip:SfChipGroup>
```

**Code Behind**

Handle the `SelectionChanged` event to update the selected and deselected chips:

```csharp
private void chipgroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                    item.ShowSelectionIndicator= true;
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
                    item.ShowSelectionIndicator= false;
                    item.SelectedColor = Colors.Black;
                    item.FontAttributes = FontAttributes.None;
                }
            }
        }
    }            
```

By following these steps, you can successfully apply a selection indicator to choice chips in a .NET MAUI application.

**Output**

![ChipGroup.gif](https://support.syncfusion.com/kb/agent/attachment/article/16171/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIzNDEwIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.VAARcf1EGmJMU5z7vN1W78indUmZ5UYIOeffqBbYIos)