using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp22
{
    public partial class MainWindow : Window
    {
        private List<User> users;

        public MainWindow()
        {
            InitializeComponent();
            LoadUsers();
            UserListBox.ItemsSource = users;
        }

        private void LoadUsers()
        {

            users = new List<User>
            {
                new User { Id = 1, FirstName = "Иван", LastName = "Иванов", MiddleName = "Иванович", Status = "Ожидает проверки", VerificationPhoto = "D:\\USTANOV\\photo\\EGRN1.jpg" },
                new User { Id = 2, FirstName = "Александр", LastName = "Петров", MiddleName = "Олегович", Status = "Ожидает проверки", VerificationPhoto = "D:\\USTANOV\\photo\\EGRN1.jpg" },
            };

        }

        private void UserListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (UserListBox.SelectedItem is User selectedUser)
            {
                LastNameTextBlock.Text = selectedUser.LastName;
                FirstNameTextBlock.Text = selectedUser.FirstName;
                MiddleNameTextBlock.Text = selectedUser.MiddleName;
                StatusTextBlock.Text = selectedUser.Status;
                UserPhoto.Source = new BitmapImage(new Uri(selectedUser.VerificationPhoto, UriKind.Relative));
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserListBox.SelectedItem is User selectedUser)
            {
                selectedUser.Status = "Проверка пройдена";
                MessageBox.Show($"Пользователь {selectedUser.FirstName} {selectedUser.LastName} был подтверждён.");
                UserListBox.Items.Refresh();
            }
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserListBox.SelectedItem is User selectedUser)
            {
                selectedUser.Status = "Проверка не пройдена";
                MessageBox.Show($"Пользователь {selectedUser.FirstName} {selectedUser.LastName} был отклонён.");
                UserListBox.Items.Refresh();
            }
        }
    }
}
