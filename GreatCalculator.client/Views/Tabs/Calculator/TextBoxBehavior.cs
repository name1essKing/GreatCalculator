using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace GreatCalculator.Client.Views.Tabs
{
    public class TextBoxBehavior
    {   // Измененное поведение текстбокса, чтобы ограничить ввод с клавиатуры.
        private readonly TextBox _textBox;

        public TextBoxBehavior(TextBox textBox)
        {
            _textBox = textBox;
            _textBox.AddHandler(TextBox.KeyDownEvent, OnKeyDown, RoutingStrategies.Tunnel);
            _textBox.AddHandler(TextBox.TextInputEvent, OnTextInput, RoutingStrategies.Tunnel);
            _textBox.LostFocus += OnLostFocus; // Добавляем обработчик потери фокуса
        }

        private void OnLostFocus(object? sender, RoutedEventArgs e)
        {
            // Если текст пустой или null, устанавливаем "0"
            if (string.IsNullOrEmpty(_textBox.Text))
            {
                _textBox.Text = "0";
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender;

            if (e.Key == Key.Space)
            {
                e.Handled = true;
                return;
            }

            var allowedKeys = new[]
            {
                Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9,
                Key.OemPeriod, Key.Decimal, Key.Back, Key.Left, Key.Right, Key.Delete, Key.Tab
            };

            if (Array.IndexOf(allowedKeys, e.Key) == -1)
            {
                e.Handled = true;
            }

            // Если нажат Backspace и текст станет пустым — блокируем
            if (e.Key == Key.Back && textBox.Text.Length <= 1)
            {
                textBox.Text = "0"; // Принудительно ставим "0" вместо удаления
                e.Handled = true;
            }
        }

        private void OnTextInput(object sender, TextInputEventArgs e)
        {
            var textBox = (TextBox)sender;

            // Если текст "0" и ввели цифру — заменяем
            if (textBox.Text == "0" && char.IsDigit(e.Text[0]))
            {
                textBox.Text = e.Text;
                e.Handled = true;
                return;
            }

            if (e.Text == " " || (e.Text == "." && textBox.Text.Contains(".")))
            {
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(e.Text[0]) && e.Text != ".")
            {
                e.Handled = true;
            }
        }
    }
}