namespace StudentApp
{
    partial class StudentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirth;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonAddExam;
        private System.Windows.Forms.Button buttonEditExam;
        private System.Windows.Forms.Button buttonDeleteExam;
        private System.Windows.Forms.ListBox listBoxExams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.dateTimePickerBirth = new System.Windows.Forms.DateTimePicker();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonAddExam = new System.Windows.Forms.Button();
            this.buttonEditExam = new System.Windows.Forms.Button();
            this.buttonDeleteExam = new System.Windows.Forms.Button();
            this.listBoxExams = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(140, 20);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(200, 22);
            this.textBoxFirstName.TabIndex = 0;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(140, 60);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(200, 22);
            this.textBoxLastName.TabIndex = 1;
            // 
            // dateTimePickerBirth
            // 
            this.dateTimePickerBirth.Location = new System.Drawing.Point(140, 100);
            this.dateTimePickerBirth.Name = "dateTimePickerBirth";
            this.dateTimePickerBirth.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerBirth.TabIndex = 2;
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Items.AddRange(new object[] {
            "Бакалавр",
            "Спеціаліст",
            "Магістр"});
            this.comboBoxLevel.Location = new System.Drawing.Point(140, 140);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(200, 24);
            this.comboBoxLevel.TabIndex = 3;
            // 
            // buttonAddExam
            // 
            this.buttonAddExam.Location = new System.Drawing.Point(20, 180);
            this.buttonAddExam.Name = "buttonAddExam";
            this.buttonAddExam.Size = new System.Drawing.Size(90, 30);
            this.buttonAddExam.TabIndex = 4;
            this.buttonAddExam.Text = "Додати";
            this.buttonAddExam.UseVisualStyleBackColor = true;
            this.buttonAddExam.Click += new System.EventHandler(this.buttonAddExam_Click);
            // 
            // buttonEditExam
            // 
            this.buttonEditExam.Location = new System.Drawing.Point(120, 180);
            this.buttonEditExam.Name = "buttonEditExam";
            this.buttonEditExam.Size = new System.Drawing.Size(90, 30);
            this.buttonEditExam.TabIndex = 5;
            this.buttonEditExam.Text = "Редагувати";
            this.buttonEditExam.UseVisualStyleBackColor = true;
            this.buttonEditExam.Click += new System.EventHandler(this.buttonEditExam_Click);
            // 
            // buttonDeleteExam
            // 
            this.buttonDeleteExam.Location = new System.Drawing.Point(220, 180);
            this.buttonDeleteExam.Name = "buttonDeleteExam";
            this.buttonDeleteExam.Size = new System.Drawing.Size(90, 30);
            this.buttonDeleteExam.TabIndex = 6;
            this.buttonDeleteExam.Text = "Видалити";
            this.buttonDeleteExam.UseVisualStyleBackColor = true;
            this.buttonDeleteExam.Click += new System.EventHandler(this.buttonDeleteExam_Click);
            // 
            // listBoxExams
            // 
            this.listBoxExams.FormattingEnabled = true;
            this.listBoxExams.ItemHeight = 16;
            this.listBoxExams.Location = new System.Drawing.Point(20, 220);
            this.listBoxExams.Name = "listBoxExams";
            this.listBoxExams.Size = new System.Drawing.Size(320, 100);
            this.listBoxExams.TabIndex = 7;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(140, 340);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 30);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.Text = "Ім'я:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.Text = "Прізвище:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 100);
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.Text = "Дата народження:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 140);
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.Text = "Освітній рівень:";
            // 
            // StudentForm
            // 
            this.ClientSize = new System.Drawing.Size(380, 400);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                textBoxFirstName, textBoxLastName, dateTimePickerBirth, comboBoxLevel,
                buttonAddExam, buttonEditExam, buttonDeleteExam, listBoxExams, buttonSave,
                label1, label2, label3, label4
            });
            this.Name = "StudentForm";
            this.Text = "Студент";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
