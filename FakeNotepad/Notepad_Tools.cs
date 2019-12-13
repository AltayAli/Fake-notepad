using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeNotepad
{
    public class Notepad_Tools
    {
        public static Form MainForm { get; set; }
        public static RichTextBox TextArea { get; set; }
        public static StringBuilder Buffer { get; set; }
        public static Panel StatusBar { get; set; }
        public string FileName { get; set; }
        public int TextLength { get; set; }
        public static string InputText { get; set; } = String.Empty;
        public string searchingWord { get; set; } = String.Empty;
        private int count { get; set; } = 0;
        private int index { get; set; } = 0;
        public bool isUp { get; set; } = true;
        public bool isShowStatusbar { get; set; } = false;
        private int removalIndex { get; set; }
        public bool isWrap { get; set; }
        List<int> indexes ;
        FontDialog font { get; set; }
        static Notepad_Tools()
        {
            Buffer = new StringBuilder();
        }
        public Notepad_Tools()
        {
            indexes = new List<int>();
        }
        public void SaveFile()
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream stream = File.Open(savedialog.FileName + ".txt", FileMode.CreateNew))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        
                        writer.Write(TextArea.Text);
                        FileName=savedialog.FileName+".txt";
                        MainForm.Text = FileName;
                    }
                }
            }
        }
        public void OpenFile()
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                using (Stream reader = File.OpenRead(open.FileName))
                {
                    FileName = open.FileName;
                    using (StreamReader sm = new StreamReader(reader))
                    {
                        TextArea.Text = sm.ReadToEnd();
                        TextLength = TextArea.Text.Length;
                        MainForm.Text = FileName;
                    }
                }
            }
        }
        public void WhenSaveFile()
        {
            File.WriteAllText(FileName, TextArea.Text);
            TextLength = TextArea.Text.Length;
        }
        public bool isfileExist()
        {
            if(FileName!=null)
                 return File.Exists(FileName);

            return false;
        }
        
        public void Cut()
        {
            Copy();
            Delete();
        }
        public void Copy()
        {
            Buffer.Clear();
            Buffer.Append(TextArea.SelectedText);
        }
        public void Paste()
        {
            if (TextArea.SelectionStart < TextArea.Text.Length - 1)
            {
                List<string> mytext = new List<string>();
                mytext.Add(TextArea.Text.Substring(0, TextArea.Text.Length - TextArea.SelectionStart - 1));
                mytext.Add(Buffer.ToString());
                mytext.Add(TextArea.Text.Substring(TextArea.SelectionStart - 1));
                TextArea.Clear();
                foreach (var item in mytext)
                {
                    TextArea.Text += item;
                }
            }
            else
            {
                TextArea.Text += Buffer.ToString();
            }

            TextArea.SelectionStart = TextArea.Text.Length;

        }
        public void Delete()
        {
            int index = TextArea.Text.IndexOf(TextArea.SelectedText);
            TextArea.Text = TextArea.Text.Remove(index, TextArea.SelectedText.Length);
            TextArea.SelectionStart = index;
        }

        public void SelectAll()
        {
           TextArea.SelectAll();
        }

        public void KeyDown()
        {

        }
        public void FindWord()
        {
            if (isUp)
            {
                count++;
                if (count > indexes.Count - 1)
                {
                    count = 0;
                }

            }
            else
            {
                count--;
                if (count < 0)
                {
                    count = indexes.Count - 1;
                }
            }

            TextArea.Select(indexes[count], searchingWord.Length);
            removalIndex = indexes[count];
            index = indexes[count] + searchingWord.Length;
        }
        private bool indexIsHere(List<int> indexes, int a)
        {
            bool isTrue = false;
            foreach (var index in indexes)
            {
                if (index == a)
                {
                    isTrue = true;
                }
            }
            return isTrue;
        }

        public void TextChanged(TextBox textBox)
        {
            searchingWord = textBox.Text;
            InputText = searchingWord;
            if (indexes.Count > 0)
            {
                indexes.Clear();
            }
            if (TextArea.Text.Contains(searchingWord))
            {

                for (int i = 0; i < TextArea.Text.Length; i++)
                {
                    int a = TextArea.Text.IndexOf(searchingWord, i);
                    if (!indexIsHere(indexes, a) && a != -1)
                    {
                        indexes.Add(a);
                    }
                }
                if (isUp)
                {
                    index = indexes[indexes.Count - 1];
                }
                else
                {
                    index = 0;
                }
            }
            
        }
        public void Replace(string newWord)
        {
           // FindWord();
            List<string> mytext = new List<string>();
            int length = TextArea.SelectedText.Length;
            mytext.Add(TextArea.Text.Substring(0, removalIndex));
            mytext.Add(newWord);
            mytext.Add(TextArea.Text.Substring(removalIndex + length ));
            TextArea.Clear();
            foreach (var item in mytext)
            {
                TextArea.Text += item;
            }
            
        }
        public void ReplaceAll(string newWord)
        {
            TextArea.Text = TextArea.Text.Replace(searchingWord, newWord);
        }
        public void GoToLine(int lineNumber)
        {
            string[] allLines = TextArea.Lines;
            if (lineNumber <= 0)
            {
                TextArea.SelectionStart = TextArea.GetFirstCharIndexFromLine(0);
            }else if (lineNumber > allLines.Length)
            {
                TextArea.SelectionStart = TextArea.GetFirstCharIndexFromLine(Convert.ToInt32(allLines.Length-1));
            }
            else
            {
                TextArea.SelectionStart = TextArea.GetFirstCharIndexFromLine(lineNumber-1);
            }
           
        }
        public void ShowDateTime()
        {
            List<string> mytext = new List<string>();
            mytext.Add(TextArea.Text.Substring(0, TextArea.SelectionStart));
            mytext.Add(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            mytext.Add(TextArea.Text.Substring(TextArea.SelectionStart));
            TextArea.Clear();
            foreach (var item in mytext)
            {
                TextArea.Text += item;
            }

        }

        public void WrapWord()
        {
            if (isWrap)
            {
                TextArea.WordWrap = true;
                TextArea.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            }else
            {
                TextArea.WordWrap = false;
                TextArea.ScrollBars = RichTextBoxScrollBars.Both;
            }
        }

        public void ApplyFonts()
        {
            font = new FontDialog();
            DialogResult result = font.ShowDialog();
            if (result== DialogResult.OK)
            {
                TextArea.SelectionFont = font.Font;
            }
        }

        public void ShowStatusBar()
        {
            if (isShowStatusbar)
            {
                StatusBar.Visible = true;
            }
            else
            {
                StatusBar.Visible = false;

            }
        }
        public string Status()
        {
            int s = TextArea.SelectionStart;
            int y = TextArea.GetLineFromCharIndex(s);
            int x = s - TextArea.GetFirstCharIndexFromLine(y);
            return $"Ln {y+1}, Col{x+1}";
        }

        public  void Print(PrintPreviewDialog print,PrintDocument document)
        {
            print.Document = document;
            if (print.ShowDialog() == DialogResult.OK)
            {
                document.Print();
            }
        }

        public string getTextareaText()
        {
            return TextArea.Text;
        }
        public Font getTextAreaFont()
        {
            return font.Font;
        }
      
    }
}
