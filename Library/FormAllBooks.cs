using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Library
{
    public partial class FormAllBooks : Form
    {
        internal static DataSet dataSet = new DataSet();

        public DataSet DataSet { get => dataSet; set => dataSet = value; }

        public FormAllBooks()
        {
            InitializeComponent();
            LoadDataGridView();
        }

        void LoadDataGridView()
        {
            DataSet.ReadXml("../../books.xml");
            booksDataGridView.DataSource = DataSet;
            booksDataGridView.DataMember = "book";
        }

        private void FormAllBooks_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddBook newForm = new FormAddBook();
            newForm.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = booksDataGridView.CurrentCell.RowIndex;
            if(rowIndex > 0)
            {
                booksDataGridView.Rows.RemoveAt(rowIndex);
            }
        }

        private void buttonSaveAndExit_Click(object sender, EventArgs e)
        {
            DataSet = (DataSet)booksDataGridView.DataSource;
            dataSet.WriteXml("../../books.xml");
            this.Dispose();
        }
    }
}
