using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lab_rob_5
{
    public partial class Reports : Form
    {
        Coach selected_coach;
        Student  selected_student;
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            Refresh_Students();
            Refresh_Coach();
        }

        private void Refresh_Coach() // оновлення даних про тренерів з БД
        {
            Connection.connect.Open();

            SqlCommand get_coach = new SqlCommand("select ID, first_name, last_name, phone_number, email from Coach", Connection.connect);

            SqlDataReader coach_reader = get_coach.ExecuteReader();

            Select_Coach1_Box.Items.Clear();
            Select_Coach2_Box.Items.Clear();

            while (coach_reader.Read())
            {
                Coach coach = new Coach((int)coach_reader[0], coach_reader[1].ToString(), coach_reader[2].ToString(), coach_reader[3].ToString(), coach_reader[4].ToString());

                Select_Coach1_Box.Items.Add(coach);
                Select_Coach2_Box.Items.Add(coach);

                Select_Coach1_Box.DisplayMember = "name";
                Select_Coach2_Box.DisplayMember = "name";
            }

            Connection.connect.Close();
        }

        private void Refresh_Students() // оновлення даних про студентів з БД
        {
            Connection.connect.Open();

            SqlCommand get_Students = new SqlCommand("select ID, first_name, last_name, phone_number, email, age from Student", Connection.connect);

            SqlDataReader student_reader = get_Students.ExecuteReader();

            Select_Student_Box.Items.Clear();

            while (student_reader.Read())
            {
                Student student = new Student((int)student_reader[0], student_reader[1].ToString(), student_reader[2].ToString());

                Select_Student_Box.Items.Add(student);
                Select_Student_Box.DisplayMember = "Name";
            }

            Connection.connect.Close();
        }

        private void Report1_Click(object sender, EventArgs e) // реалізація першого звіту
        {
            try
            {
                if (!(Select_Coach1_Box.SelectedIndex > -1)) throw new Exception("Виберіть тренера. ");

                selected_coach = (Coach) Select_Coach1_Box.SelectedItem;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"select Module.module_name, Training. training_topic, Module.event_date from Module join Training on (Training.ID = Module.training_id) join Coach on (Training.coach_id = Coach.ID) where Coach.first_name = '{selected_coach.First_Name}' and Coach.last_name = '{selected_coach.Last_Name}'; ", Connection.connect);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Student_Result");

                dataGridView1.DataSource = dataSet.Tables["Student_Result"];
                dataGridView1.Refresh();

                Report1.ForeColor = System.Drawing.Color.Black;
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Report1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void Report2_Click(object sender, EventArgs e) // реалізація третього звіту
        {
            try
            {
                if (!(Select_Coach2_Box.SelectedIndex > -1)) throw new Exception("Виберіть тренера. ");
                if (!(Select_Student_Box.SelectedIndex > -1)) throw new Exception("Виберіть студента. ");

                selected_coach = (Coach) Select_Coach2_Box.SelectedItem;
                selected_student = (Student) Select_Student_Box.SelectedItem;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"select Test.test_title, Answer.answer, Answer.scores from Answer  join Result on(Answer.result_id = Result.ID) join Student on (Result.student_id = Student.ID) join Test on (Result.test_id = Test.ID) join Module on (Module.ID = Test.module_id) join Training on (Training.ID = Module.training_id) join Coach on (Training.coach_id = Coach.ID) where  Student.first_name = '{selected_student.First_Name}' and Student.last_name = '{selected_student.Last_Name}' and Answer.is_right = 1 and Coach.first_name = '{selected_coach.First_Name}' and Coach.last_name = '{selected_coach.Last_Name}'; ", Connection.connect);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Results");

                dataGridView1.DataSource = dataSet.Tables["Results"];
                dataGridView1.Refresh();

                Report2.ForeColor = System.Drawing.Color.Black;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Report2.ForeColor = System.Drawing.Color.Red;
            }
        }

        /*
         * Запит модифіковано таким чином, щоб отримувати результати більше певного значення. 
         */
        private void Report3_Click(object sender, EventArgs e) // реалізація другого звіту
        {
            string Error;

            try
            {
                if (!Validator.Check_Result(Result_Box.Text, out Error)) throw new Exception(Error);

                int Result = Convert.ToInt32(Result_Box.Text);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"select Student.first_name, Student.last_name, Student.age, Module.module_name as Module, Retake_Result.retake_result from Student join Result on (Student.ID = Result.student_id) join Test on (Result.test_id = Test.ID) join Module on (Test.module_id = Module.ID) join Retake_Result on (Result.ID = Retake_Result.previous_result) where Result.admission_to_retake = 1 and Retake_Result.retake_result > 50 and Retake_Result > {Result} ", Connection.connect);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Results");

                dataGridView1.DataSource = dataSet.Tables["Results"];
                dataGridView1.Refresh();

                Report3.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Report3.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Register_Coach forma3 = new Register_Coach();
            forma3.Show();
            Hide();
        }

        private void Reports_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
