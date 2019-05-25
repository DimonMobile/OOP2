using _11.Commands;
using DbContexts;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private RecordContext context;
        public void OnPropertyNotifyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<RecordViewModel> Records { get; set; }

        public MainViewModel(RecordContext context)
        {
            this.context = context;
            Records = new ObservableCollection<RecordViewModel>();
            var items = context.Record.Select(p => p);
            foreach(Record item in items)
            {
                Records.Add(new RecordViewModel(item, Records));
            }
        }
        public RecordContext Context
        {
            get
            {
                return context;
            }
        }

        private ICommand createRecordCommand;

        public ICommand NewRecordCommand
        {
            get {
                if (createRecordCommand == null)
                    createRecordCommand = new CreateRecordCommand(Records);
                return createRecordCommand;
            }
        }
    }
}
