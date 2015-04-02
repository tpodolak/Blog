using System;
using System.Linq.Expressions;
using Model.NHibernateEventListener;
using NHibernate.Event;
using NHibernate.Impl;
using NHibernate.Persister.Entity;

namespace NHibernateEventListener
{
    public class NHListener : IPreInsertEventListener,
                   IPreUpdateEventListener
    {
        private static readonly string ModificationDatePropertyName = GetPropertyName<IDateInfo>(val => val.ModificationDate),
                                       CreationDatePropertyName = GetPropertyName<IDateInfo>(val => val.CreationDate);


        public bool OnPreInsert(PreInsertEvent @event)
        {
            IDateInfo dateInfo;
            if ((dateInfo = @event.Entity as IDateInfo) != null)
            {
                var currentDate = DateTime.Now;
                dateInfo.CreationDate = dateInfo.ModificationDate = currentDate;
                SetState(@event.Persister, @event.State, ModificationDatePropertyName, currentDate);
                SetState(@event.Persister, @event.State, CreationDatePropertyName, currentDate);
            }

            return false;
        }

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            IDateInfo dateInfo;
            if ((dateInfo = @event.Entity as IDateInfo) != null)
            {
                var currentDate = DateTime.Now;
                dateInfo.ModificationDate = currentDate;
                SetState(@event.Persister, @event.State, ModificationDatePropertyName, currentDate);
            }
            return false;
        }



        private void SetState(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
                return;
            state[index] = value;
        }

        private static string GetPropertyName<TType>(Expression<Func<TType, object>> expression)
        {
            return ExpressionProcessor.FindPropertyExpression(expression.Body);
        }
    }
}