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
    /// Логика взаимодействия для CurrentClient.xaml
    /// </summary>
    public partial class CurrentClient : Window
    {
        public CurrentClient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientList re = new  ClientList();
            this.Hide();
            re.Show();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            RealtorEntities db = new RealtorEntities();
            var client = db.Client.Find(SecurityContext.idClient);
            ClientLastName.Text = client.LastName;
            ClientName.Text = client.Name;
            ClientMiddleName.Text = client.MiddleName;
            phone.Text = client.Phone;
            Email.Text = client.Email;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RealtorEntities db = new RealtorEntities();
            Client client = db.Client.Find(SecurityContext.idClient);
            client.LastName = ClientLastName.Text;
            client.MiddleName = ClientMiddleName.Text;
            client.Name = ClientName.Text;
            client.Phone = phone.Text;
            client.Email = Email.Text;
            db.Client.Create();
            db.SaveChanges();
            ClientList re = new ClientList();
            this.Hide();
            re.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RealtorEntities db = new RealtorEntities();
            Client client = db.Client.Find(SecurityContext.idClient);
            db.Client.Remove(db.Client.Where(dr => dr.id == SecurityContext.idClient).FirstOrDefault());
            db.SaveChanges();
            ClientList re = new ClientList();
            this.Hide();
            re.Show();
        }
    }
}
