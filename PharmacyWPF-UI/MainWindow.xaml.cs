using PharmacyWPF_UI.Controls;
using PharmacyWPF_UI.Pages.Admin;
using PharmacyWPF_UI.Pages.Pharmacist;
using System;
using System.Windows;
using System.Windows.Controls;
using UserInfoClass;

namespace PharmacyWPF_UI
{
    public partial class MainWindow : Window
    {
        private UserInfo _currentUser; 

        public MainWindow(SidebarRole role, string userInitial, UserInfo currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            Sidebar.Role = role;
            TopBar.SetUser(userInitial, role);
            Sidebar.NavigationRequested += OnNavigationRequested;
            Sidebar.SignOutRequested += OnSignOutRequested;
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
                    return new SellMedicinePage(_currentUser); 
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
                case "SalesHistory":
                    return new SalesHistoryPage();
                default:
                    return null;
            }
        }
    }
}