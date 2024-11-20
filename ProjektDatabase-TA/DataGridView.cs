using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjektDatabase_TA
{
    public partial class DataGridView : Form
    {
        Login login;
        CompleteEntry CE;
        int id;
        Tables Tables;

        public DataGridView()
        {
            InitializeComponent();
        }
        public DataGridView(Login login, CompleteEntry CE, int id, Tables t)
        {
            this.login = login;
            this.CE = CE;
            this.id = id;
            InitializeComponent();
            Tables = t;
            this.Text = Tables.Get_Name;
            SetupGrid();
            LoadingGrid(login.database.DataGridViews(t));
        }

        public DataGridView(Login login, Tables t)
        {
            this.login = login;
            InitializeComponent();
            Tables = t;
            this.Text = Tables.Get_Name;
            SetupGrid();
            LoadingGrid(login.database.DataGridViews(t));
        }


        private void Grid_Load(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (CE != null)
            {
                try
                {
                    CE.BoxFormsTextboxs[id].Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString();
                    this.Close();
                }
                catch (Exception h)
                {
                    Console.WriteLine(h.ToString());
                }
            }
        }

        
        public void SetupGrid()
        {
            //Zde se k atributum nacita nazev(v app a databazi)(sloupec)
            for (int i = 0; i < Tables.AtributtesCount; i++)
                dataGridView1.Columns.Add(Tables.Get_Atribut(i).Get_NameD, Tables.Get_Atribut(i).Get_Name);
        }

        //Slouzi k nacitani dat do datagridu...
        public void LoadingGrid(List<object> li)
        {
            object[] login = new object[Tables.AtributtesCount];

            int j = 0;
            foreach (object o in li)
            {
                login[j] = o;
                //Zde se detekuje konec radku + zacatek dalsiho
                if (j == Tables.AtributtesCount - 1)
                {
                    dataGridView1.Rows.Add(login);
                    j = 0;
                }
                else
                    j++;
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
