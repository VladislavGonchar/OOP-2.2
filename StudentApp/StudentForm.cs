// StudentForm (with validation and dialog prompt)
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

            // Оновлюємо список варіантів у випадаючому меню (тепер українською)
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
    }
}
