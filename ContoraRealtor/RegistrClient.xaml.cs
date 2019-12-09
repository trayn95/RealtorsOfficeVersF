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
using System.Windows.Shapes;

namespace ContoraRealtor
{
    /// <summary>
    /// Логика взаимодействия для RegistrClient.xaml
    /// </summary>
    public partial class RegistrClient : Window
    {
        public RegistrClient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientList re = new ClientList();
            this.Hide();
            re.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RealtorEntities db = new RealtorEntities();
            Client save = new Client
            {
                LastName = ClientLastName.Text,
                Name = ClientName.Text,
                MiddleName = ClientMiddleName.Text,
                Phone = phone.Text,
                Email = Email.Text,
            };
            db.Client.Add(save);
            db.SaveChanges();
            MessageBox.Show("Клиент добавлен");
            ClientList reg = new ClientList();
            this.Hide();
            reg.Show();
        }
    }
}
