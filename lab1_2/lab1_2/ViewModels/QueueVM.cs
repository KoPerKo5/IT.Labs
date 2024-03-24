using lab1_3.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;

namespace lab1_3.ViewModel
{
    public class QueueVM : BindableBase
    {
        #region Fields
        private readonly IQueue _stack = new Queue();
        private string _topItem = "";
        private String _newItem;
        private Int32 _count;
        #endregion

        #region Commands
        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand RemoveCommand { get; private set; }
        public DelegateCommand ClearCommand { get; private set; }
        public ObservableCollection<string> Items { get; private set; } = new ObservableCollection<string>();
        #endregion

        #region Constructors
        public QueueVM()
        {
            AddCommand = new DelegateCommand(AddItem);
            RemoveCommand = new DelegateCommand(RemoveItem);
            ClearCommand = new DelegateCommand(ClearQueue);

            Count = Items.Count;
        }
        #endregion

        #region Private Realisation
        private void AddItem()
        {
            if (Items.Contains(_newItem) || _newItem == "")
            {
                MessageBox.Show("Does this element already exist or are you trying to add an empty element", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _stack.Add(_newItem);
            Items.Add(_newItem);
            _newItem = "";

            Count = Items.Count;
        }

        private void RemoveItem()
        {
            try
            {
                _stack.Remove();
                Items.RemoveAt(_stack.Count);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Queue is empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            TopItem = _stack.Count > 0 ? _stack.Remove().ToString() : "";

            Count = Items.Count;
        }

        private void ClearQueue()
        {
            _stack.Clear();
            Items.Clear();
            TopItem = "";

            Count = Items.Count;
        }
        #endregion

        #region Properties
        public string NewItem
        {
            get => _newItem;
            set => SetProperty(ref _newItem, value);

        }

        public string TopItem
        {
            get => _topItem;
            set => SetProperty(ref _topItem, value);
        }

        public Int32 Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }
        #endregion
    }
}
