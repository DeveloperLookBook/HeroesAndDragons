using ServerApp.Data.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Invokers
{
    public class CommandInvoker
    {
        private int _current;

        private List<ICommand> Commands => new List<ICommand>();
        private object         Lock     => new object();
        private int            Current
        {
            get => this._current;
            set
            {
                lock (this.Lock)
                {
                    this._current = value;
                }
            }
        }

        public void StoreCommand  (ICommand command)
        {
            lock(this.Lock)
            {
                this.Commands.Add(command);
            }
        }
        public void ExecuteCommand()
        {
            lock (this.Lock)
            {
                this.Commands[this.Current++].Execute();
            }
        }
    }
}
