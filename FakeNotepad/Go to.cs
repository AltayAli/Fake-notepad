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
    public partial class Go_to : Form
    {
        public Go_to()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btn_goto_Click(object sender, EventArgs e)
        {
            Notepad_Tools nt = new Notepad_Tools();
            if(int.TryParse(txbx_linenumber.Text,out int rs))
            nt.GoToLine(Convert.ToInt32(txbx_linenumber.Text));

            this.Close();
        }
    }
}
