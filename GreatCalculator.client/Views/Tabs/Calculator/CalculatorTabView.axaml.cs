using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GreatCalculator.Client.Views.Tabs;

public partial class CalculatorTabView : UserControl
{
    public CalculatorTabView()
    {
        InitializeComponent();

        // behavior для TextBox.
        var textBox = this.FindControl<TextBox>("CalculatorTextBox");
        new TextBoxBehavior(textBox);
    }
}