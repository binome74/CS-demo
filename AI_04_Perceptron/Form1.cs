using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AI_04 {
    public partial class Form1 : Form {

        Neural N;

        public Form1() {
            InitializeComponent();
            N = new Neural();
            N.ListsChanged += new ListsChangedEvent(ListsChangedHandler);
            N.WVectorChange += new WVectorChangeEvent(WVectorChangeHandler);
        }

        private void WVectorChangeHandler() {
            if (N.WVectorState == true) {
                lblWVectorState.Text = @"Вектор W весовых коэффициентов заполнен";
                btnSaveW.BackColor = Color.Orange;
            } else {
                btnSaveW.BackColor = btnReadW.BackColor;
                lblWVectorState.Text = @"Вектор W весовых коэффициентов пуст";
            }
        }

        private void ListsChangedHandler() {
            btnSaveVectors.BackColor = Color.Orange;
            if ((N.PDFVectorsCount > 0) || (N.NonPDFVectorsCount > 0)) {
                lblVectorsState.Text =
                    String.Format("Загружено {0} PDF векторов и {1} не PDF векторов", N.PDFVectorsCount, N.NonPDFVectorsCount);
            } else {
                lblVectorsState.Text = @"Векторы для обучения не загружены";
            }
        }

        private void btnOpenListPDF_Click(object sender, EventArgs e) {
            openDlg.Filter = @"Текстовые файлы|*.txt";
            if (openDlg.ShowDialog(this) == DialogResult.OK) {
                pathPDF.Text = openDlg.FileName;
            }
        }

        private void btnOpenListNonPDF_Click(object sender, EventArgs e) {
            openDlg.Filter = @"Текстовые файлы|*.txt";
            if (openDlg.ShowDialog(this) == DialogResult.OK) {
                pathNonPDF.Text = openDlg.FileName;
            }
        }

        private void btnCountVectors_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;
            try {
                N.CreateInputVectors(pathPDF.Text, true);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;
            }
            try {
                N.CreateInputVectors(pathNonPDF.Text, false);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
            MessageBox.Show("Векторы вычислены", "Вычислить", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e) {
            N.ClearVectors();
            MessageBox.Show("Списки векторов очищены", "Очистка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveVectors_Click(object sender, EventArgs e) {
            saveDlg.Filter = @"Файлы векторов|*.dat";
            if (saveDlg.ShowDialog(this) == DialogResult.OK) {
                try {
                    N.SaveVectorsToFile(saveDlg.FileName);
                    btnSaveVectors.BackColor = btnCountVectors.BackColor;
                    MessageBox.Show(saveDlg.FileName + "\nСохранено успешно", "Сохранить", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReadVectors_Click(object sender, EventArgs e) {
            openDlg.Filter = @"Файлы векторов|*.dat";
            if (openDlg.ShowDialog(this) == DialogResult.OK) {
                try {
                    bool was_empty = N.VectorsEmpty;
                    N.ReadVectorsFromFile(openDlg.FileName);
                    if (was_empty) btnSaveVectors.BackColor = btnCountVectors.BackColor;
                    MessageBox.Show(saveDlg.FileName + "\nПрочитано успешно", "Прочитать", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTeach_Click(object sender, EventArgs e) {
            try {
                double quality = N.Teach();
                MessageBox.Show("Обучение окончено. Качество: " + quality.ToString("F"), "Обучение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            saveDlg.Filter = @"Файлы весовых векторов|*.wdt";
            if (saveDlg.ShowDialog(this) == DialogResult.OK) {
                try {
                    N.SaveWToFile(saveDlg.FileName);
                    btnSaveW.BackColor = btnReadW.BackColor;
                    MessageBox.Show(saveDlg.FileName + "\nСохранено успешно", "Сохранить", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReadW_Click(object sender, EventArgs e) {
            openDlg.Filter = @"Файлы весовых векторов|*.wdt";
            if (openDlg.ShowDialog(this) == DialogResult.OK) {
                try {
                    N.ReadWFromFile(openDlg.FileName);
                    btnSaveW.BackColor = btnReadW.BackColor;
                    MessageBox.Show(saveDlg.FileName + "\nПрочитано успешно", "Прочитать", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            openDlg.Filter = @"Все файлы|*.*";
            if (openDlg.ShowDialog(this) == DialogResult.OK) {
                TestFilePath.Text = openDlg.FileName;
            }
        }

        private void button3_Click_1(object sender, EventArgs e) {
            string format;
            DialogResult answer;

            if (N.WVectorState == false) {
                MessageBox.Show("весовые коэффициенты не загружены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            try {
                format = N.DetermineFileFormat(TestFilePath.Text);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;
            }
            this.Cursor = Cursors.Default;
            answer = MessageBox.Show("Мы посовещались и решили: это " + format + "\nЭто действительно так?", "Определить формат", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) {
                answer = MessageBox.Show("Добавить данные этого файла для обучения?", "Определить формат", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes) {
                    this.Cursor = Cursors.WaitCursor;
                    try {
                        N.CreateInputVector(TestFilePath.Text, !format.Equals("PDF"));
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.Cursor = Cursors.Default;
                }
            }
        }
    }
}
