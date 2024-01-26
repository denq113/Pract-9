using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pract_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string name1 = Convert.ToString(f.textBox1.Text);
                int kol1 = Convert.ToInt32(f.textBox2.Text);
                double stoim1 = Convert.ToDouble(f.textBox3.Text);
                People p = new People(name1,kol1,stoim1);
                listBox1.Items.Add(p);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Обьект для удаления не выбран");
            } 
            else
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Обьект для редоктирования не выбран");
            }
            else
            {
               Form2 f = new Form2();
               People p = listBox1.Items[listBox1.SelectedIndex] as People;
               f.textBox1.Text = p.Name;
                f.textBox2.Text = p.Kol.ToString();
                f.textBox3.Text = p.Stoim.ToString();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    string skladame = f.textBox1.Text;
                    int skladkol = Convert.ToInt32(f.textBox2.Text);
                    double skladStoim = Convert.ToDouble(f.textBox3.Text);
                    p.Name = skladame;
                    p.Kol = skladkol;
                    p.Stoim = skladStoim;
                    listBox1.Items[listBox1.SelectedIndex] = p;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double sred = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                People p = listBox1.Items[i] as People;
                double g = p.Stoim;
                sred = sred + g;
            }
            sred = sred / listBox1.Items.Count;
            label2.Text = sred.ToString();
        }
    }
}
