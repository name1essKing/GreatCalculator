using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace GreatCalculator.Client.Views.Tabs
{
    public sealed partial class CalculatorTabViewModel
    {
        public sealed class CalculatorTabViewModelCommands
        {
            public CalculatorTabViewModelCommands(CalculatorTabViewModel vm)
            {
                Square = ReactiveCommand.Create(() =>
                {
                    vm.Square();
                });
            }

            public IReactiveCommand Square { get; }

        }

        private CalculatorTabViewModelCommands _commands;

        public CalculatorTabViewModelCommands Commands => _commands ??= new(this);
    }
}
