using Avalonia.Controls;
using GreatCalculator.ui;
using ReactiveUI;
using System;
using System.ComponentModel;
using Microsoft.CodeAnalysis;

namespace GreatCalculator.Client.Views.Tabs
{
    /// <summary>
    /// Модель представления для вкладки калькулятора.
    /// Управляет состоянием и логикой калькулятора, включая операции и отображение результата.
    /// </summary>
    public sealed partial class CalculatorTabViewModel : ReactiveViewModelBase
    {
        private double _firstValue;  // поле для первого значения в операции.
        private double _secondValue; // поле для второго значения в операции.
        private string _result;     // поле для хранения результата.
        private OperationEnum _operator = OperationEnum.Plus;  // Операция по умолчанию (сложение).
        private bool _operatorChecker; // Флаг, указывающий, что операция выполнена.

        /// <summary>
        /// Свойство для получения или установки результата вычислений.
        /// </summary>
        public string Result
        {
            get => _result;
            set => this.RaiseAndSetIfChanged(ref _result, value);
        }

        /// <summary>
        /// Конструктор, инициализирующий результат значением "0".
        /// </summary>
        public CalculatorTabViewModel()
        {
            Result = "0";
        }

        /// <summary>
        /// Добавляет число к текущему результату.
        /// Если результат равен "0" или "Error", заменяет его на новое значение.
        /// </summary>
        /// <param name="newValue">Число для добавления.</param>
        public void AddNumber(double newValue)
        {
            Result = (Result == "0" || Result == "Error")
                ? Result = newValue.ToString()
                : Result += newValue.ToString();
        }

        /// <summary>
        /// Очищает текущий ввод и устанавливает результат в "0".
        /// </summary>
        public void ClearEntry()
        {
            Result = "0";
        }

        /// <summary>
        /// Очищает все значения и устанавливает результат в "0".
        /// </summary>
        public void ClearAll()
        {
            _firstValue = _secondValue = 0;
            Result = "0";
        }

        /// <summary>
        /// Удаляет последний символ в результате.
        /// Если длина строки меньше 2, устанавливает результат в "0".
        /// </summary>
        public void Backspace()
        {
            Result = Result.Length > 1
                ? Result.Remove(Result.Length - 1)
                : "0";
        }

        /// <summary>
        /// Преобразует текущее число в его дробную форму (обратная величина).
        /// Если число равно 0, отображается "Error".
        /// </summary>
        public void ChangeToDivider()
        {
            if (double.TryParse(Result, out double resultValue))
            {
                Result = resultValue > 0 || resultValue < 0
                    ? (1 / resultValue).ToString()
                    : "Error";
            }
        }

        /// <summary>
        /// Возводит текущее число в квадрат.
        /// </summary>
        public void Square()
        {
            Result = Convert.ToString(Convert.ToDouble(Result) * Convert.ToDouble(Result));
        }

        /// <summary>
        /// Извлекает квадратный корень из текущего числа.
        /// </summary>
        public void SquareRoot()
        {
            Result = Convert.ToString(Math.Sqrt(Convert.ToDouble(Result)));
        }

        /// <summary>
        /// Меняет знак текущего числа на противоположный.
        /// Если число равно 0, отображается "Error".
        /// </summary>
        public void Reverse()
        {
            if (double.TryParse(Result, out double resultValue))
            {
                Result = resultValue > 0 || resultValue < 0
                    ? (-1 * resultValue).ToString()
                    : "Error";
            }
        }

        /// <summary>
        /// Добавляет точку к результату.
        /// </summary>
        public void Dot()
        {
            Result += ".";
        }

        /// <summary>
        /// Выполняет математическую операцию (сложение, вычитание и т.д.)
        /// и обновляет результат.
        /// </summary>
        /// <param name="operation">Операция, которую нужно выполнить.</param>
        public void PerformOperation(OperationEnum operation)
        {
            _secondValue = Convert.ToDouble(Result);
            switch (_operator)
            {
                // Сложение.
                case OperationEnum.Plus:
                    {
                        _firstValue += _secondValue;
                        Result = "0";
                        break;
                    }
                // Вычитание.
                case OperationEnum.Minus:
                    {
                        _firstValue -= _secondValue;
                        Result = "0";
                        break;
                    }
                // Умножение.
                case OperationEnum.Multiply:
                    {
                        if (_operatorChecker == true && (_firstValue == 0 || _secondValue == 0))
                        {
                            break;
                        }
                        else
                        {
                            _firstValue *= _secondValue;
                            Result = "0";
                            break;
                        }
                    }
                // Деление.
                case OperationEnum.Divide:
                    {
                        if (_operator == OperationEnum.Divide && operation == OperationEnum.Result && _secondValue == 0)
                        {
                            // Защита от деления на 0.
                            Result = "Error";
                            return;
                        }
                        else if (_operatorChecker == true && (_firstValue == 0 || _secondValue == 0))
                        {
                            break;
                        }
                        else
                        {
                            _firstValue /= _secondValue;
                            Result = "0";
                            break;
                        }
                    }
            }

            // Если была нажата кнопка "=", выводим итоговое значение.
            if (operation == OperationEnum.Result)
            {
                Result = _firstValue.ToString();
                _operator = OperationEnum.Plus;
                _firstValue = 0;
                _operatorChecker = false;
            }
            else
            {
                // Если была выбрана новая операция, сохраняем ее для следующего вычисления.
                _operator = operation;
                _operatorChecker = true;
            }
        }
    }
}
