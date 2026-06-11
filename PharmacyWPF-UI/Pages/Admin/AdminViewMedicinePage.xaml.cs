using System.Windows;
using System.Windows.Controls;

namespace PharmacyWPF_UI.Pages.Admin
{
    public partial class ViewMedicinePage : Page
    {
        public ViewMedicinePage()
        {
            InitializeComponent();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e) { SearchIcon.Visibility = string.IsNullOrEmpty(SearchBox.Text) ? Visibility.Visible : Visibility.Collapsed; }
        private void ExportBtn_Click(object sender, RoutedEventArgs e) { }
    }
}
