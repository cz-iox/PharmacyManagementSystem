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

        private void loadUserData()
        {
            List<UserInfo> userList = UserInfo.LoadUserMG();
            UsersGrid.ItemsSource = userList;
        }

  
        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            string fullName = FullNameBox.Text.Trim();
            string phone = PhoneBox.Text.Trim();
            string passwordText = PasswordBox.Password.Trim();
            string role = RoleCombo.SelectedItem as string;
            string shift = ShiftCombo.SelectedItem as string;

 
            if (string.IsNullOrEmpty(fullName) ||
                string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(passwordText) ||
                string.IsNullOrEmpty(shift))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(passwordText, out int password))
            {
                MessageBox.Show("Password must be a number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

       
            UserInfo newUser = new UserInfo(fullName, role, phone, shift, password)
            {
                lastlogin = System.DateTime.Now
            };

            UserInfo.SaveUserInfo(newUser);
            loadUserData();
            ClearForm_Click(null, null); 
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
            if (btn == null) return;

            UserInfo selectedUser = btn.Tag as UserInfo;
            if (selectedUser == null) return;

            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to delete " + selectedUser.Name + "?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes) return;

            UserInfo.DeleteUser(selectedUser.Name);
            loadUserData();
        }
    }
}