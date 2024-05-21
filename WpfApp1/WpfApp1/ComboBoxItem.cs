using Reactive.Bindings;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ComboBoxItem<T>
    {
        public required T Value { get; init; }

        public required string DisplayText { get; init; }

        public ReadOnlyReactivePropertySlim<bool> IsEnabled { get; init; } = new(Observable.Return(true), true);

        public ReadOnlyReactivePropertySlim<bool> IsVisibled { get; init; } = new(Observable.Return(true), true);
    }
}
