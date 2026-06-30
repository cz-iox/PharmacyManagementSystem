using MahApps.Metro.IconPacks;
using System.Windows;
using System.Windows.Controls;

namespace PharmacyWPF_UI.Controls
{
    public partial class StatCardControl : UserControl
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(StatCardControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(string), typeof(StatCardControl), new PropertyMetadata("0"));

        public static readonly DependencyProperty TrendTextProperty =
            DependencyProperty.Register(nameof(TrendText), typeof(string), typeof(StatCardControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty TrendIsPositiveProperty =
            DependencyProperty.Register(nameof(TrendIsPositive), typeof(bool), typeof(StatCardControl), new PropertyMetadata(true));

        public static readonly DependencyProperty ShowTrendProperty =
            DependencyProperty.Register(nameof(ShowTrend), typeof(bool), typeof(StatCardControl), new PropertyMetadata(true));

        public static readonly DependencyProperty IconKindProperty =
            DependencyProperty.Register(nameof(IconKind), typeof(PackIconMaterialKind), typeof(StatCardControl), new PropertyMetadata(PackIconMaterialKind.ChartLine));

        public StatCardControl()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public string TrendText
        {
            get => (string)GetValue(TrendTextProperty);
            set => SetValue(TrendTextProperty, value);
        }

        public bool TrendIsPositive
        {
            get => (bool)GetValue(TrendIsPositiveProperty);
            set => SetValue(TrendIsPositiveProperty, value);
        }

        public bool ShowTrend
        {
            get => (bool)GetValue(ShowTrendProperty);
            set => SetValue(ShowTrendProperty, value);
        }

        public PackIconMaterialKind IconKind
        {
            get => (PackIconMaterialKind)GetValue(IconKindProperty);
            set => SetValue(IconKindProperty, value);
        }
    }
}
