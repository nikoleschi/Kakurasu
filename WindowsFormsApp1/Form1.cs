using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        int[,] game = new int[5,5];
        int[] column = new int[5];
        int[] row = new int[5];
        int[] btncol = new int[5];
        int[] btnrow = new int[5];
        int  ms10 = 0, s01 = 0, s10 = 0, m = 0;
        double ms01 = 0;
        bool start = false;
        public Form1()
        {
            InitializeComponent();
        }
        Random r = new Random();
        int rand()
        {
            return r.Next() % 5;
        }
        void igra()
        {
            int sqrow, n, sumarow, sumacol;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++) game[i, j] = 0;
                btncol[i] = 0;
                btnrow[i] = 0;
            }
            for (int i = 0; i < 5; i++)
            {
                sqrow = rand() + 1;
                while (sqrow > 0)
                {
                    do n = rand();
                    while (game[i, n] == 1);
                    game[i, n] = 1; sqrow--;
                }
            }
            for(int i = 0; i < 5; i++)
            {
                sumacol = 0; sumarow = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (game[i, j] == 1) sumacol = sumacol + j + 1;
                    if (game[j, i] == 1) sumarow = sumarow + j + 1;
                }
                row[i] = sumarow;
                column[i] = sumacol;
            }
            label15.Text = column[0].ToString(); label15.Visible = true;
            label14.Text = column[1].ToString(); label14.Visible = true;
            label13.Text = column[2].ToString(); label13.Visible = true;
            label12.Text = column[3].ToString(); label12.Visible = true;
            label11.Text = column[4].ToString(); label11.Visible = true;
            label20.Text = row[0].ToString(); label20.Visible = true;
            label19.Text = row[1].ToString(); label19.Visible = true;
            label18.Text = row[2].ToString(); label18.Visible = true;
            label17.Text = row[3].ToString(); label17.Visible = true;
            label16.Text = row[4].ToString(); label16.Visible = true;

        }

        void clear(bool f)
        {
            try
            {
                foreach (var button in this.Controls.OfType<Button>())
                {
                    if (button.BackColor == Color.Black) button.BackColor = Color.White;
                    button.Enabled = f;
                    button.Image = null;
                    button.Refresh();
                }
            }
            catch { }
        }
        void timer()
        {
            label21.Text = Math.Round(ms01, MidpointRounding.ToEven).ToString();
            label22.Text = ms10.ToString();
            label24.Text = s01.ToString();
            label25.Text = s10.ToString();
            label27.Text = m.ToString();
        }

        private void Button26_Click(object sender, EventArgs e)
        {
            if (start == false)
            {
                igra();
                start = true;
                button26.Text = "Готово";
                timer1.Enabled = true;
                try
                {
                    foreach (var button in this.Controls.OfType<Button>())
                    {
                        button.Enabled = true; 
                    }
                }
                catch { }
                if (броячЗаОставащиToolStripMenuItem.Checked == true) { ost(); broyachi(true); }
                else if (броячЗаНаправениToolStripMenuItem.Checked == true) { napr(); broyachi(true); }
                опцииToolStripMenuItem.Enabled = true;
            }
            else
                if (Enumerable.SequenceEqual(column, btncol) == true && Enumerable.SequenceEqual(row, btnrow) == true)
            {
                timer1.Enabled = false;
                MessageBox.Show("Поздравления !");
                try
                {
                    foreach (var button in this.Controls.OfType<Button>())
                    {
                        button.Enabled = false;
                    }
                }
                catch { }
            }
            else MessageBox.Show("Имате грешки");
            label1.Focus();
        }

        private void ПравилаToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Какурасу се играе на правоъгълна решетка. Някои клетки трябва да са черни по следните правила: " +
                "\n1. Сумата от всички чирни клетки на всеки ред трябва да отговаря на числото в дясно от реда." +
                "\n2. Сумата от всички чирни клетки на всяка колона трябва да отговаря на числото под колоната." +
                "\n3. Ако черна клетка е първа на реда/колоната нейната стойност е 1. Ако е втора стойността и е 2 и т.н.", "Правила");
        }

        private void ПравилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button27_Click(object sender, EventArgs e)
        {
            clear(true);
            for (int i = 0; i < 5; i++)
            {
                btncol[i] = 0;
                btnrow[i] = 0;
            }
            if (броячЗаОставащиToolStripMenuItem.Checked == true) ost();
            else if (броячЗаНаправениToolStripMenuItem.Checked == true) napr();
            label1.Focus();
        }

        private void Button28_Click(object sender, EventArgs e)
        {
            clear(true);
            for (int i = 0; i < 5; i++)
                for(int j = 0; j < 5; j++)
                    if(game[i,j] == 1)
                    {
                        try
                        {
                            foreach (var button in this.Controls.OfType<Button>())
                            {
                                if (button.TabIndex == i * 5 + j + 1) button.BackColor = Color.Black;
                                button.Enabled = false;
                            }
                        }
                        catch { }
                    }
            for(int i = 0; i < 5; i++)
            {
                btncol[i] = column[i];
                btnrow[i] = row[i];
            }

            timer1.Enabled = false;
            if (броячЗаОставащиToolStripMenuItem.Checked == true) ost();
            else if (броячЗаНаправениToolStripMenuItem.Checked == true) napr();
        }

        void broyachi(bool f)
        {
            label26.Visible = f; 
            label29.Visible = f;
            label31.Visible = f;
            label30.Visible = f;
            label32.Visible = f;
            label33.Visible = f;
            label34.Visible = f;
            label35.Visible = f;
            label36.Visible = f;
            label37.Visible = f;
        }

        void ost()
        {
            label26.Text = (column[0] - btncol[0]).ToString();
            label29.Text = (column[1] - btncol[1]).ToString();
            label31.Text = (column[2] - btncol[2]).ToString();
            label30.Text = (column[3] - btncol[3]).ToString();
            label32.Text = (column[4] - btncol[4]).ToString();
            label37.Text = (row[0] - btnrow[0]).ToString();
            label35.Text = (row[1] - btnrow[1]).ToString();
            label36.Text = (row[2] - btnrow[2]).ToString();
            label34.Text = (row[3] - btnrow[3]).ToString();
            label33.Text = (row[4] - btnrow[4]).ToString();
        }

        void napr()
        {
            label26.Text = btncol[0].ToString();
            label29.Text = btncol[1].ToString();
            label31.Text = btncol[2].ToString();
            label30.Text = btncol[3].ToString();
            label32.Text = btncol[4].ToString();
            label37.Text = btnrow[0].ToString();
            label35.Text = btnrow[1].ToString();
            label36.Text = btnrow[2].ToString();
            label34.Text = btnrow[3].ToString();
            label33.Text = btnrow[4].ToString();
        }

        private void БроячЗаОставащиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            броячЗаОставащиToolStripMenuItem.Checked = true;
            броячЗаНаправениToolStripMenuItem.Checked = false;
            изключенБроячToolStripMenuItem.Checked = false;
            broyachi(true); ost();
            
        }

        private void БроячЗаНаправениToolStripMenuItem_Click(object sender, EventArgs e)
        {
            броячЗаОставащиToolStripMenuItem.Checked = false;
            броячЗаНаправениToolStripMenuItem.Checked = true;
            изключенБроячToolStripMenuItem.Checked = false;
            broyachi(true); napr();
        }

        private void ИзключенБроячToolStripMenuItem_Click(object sender, EventArgs e)
        {
            броячЗаОставащиToolStripMenuItem.Checked = false;
            броячЗаНаправениToolStripMenuItem.Checked = false;
            изключенБроячToolStripMenuItem.Checked = true;
            broyachi(false);
        }

        private void Button_Click(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            if (e.Button == MouseButtons.Right)
            {
                b.Image = Properties.Resources.Screenshot_2;
            }
            else
            {
                b.Image = null;
                b.Refresh();
                if (b.BackColor != Color.Black)
                {
                    b.BackColor = Color.Black;
                    btncol[(b.TabIndex - 1) / 5] = btncol[(b.TabIndex - 1) / 5] + ((b.TabIndex - 1) % 5) + 1;
                    btnrow[(b.TabIndex - 1) % 5] = btnrow[(b.TabIndex - 1) % 5] + ((b.TabIndex - 1) / 5) + 1;
                }
                else
                {
                    b.BackColor = Color.White;
                    btncol[(b.TabIndex - 1) / 5] = btncol[(b.TabIndex - 1) / 5] - ((b.TabIndex - 1) % 5) - 1;
                    btnrow[(b.TabIndex - 1) % 5] = btnrow[(b.TabIndex - 1) % 5] - ((b.TabIndex - 1) / 5) - 1;
                }
            }
            if (броячЗаОставащиToolStripMenuItem.Checked == true) ost();
            else if (броячЗаНаправениToolStripMenuItem.Checked == true) napr();
            label1.Focus();
        }

        private void ОтносноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Направено от Никола Красимиров Михайлов.", "Какурасу");
        }

        private void НоваИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label15.Visible = false;
            label14.Visible = false;
            label13.Visible = false;
            label12.Visible = false;
            label11.Visible = false;
            label20.Visible = false;
            label19.Visible = false;
            label18.Visible = false;
            label17.Visible = false;
            label16.Visible = false;
            clear(false);
            start = false;
            timer1.Enabled = false;
            button26.Text = "Старт"; button26.Enabled = true;
            ms01 = 0; ms10 = 0; s01 = 0; s10 = 0; m = 0; timer();
            button27.Enabled = false;
            button28.Enabled = false;
            broyachi(false);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ms01= ms01 + 1.66;
            if(ms01 >= 9.7)
            {
                ms01 = 0;
                ms10++;
            }
            if(ms10 == 10)
            {
                ms10 = 0;
                s01++;
            }
            if(s01 == 10)
            {
                s01 = 0;
                s10++;
            }
            if(s10 == 6)
            {
                s10 = 0;
                m++;
            }
            timer();
        }
    }
}
