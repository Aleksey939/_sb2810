using SeaBattle.Service.Base;
using SeaBattle.Service.Service;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           var useraccount= UnitOfWork.Instance.userAccountService.AddUser(EmeilTB.Text, PassTB.Password);
            var user = UnitOfWork.Instance.userService.AddUser(useraccount.Id,FNTb.Text,LNTb.Text,LoginTB.Text);
            if (useraccount != null) MessageBox.Show("Complate");
            else MessageBox.Show("error!");
            this.Close();
            EmeilService email = new EmeilService("a.ivanov@rovas.ua", EmeilTB.Text, "Registration Sea Battle", "Registration Complate you login - "+ EmeilTB.Text+ " you password - " + PassTB.Password);
            MessageBox.Show("На вашу почту отправлено письмо");
        }
    }
}
