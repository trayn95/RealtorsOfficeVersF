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
    /// Логика взаимодействия для CurrentRealtor.xaml
    /// </summary>
    public partial class CurrentRealtor : Window
    {
        public CurrentRealtor()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {   RealtorEntities db = new RealtorEntities();
            var realtor = db.Realtor.Find(SecurityContext.idRealtor);
            RealtorLastName.Text = realtor.LastName;
            RealtorName.Text = realtor.Name;
            RealtorMiddleName.Text = realtor.MiddleName;
            RealtorCommis.Text = realtor.Comission;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RealtorEntities db = new RealtorEntities();
            Realtor realtor = db.Realtor.Find(SecurityContext.idRealtor);
            realtor.LastName = RealtorLastName.Text;
            realtor.MiddleName = RealtorMiddleName.Text;
            realtor.Name = RealtorName.Text;
            realtor.Comission = RealtorCommis.Text;
            db.Realtor.Create();
            db.SaveChanges();
            RealtorList re = new RealtorList();
            this.Hide();
            re.Show();




        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RealtorEntities db = new RealtorEntities();
            Realtor realtor = db.Realtor.Find(SecurityContext.idRealtor);
            db.Realtor.Remove(db.Realtor.Where(dr => dr.id == SecurityContext.idRealtor).FirstOrDefault());
            db.SaveChanges();
            RealtorList re = new RealtorList();
            this.Hide();
            re.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RealtorList re = new RealtorList();
            this.Hide();
            re.Show();
        }
    }
}
