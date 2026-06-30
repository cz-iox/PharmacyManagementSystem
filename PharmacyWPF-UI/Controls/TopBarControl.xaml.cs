using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace PharmacyWPF_UI.Controls
{
    public partial class TopBarControl : UserControl
    {
        public TopBarControl()
        {
            InitializeComponent();
            DateText.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy");
        }

        public void SetUser(string userInitial, SidebarRole role)
        {
            UserInitialText.Text = string.IsNullOrEmpty(userInitial) ? "?" : userInitial.Substring(0, 1).ToUpperInvariant();
            SetRole(role);
        }

        public void SetRole(SidebarRole role)
        {
            if (role == SidebarRole.Admin)
            {
                RoleBadgeText.Text = "Admin";
                RoleBadge.Background = new SolidColorBrush(Color.FromRgb(237, 233, 254));
                RoleBadgeText.Foreground = new SolidColorBrush(Color.FromRgb(109, 40, 217));
            }
            else
            {
                RoleBadgeText.Text = "Pharmacist";
                RoleBadge.Background = new SolidColorBrush(Color.FromRgb(218, 240, 238));
                RoleBadgeText.Foreground = new SolidColorBrush(Color.FromRgb(0, 172, 178));
            }
        }
    }
}
