using DbContexts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public MainViewModel(RecordContext context)
        {
            this.context = context;
        }
        public RecordContext Context
        {
            get
            {
                return context;
            }
        }

    }
}
