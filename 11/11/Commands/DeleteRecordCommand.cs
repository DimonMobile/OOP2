using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModels;

namespace _11.Commands
{
    class DeleteRecordCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        ICollection<RecordViewModel> collection;
        RecordViewModel record;

        public DeleteRecordCommand(ICollection<RecordViewModel> collection, RecordViewModel record)
        {
            this.collection = collection;
            this.record = record;
        }

        public bool CanExecute(object parameter)
        {
            return collection != null && collection.Contains(record);
        }

        public void Execute(object parameter)
        {
            collection.Remove(record);
        }
    }
}
