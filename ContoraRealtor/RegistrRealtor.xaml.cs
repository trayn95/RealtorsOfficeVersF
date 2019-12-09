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
    /// Логика взаимодействия для RegistrRealtor.xaml
    /// </summary>
    public partial class RegistrRealtor : Window
    {
        public RegistrRealtor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RealtorEntities db = new RealtorEntities();
            Realtor save = new Realtor
            {
                LastName = RealtorLastName.Text,
                Name = RealtorName.Text,
                MiddleName = RealtorMiddleName.Text,
                Comission = RealtorCommis.Text,
            };
            db.Realtor.Add(save);
            db.SaveChanges();
            MessageBox.Show("Реалтор добавлен");
            RealtorList reg = new RealtorList();
            this.Hide();
            reg.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RealtorList reg = new RealtorList();
            this.Hide();
            reg.Show();
        }
    }
}
