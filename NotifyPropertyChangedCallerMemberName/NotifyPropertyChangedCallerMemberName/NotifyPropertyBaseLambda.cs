using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace NotifyPropertyChangedCallerMemberName
{
    public class NotifyPropertyBaseLambda : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(Expression<Func<object>> propertyExpression)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(GetPropertyName(propertyExpression)));
        }

        private string GetPropertyName(Expression<Func<object>> propertyExpression)
        {
            var unaryExpression = propertyExpression.Body as UnaryExpression;
            var memberExpression = unaryExpression == null ? (MemberExpression)propertyExpression.Body : (MemberExpression)unaryExpression.Operand;
            var propertyName = memberExpression.Member.Name;
            return propertyName;
        }
    }
}