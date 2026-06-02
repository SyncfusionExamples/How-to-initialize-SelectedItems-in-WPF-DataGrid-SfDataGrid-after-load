# How to initialize SelectedItems in WPF DataGrid (SfDataGrid) after load?

In [WPF DataGrid](https://www.syncfusion.com/wpf-controls/datagrid) (SfDataGrid), the [SelectedItems](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_SelectedItems) collection is initialized only after the control is fully loaded to ensure proper binding support. In this scenario, accessing [SelectedItems](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_SelectedItems) before the control has completed initialization leads to `NullReferenceException`.

To resolve this, you can either manually initialize the [SelectedItems](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfGridBase.html#Syncfusion_UI_Xaml_Grid_SfGridBase_SelectedItems) collection before accessing it or use the Dispatcher to defer access until the control is loaded. A sample approach is shown below.

**C#**
```csharp
protected override void OnAttached()
 {
     base.OnAttached();

     // Solution 1:Here initialize the SelectedItems before accessing

     if (AssociatedObject.SelectedItems == null)
     {
         AssociatedObject.SelectedItems = new ObservableCollection<object>();
     }
     AssociatedObject.SelectedItems.CollectionChanged += OnSelectedItemsChanged;


     // Solution 2: Here using Dispatcher
     AssociatedObject.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(() =>
     {
         //This event call after control loaded
         AssociatedObject.SelectedItems.CollectionChanged += OnSelectedItemsChanged;
     }));
 }
 ```

For more details about this change, refer to the release notes: [Essential Studio for WPF Weekly NuGet Release Notes](https://help.syncfusion.com/wpf/release-notes/v20.3.0.49?type=all#sfdatagrid-bug-fixes)

Take a moment to peruse the [WPF DataGrid - Selection](https://help.syncfusion.com/wpf/datagrid/selection) documentation, to learn more about selection with example.