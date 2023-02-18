using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace REghZyWPFLib.Core {
    public abstract class BaseViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private static void Validate(string propertyName) {
            if (propertyName == null) {
                throw new ArgumentNullException(nameof(propertyName), "Property Name is null");
            }
        }

        public void RaisePropertyChanged<T>(ref T property, T newValue, [CallerMemberName] string propertyName = null) {
            Validate(propertyName);
            property = newValue;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RaisePropertyChangedCheckEqual<T>(ref T property, T newValue, [CallerMemberName] string propertyName = null) {
            Validate(propertyName);
            if (EqualityComparer<T>.Default.Equals(property, newValue))
                return;

            property = newValue;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            Validate(propertyName);
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RaisePropertyChangedWithCallback<T>(ref T property, T newValue, Action<T> postChangedCallback = null, Action<T> preChangedCallback = null, [CallerMemberName] string propertyName = null) {
            Validate(propertyName);
            if (EqualityComparer<T>.Default.Equals(property, newValue))
                return;

            preChangedCallback?.Invoke(property);
            property = newValue;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            postChangedCallback?.Invoke(property);
        }

        public void RaisePropertyChangedWithCallback(Action callback, [CallerMemberName] string propertyName = null) {
            Validate(propertyName);
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            callback?.Invoke();
        }

        public void RaisePropertyChangedForceWithCallback<T>(ref T property, T newValue, Action<T> postChangedCallback = null, Action<T> preChangedCallback = null, [CallerMemberName] string propertyName = null) {
            Validate(propertyName);
            preChangedCallback?.Invoke(property);
            property = newValue;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            postChangedCallback?.Invoke(property);
        }

        public void RaisePropertyChangedWithCallback<T>(ref T property, T newValue, Action postChangedCallback = null, Action preChangedCallback = null, [CallerMemberName] string propertyName = null) {
            Validate(propertyName);
            if (EqualityComparer<T>.Default.Equals(property, newValue))
                return;

            preChangedCallback?.Invoke();
            property = newValue;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            postChangedCallback?.Invoke();
        }

        public void RaisePropertyChangedForceWithCallback<T>(ref T property, T newValue, Action postChangedCallback = null, Action preChangedCallback = null, [CallerMemberName] string propertyName = null) {
            Validate(propertyName);
            preChangedCallback?.Invoke();
            property = newValue;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            postChangedCallback?.Invoke();
        }
    }
}