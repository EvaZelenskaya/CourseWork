using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Coursework
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            String loginUser = loginField.Text;
            String passUser = passField.Password;
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

           MySqlCommand command = new MySqlCommand("SELECT * FROM учёт_обмена_валют.staff WHERE  `login_Staff `= @uL AND  `password_Staff `= @uP", db.getConnection());
       //    MySqlCommand command = new MySqlCommand("SELECT * FROM staff WHERE  `login_Staff `=@uL AND  `password_Staff `=@uP", db.getConnection());
          // MySqlCommand command = new MySqlCommand("SELECT * FROM `staff` WHERE  `login_Staff `=@uL AND  `password_Staff `=@uP", db.getConnection());
          //  MySqlCommand command = new MySqlCommand("SELECT * FROM `staff` WHERE  `login_Staff ` = loginUser" '  AND  `password_Staff `=' "passUser"' );
;       command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser; 
;       command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table); // поместили внутрь объекты

            if (table.Rows.Count > 0) // сколько записей
                MessageBox.Show("Yes");
            else
                MessageBox.Show("Sorry");
        }
    }
}
