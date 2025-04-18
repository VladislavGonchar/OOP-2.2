﻿using System;
using System.Windows.Forms;
using StudentLibrary.Models;

namespace StudentApp
{
    public partial class ExamForm : Form
    {
        public Exam Exam { get; private set; }

        public ExamForm(Exam exam = null)
        {
            InitializeComponent();
            if (exam != null)
            {
                Exam = exam;
                textBoxSubject.Text = exam.Subject;
                numericUpDownGrade.Value = exam.Grade;
                dateTimePickerExamDate.Value = exam.ExamDate;
            }
            else
            {
                Exam = new Exam();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(textBoxSubject.Text))
            {
                MessageBox.Show(
                    "Будь ласка, заповніть всі поля (назва екзамену не може бути порожньою).",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            
            Exam.Subject = textBoxSubject.Text;
            Exam.Grade = (int)numericUpDownGrade.Value;
            Exam.ExamDate = dateTimePickerExamDate.Value;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
