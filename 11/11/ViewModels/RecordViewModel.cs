using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using _11.Commands;
using Models;

namespace ViewModels
{
    class RecordViewModel : INotifyPropertyChanged
    {
        private Record record;
        private ICollection<RecordViewModel> collection;

        public RecordViewModel(Record record, ICollection<RecordViewModel> collection)
        {
            this.record = record;
            this.collection = collection;
        }

        public string Fio
        {
            get { return record.Fio; }
            set
            {
                record.Fio = value;
                OnPropertyChanged("Fio");
            }
        }

        public string Subject
        {
            get { return record.Subject; }
            set
            {
                record.Subject = value;
                OnPropertyChanged("Subject");
            }
        }

        public DateTime Time
        {
            get { return record.Time; }
            set
            {
                record.Time = value;
                OnPropertyChanged("Time");
            }
        }

        public int Duration
        {
            get { return record.Duration; }
            set
            {
                record.Duration = value;
                OnPropertyChanged("Duration");
            }
        }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand removeCommand;
        public ICommand RemoveCommand
        {
            get
            {
                if (removeCommand == null)
                    removeCommand = new DeleteRecordCommand(collection, this);
                return removeCommand;
            }
        }
    }
}
