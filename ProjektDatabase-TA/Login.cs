using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjektDatabase_TA
{
    public partial class Login : Form
    {
        public Database database;
        public bool check = true;
        public Login()
        {
            InitializeComponent();
            VisibleConElementLogin();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
                database = new Database(comboBox1.Text, textBox2.Text, textBox2.Text, textBox3.Text);
                LoadingTablesDB();
                if (database.OpenConnection())
                {
                    ChooseOperations chooseOper = new ChooseOperations(this);
                    chooseOper.Visible = true;
                    label4.Text = "Connected.";
                }
                else
                {
                    label4.Text = "Fail connection or dropped.";
                }
            
                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void Label4Text(string labeltext)
        {
            label4.Text = labeltext;
        }
        public void LoadingTablesDB()
        {
            Tables TravelAgency = database.AddTable(new Tables("TravelAgency", "Agency"));
            TravelAgency.AddAtributtes(new Atributtes("id", "ID", "ID", TravelAgency));
            TravelAgency.AddAtributtes(new Atributtes("text", "Name", "Name", 20, 3, true));//datovy typ,nazev v databazi,nezv v app,...
            TravelAgency.AddAtributtes(new Atributtes("text", "Phonenumber", "Phone", 3, 1, false));
            TravelAgency.AddAtributtes(new Atributtes("text", "WebSites", "Websites", 3, 1, false));

            Tables ZipCode = database.AddTable(new Tables("ZipCode", "ZipCode"));
            ZipCode.AddAtributtes(new Atributtes("id", "ID", "IDss", ZipCode));
            ZipCode.AddAtributtes(new Atributtes("number", "Code", "Code", 20, 3, true));

            Tables Customers = database.AddTable(new Tables("Customers", "Customers"));
            Customers.AddAtributtes(new Atributtes("id", "ID", "ID", Customers));
            Customers.AddAtributtes(new Atributtes("text", "FirstName", "Name", 20, 3, true));
            Customers.AddAtributtes(new Atributtes("text", "LastName", "Surname", 20, 3, true));
            Customers.AddAtributtes(new Atributtes("number", "Phonenumber", "Phone", 20, 3, true));
            Customers.AddAtributtes(new Atributtes("date", "Datenumber", "Date number", 20, 3, true));
            Customers.AddAtributtes(new Atributtes("text", "E-mail", "E-mail", 20, 3, true));
            Customers.AddAtributtes(new Atributtes("text", "City", "City", 20, 3, true));
            Customers.AddAtributtes(new Atributtes("text", "AdressName", "Adress name", 20, 3, true));
            Customers.AddAtributtes(new Atributtes("text", "Adressnumber", "Adress number", 20, 3, true));
            Customers.AddAtributtes(new Atributtes("number", "ZiPCodeID", "ZiP code", 20, 3, true));

            Tables Service = database.AddTable(new Tables("Service", "Service"));
            Service.AddAtributtes(new Atributtes("ID", "ID", "ID", Service));
            Service.AddAtributtes(new Atributtes("text", "HotelName", "Hotel name", 20, 3, true));
            Service.AddAtributtes(new Atributtes("number", "HotelCapacity", "Capacity hotel", 20, 3, true));
            Service.AddAtributtes(new Atributtes("text", "Restaurantnumber", "Restaurant star", 20, 3, true));

            Tables Tour = database.AddTable(new Tables("Tour", "Tour"));
            Tour.AddAtributtes(new Atributtes("id", "ID", "ID", Tour));
            Tour.AddAtributtes(new Atributtes("text", "Location", "Location", 20, 3, true));
            Tour.AddAtributtes(new Atributtes("number", "Payments", "Payment", 20, 3, true));
            Tour.AddAtributtes(new Atributtes("date", "PaymentsDate", "Payment date", 20, 3, true));
            Tour.AddAtributtes(new Atributtes("text", "TourCode", "TourCode", 20, 3, true));
            Tour.AddAtributtes(new Atributtes("number", "Nightnumber", "Night number", 20, 3, true));
            Tour.AddAtributtes(new Atributtes("text", "TourType", "Tour type", 20, 3, true));

            Tables Booking = database.AddTable(new Tables("Booking", "Reservation"));
            Booking.AddAtributtes(new Atributtes("id", "ID", "ID", Booking));
            Booking.AddAtributtes(new Atributtes("number", "CustomersID", "Customer", 20, 3, true));
            Booking.AddAtributtes(new Atributtes("number", "ServiceID", "Service", 20, 3, true));
            Booking.AddAtributtes(new Atributtes("number", "TravelAgencyID", "Agency", 20, 3, true));
            Booking.AddAtributtes(new Atributtes("number", "TourID", "Tour", 20, 3, true));
            Booking.AddAtributtes(new Atributtes("date", "BookingStartDate", "Start date", 20, 3, true));
            Booking.AddAtributtes(new Atributtes("date", "BookingEndDate", "End date", 20, 3, true));
            Booking.AddAtributtes(new Atributtes("bit", "BookingStatus", "Status", 20, 3, true));

            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void label4_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

       

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                /*Zmena jmena checkbox :)*/
                checkBox1.Text = "Login with full paramaters";
                /*Pro prihlasovani pomoci i serveru zadani*/
                comboBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                button1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                /*Pro prihlasovani bez serveru*/
                textBox4.Visible = true;
                textBox1.Visible = true;
                button2.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
            }
            else if (checkBox1.Checked == false)
            {
                /*Zmena jmena checkbox :)*/
                checkBox1.Text = "Login with User and Password";
                /*Pro prihlasovani pomoci i serveru zadani*/
                comboBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                button1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                /*Pro prihlasovani bez serveru*/
                textBox4.Visible = false;
                textBox1.Visible = false;
                button2.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
            }
        }
        public void VisibleConElementLogin()
        {
            textBox1.Visible = false;
            textBox4.Visible = false;
            button2.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            database = new Database(textBox4.Text, textBox1.Text);
            LoadingTablesDB();
            if (database.OpenConnection())
            {
                ChooseOperations chooseOper = new ChooseOperations(this);
                chooseOper.Visible = true;
                label4.Text = "Connected.";
            }
            else
            {
                label4.Text = "Fail connection or dropped.";
            }
        }
    }
}
