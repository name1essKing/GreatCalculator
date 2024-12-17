using Avalonia.Controls;
using GreatCalculator.ui;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace GreatCalculator.Client.Views.Tabs
{
    public sealed partial class CalculatorTabViewModel : ReactiveViewModelBase
    {
        private double _firstValue;
        
        private double _secondValue;
        
        private string _result;



        public string Result
        {
            get => _result;
            set => this.RaiseAndSetIfChanged(ref _result, value);
        }

        public CalculatorTabViewModel()
        {
            Result = "0";
        }

        //methods

        public void Square()
        {
            Result = Convert.ToString(Convert.ToDouble(Result) * Convert.ToDouble(Result));
        }
    
    
    
    
    
    
    
    
    
    }
}
