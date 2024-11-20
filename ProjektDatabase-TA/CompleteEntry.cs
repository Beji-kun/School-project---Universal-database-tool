using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjektDatabase_TA
{
    public partial class CompleteEntry : Form
    {
        Login login;
        ChooseOperations ChooseOper;
        int operation, TablesID;
        Tables Tables;

        public System.Windows.Forms.TextBox[] BoxFormsTextboxs;
        System.Windows.Forms.Label[] NameLabel;

        public CompleteEntry(Login form, int o, int t, string Name, ChooseOperations ChooseOper)
        {
            InitializeComponent();
            this.Text = Name;
            login = form;
            this.ChooseOper = ChooseOper;
            operation = o;
            TablesID = t;

            //Generace tlacitka close
            System.Windows.Forms.Button buttonx = new System.Windows.Forms.Button();
            buttonx.Location = new System.Drawing.Point(this.Width / 2 - 37, 0);
            buttonx.Name = "buttonx";
            buttonx.Size = new System.Drawing.Size(75, 23);
            buttonx.TabIndex = 0;
            buttonx.Text = "Exit";
            buttonx.UseVisualStyleBackColor = true;
            buttonx.Visible = true;
            buttonx.Click += new System.EventHandler(Close_this);
            Controls.Add(buttonx);

            //upraveni vstupni tabulky podle operace
            //pro update se nakopiruje vsecko
            //pro insert se nakopiruje vse krome id atributu
            //pro delete se nakopiruje pouze id
            Tables = new Tables(login.database.Get_Tables(TablesID).Get_NameD, login.database.Get_Tables(TablesID).Get_Name);
            for (int i = 0; i < (operation != 3 ? login.database.Get_Tables(TablesID).AtributtesCount : 1); i++)
            {
                if (!(operation == 1 && i == 0))
                    Tables.AddAtributtes(login.database.Get_Tables(TablesID).Get_Atribut(i));
            }

            SetDesignForms();
        }

        private void Close_this(object sender, EventArgs e)
        {
            this.Close();
        }

        void SetDesignForms()
        {
            BoxFormsTextboxs = new System.Windows.Forms.TextBox[Tables.AtributtesCount];
            NameLabel = new System.Windows.Forms.Label[Tables.AtributtesCount];

            //vytvareni obsahu okna- generovani buttonu,textboxu,lablelu a dalsich
            for (int i = 0; i < (operation == 3 ? 1 : Tables.AtributtesCount); i++)
            {
                //uprava vysky formu
                this.Height += 29;

                //rozhodnuti zda-li momentalni prvek je urcen pro zadavani nebo ID aby se vytvoril button vedle
                bool hybrid = DataType(Tables.Get_Atribut(i).get_DataType);

                //Generace textboxu
                BoxFormsTextboxs[i] = new System.Windows.Forms.TextBox();
                BoxFormsTextboxs[i].Location = new System.Drawing.Point(100, 23 + 29 * i);
                BoxFormsTextboxs[i].Name = "textBox" + i;
                //zmensi se pokud se ma zadavat DATUM nebo ID
                BoxFormsTextboxs[i].Size = new System.Drawing.Size((int)((double)127 / (hybrid ? 1.5 : 1.0)), 20);//Vyska,sirka
                BoxFormsTextboxs[i].TabIndex = 1 + i;
                BoxFormsTextboxs[i].Text = "";
                BoxFormsTextboxs[i].Enabled = !hybrid;

                //slouzi pro nacteni dat pri uprave tabulky
                if (operation == 2 && i == 0)
                    BoxFormsTextboxs[i].TextChanged += new System.EventHandler(LoadValue);
                Controls.Add(BoxFormsTextboxs[i]);

                //vytvoreni button nebo checkbox pro zadani bud ID, DATUMU nebo boolu(checckbox
                switch (DataTypeID(Tables.Get_Atribut(i).get_DataType))
                {
                    case 0:
                        System.Windows.Forms.Button Button = new System.Windows.Forms.Button();
                        Button.Location = new System.Drawing.Point(185, 21 + 29 * i);
                        Button.Name = "button1";
                        Button.Size = new System.Drawing.Size(42, 23);
                        Button.TabIndex = i;
                        Button.Text = (Tables.Get_Atribut(i).get_DataType == "date" ? "Date" : "ID");
                        Button.UseVisualStyleBackColor = true;
                        Button.Click += new System.EventHandler(InsertValue);
                        Controls.Add(Button);
                        break;

                    case 1:
                        CheckBox Chckbox = new CheckBox();
                        Chckbox.AutoSize = true;
                        Chckbox.Location = new System.Drawing.Point(185, 25 + 29 * i);
                        Chckbox.Name = "Chckbox";
                        Chckbox.Size = new System.Drawing.Size(80, 17);
                        Chckbox.TabIndex = i;
                        Chckbox.Text = "No";
                        Chckbox.UseVisualStyleBackColor = true;
                        Chckbox.CheckedChanged += new System.EventHandler(CheckYesNo);
                        Controls.Add(Chckbox);
                        BoxFormsTextboxs[i].Text = "0";
                        break;

                    case -1:
                    default:
                        break;
                }

                //nazvy vedle textboxu
                NameLabel[i] = new System.Windows.Forms.Label();
                NameLabel[i].AutoSize = true;
                NameLabel[i].Location = new System.Drawing.Point(6, 26 + 29 * i);
                NameLabel[i].Name = "label1" + i;
                NameLabel[i].Size = new System.Drawing.Size(38, 13);
                NameLabel[i].TabIndex = 1 + Tables.AtributtesCount + i;
                NameLabel[i].Text = Tables.Names()[i];
                Controls.Add(NameLabel[i]);
            }

            //Button pro vyvolani potvrzeni k odeslani dat
            System.Windows.Forms.Button buttonx = new System.Windows.Forms.Button();
            buttonx.Location = new System.Drawing.Point(this.Width / 2 - 37, this.Height - 29);
            buttonx.Name = "buttonx";
            buttonx.Size = new System.Drawing.Size(75, 23);
            buttonx.TabIndex = 0;
            buttonx.Text = "Enter";
            buttonx.UseVisualStyleBackColor = true;
            buttonx.Visible = true;
            buttonx.Click += new System.EventHandler(Confirm);

            Controls.Add(buttonx);

            //doupraveni vysky
            this.Height += 29;
        }

        //rozhodnuti mezi zadanim DATUMU nebo ID
        private void InsertValue(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            if (but.Text == "Date")
            {
                Date_get date_get = new Date_get(login, this, but.TabIndex);
                date_get.Visible = true;
            }
            if (but.Text == "ID")
            {
                DataGridView grid = new DataGridView(login, this, but.TabIndex, Tables.Get_Atribut(but.TabIndex).get_Tables);
                grid.Visible = true;
            }
        }

        private void CheckYesNo(object sender, EventArgs e)
        {
            CheckBox ch = (CheckBox)sender;
            ch.Text = (ch.Checked ? "Yes" : "No");//Yes true,No false
            BoxFormsTextboxs[ch.TabIndex].Text = (ch.Checked ? 1 : 0) + "";
        }

        //odesilaci metoda
        private void Confirm(object sender, EventArgs e)
        {
            //overeni spravnosti zadanych hodnot
            for (int i = 0; i < Tables.AtributtesCount; i++)
            {
                if (BoxFormsTextboxs[i].Text == "")
                {
                    login.Label4Text("Empty - " + Tables.Get_Atribut(i).Get_Name);
                    return;
                }

                string mess = Tables.Get_Atribut(i).set(BoxFormsTextboxs[i].Text);

                if (mess != "")
                {
                    login.Label4Text("Empty - " + Tables.Get_Atribut(i).Get_Name + mess);
                    return;
                }
            }

            //Zde se prekopirovavaji data do pole
            string[] values = new string[Tables.AtributtesCount];
            for (int i = 0; i < Tables.AtributtesCount; i++)
                values[i] = BoxFormsTextboxs[i].Text;

            //vyber operace
            switch (operation)
            {
                case 1:
                    if (login.database.Insert(values, TablesID))
                    {
                        login.Label4Text("Done.");

                        this.Close();
                    }
                    else
                        login.Label4Text("It is not done.");
                    break;

                case 2:
                    if (login.database.Update(values, TablesID))
                    {
                        login.Label4Text("Done.");
                        this.Close();
                    }
                    else
                        login.Label4Text("It is not done.");
                    break;

                case 3:
                    if (login.database.Delete(TablesID, Convert.ToInt32(values[0])))
                    {
                        login.Label4Text("Done.");
                        this.Close();
                    }
                    else
                        login.Label4Text("It is not done.");
                    break;

                default:
                    break;

            }
        }

        //Nastaveni souradnic formu
        private void Form3_Load(object sender, EventArgs e)
        {
            this.Left = ChooseOper.DesktopLocation.X + ChooseOper.Width + 10;
            this.Top = ChooseOper.DesktopLocation.Y;
        }

        //Nacteni dat pri uprave tabulky
        private void LoadValue(object sender, EventArgs e)
        {
            object[] values = login.database.SelectTableValue(login.database.Get_Tables(TablesID), Convert.ToInt32(((TextBox)sender).Text));
            for (int i = 1; i < Tables.AtributtesCount; i++)
            {
                BoxFormsTextboxs[i].Text = values[i] + "";
            }
        }

        public bool DataType(string s)
        {
            switch (s)
            {
                case "date":
                case "id":
                case "bit":
                    return true;

                case "number":
                case "double":
                case "text":
                default:
                    return false;
            }
        }

        public int DataTypeID(string s)
        {
            switch (s)
            {
                case "date":
                case "id":
                    return 0;
                case "bit":
                    return 1;

                case "number":
                case "double":
                case "text":
                default:
                    return -1;
            }
        }

        private void CompleteEntry_Load(object sender, EventArgs e)
        {

        }


    }
}
/*
 * Otazka Mandik.
 * (pridani datoveho typu double) kde a jak pridat a zmenit?
zmenit v tride atribut, choseoperation, Completeentry
(pridani datoveho typu double)
*/