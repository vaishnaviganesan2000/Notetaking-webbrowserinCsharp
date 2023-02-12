using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Reproj
{
    public partial class Notetaker : Form
    {
        
        DataTable notes = new DataTable();
        bool editing = false;
        public Notetaker()
        {
            InitializeComponent();
        }
        private void Notetaker_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            previousNotes.DataSource = notes;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
           if(editing)
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = titlebox.Text;
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Note"] = notebox.Text;

            }
            else
            {
                notes.Rows.Add(titlebox.Text,notebox.Text);
            }
            titlebox.Text = "";
            notebox.Text = "";
            editing = false;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();
            }
            catch
            {
                Exception ex = new Exception();
                Console.WriteLine("Not A Valid Note");
            }
        }

        private void NewNoteButton_Click(object sender, EventArgs e)
        {
            titlebox.Text = "";
            notebox.Text = "";
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            titlebox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            notebox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing= true;
        }

        private void previousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titlebox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            notebox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void clocktimer_Tick(object sender, EventArgs e)
        {
            clocklabel2.Text = DateTime.Now.ToString("dddd,dd MMMM yyyy");
            clocklabel.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void clocklabel_Click(object sender, EventArgs e)
        {
            clocktimer.Start();
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            titlebox.ForeColor = Color.Red;
            notebox.ForeColor = Color.Red;
           



        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            titlebox.ForeColor = Color.Green;
            notebox.ForeColor = Color.Green;
            

        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            titlebox.ForeColor = Color.Blue;
            notebox.ForeColor = Color.Blue;
           

        }

        private void styleButton1_Click(object sender, EventArgs e)
        {
            titlebox.Font = new Font("Times New Roman", 9, FontStyle.Regular);
            notebox.Font = new Font("Times New Roman", 9, FontStyle.Regular);

        }

        private void styleButton2_Click(object sender, EventArgs e)
        {
            titlebox.Font = new Font("Tahoma", 9, FontStyle.Bold);
            notebox.Font = new Font("Tahoma", 9, FontStyle.Bold);
           
        }

        private void blackButton_Click(object sender, EventArgs e)
        {
            titlebox.ForeColor = Color.Black;
            notebox.ForeColor = Color.Black;
           

        }

        public static void Search(string Query)
        {
            Process.Start("https://www.bing.com/search?q=" + Query);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search(textBox2.Text);
        }

        
    }
}
