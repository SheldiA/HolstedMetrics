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
            this.rtb_main = new System.Windows.Forms.RichTextBox();
            this.bt_calculate = new System.Windows.Forms.Button();
            this.open_file = new System.Windows.Forms.OpenFileDialog();
            this.gb_chooseMetric = new System.Windows.Forms.GroupBox();
            this.rb_holsted = new System.Windows.Forms.RadioButton();
            this.rb_mayers = new System.Windows.Forms.RadioButton();
            this.rb_borderValue = new System.Windows.Forms.RadioButton();
            this.gb_chooseMetric.SuspendLayout();
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
            // rtb_main
            // 
            this.rtb_main.Location = new System.Drawing.Point(325, 57);
            this.rtb_main.Name = "rtb_main";
            this.rtb_main.Size = new System.Drawing.Size(298, 151);
            this.rtb_main.TabIndex = 2;
            this.rtb_main.Text = "";
            // 
            // bt_calculate
            // 
            this.bt_calculate.Location = new System.Drawing.Point(220, 122);
            this.bt_calculate.Name = "bt_calculate";
            this.bt_calculate.Size = new System.Drawing.Size(99, 38);
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
            // gb_chooseMetric
            // 
            this.gb_chooseMetric.Controls.Add(this.rb_borderValue);
            this.gb_chooseMetric.Controls.Add(this.rb_mayers);
            this.gb_chooseMetric.Controls.Add(this.rb_holsted);
            this.gb_chooseMetric.Location = new System.Drawing.Point(19, 78);
            this.gb_chooseMetric.Name = "gb_chooseMetric";
            this.gb_chooseMetric.Size = new System.Drawing.Size(182, 102);
            this.gb_chooseMetric.TabIndex = 4;
            this.gb_chooseMetric.TabStop = false;
            this.gb_chooseMetric.Text = "Выберите метрику";
            // 
            // rb_holsted
            // 
            this.rb_holsted.AutoSize = true;
            this.rb_holsted.Checked = true;
            this.rb_holsted.Location = new System.Drawing.Point(11, 21);
            this.rb_holsted.Name = "rb_holsted";
            this.rb_holsted.Size = new System.Drawing.Size(73, 17);
            this.rb_holsted.TabIndex = 0;
            this.rb_holsted.TabStop = true;
            this.rb_holsted.Text = "Холстеда";
            this.rb_holsted.UseVisualStyleBackColor = true;
            // 
            // rb_mayers
            // 
            this.rb_mayers.AutoSize = true;
            this.rb_mayers.Location = new System.Drawing.Point(11, 44);
            this.rb_mayers.Name = "rb_mayers";
            this.rb_mayers.Size = new System.Drawing.Size(70, 17);
            this.rb_mayers.TabIndex = 1;
            this.rb_mayers.Text = "Майерса";
            this.rb_mayers.UseVisualStyleBackColor = true;
            // 
            // rb_borderValue
            // 
            this.rb_borderValue.AutoSize = true;
            this.rb_borderValue.Location = new System.Drawing.Point(11, 70);
            this.rb_borderValue.Name = "rb_borderValue";
            this.rb_borderValue.Size = new System.Drawing.Size(175, 17);
            this.rb_borderValue.TabIndex = 2;
            this.rb_borderValue.Text = "Метрика граничных значений";
            this.rb_borderValue.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 239);
            this.Controls.Add(this.gb_chooseMetric);
            this.Controls.Add(this.bt_calculate);
            this.Controls.Add(this.rtb_main);
            this.Controls.Add(this.tb_fileName);
            this.Controls.Add(this.bt_chooseFile);
            this.Name = "FormMain";
            this.Text = "Holsted";
            this.gb_chooseMetric.ResumeLayout(false);
            this.gb_chooseMetric.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_chooseFile;
        private System.Windows.Forms.TextBox tb_fileName;
        private System.Windows.Forms.RichTextBox rtb_main;
        private System.Windows.Forms.Button bt_calculate;
        private System.Windows.Forms.OpenFileDialog open_file;
        private System.Windows.Forms.GroupBox gb_chooseMetric;
        private System.Windows.Forms.RadioButton rb_borderValue;
        private System.Windows.Forms.RadioButton rb_mayers;
        private System.Windows.Forms.RadioButton rb_holsted;
    }
}

