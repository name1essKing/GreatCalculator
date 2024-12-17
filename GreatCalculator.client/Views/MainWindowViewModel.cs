using GreatCalculator.ui;
using GreatCalculator.Client.Views.Tabs;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GreatCalculator.Client.Views
{

    public sealed partial class MainWindowViewModel : ReactiveViewModelBase
    {


        public CalculatorTabViewModel CalculatorTabViewModel { get; }


        //конструктор 
        public MainWindowViewModel()
        {
            CalculatorTabViewModel = new CalculatorTabViewModel();

        }


    }
}
