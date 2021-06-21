using System;
using BindingsRx.Filters;
using UniRx;
using UnityEngine;

namespace BindingsRx.Bindings
{
    public static class ReactivePropertyExtensions
    {
        public static IDisposable BindValueToButtonOnClick<T>(this IReactiveProperty<T> toUpdateSource, UnityEngine.UI.Button fromButton, Func<T> onClickValue)
        {

            return GenericBindings.Bind(fromButton.OnClickAsObservable(), _ => toUpdateSource.Value = onClickValue()).AddTo(fromButton);
        }
    }
}