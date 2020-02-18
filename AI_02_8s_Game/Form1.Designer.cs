namespace AI_02 {
    partial class Form1 {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.новаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.решитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gameField = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cell8 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cell7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cell6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cell5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cell4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cell3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cell2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cell1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cell0 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.gameField.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяИграToolStripMenuItem,
            this.решитьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(209, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // новаяИграToolStripMenuItem
            // 
            this.новаяИграToolStripMenuItem.Enabled = false;
            this.новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            this.новаяИграToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.новаяИграToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.новаяИграToolStripMenuItem.Text = "Новая игра";
            this.новаяИграToolStripMenuItem.Click += new System.EventHandler(this.новаяИграToolStripMenuItem_Click);
            // 
            // решитьToolStripMenuItem
            // 
            this.решитьToolStripMenuItem.Enabled = false;
            this.решитьToolStripMenuItem.Name = "решитьToolStripMenuItem";
            this.решитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.решитьToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.решитьToolStripMenuItem.Text = "Решить";
            this.решитьToolStripMenuItem.Click += new System.EventHandler(this.решитьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 27);
            this.progressBar1.Maximum = 181440;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(209, 21);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 1;
            // 
            // gameField
            // 
            this.gameField.Controls.Add(this.panel9);
            this.gameField.Controls.Add(this.panel8);
            this.gameField.Controls.Add(this.panel7);
            this.gameField.Controls.Add(this.panel6);
            this.gameField.Controls.Add(this.panel5);
            this.gameField.Controls.Add(this.panel4);
            this.gameField.Controls.Add(this.panel3);
            this.gameField.Controls.Add(this.panel2);
            this.gameField.Controls.Add(this.panel1);
            this.gameField.Location = new System.Drawing.Point(0, 54);
            this.gameField.Name = "gameField";
            this.gameField.Size = new System.Drawing.Size(209, 122);
            this.gameField.TabIndex = 12;
            this.gameField.Visible = false;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.cell8);
            this.panel9.Location = new System.Drawing.Point(121, 81);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(24, 28);
            this.panel9.TabIndex = 20;
            // 
            // cell8
            // 
            this.cell8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cell8.Location = new System.Drawing.Point(3, 0);
            this.cell8.Name = "cell8";
            this.cell8.Size = new System.Drawing.Size(19, 25);
            this.cell8.TabIndex = 4;
            this.cell8.Tag = "8";
            this.cell8.Text = "A";
            this.cell8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cell8.Click += new System.EventHandler(this.cell_Click);
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.cell7);
            this.panel8.Location = new System.Drawing.Point(91, 81);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(24, 28);
            this.panel8.TabIndex = 19;
            // 
            // cell7
            // 
            this.cell7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cell7.Location = new System.Drawing.Point(3, 0);
            this.cell7.Name = "cell7";
            this.cell7.Size = new System.Drawing.Size(19, 25);
            this.cell7.TabIndex = 4;
            this.cell7.Tag = "7";
            this.cell7.Text = "A";
            this.cell7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cell7.Click += new System.EventHandler(this.cell_Click);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.cell6);
            this.panel7.Location = new System.Drawing.Point(61, 81);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(24, 28);
            this.panel7.TabIndex = 18;
            // 
            // cell6
            // 
            this.cell6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cell6.Location = new System.Drawing.Point(3, 0);
            this.cell6.Name = "cell6";
            this.cell6.Size = new System.Drawing.Size(19, 25);
            this.cell6.TabIndex = 4;
            this.cell6.Tag = "6";
            this.cell6.Text = "A";
            this.cell6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cell6.Click += new System.EventHandler(this.cell_Click);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.cell5);
            this.panel6.Location = new System.Drawing.Point(121, 47);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(24, 28);
            this.panel6.TabIndex = 17;
            // 
            // cell5
            // 
            this.cell5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cell5.Location = new System.Drawing.Point(3, 0);
            this.cell5.Name = "cell5";
            this.cell5.Size = new System.Drawing.Size(19, 25);
            this.cell5.TabIndex = 4;
            this.cell5.Tag = "5";
            this.cell5.Text = "A";
            this.cell5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cell5.Click += new System.EventHandler(this.cell_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cell4);
            this.panel5.Location = new System.Drawing.Point(91, 47);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(24, 28);
            this.panel5.TabIndex = 16;
            // 
            // cell4
            // 
            this.cell4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cell4.Location = new System.Drawing.Point(3, 0);
            this.cell4.Name = "cell4";
            this.cell4.Size = new System.Drawing.Size(19, 25);
            this.cell4.TabIndex = 4;
            this.cell4.Tag = "4";
            this.cell4.Text = "A";
            this.cell4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cell4.Click += new System.EventHandler(this.cell_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cell3);
            this.panel4.Location = new System.Drawing.Point(61, 47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(24, 28);
            this.panel4.TabIndex = 15;
            // 
            // cell3
            // 
            this.cell3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cell3.Location = new System.Drawing.Point(3, 0);
            this.cell3.Name = "cell3";
            this.cell3.Size = new System.Drawing.Size(19, 25);
            this.cell3.TabIndex = 4;
            this.cell3.Tag = "3";
            this.cell3.Text = "A";
            this.cell3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cell3.Click += new System.EventHandler(this.cell_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cell2);
            this.panel3.Location = new System.Drawing.Point(121, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(24, 28);
            this.panel3.TabIndex = 14;
            // 
            // cell2
            // 
            this.cell2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cell2.Location = new System.Drawing.Point(3, 0);
            this.cell2.Name = "cell2";
            this.cell2.Size = new System.Drawing.Size(19, 25);
            this.cell2.TabIndex = 4;
            this.cell2.Tag = "2";
            this.cell2.Text = "A";
            this.cell2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cell2.Click += new System.EventHandler(this.cell_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cell1);
            this.panel2.Location = new System.Drawing.Point(91, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(24, 28);
            this.panel2.TabIndex = 13;
            // 
            // cell1
            // 
            this.cell1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cell1.Location = new System.Drawing.Point(3, 0);
            this.cell1.Name = "cell1";
            this.cell1.Size = new System.Drawing.Size(19, 25);
            this.cell1.TabIndex = 4;
            this.cell1.Tag = "1";
            this.cell1.Text = "A";
            this.cell1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cell1.Click += new System.EventHandler(this.cell_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cell0);
            this.panel1.Location = new System.Drawing.Point(61, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(24, 28);
            this.panel1.TabIndex = 12;
            // 
            // cell0
            // 
            this.cell0.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cell0.Location = new System.Drawing.Point(3, 0);
            this.cell0.Name = "cell0";
            this.cell0.Size = new System.Drawing.Size(19, 25);
            this.cell0.TabIndex = 4;
            this.cell0.Tag = "0";
            this.cell0.Text = "A";
            this.cell0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cell0.Click += new System.EventHandler(this.cell_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1100;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 300;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 21);
            this.button1.TabIndex = 21;
            this.button1.Text = "Стоп";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 201);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gameField);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Восьмерки";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gameField.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem новаяИграToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem решитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel gameField;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label cell8;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label cell7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label cell6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label cell5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label cell4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label cell3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label cell2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label cell1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label cell0;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button1;
    }
}

