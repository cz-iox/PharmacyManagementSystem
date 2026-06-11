using UserInfoClass;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace PharmacyWPF_UI.Pages.Admin
{
    public partial class PharmacistsPage : Page
    {
        public PharmacistsPage()
        {
            InitializeComponent();
            LoadStaffData();
        }

        private void LoadStaffData()
        {
            List<UserInfo> staffList = UserInfo.LoadUser();
            List<UserInfo> pharmacists = new List<UserInfo>();
            foreach (UserInfo staff in staffList)
            {
                if (staff.Role == "Pharmacist")
                {
                    pharmacists.Add(staff);
                }
            }
            StaffGrid.ItemsSource = pharmacists;
        }



        private void SaveStaff_Click(object sender, RoutedEventArgs e) { }
        private void CancelStaff_Click(object sender, RoutedEventArgs e) { }
        private void DeleteStaff_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            UserInfo selectedStaff = (UserInfo)btn.Tag;
            UserInfo.DeleteUser(selectedStaff.Name);
            LoadStaffData();
        }
    }
}