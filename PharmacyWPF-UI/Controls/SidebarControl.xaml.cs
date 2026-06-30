using System;
using System.Windows;
using System.Windows.Controls;

namespace PharmacyWPF_UI.Controls
{
    public enum SidebarRole
    {
        Pharmacist,
        Admin
    }

    public partial class SidebarControl : UserControl
    {
        public static readonly DependencyProperty RoleProperty =
            DependencyProperty.Register(
                nameof(Role),
                typeof(SidebarRole),
                typeof(SidebarControl),
                new PropertyMetadata(SidebarRole.Pharmacist, OnRoleChanged));

        public event EventHandler<string> NavigationRequested;
        public event EventHandler SignOutRequested;

        public SidebarControl()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        public SidebarRole Role
        {
            get => (SidebarRole)GetValue(RoleProperty);
            set => SetValue(RoleProperty, value);
        }

        private static void OnRoleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SidebarControl sidebar)
                sidebar.ApplyRole();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ApplyRole();
            SelectDefaultItem();
        }

        private void ApplyRole()
        {
            bool isAdmin = Role == SidebarRole.Admin;
            PharmacistNav.Visibility = isAdmin ? Visibility.Collapsed : Visibility.Visible;
            AdminNav.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
        }

        private void SelectDefaultItem()
        {
            if (Role == SidebarRole.Admin)
            {
                AdminMedicineToggle.IsChecked = false;
                foreach (var child in FindVisualChildren<RadioButton>(AdminNav))
                {
                    if (child.Tag as string == "AdminDashboard")
                    {
                        child.IsChecked = true;
                        return;
                    }
                }
            }
            else
            {
                PharmacistMedicineToggle.IsChecked = false;
                foreach (var child in FindVisualChildren<RadioButton>(PharmacistNav))
                {
                    if (child.Tag as string == "Dashboard")
                    {
                        child.IsChecked = true;
                        return;
                    }
                }
            }
        }

        private void NavItem_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radio && radio.Tag is string tag && radio.IsChecked == true)
            {
                if (Role == SidebarRole.Pharmacist)
                    PharmacistMedicineToggle.IsChecked = IsMedicineSubTag(tag);
                else
                    AdminMedicineToggle.IsChecked = IsAdminMedicineSubTag(tag);

                NavigationRequested?.Invoke(this, tag);
            }
        }

        private static bool IsMedicineSubTag(string tag)
        {
            return tag == "AddMedicine"
                || tag == "ModifyMedicine"
                || tag == "ViewMedicine"
                || tag == "ValidityCheck";
        }

        private static bool IsAdminMedicineSubTag(string tag)
        {
            return tag == "AdminViewMedicine" || tag == "AdminValidityCheck";
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            SignOutRequested?.Invoke(this, EventArgs.Empty);
        }

        private static System.Collections.Generic.IEnumerable<T> FindVisualChildren<T>(DependencyObject parent)
            where T : DependencyObject
        {
            if (parent == null)
                yield break;

            int count = System.Windows.Media.VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var child = System.Windows.Media.VisualTreeHelper.GetChild(parent, i);
                if (child is T match)
                    yield return match;

                foreach (var nested in FindVisualChildren<T>(child))
                    yield return nested;
            }
        }
    }
}
