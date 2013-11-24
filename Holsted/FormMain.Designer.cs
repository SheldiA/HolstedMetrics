namespace Holsted
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_chooseFile = new System.Windows.Forms.Button();
            this.tb_fileName = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bt_calculate = new System.Windows.Forms.Button();
            this.open_file = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // bt_chooseFile
            // 
            this.bt_chooseFile.Location = new System.Drawing.Point(275, 7);
            this.bt_chooseFile.Name = "bt_chooseFile";
            this.bt_chooseFile.Size = new System.Drawing.Size(135, 34);
            this.bt_chooseFile.TabIndex = 0;
            this.bt_chooseFile.Text = "Open file";
            this.bt_chooseFile.UseVisualStyleBackColor = true;
            this.bt_chooseFile.Click += new System.EventHandler(this.bt_chooseFile_Click);
            // 
            // tb_fileName
            // 
            this.tb_fileName.Location = new System.Drawing.Point(18, 15);
            this.tb_fileName.Name = "tb_fileName";
            this.tb_fileName.Size = new System.Drawing.Size(242, 20);
            this.tb_fileName.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(18, 59);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(467, 151);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // bt_calculate
            // 
            this.bt_calculate.Location = new System.Drawing.Point(153, 232);
            this.bt_calculate.Name = "bt_calculate";
            this.bt_calculate.Size = new System.Drawing.Size(176, 31);
            this.bt_calculate.TabIndex = 3;
            this.bt_calculate.Text = "Calculate";
            this.bt_calculate.UseVisualStyleBackColor = true;
            this.bt_calculate.Click += new System.EventHandler(this.bt_calculate_Click);
            // 
            // open_file
            // 
            this.open_file.DefaultExt = "*.txt";
            this.open_file.Filter = "TXT Files|*.txt";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 376);
            this.Controls.Add(this.bt_calculate);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tb_fileName);
            this.Controls.Add(this.bt_chooseFile);
            this.Name = "FormMain";
            this.Text = "Holsted";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_chooseFile;
        private System.Windows.Forms.TextBox tb_fileName;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button bt_calculate;
        private System.Windows.Forms.OpenFileDialog open_file;
    }
}

