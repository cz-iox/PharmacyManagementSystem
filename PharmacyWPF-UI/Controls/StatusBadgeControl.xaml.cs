using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PharmacyClassLibrary;

namespace PharmacyWPF_UI.Controls
{
    public partial class StatusBadgeControl : UserControl
    {
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register(
                nameof(Status),
                typeof(MedicineStatusKind),
                typeof(StatusBadgeControl),
                new PropertyMetadata(MedicineStatusKind.Valid, OnStatusChanged));

        public StatusBadgeControl()
        {
            InitializeComponent();
            Loaded += (_, __) => ApplyStatus();
        }

        public MedicineStatusKind Status
        {
            get => (MedicineStatusKind)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        private static void OnStatusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is StatusBadgeControl badge)
                badge.ApplyStatus();
        }

        private void ApplyStatus()
        {
            if (!IsLoaded && BadgeText == null)
                return;

            switch (Status)
            {
                case MedicineStatusKind.Expired:
                    BadgeText.Text = "Expired";
                    SetColors("#FECACA", "#991B1B");
                    break;
                case MedicineStatusKind.ExpiringSoon:
                    BadgeText.Text = "Expiring Soon";
                    SetColors("#FEF3C7", "#92400E");
                    break;
                default:
                    BadgeText.Text = "Valid";
                    SetColors("#D1FAE5", "#065F46");
                    break;
            }
        }

        private void SetColors(string bgHex, string fgHex)
        {
            BadgeBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(bgHex));
            BadgeText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(fgHex));
        }
    }
}
