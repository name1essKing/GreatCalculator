using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace GreatCalculator.Client.Views.Tabs
{
    public class TextBoxBehavior
    {
        private readonly TextBox _textBox;

        public TextBoxBehavior(TextBox textBox)
        {
            _textBox = textBox;
            _textBox.AddHandler(TextBox.KeyDownEvent, OnKeyDown, RoutingStrategies.Tunnel);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender;

            // Проверяем, если пользователь нажимает клавиши, которые нам не нужны.
            if (e.Key == Key.Space)
            {
                e.Handled = true; // блокируем пробел
                return;
            }

            // Разрешаем только цифры, точку и управляющие клавиши (Backspace, стрелки)
            var allowedKeys = new[]
            {
                Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9, // Цифры
                Key.Decimal,          // Точка
                Key.Back,             // Backspace
                Key.Left, Key.Right,  // Стрелки
            };

            // Блокируем все клавиши, которые не разрешены
            if (Array.IndexOf(allowedKeys, e.Key) == -1)
            {
                e.Handled = true; // Блокируем ввод
            }

            // Если нажата клавиша Backspace
            if (e.Key == Key.Back)
            {
                // Проверяем, если весь текст выделен
                if (textBox.SelectionStart != textBox.SelectionEnd) // Проверка выделенного текста
                {
                    e.Handled = true; // Блокируем удаление текста при выделении
                    return;
                }

                // Если длина текста больше 1, удаляем последний символ
                if (textBox.Text.Length > 1)
                {
                    // Символ будет удален по одному
                }
                else if (textBox.Text.Length == 1 && int.TryParse(textBox.Text, out int value) && value >= 1 && value <= 9)
                {
                    // Если длина текста равна 1 и это цифра от 1 до 9, заменим текст на "0"
                    textBox.Text = "0";
                    e.Handled = true; // Блокируем дальнейшую обработку (удаление символа)
                }
                else if (string.IsNullOrEmpty(textBox.Text) || textBox.Text.Length == 1)
                {
                    // Если длина текста == 1, не разрешаем удалить
                    e.Handled = true;  // Блокируем удаление, оставляем текст "0"
                }
            }
        }



        private void OnTextInput(object sender, TextInputEventArgs e)
        {
            var textBox = (TextBox)sender;

            // Если текст пустой и не равно "0", запишем "0"
            if (string.IsNullOrEmpty(textBox.Text) && e.Text != "" && e.Text != "0")
            {
                textBox.Text = e.Text; // Если текст пустой, записываем введённую цифру
            }

            // Если текст начинается с "0", а ввели цифру, то заменяем "0" на введенную цифру
            if (textBox.Text == "0" && char.IsDigit(e.Text[0]))
            {
                textBox.Text = e.Text; // Заменяем "0" на введённое число
            }

            // Проверяем, если введен пробел
            if (e.Text == " ")
            {
                e.Handled = true;  // Блокируем пробел
            }

            // Обрабатываем случаи, если точка вводится повторно
            if (e.Text == "." && textBox.Text.Contains("."))
            {
                e.Handled = true; // Блокируем повторное добавление точки
            }
        }

        private void OnPreviewTextInput(object sender, TextInputEventArgs e)
        {
            // Если текст пустой, запишем "0"
            if (string.IsNullOrEmpty(_textBox.Text) && e.Text == "" && _textBox.Text != "0")
            {
                _textBox.Text = "0";
            }
        }
    }
}
