using System;
using System.Windows.Forms;
using StudentLibrary.Models;

namespace StudentApp
{
    public partial class StudentForm : Form
    {
        public Student Student { get; private set; }

        public StudentForm(Student student = null)
        {
            InitializeComponent();

            
            comboBoxLevel.Items.Clear();
            comboBoxLevel.Items.AddRange(new[] { "Бакалавр", "Спеціаліст", "Магістр" });

            if (student != null)
            {
                Student = student;
                textBoxFirstName.Text = student.FirstName;
                textBoxLastName.Text = student.LastName;
                dateTimePickerBirth.Value = student.BirthDate;
                comboBoxLevel.SelectedItem = student.Level.ToString();
            }
            else
            {
                Student = new Student();
            }

            UpdateExamList(); 
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text) || string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Student.FirstName = textBoxFirstName.Text;
            Student.LastName = textBoxLastName.Text;
            Student.BirthDate = dateTimePickerBirth.Value;

            if (comboBoxLevel.SelectedItem != null)
            {
                Student.Level = (EducationLevel)Enum.Parse(typeof(EducationLevel), comboBoxLevel.SelectedItem.ToString(), true);
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть рівень освіти.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateExamList()
        {
            listBoxExams.DataSource = null;
            listBoxExams.DataSource = Student.Exams;
        }

        private void buttonAddExam_Click(object sender, EventArgs e)
        {
            ExamForm examForm = new ExamForm();
            if (examForm.ShowDialog() == DialogResult.OK)
            {
                Student.Exams.Add(examForm.Exam);
                UpdateExamList();
            }
        }

        private void buttonEditExam_Click(object sender, EventArgs e)
        {
            if (listBoxExams.SelectedItem is Exam selectedExam)
            {
                ExamForm examForm = new ExamForm(selectedExam);
                if (examForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateExamList(); 
                }
            }
        }

        private void buttonDeleteExam_Click(object sender, EventArgs e)
        {
            if (listBoxExams.SelectedItem is Exam selectedExam)
            {
                var result = MessageBox.Show("Ви впевнені, що хочете видалити цей іспит?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Student.Exams.Remove(selectedExam);
                    UpdateExamList();
                }
            }
        }
    }
}
