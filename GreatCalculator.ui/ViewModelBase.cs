﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GreatCalculator.ui
{
    /// <summary>Базовый класс для ViewModel.</summary>
	public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new(propertyName));
    }
}
