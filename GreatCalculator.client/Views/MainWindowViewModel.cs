using GreatCalculator.Client.Views.Tabs;
using GreatCalculator.ui;
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
