
namespace lab_rob_5
{
    partial class Reports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Back = new System.Windows.Forms.Button();
            this.Report1 = new System.Windows.Forms.Button();
            this.Select_Student_Box = new System.Windows.Forms.ComboBox();
            this.Report3 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.Select_Coach2_Box = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Report2 = new System.Windows.Forms.Button();
            this.Select_Coach1_Box = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Result_Box = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Result_Box);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.Back);
            this.splitContainer1.Panel1.Controls.Add(this.Report1);
            this.splitContainer1.Panel1.Controls.Add(this.Select_Student_Box);
            this.splitContainer1.Panel1.Controls.Add(this.Report3);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.Select_Coach2_Box);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.Report2);
            this.splitContainer1.Panel1.Controls.Add(this.Select_Coach1_Box);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 0;
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(7, 406);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(75, 41);
            this.Back.TabIndex = 51;
            this.Back.Text = "Попередня форма";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Report1
            // 
            this.Report1.Location = new System.Drawing.Point(7, 60);
            this.Report1.Name = "Report1";
            this.Report1.Size = new System.Drawing.Size(268, 27);
            this.Report1.TabIndex = 50;
            this.Report1.Text = "Вивести модулі, що викладає цей тренер";
            this.Report1.UseVisualStyleBackColor = true;
            this.Report1.Click += new System.EventHandler(this.Report1_Click);
            // 
            // Select_Student_Box
            // 
            this.Select_Student_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Select_Student_Box.FormattingEnabled = true;
            this.Select_Student_Box.Location = new System.Drawing.Point(138, 141);
            this.Select_Student_Box.Name = "Select_Student_Box";
            this.Select_Student_Box.Size = new System.Drawing.Size(137, 21);
            this.Select_Student_Box.TabIndex = 49;
            // 
            // Report3
            // 
            this.Report3.Location = new System.Drawing.Point(7, 240);
            this.Report3.Name = "Report3";
            this.Report3.Size = new System.Drawing.Size(268, 53);
            this.Report3.TabIndex = 44;
            this.Report3.Text = "Вивести назви модулів та імена студентів, що успішно перездали тест, з результато" +
    "м";
            this.Report3.UseVisualStyleBackColor = true;
            this.Report3.Click += new System.EventHandler(this.Report3_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 13);
            this.label13.TabIndex = 48;
            this.label13.Text = "Вибрати студента :";
            // 
            // Select_Coach2_Box
            // 
            this.Select_Coach2_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Select_Coach2_Box.FormattingEnabled = true;
            this.Select_Coach2_Box.Location = new System.Drawing.Point(138, 114);
            this.Select_Coach2_Box.Name = "Select_Coach2_Box";
            this.Select_Coach2_Box.Size = new System.Drawing.Size(137, 21);
            this.Select_Coach2_Box.TabIndex = 47;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Вибрати тренера :";
            // 
            // Report2
            // 
            this.Report2.Location = new System.Drawing.Point(7, 169);
            this.Report2.Name = "Report2";
            this.Report2.Size = new System.Drawing.Size(268, 41);
            this.Report2.TabIndex = 45;
            this.Report2.Text = "Вивести правильні відповіді студента, тестів створених певним тренером";
            this.Report2.UseVisualStyleBackColor = true;
            this.Report2.Click += new System.EventHandler(this.Report2_Click);
            // 
            // Select_Coach1_Box
            // 
            this.Select_Coach1_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Select_Coach1_Box.FormattingEnabled = true;
            this.Select_Coach1_Box.Location = new System.Drawing.Point(138, 33);
            this.Select_Coach1_Box.Name = "Select_Coach1_Box";
            this.Select_Coach1_Box.Size = new System.Drawing.Size(137, 21);
            this.Select_Coach1_Box.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Вибрати тренера :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(4, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Звіти";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(512, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "більше";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "балів";
            // 
            // Result_Box
            // 
            this.Result_Box.Location = new System.Drawing.Point(77, 299);
            this.Result_Box.Name = "Result_Box";
            this.Result_Box.Size = new System.Drawing.Size(130, 20);
            this.Result_Box.TabIndex = 54;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Reports_FormClosed);
            this.Load += new System.EventHandler(this.Reports_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox Select_Student_Box;
        private System.Windows.Forms.Button Report3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox Select_Coach2_Box;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button Report2;
        private System.Windows.Forms.ComboBox Select_Coach1_Box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Report1;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Result_Box;
    }
}