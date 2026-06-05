using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace SfDataGridDemo
{
    public class SelectedItemsBehavior : Behavior<SfDataGrid>
    {
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

            //AssociatedObject.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(() =>
            //{
            //    //This event call after control loaded
            //    AssociatedObject.SelectedItems.CollectionChanged += OnSelectedItemsChanged;
            //}));
        }

        private void OnSelectedItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Handle selection change
        }

        protected override void OnDetaching()
        {
            AssociatedObject.SelectedItems.CollectionChanged -= OnSelectedItemsChanged;

            base.OnDetaching();
        }
    }
}
