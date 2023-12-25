using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CustomControls.messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomControls.viewmodels
{
    public class SimpleStringItem: ViewModelBase
    {
        public bool IsChecked
        {
            get { return GetProperty<bool>(); }
            set { SetProperty<bool>(value);}
        }
        public string Text
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
        public SimpleStringItem(bool isChecked, string text)
        {
            IsChecked = isChecked;
            Text = text;
        }
    }

    public class SimpleStringSearchableViewModel : SearchableListViewModel<SimpleStringItem> 
    {
        public SimpleStringSearchableViewModel(IEnumerable<SimpleStringItem> items) : base(items)
        {
            AggregateCommand = new RelayCommand(AggregateValues);
            

            ClearCommand = new RelayCommand(() =>
            {
                foreach (var item in _items)
                {
                    item.IsChecked = false;
                }
                
            } );

            SelectAllCommand = new RelayCommand(() =>
            {
                foreach (var item in _items)
                {
                    item.IsChecked = true;
                }
                
            });

            InvertSelectionCommand = new RelayCommand(() =>
            {
                foreach (var item in Items)
                {
                    item.IsChecked = !item.IsChecked;
                }

            });

            ItemsChecked = new List<SimpleStringItem>();

            WeakReferenceMessenger.Default.Register<SelectedItemRemoved>(this, (r, m) =>
            {
               AggregateCommand.Execute(null);
            });
        }

        public string SearchText
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); SearchText_Changed(); }
        }

        protected void SearchText_Changed()
        {
            if (_items != null)
            {
                Items = (_items.Where(x => x.Text.Contains(SearchText)).ToList());
            }                    
        }      

        public ICommand AggregateCommand
        {
            get { return GetProperty<ICommand>(); }
            set { SetProperty<ICommand>(value); }
        }

       

        public ICommand ClearCommand
        {
            get => GetProperty<ICommand>();
            set => SetProperty<ICommand>(value);
        }

        public ICommand SelectAllCommand
        {
            get => GetProperty<ICommand>();
            set => SetProperty<ICommand>(value);
        }

        public ICommand InvertSelectionCommand
        {
            get => GetProperty<ICommand>();
            set => SetProperty<ICommand>(value);
        }

        
        void AggregateValues()
        {
            ItemsChecked =  _items.Where(x => x.IsChecked).ToList();            
        }

        
        public List<SimpleStringItem> ItemsChecked
        {
            get => GetProperty<List<SimpleStringItem>>();
            set => SetProperty<List<SimpleStringItem>>(value);
        }
    }
}
