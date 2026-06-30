using PharmacyWPF_UI.Controls;
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
            string password = PasswordBox.Password.Trim();

          
            if (!int.TryParse(password, out int passwordInt))
            {
                ErrorText.Text = "Invalid username or password.";
                ErrorText.Visibility = Visibility.Visible;
                PasswordBox.Clear();
                PasswordBox.Focus();
                return;
            }

            UserInfo loggedInUser = UserInfo.Login(username, passwordInt);
            if (loggedInUser != null)
            {
                if (loggedInUser.Role == "Admin")
                    OpenMain(SidebarRole.Admin, "A", loggedInUser); 
                else
                    OpenMain(SidebarRole.Pharmacist, "P", loggedInUser); 
                return;
            }
            ErrorText.Text = "Invalid username or password.";
            ErrorText.Visibility = Visibility.Visible;
            PasswordBox.Clear();
            PasswordBox.Focus();
        }
        private void OpenMain(SidebarRole role, string userInitial, UserInfo currentUser) 
        {
            var main = new MainWindow(role, userInitial, currentUser); 
            main.Show();
            Close();
        }
    }
}