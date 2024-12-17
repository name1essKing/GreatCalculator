using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCalculator.Client.Views
{
    public sealed partial class MainWindowViewModel
    {
        public sealed class MainWindowViewModelCommands
        { 
            public MainWindowViewModelCommands(MainWindowViewModel vm) 
            { 
            
            }
        }
    
        private MainWindowViewModelCommands _commands;

        public MainWindowViewModelCommands Commands => _commands ??= new(this);
    }
}
