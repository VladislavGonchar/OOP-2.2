using System;
using System.Windows.Forms;
using StudentLibrary.Models;

namespace StudentApp
{
    public partial class StudentForm : Form
    {
        public Student Student { get; private set; }

        private ListBox listBoxExams;
        private Button buttonAddExam;
        private Button buttonEditExam;
        private Button buttonDeleteExam;

        public StudentForm(Student student = null)
        {
            InitializeComponent();

            // Заповнюємо рівні освіти
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

            InitializeExamControls(); // Додаємо управління для іспитів
            UpdateExamList(); // Оновлюємо список іспитів
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

        // --------------------- Елементи управління іспитами ---------------------

        private void InitializeExamControls()
        {
            // ListBox для іспитів
            listBoxExams = new ListBox
            {
                Top = 200,
                Left = 20,
                Width = 300,
                Height = 100
            };
            Controls.Add(listBoxExams);

            // Кнопка додати
            buttonAddExam = new Button
            {
                Text = "Додати іспит",
                Top = listBoxExams.Bottom + 10,
                Left = listBoxExams.Left,
                Width = 90
            };
            buttonAddExam.Click += buttonAddExam_Click;
            Controls.Add(buttonAddExam);

            // Кнопка редагувати
            buttonEditExam = new Button
            {
                Text = "Редагувати",
                Top = listBoxExams.Bottom + 10,
                Left = buttonAddExam.Right + 10,
                Width = 90
            };
            buttonEditExam.Click += buttonEditExam_Click;
            Controls.Add(buttonEditExam);

            // Кнопка видалити
            buttonDeleteExam = new Button
            {
                Text = "Видалити",
                Top = listBoxExams.Bottom + 10,
                Left = buttonEditExam.Right + 10,
                Width = 90
            };
            buttonDeleteExam.Click += buttonDeleteExam_Click;
            Controls.Add(buttonDeleteExam);
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
                    UpdateExamList(); // оновлюємо список
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
