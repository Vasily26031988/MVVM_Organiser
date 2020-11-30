using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MVVM_Organiser.ViewModel
{
    public class ToDoViewModel : INotifyPropertyChanged
    {
        // TODO. Перенести в папку с моделью.
        public class DataModel
        {
            public bool IsDone { get; set; }
            public DateTime CreationDate { get; set; }
            public string Text { get; set; }
        }

        private ObservableCollection<DataModel> _dataItem;
        public ObservableCollection<DataModel> DadaItem
        {
            get { return _dataItem; }
            set
            {
                _dataItem = value;
                OnPropertyChanged(nameof(DadaItem));
            }
        }

        public ToDoViewModel()
        {
            DadaItem = new ObservableCollection<DataModel>()
            {
                new DataModel { CreationDate = DateTime.Now, IsDone = false, Text = "Задача номер 1"},
                new DataModel { CreationDate = DateTime.Now, IsDone = true, Text = "Задача номер 2" },
            };
        }
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
