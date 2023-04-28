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
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private string university = "";
        private string dbConnection = (@"Data Source = DESKTOP-9KF1G5V\SQLEXPRESS; Initial Catalog = Users; Integrated Security=True");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen.Visibility = Visibility.Hidden;
            Unis.Visibility = Visibility.Visible;
            SqlConnection sqlCon = new SqlConnection(dbConnection);
            try
            {
                sqlCon.Open();
                Random rnd = new Random();
                int idNum = rnd.Next(0, 100000);
                String query = "SELECT COUNT (1) FROM Users WHERE UserName=@Username AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", UsernameBox.Text);
                sqlCmd.Parameters.AddWithValue("@Password", passwordbox.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {

                    LoginScreen.Visibility = Visibility.Hidden;
                    Unis.Visibility = Visibility.Visible;

                    query = "Select * from yale";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    YaleStudents.ItemsSource = dt.DefaultView;
                    query = "Select * from harvard";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    reader = sqlCmd.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(reader);
                    HarvardStudents.ItemsSource = dt.DefaultView;
                    query = "Select * from cornell";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    reader = sqlCmd.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(reader);
                    CornellStudents.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("Username or Password incorrect");
                }
                
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            LoginScreen.Visibility = Visibility.Hidden;
            SignupScreen.Visibility = Visibility.Visible;
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            SignupScreen.Visibility = Visibility.Hidden;
            Unis.Visibility = Visibility.Visible;
            SqlConnection sqlCon = new SqlConnection(dbConnection);
            try
            {
                sqlCon.Open();
                Random rnd = new Random();
                int idNum = rnd.Next(0, 100000);
                String query = "INSERT INTO Users (UserID, Username, Password) values ('" + idNum + "', '" + UsernameBox2.Text + "', '" + passwordbox2.Password + "') ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();


                query = "Select * from yale";
                sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                YaleStudents.ItemsSource = dt.DefaultView;
                query = "Select * from harvard";
                sqlCmd = new SqlCommand(query, sqlCon);
                reader = sqlCmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
                HarvardStudents.ItemsSource = dt.DefaultView;
                query = "Select * from cornell";
                sqlCmd = new SqlCommand(query, sqlCon);
                reader = sqlCmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
                CornellStudents.ItemsSource = dt.DefaultView;
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            LoginScreen.Visibility = Visibility.Visible;
            SignupScreen.Visibility = Visibility.Hidden;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Info.Visibility = Visibility.Visible;
            Cornell.Visibility = Visibility.Hidden;
            Harvard.Visibility = Visibility.Hidden;
            Yale.Visibility = Visibility.Hidden;
            university = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string studentid = "";
            string deleteid = "";
            string name = "";
            string sex = "";
            string grade = "";
            switch (university)
            {
                case "cornell":
                    studentid = CreateRoomText_Copy3.Text;
                    name = CreateRoomText.Text;
                    sex = CreateRoomText_Copy.Text;
                    grade = CreateRoomText_Copy1.Text;
                    deleteid = CreateRoomText_Copy2.Text;
                    break;
                case "harvard":
                    studentid = CreateRoomText_Copy7.Text;
                    name = CreateRoomText1.Text;
                    sex = CreateRoomText_Copy4.Text;
                    grade = CreateRoomText_Copy5.Text;
                    deleteid = CreateRoomText_Copy6.Text;
                    break;
                case "yale":
                    studentid = CreateRoomText_Copy11.Text;
                    name = CreateRoomText2.Text;
                    sex = CreateRoomText_Copy8.Text;
                    grade = CreateRoomText_Copy9.Text;
                    deleteid = CreateRoomText_Copy10.Text;
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }

            SqlConnection sqlCon = new SqlConnection(dbConnection);
            try
            {
                sqlCon.Open();
                String query = "INSERT INTO "+university+" (StudentID, Name, Sex, Grade) values ('" + studentid + "','" + name + "','" + sex + "','" + grade + "') ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Succesfully added!");
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string studentid = "";
            string name = "";
            string sex = "";
            string grade = "";
            switch (university)
            {
                case "cornell":
                    studentid = CreateRoomText_Copy3.Text;
                    name = CreateRoomText.Text;
                    sex = CreateRoomText_Copy.Text;
                    grade = CreateRoomText_Copy1.Text;
                    break;
                case "harvard":
                    studentid = CreateRoomText_Copy7.Text;
                    name = CreateRoomText1.Text;
                    sex = CreateRoomText_Copy4.Text;
                    grade = CreateRoomText_Copy5.Text;
                    break;
                case "yale":
                    studentid = CreateRoomText_Copy11.Text;
                    name = CreateRoomText2.Text;
                    sex = CreateRoomText_Copy8.Text;
                    grade = CreateRoomText_Copy9.Text;
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }

            SqlConnection sqlCon = new SqlConnection(dbConnection);
            try
            {
                sqlCon.Open();
                String query = "UPDATE" + university + "SET Name = "+name+", Sex = "+ sex +", Grade = "+grade+" Where StudentID = "+studentid;
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Succesfully updated!");
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string deleteid = "";
            switch (university)
            {
                case "cornell":
                    deleteid = CreateRoomText_Copy2.Text;
                    break;
                case "harvard":
                    deleteid = CreateRoomText_Copy6.Text;
                    break;
                case "yale":
                    deleteid = CreateRoomText_Copy10.Text;
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }

            SqlConnection sqlCon = new SqlConnection(dbConnection);
            try
            {
                sqlCon.Open();
                String query = "DELETE FROM" + university + "WHERE StudentID = "+deleteid;
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Succesfully deleted!");
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Info.Visibility = Visibility.Hidden;
            Cornell.Visibility = Visibility.Visible;
            university = "cornell";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Info.Visibility = Visibility.Hidden;
            Harvard.Visibility = Visibility.Visible;
            university = "harvard";
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Info.Visibility = Visibility.Hidden;
            Yale.Visibility = Visibility.Visible;
            university = "yale";
        }
    }
}
