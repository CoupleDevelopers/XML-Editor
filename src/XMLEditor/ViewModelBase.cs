using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace XMLEditor
{
    internal class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> selectorExpression)
        {
            if (selectorExpression == null)
                throw new ArgumentNullException("selectorExpression");
            MemberExpression? body = selectorExpression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("The body must be a member expression");
            OnPropertyChanged(body.Member.Name);
        }

        protected bool SetField<T>(ref T field, T value, Expression<Func<T>> selectorExpression)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(selectorExpression);
            return true;
        }
    }
}