using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AI_02 {
    public partial class Form1 : Form {

        Game G;
        Thread T;
        byte[] state;
        Label[] field;

        public Form1() {
            InitializeComponent();
            this.Cursor = Cursors.AppStarting;

            field = new Label[9];
            field[0] = cell0; field[1] = cell1; field[2] = cell2;
            field[3] = cell3; field[4] = cell4; field[5] = cell5;
            field[6] = cell6; field[7] = cell7; field[8] = cell8;

            G = new Game();
            T = new Thread(new ThreadStart(G.BuildGraph));
            progressBar1.Minimum = 0;
            progressBar1.Maximum = G.TotalCombinations;
            T.Start();
            timer1.Start();
        }

        private void ApplyState() {
            for (int i = 0; i < field.Length; i++) {
                if (state[i] != 0) {
                    field[i].Text = state[i].ToString();
                } else {
                    field[i].Text = " ";
                }
            }
        }

        private void NewGame() {
            state = G.New();
            ApplyState();
            timer2.Stop();
            button1.Visible = false;
            gameField.Enabled = true;
            решитьToolStripMenuItem.Enabled = true;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) {
            if (T.IsAlive) {
                T.Abort();
                T.Join();
            }
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            progressBar1.Value = G.NodesGenerated;
            if (G.NodesGenerated >= G.TotalCombinations) {
                timer1.Stop();
                T.Join();
                progressBar1.Visible = false;
                gameField.Visible = true;
                новаяИграToolStripMenuItem.Enabled = true;
                решитьToolStripMenuItem.Enabled = true;
                NewGame();
                this.Cursor = Cursors.Default;
            }
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e) {
            NewGame();
        }

        private void cell_Click(object sender, EventArgs e) {
            Label lbl = (Label)sender;
            int cell = Convert.ToInt32(lbl.Tag);
            int crow = cell / 3;
            int ccol = cell % 3;
            int free = Array.IndexOf(state, (byte)0);
            int frow = free / 3;
            int fcol = free % 3;

            // пользователь передвинуть клетку index на место свободной
            // надо проверить, можно ли это сделать
            if (frow == crow) {
                // строки совпали, проверим клетки на смежность
                if ((ccol == fcol - 1) || (ccol == fcol + 1)) {
                    state[free] = state[cell];
                    state[cell] = 0;
                    ApplyState();
                }
            } else if (fcol == ccol) {
                // столбцы совпали, проверим клетки на смежность
                if ((crow == frow - 1) || (crow == frow + 1)) {
                    state[free] = state[cell];
                    state[cell] = 0;
                    ApplyState();
                }
            }
            if (G.haveWon(state) == true) {
                MessageBox.Show("Вы выиграли!", "Восьмерки");
                gameField.Enabled = false;
                решитьToolStripMenuItem.Enabled = false;
            }
        }

        private void решитьToolStripMenuItem_Click(object sender, EventArgs e) {
            button1.Visible = true;
            timer2.Start();
        }

        private void stepUp() {
            byte[] nstate = null;
            try {
                nstate = G.stepUp(state);
            }
            catch (Exception ex) {
                timer2.Stop(); button1.Visible = false;
                MessageBox.Show(ex.Message, "Ошибка");
            }
            if (nstate == null) {
                if (G.haveWon(state) == true) {
                    timer2.Stop(); button1.Visible = false;
                    MessageBox.Show("Готово", "Восьмерки");
                    gameField.Enabled = false;
                    решитьToolStripMenuItem.Enabled = false;
                } else {
                    timer2.Stop(); button1.Visible = false;
                    MessageBox.Show("Возвращено пустое родительское состояние", "Ошибка");
                }
            } else {
                state = nstate;
                ApplyState();
            }
        }

        private void timer2_Tick(object sender, EventArgs e) {
            stepUp();
        }

        private void button1_Click(object sender, EventArgs e) {
            timer2.Stop();
            ((Button)sender).Visible = false;
        }
    }
}
