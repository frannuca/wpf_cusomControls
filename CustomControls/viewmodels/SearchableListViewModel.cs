using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomControls.viewmodels
{
  
    
    public abstract class SearchableListViewModel<T> : ViewModelBase
    {
        protected T[] _items;
        public SearchableListViewModel(IEnumerable<T> items):base()
        {
            _items= items.ToArray();
            Items = new List<T>(items);
            
        }
        public List<T> Items
        {
            get { return GetProperty<List<T>>(); }
            set { SetProperty<List<T>>(value); }
        }

        public T SelectedItem
        {
            get { return GetProperty<T>(); }
            set { SetProperty<T>(value); }
        }

        


        
    }
}
