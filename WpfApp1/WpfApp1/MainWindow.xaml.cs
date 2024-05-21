using Reactive.Bindings;

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ReactivePropertySlim<bool> IsItemEnabled { get; } = new(true);

        public ReactivePropertySlim<bool> IsItemVisibled { get; } = new(true);

        public ReactivePropertySlim<bool> IsSelectabled { get; } = new(true);


        public ReactiveCollection<ComboBoxItem<int>> Items { get; } = [];

        public ReactivePropertySlim<int> SelectedValue { get; } = new(0);

        public MainWindow()
        {
            InitComboBoxItems();

            IsSelectabled.Subscribe(x =>
            {
                InitComboBoxItems();
            });

            InitializeComponent();
        }

        private void InitComboBoxItems()
        {
            Items.Clear();

            for (int i = 0; i < 5; i++)
            {
                if (i == 2)
                {
                    Items.Add(
                        new()
                        {
                            Value = i,
                            DisplayText = $"{i + 1} : item {i + 1} (有効無効切り替え)",
                            IsEnabled = IsItemEnabled.ToReadOnlyReactivePropertySlim(true),
                        });
                }
                else if (i == 3)
                {
                    if (IsSelectabled.Value)
                    {
                        Items.Add(
                            new()
                            {
                                Value = i,
                                DisplayText = $"{i + 1} : item {i + 1}（表示非表示切り替え）",
                                IsVisibled = IsItemVisibled.ToReadOnlyReactivePropertySlim(true),
                            });
                    }
                }
                else
                {
                    Items.Add(
                        new()
                        {
                            Value = i,
                            DisplayText = $"{i + 1} : item {i + 1}",
                        });
                }
            }

            SelectedValue.ForceNotify();

            CorrectSelectedValue();
        }

        private void CorrectSelectedValue()
        {
            if(!Items.Any(x => x.Value == SelectedValue.Value))
            {
                SelectedValue.Value = 0;
            }
        }
    }
}