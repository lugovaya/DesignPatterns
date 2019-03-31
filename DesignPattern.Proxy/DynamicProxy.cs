using System;
using System.Reflection;

namespace DesignPattern.Proxy
{
    public class DynamicProxy<T> : DispatchProxy
    {
        private T _decorated;
        private Predicate<MethodInfo> _filter;
        
        public event EventHandler<MethodInfo> BeforeExecute;
        public event EventHandler<MethodInfo> AfterExecute;
        public event EventHandler<MethodInfo> ErrorExecuting;
        
        public Predicate<MethodInfo> Filter
        {
            get => _filter;
            set
            {
                if (value == null)
                    _filter = m => true;
                else
                    _filter = value;
            }
        }
        
        public static T Create(T decorated, EventHandler<MethodInfo> beforeExecute, 
            EventHandler<MethodInfo> onSuccessExecute, EventHandler<MethodInfo> onFailedExecute)
        {
            object proxy = Create<T, DynamicProxy<T>>();

            ((DynamicProxy<T>) proxy).SetParameters(decorated, beforeExecute, onSuccessExecute, onFailedExecute);
            
            return (T)proxy;
        }
        
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            OnBeforeExecute(targetMethod);

            try
            {
                var result = targetMethod.Invoke(_decorated, args);
                OnAfterExecute(targetMethod);

                return result;
            }
            catch (Exception)
            {
                OnErrorExecuting(targetMethod);
                return null;
            }
        }
        
        private void OnBeforeExecute(MethodInfo methodCall)
        {
            if (BeforeExecute == null) return;
            
            if (_filter(methodCall))
                BeforeExecute(this, methodCall);
        }
        private void OnAfterExecute(MethodInfo methodCall)
        {
            if (AfterExecute == null) return;
            
            if (_filter(methodCall))
                AfterExecute(this, methodCall);
        }
        private void OnErrorExecuting(MethodInfo methodCall)
        {
            if (ErrorExecuting == null) return;
            
            if (_filter(methodCall))
                ErrorExecuting(this, methodCall);
        }
        
        private void SetParameters(T decorated, EventHandler<MethodInfo> beforeExecute, 
            EventHandler<MethodInfo> onSuccessExecute, EventHandler<MethodInfo> onFailedExecute)
        {
            if (decorated == null)
                throw new ArgumentNullException(nameof(decorated));
            
            _decorated = decorated;

            Filter = m => true;

            BeforeExecute += beforeExecute;
            AfterExecute += onSuccessExecute;
            ErrorExecuting += onFailedExecute;
        }
    }
}