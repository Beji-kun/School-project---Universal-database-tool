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
    public partial class ChooseOperations : Form
    {
        Login login;
        System.Windows.Forms.GroupBox GroupBox;
        System.Windows.Forms.Button[] Button;
        int operation;

        public ChooseOperations(Login form)
        {
            InitializeComponent();
            login = form;
            Button = new System.Windows.Forms.Button[0];
            operation = 0;
        }

        //vyrovnani formu
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Left = login.DesktopLocation.X + login.Width + 10;
            this.Top = login.DesktopLocation.Y + login.Height - Height;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }      

        private void button5_Click(object sender, System.EventArgs e)
        {
            try
            {
                login.database.CloseConnection();
                login.Label4Text("Disconnected");
                this.Close();
            }
            catch (Exception)
            {
                login.Label4Text("Fail connection...");
            }
        }

        public void set_choose_Tables(String operation)
        {

            //obnoveni / promazani starych buttnu
            if (Button.Length > 0)
            {
                for (int i = 0; i < Button.Length; i++)
                {
                    if (Controls.Contains(Button[i]))
                        Controls.Remove(Button[i]);
                }
            }

            //obnoveni / promazani groupboxu
            if (Controls.Contains(GroupBox))
                Controls.Remove(GroupBox);


            //z designeru
            GroupBox = new System.Windows.Forms.GroupBox();
            Button = new System.Windows.Forms.Button[login.database.TableCount];

            //z designeru
            GroupBox.SuspendLayout();
            SuspendLayout();

            //vygenerovani buttnu podle tabulek
            for (int i = 0; i < login.database.TableCount; i++)
            {
                Button[i] = new System.Windows.Forms.Button();
                Button[i].Location = new System.Drawing.Point(6, 19 + i * 29);
                Button[i].Name = "123456789" + i;
                Button[i].Size = new System.Drawing.Size(75, 23);
                Button[i].TabIndex = 8 + i;
                Button[i].Text = login.database.TableNames()[i];
                Button[i].UseVisualStyleBackColor = true;
                Button[i].Visible = true;
                Button[i].Click += new System.EventHandler(Choose_Tables);
                GroupBox.Controls.Add(Button[i]);
            }

            //nastaveni groupboxu
            GroupBox.Location = new System.Drawing.Point(43, 30);
            GroupBox.Name = "336";
            GroupBox.Size = new System.Drawing.Size(88, 19 + 29 * login.database.TableCount + 6);
            GroupBox.TabIndex = 7;
            GroupBox.TabStop = false;
            GroupBox.Text = operation;
            Controls.Add(GroupBox);

            GroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        //vybrani odpovidajiciho prvku/formy podle operace
        private void Choose_Tables(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            if (operation == 0)
            {
                //slouzi k zobrazeni datagridu pokud by bylo false tak se datagrid nezobrazi
                DataGridView f5 = new DataGridView(login, login.database.Get_Tables(but.TabIndex - 8));
                f5.Visible = true;
            }
            else
            {
                //slouzi k zobrazeni formu kde se vygenerovaji textboxy,a dalsi veci 
                CompleteEntry CE = new CompleteEntry(login, operation, (but.TabIndex - 8), GroupBox.Text + " " + login.database.TableNames()[but.TabIndex - 8], this);
                CE.Visible = true;
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                login.database.CloseConnection();
                login.Label4Text("Disconnected");
                this.Close();
            }
            catch (Exception)
            {
                login.Label4Text("Fail connection...");
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operation = 0;
            set_choose_Tables("Show");
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operation = 1;
            set_choose_Tables("Add");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operation = 2;
            set_choose_Tables("Edit");
        }

        private void earseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operation = 3;
            set_choose_Tables("Delete");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
