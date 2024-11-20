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
    public partial class Date_get : Form
    {
        CompleteEntry CE;
        Login login;
        int id;
        public Date_get(Login login, CompleteEntry CE, int id)
        {
            this.CE = CE;
            this.login = login;
            this.id = id;
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            this.Left = CE.DesktopLocation.X;
            this.Top = CE.DesktopLocation.Y + CE.Height + 10;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                int year, month, day, hour, minute, second;
                try
                {
                    year = Convert.ToInt32(textBox1.Text);
                    month = Convert.ToInt32(textBox2.Text);
                    day = Convert.ToInt32(textBox3.Text);
                    hour = Convert.ToInt32(textBox4.Text);
                    minute = Convert.ToInt32(textBox5.Text);
                    second = Convert.ToInt32(textBox6.Text);
                }
                catch
                {
                    return;
                }
                if (year > 0) { } else { MessageBox.Show("Badly year"); return; }
                if (month > 0 && month < 13) { } else { MessageBox.Show("Badly month"); return; }
                if (day > 0 && day < 32) { } else { MessageBox.Show("Badly day"); return; }
                if (hour >= 0 && hour < 24) { } else { MessageBox.Show("Badly hour"); return; }
                if (minute >= 0 && minute < 60) { } else { MessageBox.Show("Badly minute"); return; }
                if (second >= 0 && second < 60) { } else { MessageBox.Show("Badly second"); return; }

                CE.BoxFormsTextboxs[id].Text =
                 year + "-" +
                    (month >= 10 ? "" + month : "0" + month) + "-" +
                    (day >= 10 ? "" + day : "0" + day) + " " +
                    (hour >= 10 ? "" + hour : "0" + hour) + ":" +
                    (minute >= 10 ? "" + minute : "0" + minute) + ":" +
                    (second >= 10 ? "" + second : "0" + second) + ".000";
                this.Close();
            }
        
        }


        private void Date_get_Load(object sender, EventArgs e)
        {

        }
    }
}
