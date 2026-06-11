using PharmacyWPF_UI.Controls;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using UserInfoClass;

namespace PharmacyWPF_UI
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            UsernameBox.Focus();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e) => AttemptLogin();

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                AttemptLogin();
        }

        private void AttemptLogin()
        {
            ErrorText.Visibility = Visibility.Collapsed;

            string username = UsernameBox.Text.Trim();
            string password = PasswordBox.Password;

            if (username == "admin" && password == "admin123")
            {
                OpenMain(SidebarRole.Admin, "A");
                return;
            }

            if (username == "t" && password == "t123")
            {
                OpenMain(SidebarRole.Pharmacist, "P");
                return;
            }
            if (username == "o" && password == "o1")
            {
                OpenMain(SidebarRole.Admin, "A");
                return;
            }
            if (UserInfo.LoadUserFull().Any(u => u.Name == username && u.password.ToString() == password))
            {
                var user = UserInfo.LoadUserFull().First(u => u.Name == username && u.password.ToString() == password);
                UserInfo.UpdateLastLogin(user);
                if (user.Role == "Admin")
                {
                    OpenMain(SidebarRole.Admin, "A");
                }
                else if (user.Role == "Pharmacist")
                {
                    OpenMain(SidebarRole.Pharmacist, "P");
                }
                return;
            }

            ErrorText.Text = "Invalid username or password.";
            ErrorText.Visibility = Visibility.Visible;
            PasswordBox.Clear();
            PasswordBox.Focus();
        }

        private void OpenMain(SidebarRole role, string userInitial)
        {
            var main = new MainWindow(role, userInitial);
            main.Show();
            Close();
        }
    }
}
