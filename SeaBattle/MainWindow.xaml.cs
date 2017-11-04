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
using System.Xml;
using SeaBattle.Controls;
using SeaBattle.Service;
using SeaBattle.Data.Context;
using SeaBattle.Service.Base;

namespace SeaBattle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private SeaBattleContext context=new SeaBattleContext() ;
       // private FieldService _service;
        public MainWindow()
        {
          //  _service = new FieldService(context);
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var doc = new XmlDocument();
            var root = doc.CreateElement("field");
            for (int i = 0; i < EnemyField.Size; i++)
            {
                for (int j = 0; j < EnemyField.Size; j++)
                {
                    var cell = EnemyField[i, j];
                    var node = doc.CreateElement("cell");

                    var xAttr = doc.CreateAttribute("x");
                    xAttr.InnerText = (cell.X - 1).ToString();

                    var yAttr = doc.CreateAttribute("y");
                    yAttr.InnerText = (cell.Y - 1).ToString();

                    var stateAttr = doc.CreateAttribute("state");
                    stateAttr.InnerText = (cell.State == CellState.Missed ? (int)CellState.Ship : (int)CellState.None).ToString();

                    node.Attributes.Append(xAttr);
                    node.Attributes.Append(yAttr);
                    node.Attributes.Append(stateAttr);
                    root.AppendChild(node);
                }
            }
            doc.AppendChild(root);
            doc.Save(Environment.CurrentDirectory + "1.xml");
           // _service.SaveBattleFild(doc);
           UnitOfWork.Instance.fieldService.SaveBattleFild(doc);
             MessageBox.Show("Complate");
        
            //root.InnerText = "Test";
            //doc.AppendChild(root);
            //doc.Save(Environment.CurrentDirectory + "1.xml");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // var path = Environment.CurrentDirectory + "1.xml";
            // var doc = new XmlDocument();
            //doc.Load(path);
            // var doc = _service.GetBattleField();
            var doc =   UnitOfWork.Instance.fieldService.GetBattleField();
            if (doc == null) return;
            var root = doc.DocumentElement;

            var list = root.GetElementsByTagName("cell");
            foreach (XmlNode node in list)
            {
                var x = Convert.ToInt32(node.Attributes["x"].Value);
                var y = Convert.ToInt32(node.Attributes["y"].Value);
                var state = Convert.ToInt32(node.Attributes["state"].Value);
                var cell = EnemyField[y, x];
                cell.X = x;
                cell.Y = y;
                cell.State = (CellState)state;
            }
            MessageBox.Show("Complate");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Login loginForm = new Login();
            //loginForm.MdiParent = this;
            loginForm.Show();

            

        }
}
}
