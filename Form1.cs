using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MiniWord_Phap
{
    public partial class Form1 : Form
    {
        string fileName;


        public Form1()
        {
            InitializeComponent();

            Load();
        }

        void Load()
        {
            Font newFont = new Font("Times New Romance", (int)numericUpDown1.Value, FontStyle.Regular); 
        }

        //Close
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rtxbWord.Modified)
            {
                if (MessageBox.Show("Bạn có muốn lưu tập tin đang soạn thảo hay không?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                }
            }
        }
        //Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Font
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = rtxbWord.Font;
            if(fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rtxbWord.Font = fontDialog1.Font;
            }
        }
        //SaveAsFile
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(fileName, rtxbWord.Text);
                this.Text = fileName;
            }
        }
        //SaveFile
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fileName == null)
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
            else
            {
                System.IO.File.WriteAllText(fileName, rtxbWord.Text);
                this.Text = "MiniWord - " + fileName;
            }
        }
        private void SaveIcon_Click(object sender, EventArgs e)
        {
            if (fileName == null)
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
            else
            {
                System.IO.File.WriteAllText(fileName, rtxbWord.Text);
                this.Text = "MiniWord - " + fileName;
            }
        }

        //OpenFile
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtxbWord.Modified)
            {
                if(MessageBox.Show("Bạn có muốn lưu tập tin đang soạn thảo hay không?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                }    
            }
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                fileName = openFileDialog1.FileName;
                rtxbWord.Text = System.IO.File.ReadAllText(fileName);
                this.Text = "MiniWord - " + fileName;
            }
        }
        //NewFile
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtxbWord.Modified)
            {
                if (MessageBox.Show("Bạn có muốn lưu tập tin đang soạn thảo hay không?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                }
            }
            rtxbWord.Text = "";
            this.Text = "MiniWord - ";
        }
        //Cut
        public void CutTex()
        {
            rtxbWord.Cut();
        }
        //Copy
        public void CopyTex()
        {
            rtxbWord.Copy();
        }
        //Paste
        public void PasteTex()
        {
            rtxbWord.Paste();
        }
        //SelectAll
        public void SelectAll()
        {
            rtxbWord.SelectAll();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CutTex();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyTex();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteTex();
        }

        private void rtxbWord_TextChanged(object sender, EventArgs e)
        {
            if (rtxbWord.Modified)
            {
                this.Text = "MiniWord - " + fileName + "*";
            }

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CutTex();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CopyTex();
        }

        private void paseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteTex();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        void TexNormal(RichTextBox rtxb)
        {
            Font newFont = new Font(rtxb.SelectionFont.FontFamily.Name, rtxb.SelectionFont.Size, FontStyle.Regular);
            rtxb.SelectionFont = newFont;
        }

        private void BoldTex_Click(object sender, EventArgs e)
        {
            if (BoldTex.Checked)
            {
                BoldTex.BackColor = Color.Gray;
                ItalicTex.BackColor = Color.White;
                UnderlinedTex.BackColor = Color.White;
                Tex_BlodItalic.BackColor = Color.White;
                TexBold(rtxbWord);
            }
            else
            {
                BoldTex.BackColor = Color.White;
                TexNormal(rtxbWord);
            }

        }

        void TexBold(RichTextBox rtxb)
        {
            Font newFont = new Font(rtxb.SelectionFont.FontFamily.Name, rtxb.SelectionFont.Size, FontStyle.Bold);
            rtxb.SelectionFont = newFont;
        }

        private void ItalicTex_Click(object sender, EventArgs e)
        {
            if (ItalicTex.Checked)
            {
                BoldTex.BackColor = Color.White;
                UnderlinedTex.BackColor = Color.White;
                Tex_BlodItalic.BackColor = Color.White;
                ItalicTex.BackColor = Color.Gray;
                TexItalic(rtxbWord);
            }
            else
            {
                ItalicTex.BackColor = Color.White;
                TexNormal(rtxbWord);
            }
        }

        void TexItalic(RichTextBox rtxb)
        {
            Font newFont = new Font(rtxb.SelectionFont.FontFamily.Name, rtxb.SelectionFont.Size, FontStyle.Italic);
            rtxb.SelectionFont = newFont;
        }

        private void UnderlinedTex_Click(object sender, EventArgs e)
        {
            if (UnderlinedTex.Checked)
            {
                Tex_BlodItalic.BackColor = Color.White;
                BoldTex.BackColor = Color.White;
                ItalicTex.BackColor = Color.White;
                UnderlinedTex.BackColor = Color.Gray;
                TexUnderlined(rtxbWord);
            }
            else
            {
                UnderlinedTex.BackColor = Color.White;
                TexNormal(rtxbWord);
            }
        }

        void TexUnderlined(RichTextBox rtxb)
        {
            Font newFont = new Font(rtxb.SelectionFont.FontFamily.Name, rtxb.SelectionFont.Size, FontStyle.Underline);
            rtxb.SelectionFont = newFont;
        }

        private void Tex_BlodItalic_Click(object sender, EventArgs e)
        {
            if (Tex_BlodItalic.Checked)
            {
                BoldTex.BackColor = Color.White;
                ItalicTex.BackColor = Color.White;
                UnderlinedTex.BackColor = Color.White;
                Tex_BlodItalic.BackColor = Color.Gray;
                Tex_ItalicBold(rtxbWord);
            }
            else
            {
                Tex_BlodItalic.BackColor = Color.White;
                TexNormal(rtxbWord);
            }
        }

        void Tex_ItalicBold(RichTextBox rtxb)
        {
            Font newFont = new Font(rtxb.SelectionFont.FontFamily.Name, rtxb.SelectionFont.Size, FontStyle.Bold | FontStyle.Italic);
            rtxb.SelectionFont = newFont;
        }

        private void undoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            rtxbWord.Undo();
        }

        private void UndoIcon_Click_1(object sender, EventArgs e)
        {
            rtxbWord.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxbWord.Redo();
        }

        private void RedoIcon_Click(object sender, EventArgs e)
        {
            rtxbWord.Redo();
        }

        void ChangeSize(RichTextBox rtxb, int size)
        {
            Font newFont = new Font(rtxb.SelectionFont.FontFamily.Name, size, rtxbWord.SelectionFont.Style);
            rtxb.SelectionFont = newFont;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ChangeSize(rtxbWord, (int)numericUpDown1.Value);
        }

        private void TexColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog(); //Khởi tạo đối tượng ColorDialog 
            dlg.ShowDialog(); //Hiển thị hộp thoại

            if (dlg.ShowDialog() == DialogResult.OK) //Nếu nhấp vào nút OK trên hộp thoại
            {
                TexColor.BackColor = dlg.Color;
                rtxbWord.SelectionColor = dlg.Color;
            }
        }

        private void ColorBackGR_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ColorBackGR.BackColor = dlg.Color;
                rtxbWord.SelectionBackColor = dlg.Color;
            }
        }

        private void displayImage(string name)
        {
            Clipboard.SetImage(Image.FromFile(name));

            rtxbWord.Paste();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.png; *.bmp)|*.jpg; *.jpeg; *.gif; *.png; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                displayImage(open.FileName);
            }
        }
    }
}
