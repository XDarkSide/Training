using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lab_rob_5
{
    public partial class Register_Training_Module : Form
    {
        Coach selected_Coach;
        Training selected_Training;
        public Register_Training_Module()
        {
            InitializeComponent();
        }
        private void Register_Training_Load(object sender, EventArgs e)
        {
            Refresh_Training();
            Refresh_Coach();
            
        }
        private void Refresh_Training() // оновлення даних про тренінги в БД
        {

            Connection.connect.Open();

            SqlCommand get_training = new SqlCommand("select ID, training_topic, coach_id from Training", Connection.connect);

            SqlDataReader training_reader = get_training.ExecuteReader();

            Training_Box_1.Items.Clear();
            Training_Box_2.Items.Clear();
            Training_Box_3.Items.Clear();

            while (training_reader.Read())
            {
                Training training = new Training((int)training_reader[0], training_reader[1].ToString(), (int)training_reader[2]);

                Training_Box_1.Items.Add(training);
                Training_Box_2.Items.Add(training);
                Training_Box_3.Items.Add(training);

                Training_Box_1.DisplayMember = "training_topic";
                Training_Box_2.DisplayMember = "training_topic";
                Training_Box_3.DisplayMember = "training_topic";
            }

            Connection.connect.Close();
        }

        private void Refresh_Coach() // оновлення даних про тренерів в БД
        {
            Connection.connect.Open();

            SqlCommand get_coach = new SqlCommand("select ID, first_name, last_name, phone_number, email from Coach", Connection.connect);

            SqlDataReader coach_reader = get_coach.ExecuteReader();

            Coach_Box.Items.Clear();

            while (coach_reader.Read())
            {
                Coach coach = new Coach((int)coach_reader[0], coach_reader[1].ToString(), coach_reader[2].ToString(), coach_reader[3].ToString(), coach_reader[4].ToString());

                Coach_Box.Items.Add(coach);

                Coach_Box.DisplayMember = "name";
            }

            Connection.connect.Close();
        }

        private void Refresh_Module() // оновлення даних про модулі в БД
        {
            Connection.connect.Open();

            SqlCommand get_module = new SqlCommand($"select Module.ID, Module.module_name, Module.training_id from Module inner join Training on (Module.training_id = Training.ID) where Training.ID = {selected_Training.ID};", Connection.connect);

            SqlDataReader module_reader = get_module.ExecuteReader();

            Select_Module_Box.Items.Clear();

            while (module_reader.Read())
            {
                Module module = new Module((int)module_reader[0], module_reader[1].ToString(), (int) module_reader[2]);

                Select_Module_Box.Items.Add(module);

                Select_Module_Box.DisplayMember = "name";
            }

            Connection.connect.Close();
        }

        private void Training_Register_Click(object sender, EventArgs e) // добавлення нового тренінгу
        {
            Connection.connect.Open();

            string Error;
            try
            {
                if (!Validator.Check_Topic(Training_Topic_Box.Text, out Error)) throw new Exception(Error);
                if (!Validator.Check_Date(Date_Start_Picker.Value, Date_Finish_Picker.Value, out Error)) throw new Exception(Error);
                if (!(Coach_Box.SelectedIndex > -1)) throw new Exception("Виберіть одного з доступних тренерів. ");

                selected_Coach = (Coach)Coach_Box.SelectedItem;
                string Query = $"insert into Training (training_topic, start_date, finish_date, coach_id) values ('{Training_Topic_Box.Text}', '{Date_Start_Picker.Value.Year}-{Date_Start_Picker.Value.Month}-{Date_Start_Picker.Value.Day}', '{Date_Finish_Picker.Value.Year}-{Date_Finish_Picker.Value.Month}-{Date_Finish_Picker.Value.Day}',{selected_Coach.ID});";
                

                SqlCommand add_Training = new SqlCommand(Query, Connection.connect);
                add_Training.ExecuteNonQuery();

                Training_Register.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Training_Register.ForeColor = System.Drawing.Color.Red;
            }

            Connection.connect.Close(); 
            Refresh_Training();
        }
        private void Module_Register_Click_1(object sender, EventArgs e) // добавлення нового модуля
        {
            Connection.connect.Open();

            string Error;
            try
            {
                if (!Validator.Check_Topic(Module_Name_Box.Text, out Error)) throw new Exception(Error);
                if (!Validator.Check_Date(Event_Date_Picker.Value, out Error)) throw new Exception(Error);
                if (!(Training_Box_1.SelectedIndex > -1)) throw new Exception("Виберіть однин з доступних тренінгів. ");
                if (!Validator.Check_Duration(Duration_Box.Text, out Error)) throw new Exception(Error);

                Training selected_training = (Training) Training_Box_1.SelectedItem;
                string Query = $"insert into Module (module_name, event_date, training_id, duration) values ('{Module_Name_Box.Text}', '{Event_Date_Picker.Value.Year}-{Event_Date_Picker.Value.Month}-{Event_Date_Picker.Value.Day} 18:00:00', {selected_training.ID}, '{Duration_Box.Text}:0:0');";


                SqlCommand add_module = new SqlCommand(Query, Connection.connect);
                add_module.ExecuteNonQuery();

                Module_Register.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Module_Register.ForeColor = System.Drawing.Color.Red;
            }

            Connection.connect.Close();
        }

        private void Select_training_Click(object sender, EventArgs e) // вибір тренінгу
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"select Training.training_topic, Module.module_name, Module.event_date from Training left join Module on Training.ID = Module.training_id;", Connection.connect);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Training_Result");
            dataGridView1.DataSource = dataSet.Tables["Training_Result"];
            dataGridView1.Refresh();

            Connection.connect.Close();
        }

        private void Edit_Training_Click(object sender, EventArgs e) // редагування даних тренінгу
        {
            Connection.connect.Open();
            string Error;

            try
            {
                selected_Training = (Training) Training_Box_2.SelectedItem;

                if (!(Training_Box_2.SelectedIndex > -1)) throw new Exception("Виберіть один з доступних тренінгів для зміни  назви. ");
                if (!Validator.Check_Topic(Edit_name_Training.Text, out Error)) throw new Exception(Error);

                SqlCommand edit_data = new SqlCommand($"update Training set training_topic = '{Edit_name_Training.Text}' where ID = {selected_Training.ID};", Connection.connect);
                edit_data.ExecuteNonQuery();

                Edit_Training.ForeColor = System.Drawing.Color.Black;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Edit_Training.ForeColor = System.Drawing.Color.Red;
            }

            Connection.connect.Close();
            Refresh_Training();
        }

        private void Edit_Module_Click(object sender, EventArgs e) // редагування даних модуля
        {
            Connection.connect.Open();
            string Error;

            try
            {
                Module selected_module = (Module) Select_Module_Box.SelectedItem;

                if (!(Training_Box_3.SelectedIndex > -1)) throw new Exception("Виберіть один з доступних тренінгів. ");
                if (!(Select_Module_Box.SelectedIndex > -1)) throw new Exception("Виберіть один з доступних модулів. ");
                if (!Validator.Check_Topic(Edit_name_Module.Text, out Error)) throw new Exception(Error);

                SqlCommand edit_data = new SqlCommand($"update Module set module_name = '{Edit_name_Module.Text}' where ID = {selected_module.ID};", Connection.connect);
                edit_data.ExecuteNonQuery();

                Edit_Module.ForeColor = System.Drawing.Color.Black;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Edit_Module.ForeColor = System.Drawing.Color.Red;
            }

            Connection.connect.Close();
            Refresh_Module();
        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Training_Box_2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Edit_name_Training_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_Training = (Training) Training_Box_3.SelectedItem;
            Refresh_Module();
        }

        private void Select_Module_Box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Edit_name_Module_TextChanged(object sender, EventArgs e)
        {

        }

        private void Next_Click(object sender, EventArgs e)
        {
            Register_Coach forma3 = new Register_Coach();
            forma3.Show();
            Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Register_Student forma1 = new Register_Student();
            forma1.Show();
            Hide();
        }

        private void Register_Training_Module_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
