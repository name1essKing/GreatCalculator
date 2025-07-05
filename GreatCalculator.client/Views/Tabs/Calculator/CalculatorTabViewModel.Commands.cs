using ReactiveUI;
using System.Reactive;

namespace GreatCalculator.Client.Views.Tabs
{
    /// <summary>
    /// Команды для управления действиями в калькуляторе.
    /// Содержит команды для выполнения операций, таких как очистка, удаление, изменение знака и т.д.
    /// </summary>
    public sealed partial class CalculatorTabViewModel
    {
        /// <summary>
        /// Класс, содержащий команды для взаимодействия с моделью представления калькулятора.
        /// </summary>
        public sealed class CalculatorTabViewModelCommands
        {
            /// <summary>
            /// Конструктор, который инициализирует команды для взаимодействия с калькулятором.
            /// </summary>
            /// <param name="vm">Экземпляр модели представления калькулятора.</param>
            public CalculatorTabViewModelCommands(CalculatorTabViewModel vm)
            {
                // Каждая команда связывается с соответствующим методом модели представления.
                ClearEntry = ReactiveCommand.Create(() =>
                {
                    vm.ClearEntry();
                });

                ClearAll = ReactiveCommand.Create(() =>
                {
                    vm.ClearAll();
                });

                Backspace = ReactiveCommand.Create(() =>
                {
                    vm.Backspace();
                });

                ChangeToDivider = ReactiveCommand.Create(() =>
                {
                    vm.ChangeToDivider();
                });

                Square = ReactiveCommand.Create(() =>
                {
                    vm.Square();
                });

                SquareRoot = ReactiveCommand.Create(() =>
                {
                    vm.SquareRoot();
                });

                Reverse = ReactiveCommand.Create(() =>
                {
                    vm.Reverse();
                });

                Dot = ReactiveCommand.Create(() =>
                {
                    vm.Dot();
                });

                AddNumber = ReactiveCommand.Create<int>((int newValue) =>
                {
                    vm.AddNumber(newValue);
                });

                PerformOperation = ReactiveCommand.Create<OperationEnum>((operation) =>
                {
                    vm.PerformOperation(operation);
                });
            }

            /// <summary>
            /// Команда для очистки текущего ввода.
            /// </summary>
            public IReactiveCommand ClearEntry { get; }

            /// <summary>
            /// Команда для полной очистки (обнуляет все значения).
            /// </summary>
            public IReactiveCommand ClearAll { get; }

            /// <summary>
            /// Команда для удаления последнего символа.
            /// </summary>
            public IReactiveCommand Backspace { get; }

            /// <summary>
            /// Команда для изменения числа на его обратную величину.
            /// </summary>
            public IReactiveCommand ChangeToDivider { get; }

            /// <summary>
            /// Команда для возведения числа в квадрат.
            /// </summary>
            public IReactiveCommand Square { get; }

            /// <summary>
            /// Команда для извлечения квадратного корня из числа.
            /// </summary>
            public IReactiveCommand SquareRoot { get; }

            /// <summary>
            /// Команда для изменения знака числа на противоположный.
            /// </summary>
            public IReactiveCommand Reverse { get; }

            /// <summary>
            /// Команда для добавления десятичной точки.
            /// </summary>
            public IReactiveCommand Dot { get; }

            /// <summary>
            /// Команда для добавления числа к текущему результату.
            /// </summary>
            public ReactiveCommand<int, Unit> AddNumber { get; }

            /// <summary>
            /// Команда для выполнения математической операции (сложение, вычитание и т.д.).
            /// </summary>
            public ReactiveCommand<OperationEnum, Unit> PerformOperation { get; }
        }

        private CalculatorTabViewModelCommands _commands;

        /// <summary>
        /// Свойство, которое инициализирует и возвращает команды для работы с калькулятором.
        /// </summary>
        public CalculatorTabViewModelCommands Commands => _commands ??= new(this);
    }
}
