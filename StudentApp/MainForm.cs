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
        private List<Student> studentsBackup = new List<Student>();
        private bool changesMade = false; 
        private List<Student> temporaryStudents = new List<Student>(); 

        public MainForm()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            students = JsonStorage.Load();
            studentsBackup = new List<Student>(students); 
            temporaryStudents = new List<Student>(students); 
            listBoxStudents.DataSource = null;
            listBoxStudents.DataSource = temporaryStudents; 
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            if (studentForm.ShowDialog() == DialogResult.OK)
            {
                temporaryStudents.Add(studentForm.Student); 
                changesMade = true;
                listBoxStudents.DataSource = null; 
                listBoxStudents.DataSource = temporaryStudents; 
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listBoxStudents.SelectedItem is Student selectedStudent)
            {
                StudentForm studentForm = new StudentForm(selectedStudent);
                if (studentForm.ShowDialog() == DialogResult.OK)
                {
                    
                    int index = temporaryStudents.IndexOf(selectedStudent);
                    temporaryStudents[index] = studentForm.Student;
                    changesMade = true;
                    listBoxStudents.DataSource = null; 
                    listBoxStudents.DataSource = temporaryStudents; 
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
                    temporaryStudents.Remove(selectedStudent); 
                    changesMade = true;
                    listBoxStudents.DataSource = null; 
                    listBoxStudents.DataSource = temporaryStudents; 
                }
            }
        }

        private void SaveStudents()
        {
            JsonStorage.Save(temporaryStudents); 
            students = new List<Student>(temporaryStudents); 
            studentsBackup = new List<Student>(students); 
        }

        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (changesMade) 
            {
                var result = MessageBox.Show("Зберегти зміни?", "Підтвердження", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveStudents(); 
                }
                else if (result == DialogResult.No)
                {
                    temporaryStudents = new List<Student>(studentsBackup); 
                    LoadStudents(); 
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; 
                }
            }
        }
    }
}
