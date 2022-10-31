using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulateMouseClick
{
    public partial class SubForm1 : Form
    {
        public string ClickType
        {
            set
            {
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (comboBox1.Items[i].ToString().StartsWith(value))
                    {
                        comboBox1.SelectedIndex = comboBox1.Items.IndexOf(value);
                        //comboBox1.SelectedItem = value;
                        comboBox1.SelectedText = value;
                        //comboBox1.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        public string PointPosition
        {
            get { return $"{comboBox1.Text} {textBox1.Text} {textBox2.Text}"; }
            set { textBox1.Text = value; }
        }

        public string Comment { set { textBox2.Text = value; } }

        public SubForm1()
        {
            InitializeComponent();
        }

        private void SubForm1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
