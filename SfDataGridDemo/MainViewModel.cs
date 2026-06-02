using System.Collections.ObjectModel;

namespace SfDataGridDemo
{
    public class MainViewModel
    {
        public ObservableCollection<Person> Items { get; } =
            new ObservableCollection<Person>
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 40 }
            };
    }
}
