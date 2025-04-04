using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StudentLibrary.Models;
using StudentLibrary.Serialization;

namespace StudentApp
{
    public partial class MainForm : Form
    {
        private List<Student> students = new List<Student>();
        private List<Student> studentsBackup = new List<Student>(); // Копія початкових даних
        private bool changesMade = false; // Прапор для відстеження змін
        private List<Student> temporaryStudents = new List<Student>(); // Тимчасовий список для додавання/видалення

        public MainForm()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            students = JsonStorage.Load();
            studentsBackup = new List<Student>(students); // Копіюємо початкові дані
            temporaryStudents = new List<Student>(students); // Копія даних для тимчасових змін
            listBoxStudents.DataSource = null;
            listBoxStudents.DataSource = temporaryStudents; // Відображаємо тимчасовий список
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            if (studentForm.ShowDialog() == DialogResult.OK)
            {
                temporaryStudents.Add(studentForm.Student); // Додаємо тимчасово
                changesMade = true;
                listBoxStudents.DataSource = null; // Скидаємо прив'язку
                listBoxStudents.DataSource = temporaryStudents; // Оновлюємо список у ListBox
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listBoxStudents.SelectedItem is Student selectedStudent)
            {
                StudentForm studentForm = new StudentForm(selectedStudent);
                if (studentForm.ShowDialog() == DialogResult.OK)
                {
                    // Оновлюємо тимчасовий список
                    int index = temporaryStudents.IndexOf(selectedStudent);
                    temporaryStudents[index] = studentForm.Student;
                    changesMade = true;
                    listBoxStudents.DataSource = null; // Скидаємо прив'язку
                    listBoxStudents.DataSource = temporaryStudents; // Оновлюємо список у ListBox
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxStudents.SelectedItem is Student selectedStudent)
            {
                var result = MessageBox.Show("Ви впевнені, що хочете видалити цього студента?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    temporaryStudents.Remove(selectedStudent); // Видаляємо тимчасово
                    changesMade = true;
                    listBoxStudents.DataSource = null; // Скидаємо прив'язку
                    listBoxStudents.DataSource = temporaryStudents; // Оновлюємо список у ListBox
                }
            }
        }

        private void SaveStudents()
        {
            JsonStorage.Save(temporaryStudents); // Зберігаємо тільки після підтвердження
            students = new List<Student>(temporaryStudents); // Копіюємо тимчасові зміни в основний список
            studentsBackup = new List<Student>(students); // Оновлюємо копію початкових даних
        }

        // Перевірка на збереження змін перед закриттям
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (changesMade) // Якщо були зміни
            {
                var result = MessageBox.Show("Зберегти зміни?", "Підтвердження", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveStudents(); // Зберігаємо зміни
                }
                else if (result == DialogResult.No)
                {
                    temporaryStudents = new List<Student>(studentsBackup); // Відновлюємо початкові дані
                    LoadStudents(); // Оновлюємо відображення
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; // Скасовуємо закриття форми
                }
            }
        }
    }
}
