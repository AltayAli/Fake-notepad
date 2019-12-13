using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeNotepad
{
    public partial class FindForm : Form
    {
        Notepad_Tools tools;
        public FindForm()
        {
            InitializeComponent();
            tools = new Notepad_Tools();
        }
        private void FindForm_Load(object sender, EventArgs e)
        {
            textBox1.Text =Notepad_Tools.InputText;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            tools.FindWord();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tools.TextChanged(this.textBox1);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tools.isUp = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tools.isUp = false;
        }

        private void FindForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Dispose();
        }
    }
}
