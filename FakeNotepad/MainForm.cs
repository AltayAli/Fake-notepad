using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeNotepad
{
    public partial class MainForm : Form
    {


        Notepad_Tools tools;
        public MainForm()
        {
            InitializeComponent();
            tools = new Notepad_Tools();
            Notepad_Tools.MainForm = this;
            Notepad_Tools.TextArea = this.richTextBox1;
            Notepad_Tools.StatusBar = this.panel1;
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tools.SaveFile();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tools.isfileExist())
            {
                tools.WhenSaveFile();
            }
            else
            {
                tools.SaveFile();
            }
           
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0&&tools.TextLength < richTextBox1.Text.Length)
            {
                DialogResult result= MessageBox.Show("Do you what to save changes to Untitled?", "FakeNotePad", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                   tools.SaveFile();
                }
                else if(result==DialogResult.No)
                {
                    this.Text = "Untitled.txt";
                    richTextBox1.Clear();
                }
              
            }
            else
            {
                richTextBox1.Clear();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tools.OpenFile();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            tools.KeyDown();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tools.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tools.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tools.Paste();
        }

     

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tools.Delete();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm findForm = new FindForm();
            findForm.Show();
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm findForm = new FindForm();
            findForm.Show();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplaceForm rf = new ReplaceForm();
            rf.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Go_to gt = new Go_to();
            gt.Show();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tools.SelectAll();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tools.ShowDateTime();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tools.isWrap)
            {
                tools.isWrap = false;
                tools.WrapWord();
            }
            else
            {
                tools.isWrap = true;
                tools.WrapWord();
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tools.ApplyFonts();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            lbl_status.Text = tools.Status();
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tools.isShowStatusbar)
            {
                tools.isShowStatusbar = false;
                statusBarToolStripMenuItem.Checked = true;
                tools.ShowStatusBar();
            }
            else
            {
                tools.isShowStatusbar = true;

                statusBarToolStripMenuItem.Checked = false;
                tools.ShowStatusBar();
            }
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(viewHelpToolStripMenuItem.Tag.ToString());
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            e.Graphics.DrawString(tools.getTextareaText(),tools.getTextAreaFont(), Brushes.Black, new Point(100, 100));
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tools.Print(printPreviewDialog1,printDocument1);
        }
    }
}
