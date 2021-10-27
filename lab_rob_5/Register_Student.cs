using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lab_rob_5
{
    public struct Connection
    {
        public static string connection_string = "Server=tcp:itacademy.database.windows.net;Database=karalash;User ID =karalash;Password=Gmp34535;Trusted_Connection=False;Encrypt=True;";
        public static SqlConnection connect = new SqlConnection(connection_string);
    }
    public partial class Register_Student : Form
    {
        static Student selected_student;

        public Register_Student()
        {
            InitializeComponent();
        }

        private void Register_Student_Load(object sender, EventArgs e)
        {
            Refresh_Training();
            Refresh_Students();
        }


        private void Refresh_Students() // оновлення даних про студентів з БД
        {
            Connection.connect.Open();

            SqlCommand get_Students = new SqlCommand("select ID, first_name, last_name, phone_number, email, age from Student", Connection.connect);

            SqlDataReader student_reader = get_Students.ExecuteReader();

            Select_Student.Items.Clear();

            while (student_reader.Read())
            {
                Student student = new Student((int)student_reader[0], student_reader[1].ToString(), student_reader[2].ToString());

                Select_Student.Items.Add(student);
                Select_Student.DisplayMember = "Name";
            }

            Connection.connect.Close();
        }

        private void Refresh_Training() // оновлення даних про тренінги з БД
        {

            Connection.connect.Open();

            SqlCommand get_training = new SqlCommand("select ID, training_topic, coach_id from Training", Connection.connect);

            SqlDataReader training_reader = get_training.ExecuteReader();

            Select_Student.Items.Clear();

            while (training_reader.Read())
            {
                Training training = new Training((int)training_reader[0], training_reader[1].ToString(), (int)training_reader[2]);

                Select_Training_Box.Items.Add(training);
                Add_Training_Box.Items.Add(training);

                Select_Training_Box.DisplayMember = "training_topic";
                Add_Training_Box.DisplayMember = "training_topic";
            }

            Connection.connect.Close();
        }

        private void Login_Click(object sender, EventArgs e) // вхід в студентський акаунт
        {
            Connection.connect.Open();

            try
            {
                if (!(Select_Student.SelectedIndex > -1)) throw new Exception("Виберіть один з доступних акаунтів. ");

                selected_student = (Student)Select_Student.SelectedItem;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"Select Student.first_name, Student.last_name, Student.phone_number, Student.email, Student.age, Training.training_topic from Student inner join Students_List on (Student.ID = Students_List.student_id) inner join Training on (Training.ID = Students_List.training_id) where Student.ID = {selected_student.ID};", Connection.connect);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Student_Result");

                dataGridView1.DataSource = dataSet.Tables["Student_Result"];
                dataGridView1.Refresh();

                Login.ForeColor = System.Drawing.Color.Black;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Login.ForeColor = System.Drawing.Color.Red;
            }

            Connection.connect.Close();

                if (Add_Training_Box.SelectedIndex > -1 && Select_Student.SelectedIndex > -1)
                {
                    Training training = (Training) Add_Training_Box.SelectedItem;
                    Student student = (Student) Select_Student.SelectedItem;
                    int student_id = Seachr_Student(student.First_Name, student.Last_Name);

                    Register_To_List(training, student_id);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"Select Student.first_name, Student.last_name, Student.phone_number, Student.email, Student.age, Training.training_topic from Student inner join Students_List on (Student.ID = Students_List.student_id) inner join Training on (Training.ID = Students_List.training_id) where Student.ID = {selected_student.ID};", Connection.connect);

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Student_Result");
                dataGridView1.DataSource = dataSet.Tables["Student_Result"];
                dataGridView1.Refresh();
            }

            dataGridView1.Refresh();
        }

        private int Seachr_Student(string first_name, string last_name) // пошук ID студента по імені та прізвищі
        {
            Connection.connect.Open();
            SqlCommand student = new SqlCommand($"Select ID from Student where first_name = '{first_name}' and last_name = '{last_name}';", Connection.connect);
            SqlDataReader student_reader = student.ExecuteReader();

            int i = -1;

            while (student_reader.Read())
            {
                i = (int) student_reader[0];
            }

            Connection.connect.Close();

            return i;

        }

        private void Edit_Click(object sender, EventArgs e) // редагування даних студента
        {
            string Error;

            Connection.connect.Open();

            try
            {
                selected_student = (Student) Select_Student.SelectedItem;

                if (!(Select_Student.SelectedIndex > -1)) throw new Exception("Виберіть один з доступних акаунтів та здійсніть вхід. ");
                if (!Validator.Check_Phone_Number(Edit_Number_Phone_Box.Text, out Error)) throw new Exception(Error);
                if (!Validator.Check_Email(Edit_Email_Box.Text, out Error)) throw new Exception(Error);

                SqlCommand edit_data = new SqlCommand($"update Student set phone_number = '{Edit_Number_Phone_Box.Text}', email = '{Edit_Email_Box.Text}' where ID = {selected_student.ID};", Connection.connect);
                edit_data.ExecuteNonQuery();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"Select Student.first_name, Student.last_name, Student.phone_number, Student.email, Student.age, Training.training_topic from Student inner join Students_List on (Student.ID = Students_List.student_id) inner join Training on (Training.ID = Students_List.training_id) where Student.ID = {selected_student.ID};", Connection.connect);

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Student_Result");
                dataGridView1.DataSource = dataSet.Tables["Student_Result"];
                dataGridView1.Refresh();

                Edit.ForeColor = System.Drawing.Color.Black;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Edit.ForeColor = System.Drawing.Color.Red;
            }



            Connection.connect.Close();
        }

        private void Register_Click(object sender, EventArgs e) // добавлення нового студента
        {

            bool Succes = Register_To_Student();

            Training training = (Training)Select_Training_Box.SelectedItem;
            int student_id = Seachr_Student(First_Name_Box.Text, Last_name_Box.Text);

            if (Succes) Register_To_List(training, student_id);

            Refresh_Students();
        }

        private bool Register_To_Student() // добавлення студента в сутність Student
        {
            string Error;
            Connection.connect.Open();

            try
            {
                if (!Validator.Check_Name(First_Name_Box.Text, out Error) || !Validator.Check_Name(Last_name_Box.Text, out Error)) throw new Exception(Error);

                if (!Validator.Check_Phone_Number(Number_Phone_Box.Text, out Error)) throw new Exception(Error);

                if (!Validator.Check_Email(Email_Box.Text, out Error)) throw new Exception(Error);

                if (!Validator.Check_Age(Age_Box.Text, out Error)) throw new Exception(Error);

                if (!(Select_Training_Box.SelectedIndex > -1)) throw new Exception("Виберіть один з доступних тренінгів.");

                string Query = "insert into Student (first_name, last_name, phone_number, email, age) values " + "('" + First_Name_Box.Text.ToString() + "', '" + Last_name_Box.Text.ToString() + "', '" + Number_Phone_Box.Text.ToString() + "', '" + Email_Box.Text.ToString() + "', " + Convert.ToInt32(Age_Box.Text) + ");";

                SqlCommand add_student = new SqlCommand(Query, Connection.connect);
                add_student.ExecuteNonQuery();

                Register.ForeColor = System.Drawing.Color.Black;

                Connection.connect.Close();

                return true;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Register.ForeColor = System.Drawing.Color.Red;
 
            }

            Connection.connect.Close();

            Refresh_Students();

            return false;
        }

        private void Register_To_List(Training training, int student_id) // добавлення студента в сутність Students_List
        {

            Connection.connect.Open();

            try
            {
                if (student_id == -1) throw new Exception("Студента з таким іменем та прізвищем не знайдено. ");
                string Add_Query = $"insert into Students_List (student_id, training_id, register_date) values ({student_id}, {training.ID}, '{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}');";
                SqlCommand add_to_list = new SqlCommand(Add_Query, Connection.connect);
                add_to_list.ExecuteNonQuery();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Connection.connect.Close();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Add_Training_Box.SelectedIndex = -1;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Register_Training_Module forma2 = new Register_Training_Module();
            forma2.Show();
            Hide();
        }

        private void Register_Student_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
