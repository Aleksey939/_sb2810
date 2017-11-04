using SeaBattle.Service.Base;
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

namespace SeaBattle
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
       public Login()
        {
            InitializeComponent();
        }



       
private void Button_Click(object sender, RoutedEventArgs e)
        {
           var user=  UnitOfWork.Instance.userAccountService.VerifyUser(EmeilTB.Text, PassTB.Password);
           if (user!=null) MessageBox.Show("Вход Выполнен");
           else MessageBox.Show("Not Found");
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Registration regForm = new Registration();
          // regForm.MdiParent = this;
            regForm.Show();
           
        }
    }
}
