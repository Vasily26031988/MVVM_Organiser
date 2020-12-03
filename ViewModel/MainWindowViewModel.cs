using MVVM_Organiser.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MVVM_Organiser.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
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
        public MainWindowViewModel()
        {
            DadaItem = new ObservableCollection<DataModel>()
            {
                new DataModel { CreationDate = DateTime.Now, IsDone = false, Text = "Задача номер 1"},
                new DataModel { CreationDate = DateTime.Now, IsDone = true, Text = "Задача номер 2" },
            };
        }          
    }
}
