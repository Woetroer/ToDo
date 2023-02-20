//using System.Collections.ObjectModel;

//namespace Todo.Utilities;
//public class FilteredObservableCollectionFactory<T>
//{
//    private ObservableCollection<T> _base;
//    private List<FilteredCollection<T>> _filters;

//    public FilteredObservableCollectionFactory(ObservableCollection<T> baseList)
//    {
//        _base = baseList;

//        _base.CollectionChanged += BaseChanged;
//    }

//    // Add new list with filter to _filters and return observablecollection of that
//    public ObservableCollection<T> Filter(Func<T, bool> filter)
//    {
//        FilteredCollection<T> filtered = new FilteredCollection<T>(filter, _base.Where(filter).ToArray());

//        _filters.Add(filtered);

//        return filtered;
//    }

//    public void BaseChanged(object? sender, EventArgs e)
//    {
//        foreach (FilteredCollection<T> filteredList in _filters)
//        {
//            filteredList.Set(_base.Where(filteredList.Filter).ToArray());
//        }
//    }
//}