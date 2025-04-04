namespace StudentApp
{
    partial class ExamForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.NumericUpDown numericUpDownGrade;
        private System.Windows.Forms.DateTimePicker dateTimePickerExamDate;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.numericUpDownGrade = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerExamDate = new System.Windows.Forms.DateTimePicker();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrade)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(140, 20);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(200, 22);
            this.textBoxSubject.TabIndex = 0;
            // 
            // numericUpDownGrade
            // 
            this.numericUpDownGrade.Location = new System.Drawing.Point(140, 60);
            this.numericUpDownGrade.Maximum = 100;
            this.numericUpDownGrade.Name = "numericUpDownGrade";
            this.numericUpDownGrade.Size = new System.Drawing.Size(200, 22);
            this.numericUpDownGrade.TabIndex = 1;
            // 
            // dateTimePickerExamDate
            // 
            this.dateTimePickerExamDate.Location = new System.Drawing.Point(140, 100);
            this.dateTimePickerExamDate.Name = "dateTimePickerExamDate";
            this.dateTimePickerExamDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerExamDate.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(140, 140);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 30);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labels
            // 
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Text = "Предмет:";
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Text = "Оцінка:";
            this.label3.Location = new System.Drawing.Point(20, 100);
            this.label3.Text = "Дата іспиту:";
            //
            // ExamForm
            //
            this.ClientSize = new System.Drawing.Size(380, 200);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                label1, label2, label3,
                textBoxSubject, numericUpDownGrade, dateTimePickerExamDate, buttonSave
            });
            this.Name = "ExamForm";
            this.Text = "Іспит";
            this.ResumeLayout(false);
            this.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrade)).EndInit();
        }
    }
}
