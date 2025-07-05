using Avalonia.Controls;

namespace GreatCalculator.Client.Views.Tabs;

public partial class CalculatorTabView : UserControl
{
    public CalculatorTabView()
    {
        InitializeComponent();

        // behavior ��� TextBox.
        var textBox = this.FindControl<TextBox>("CalculatorTextBox");
        new TextBoxBehavior(textBox);
    }
}