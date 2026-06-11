using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UserInfoClass;

namespace PharmacyWPF_UI.Pages.Admin
{
    public partial class UserManagementPage : Page
    {
        public UserManagementPage()
        {
            InitializeComponent();
            loadUserData();
            RoleCombo.ItemsSource = new[] { "Pharmacist", "Admin" };
            RoleCombo.SelectedIndex = 0;
            ShiftCombo.ItemsSource = new[] { "Morning", "Afternoon", "Night" };
            ShiftCombo.SelectedIndex = 0;
        }
        private  void loadUserData() 
        {
            List<UserInfo> userList = UserInfo.LoadUserMG();
            UsersGrid.ItemsSource = userList;
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e) 
        {
            string fullName = FullNameBox.Text.Trim();
            string phone = PhoneBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
            string role = RoleCombo.SelectedItem as string;
            string shift = ShiftCombo.SelectedItem as string;
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(shift))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            UserInfo newUser = new UserInfo(fullName, role, phone, shift);
            UserInfo.SaveUserInfo(newUser);
            loadUserData();
        }
        private void ClearForm_Click(object sender, RoutedEventArgs e) 
        {
            FullNameBox.Clear();
            PhoneBox.Clear();
            PasswordBox.Clear();
            RoleCombo.SelectedIndex = 0;
            ShiftCombo.SelectedIndex = 0;
        }
       
        private void DeleteUser_Click(object sender, RoutedEventArgs e) 
        { 
            Button btn = sender as Button;
            UserInfo selectedUser = (UserInfo)btn.Tag;
            UserInfo.DeleteUser(selectedUser.Name);
            loadUserData();
        }
    }
}
