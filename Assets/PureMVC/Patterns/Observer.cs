
using UnityEngine;

namespace PureMVC.Patterns
{
    using PureMVC.Interfaces;
    using System;
    using System.Reflection;

    public class Observer : IObserver
    {
        protected readonly object m_syncRoot = new object();

        public Observer(string notifyMethod, object notifyContext)
        {
            this.NotifyMethod = notifyMethod;
            this.NotifyContext = notifyContext;
        }

        public bool CompareNotifyContext(object obj)
        {
            lock (this.m_syncRoot)
            {
                return this.NotifyContext.Equals(obj);
            }
        }

        public object NotifyContext { private get; set; }

        public string NotifyMethod { private get; set; }

        public void NotifyObserver(INotification notification)
        {
            object notifyContext;
            lock (this.m_syncRoot)
            {
                notifyContext = this.NotifyContext;
                //string notifyMethod = this.NotifyMethod;
            }
            //利用反射获取方法然后执行
            Type type = notifyContext.GetType();
            //这里设置忽略字母的大小写
            BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase;
            //根据设置的中介者的名字或者是命令的名字执行对应的方法，具体方法的执行在中介者和命令中已经重写对应的方法实现
            MethodInfo method = type.GetMethod(this.NotifyMethod, bindingAttr);
            method.Invoke(notifyContext , new object[] { notification });
        }
    }
}