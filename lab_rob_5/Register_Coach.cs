using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lab_rob_5
{
    public partial class Register_Coach : Form
    {
        Coach selected_coach;
        public Register_Coach()
        {
            InitializeComponent();
        }

        private void Register_Coach_Reports_Load(object sender, EventArgs e)
        {
            Refresh_Coach();
        }

        private void Refresh_Coach() // оновлення даних про тренерів з БД
        {
            Connection.connect.Open();

            SqlCommand get_Coach = new SqlCommand("select ID, first_name, last_name, phone_number, email from Coach", Connection.connect);

            SqlDataReader coach_reader = get_Coach.ExecuteReader();

            Select_Coach_Box.Items.Clear();

            while (coach_reader.Read())
            {
                Student coach = new Coach((int)coach_reader[0], coach_reader[1].ToString(), coach_reader[2].ToString(), coach_reader[3].ToString(), coach_reader[4].ToString());

                Select_Coach_Box.Items.Add(coach);
                Select_Coach_Box.DisplayMember = "Name";
            }

            Connection.connect.Close();
        }

        private void Register_Click(object sender, EventArgs e) // добавлення нового тренера
        {
            string Error;
            Connection.connect.Open();

            try
            {
                if (!Validator.Check_Name(First_Name_Box.Text, out Error) || !Validator.Check_Name(Last_Name_Box.Text, out Error)) throw new Exception(Error);

                if (!Validator.Check_Phone_Number(Number_Phone_Box.Text, out Error)) throw new Exception(Error);

                if (!Validator.Check_Email(Email_Box.Text, out Error)) throw new Exception(Error);

                string Query = "insert into Coach (first_name, last_name, phone_number, email) values " + "('" + First_Name_Box.Text.ToString() + "', '" + Last_Name_Box.Text.ToString() + "', '" + Number_Phone_Box.Text.ToString() + "', '" + Email_Box.Text.ToString() + "'); ";

                SqlCommand add_coach = new SqlCommand(Query, Connection.connect);
                add_coach.ExecuteNonQuery();

                Register.ForeColor = System.Drawing.Color.Black;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Register.ForeColor = System.Drawing.Color.Red;
            }

            Connection.connect.Close();
            Refresh_Coach();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Register_Training_Module forma2 = new Register_Training_Module();
            forma2.Show();
            Hide();
        }

        private void Select_Coach_Click(object sender, EventArgs e) // вивід інформації про всіх тренерів
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"select Coach.first_name, Coach.last_name, Coach.phone_number, Coach.email from Coach;", Connection.connect);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Coach_Result");
            dataGridView1.DataSource = dataSet.Tables["Coach_Result"];
            dataGridView1.Refresh();
        }

        private void Edit_Click(object sender, EventArgs e) // редагування даних тренера
        {
            string Error;

            Connection.connect.Open();

            try
            {
                selected_coach = (Coach) Select_Coach_Box.SelectedItem;

                if (!(Select_Coach_Box.SelectedIndex > -1)) throw new Exception("Виберіть один з доступних акаунтів та здійсніть вхід. ");
                if (!Validator.Check_Name(Edit_First_Name_Box.Text, out Error)) throw new Exception(Error);
                if (!Validator.Check_Name(Edit_Last_Name_Box.Text, out Error)) throw new Exception(Error);
                if (!Validator.Check_Phone_Number(Edit_Number_Phone_Box.Text, out Error)) throw new Exception(Error);
                if (!Validator.Check_Email(Edit_Email_Box.Text, out Error)) throw new Exception(Error);

                SqlCommand edit_data = new SqlCommand($"update Coach set phone_number = '{Edit_Number_Phone_Box.Text}', email = '{Edit_Email_Box.Text}', first_name = '{Edit_First_Name_Box.Text}', last_name = '{Edit_Last_Name_Box.Text}' where ID = {selected_coach.ID};", Connection.connect);
                edit_data.ExecuteNonQuery();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"select Coach.first_name, Coach.last_name, Coach.phone_number, Coach.email from Coach where ID = {selected_coach.ID};", Connection.connect);

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Coach_Result");
                dataGridView1.DataSource = dataSet.Tables["Coach_Result"];
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

        private void Login_Click(object sender, EventArgs e) // вибір тренера
        {
            Connection.connect.Open();

            try
            {
                if (!(Select_Coach_Box.SelectedIndex > -1)) throw new Exception("Виберіть один з доступних акаунтів. ");

                selected_coach = (Coach)Select_Coach_Box.SelectedItem;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"Select first_name, last_name, phone_number, email from Coach where ID = {selected_coach.ID};", Connection.connect);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Coach_Result");

                dataGridView1.DataSource = dataSet.Tables["Coach_Result"];
                dataGridView1.Refresh();

                Login.ForeColor = System.Drawing.Color.Black;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Login.ForeColor = System.Drawing.Color.Red;
            }

            Connection.connect.Close();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            Hide();
        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Register_Coach_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
