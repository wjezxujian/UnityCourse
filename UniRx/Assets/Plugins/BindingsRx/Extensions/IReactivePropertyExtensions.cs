
using UniRx;

namespace BindingsRx.Extensions
{
    public static class IReactivePropertyExtensions
    {
        public static ReactiveProperty<string> ToTextualPorperty<T>(this IReactiveProperty<T> nonStringProperty)
        {
            return nonStringProperty.Select(x => x.ToString()).ToReactiveProperty() as ReactiveProperty<string>;
        }
    }
}