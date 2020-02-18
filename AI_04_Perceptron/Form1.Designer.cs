namespace AI_04 {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReadVectors = new System.Windows.Forms.Button();
            this.btnSaveVectors = new System.Windows.Forms.Button();
            this.btnCountVectors = new System.Windows.Forms.Button();
            this.btnOpenListNonPDF = new System.Windows.Forms.Button();
            this.btnOpenListPDF = new System.Windows.Forms.Button();
            this.pathNonPDF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pathPDF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.openDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveDlg = new System.Windows.Forms.SaveFileDialog();
            this.lblVectorsState = new System.Windows.Forms.Label();
            this.btnTeach = new System.Windows.Forms.Button();
            this.lblWVectorState = new System.Windows.Forms.Label();
            this.btnReadW = new System.Windows.Forms.Button();
            this.btnSaveW = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TestFilePath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnReadVectors);
            this.groupBox1.Controls.Add(this.btnSaveVectors);
            this.groupBox1.Controls.Add(this.btnCountVectors);
            this.groupBox1.Controls.Add(this.btnOpenListNonPDF);
            this.groupBox1.Controls.Add(this.btnOpenListPDF);
            this.groupBox1.Controls.Add(this.pathNonPDF);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pathPDF);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Входные векторы";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReadVectors
            // 
            this.btnReadVectors.Location = new System.Drawing.Point(282, 74);
            this.btnReadVectors.Name = "btnReadVectors";
            this.btnReadVectors.Size = new System.Drawing.Size(85, 23);
            this.btnReadVectors.TabIndex = 8;
            this.btnReadVectors.Text = "Прочитать...";
            this.btnReadVectors.UseVisualStyleBackColor = true;
            this.btnReadVectors.Click += new System.EventHandler(this.btnReadVectors_Click);
            // 
            // btnSaveVectors
            // 
            this.btnSaveVectors.Location = new System.Drawing.Point(191, 74);
            this.btnSaveVectors.Name = "btnSaveVectors";
            this.btnSaveVectors.Size = new System.Drawing.Size(85, 23);
            this.btnSaveVectors.TabIndex = 7;
            this.btnSaveVectors.Text = "Сохранить...";
            this.btnSaveVectors.UseVisualStyleBackColor = true;
            this.btnSaveVectors.Click += new System.EventHandler(this.btnSaveVectors_Click);
            // 
            // btnCountVectors
            // 
            this.btnCountVectors.Location = new System.Drawing.Point(9, 74);
            this.btnCountVectors.Name = "btnCountVectors";
            this.btnCountVectors.Size = new System.Drawing.Size(85, 23);
            this.btnCountVectors.TabIndex = 6;
            this.btnCountVectors.Text = "Вычислить";
            this.btnCountVectors.UseVisualStyleBackColor = true;
            this.btnCountVectors.Click += new System.EventHandler(this.btnCountVectors_Click);
            // 
            // btnOpenListNonPDF
            // 
            this.btnOpenListNonPDF.Location = new System.Drawing.Point(292, 45);
            this.btnOpenListNonPDF.Name = "btnOpenListNonPDF";
            this.btnOpenListNonPDF.Size = new System.Drawing.Size(75, 23);
            this.btnOpenListNonPDF.TabIndex = 5;
            this.btnOpenListNonPDF.Text = "Обзор...";
            this.btnOpenListNonPDF.UseVisualStyleBackColor = true;
            this.btnOpenListNonPDF.Click += new System.EventHandler(this.btnOpenListNonPDF_Click);
            // 
            // btnOpenListPDF
            // 
            this.btnOpenListPDF.Location = new System.Drawing.Point(292, 18);
            this.btnOpenListPDF.Name = "btnOpenListPDF";
            this.btnOpenListPDF.Size = new System.Drawing.Size(75, 23);
            this.btnOpenListPDF.TabIndex = 2;
            this.btnOpenListPDF.Text = "Обзор...";
            this.btnOpenListPDF.UseVisualStyleBackColor = true;
            this.btnOpenListPDF.Click += new System.EventHandler(this.btnOpenListPDF_Click);
            // 
            // pathNonPDF
            // 
            this.pathNonPDF.Location = new System.Drawing.Point(125, 47);
            this.pathNonPDF.Name = "pathNonPDF";
            this.pathNonPDF.Size = new System.Drawing.Size(161, 21);
            this.pathNonPDF.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Список иных файлов";
            // 
            // pathPDF
            // 
            this.pathPDF.Location = new System.Drawing.Point(125, 20);
            this.pathPDF.Name = "pathPDF";
            this.pathPDF.Size = new System.Drawing.Size(161, 21);
            this.pathPDF.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Список файлов PDF";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveW);
            this.groupBox2.Controls.Add(this.btnReadW);
            this.groupBox2.Controls.Add(this.lblWVectorState);
            this.groupBox2.Controls.Add(this.btnTeach);
            this.groupBox2.Controls.Add(this.lblVectorsState);
            this.groupBox2.Location = new System.Drawing.Point(12, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 95);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Обучение";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.TestFilePath);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 226);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(377, 52);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Определение формата";
            // 
            // openDlg
            // 
            this.openDlg.Filter = "Текстовые файлы|*.txt";
            this.openDlg.Title = "Открыть список";
            // 
            // lblVectorsState
            // 
            this.lblVectorsState.AutoSize = true;
            this.lblVectorsState.Location = new System.Drawing.Point(9, 21);
            this.lblVectorsState.Name = "lblVectorsState";
            this.lblVectorsState.Size = new System.Drawing.Size(198, 13);
            this.lblVectorsState.TabIndex = 0;
            this.lblVectorsState.Text = "Векторы для обучения не загружены";
            // 
            // btnTeach
            // 
            this.btnTeach.Location = new System.Drawing.Point(292, 16);
            this.btnTeach.Name = "btnTeach";
            this.btnTeach.Size = new System.Drawing.Size(75, 23);
            this.btnTeach.TabIndex = 1;
            this.btnTeach.Text = "Обучить";
            this.btnTeach.UseVisualStyleBackColor = true;
            this.btnTeach.Click += new System.EventHandler(this.btnTeach_Click);
            // 
            // lblWVectorState
            // 
            this.lblWVectorState.AutoSize = true;
            this.lblWVectorState.Location = new System.Drawing.Point(9, 46);
            this.lblWVectorState.Name = "lblWVectorState";
            this.lblWVectorState.Size = new System.Drawing.Size(212, 13);
            this.lblWVectorState.TabIndex = 2;
            this.lblWVectorState.Text = "Вектор W весовых коэффициентов пуст";
            // 
            // btnReadW
            // 
            this.btnReadW.Location = new System.Drawing.Point(161, 66);
            this.btnReadW.Name = "btnReadW";
            this.btnReadW.Size = new System.Drawing.Size(100, 23);
            this.btnReadW.TabIndex = 3;
            this.btnReadW.Text = "Загрузить W...";
            this.btnReadW.UseVisualStyleBackColor = true;
            this.btnReadW.Click += new System.EventHandler(this.btnReadW_Click);
            // 
            // btnSaveW
            // 
            this.btnSaveW.Location = new System.Drawing.Point(267, 66);
            this.btnSaveW.Name = "btnSaveW";
            this.btnSaveW.Size = new System.Drawing.Size(100, 23);
            this.btnSaveW.TabIndex = 4;
            this.btnSaveW.Text = "Сохранить W...";
            this.btnSaveW.UseVisualStyleBackColor = true;
            this.btnSaveW.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Файл";
            // 
            // TestFilePath
            // 
            this.TestFilePath.Location = new System.Drawing.Point(48, 20);
            this.TestFilePath.Name = "TestFilePath";
            this.TestFilePath.Size = new System.Drawing.Size(137, 21);
            this.TestFilePath.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(191, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Обзор...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(282, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Определить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 284);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReadVectors;
        private System.Windows.Forms.Button btnSaveVectors;
        private System.Windows.Forms.Button btnCountVectors;
        private System.Windows.Forms.Button btnOpenListNonPDF;
        private System.Windows.Forms.Button btnOpenListPDF;
        private System.Windows.Forms.TextBox pathNonPDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pathPDF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.OpenFileDialog openDlg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveDlg;
        private System.Windows.Forms.Label lblVectorsState;
        private System.Windows.Forms.Button btnTeach;
        private System.Windows.Forms.Label lblWVectorState;
        private System.Windows.Forms.Button btnSaveW;
        private System.Windows.Forms.Button btnReadW;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TestFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
    }
}

