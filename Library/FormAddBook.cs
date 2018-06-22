using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class FormAddBook : Form
    {

        private string author;
        private string title;
        private string genre;
        private string price;
        private string date;
        private string description;
        private static int index = 100;

        public FormAddBook()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(author != null && title != null && genre != null && price !=null && date != null && description != null)
            {
                double doublePrice;
                bool isValid = double.TryParse(price, out doublePrice);
                if (isValid)
                {
                    DataRow dr = FormAllBooks.dataSet.Tables["book"].NewRow();
                    dr["id"] = index++;
                    dr["author"] = author;
                    dr["title"] = title;
                    dr["genre"] = genre;
                    dr["price"] = price;
                    dr["publish_date"] = date;
                    dr["description"] = description;
                    FormAllBooks.dataSet.Tables["book"].Rows.Add(dr);
                    this.Dispose();
                }
                else
                {
                    labelError.Text = "Cena musi być liczbą";
                }
            }
            else
            {
                labelError.Text = "Niepoprawne dane";
            }
        }

        private void textBoxAuthor_TextChanged(object sender, EventArgs e)
        {
            author = textBoxAuthor.Text;
        }

        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {
            title = textBoxTitle.Text;
        }

        private void textBoxGenre_TextChanged(object sender, EventArgs e)
        {
            genre = textBoxGenre.Text;
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            price = textBoxPrice.Text;
        }

        private void textBoxPublishDate_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            description = textBoxDescription.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }
    }
}
