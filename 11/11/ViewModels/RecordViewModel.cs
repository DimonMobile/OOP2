using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ViewModels
{
    class RecordViewModel : INotifyPropertyChanged
    {
        private Record record;

        public RecordViewModel(Record record)
        {
            this.record = record;
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
    }
}
