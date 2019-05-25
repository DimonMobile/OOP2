using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModels;

namespace _11.Commands
{
    class CreateRecordCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        ICollection<RecordViewModel> collection;

        public CreateRecordCommand(ICollection<RecordViewModel> collection)
        {
            this.collection = collection;
        }

        public bool CanExecute(object parameter)
        {
            return collection != null;
        }

        public void Execute(object parameter)
        {
            collection.Add(new RecordViewModel(new Record(), collection));
        }
    }
}
