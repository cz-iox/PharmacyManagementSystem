using PharmacyWPF_UI.Controls;
using PharmacyWPF_UI.Pages.Admin;
using PharmacyWPF_UI.Pages.Pharmacist;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PharmacyWPF_UI
{
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }


        public MainWindow(SidebarRole role, string userInitial)
        {
            InitializeComponent();

            Sidebar.Role = role;
            TopBar.SetUser(userInitial, role);
            Sidebar.NavigationRequested += OnNavigationRequested;
            Sidebar.SignOutRequested += OnSignOutRequested;
            Instance = this;
        }

        private void OnSignOutRequested(object sender, EventArgs e)
        {
            var login = new LoginWindow();
            login.Show();
            Close();
        }

        private void OnNavigationRequested(object sender, string tag)
        {
            Page page = ResolvePage(tag);
            if (page != null)
                MainFrame.Navigate(page);
        }

        private Page ResolvePage(string tag)
        {
            switch (tag)
            {
                case "Dashboard":
                    return new DashboardPage();
                case "SellMedicine":
                    return new SellMedicinePage();
                case "AddMedicine":
                    return new AddMedicinePage();
                case "ModifyMedicine":
                    return new ModifyMedicinePage();
                case "ViewMedicine":
                    return new PharmacyWPF_UI.Pages.Pharmacist.ViewMedicinePage();
                case "ValidityCheck":
                    return new ValidityCheckPage();
                case "AdminDashboard":
                    return new AdminDashboardPage();
                case "Pharmacists":
                    return new PharmacistsPage();
                case "UserManagement":
                    return new UserManagementPage();
                case "AdminViewMedicine":
                    return new PharmacyWPF_UI.Pages.Admin.ViewMedicinePage();
                case "AdminValidityCheck":
                    return new AdminValidityCheckPage();
                default:
                    return null;
            }
        }
    }
}
