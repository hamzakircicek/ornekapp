using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ornekapp
{
    public partial class Form2 : Form
    {
        Login _login = new Login();
        SqlConnection sqlBaglantisi = new SqlConnection("Data Source=DESKTOP-VMQ4RDT;Initial Catalog=marketDB;Integrated Security=True;");
        Form1 form1 = new Form1();

        public Form2()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            musteriGiris();
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _login.musteriKontrol( Convert.ToInt32(textBox3.Text));
            if (Model.kayitDurum == true)
            {
                _login.musteriEkle(textBox4.Text, Convert.ToInt32(textBox3.Text));
                _login.musteriDbOlustur(textBox4.Text, Convert.ToInt32(textBox3.Text));
            }
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void musteriGiris()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Boş Değer Girilemez");
            }
            else
            {
                sqlBaglantisi.Open();
                try
                {
                    Model.id = Convert.ToInt32(textBox1.Text);
                    Model.name = textBox2.Text;
                   
                    String whereSql = "SELECT * FROM customer WHERE  id = @userid AND userName = @userName";
                    SqlCommand SqlWhereCommand = new SqlCommand(whereSql, sqlBaglantisi);
                    SqlWhereCommand.Parameters.AddWithValue("@userid", Convert.ToInt32(textBox1.Text));
                    SqlWhereCommand.Parameters.AddWithValue("@userName", textBox2.Text);
                    SqlDataReader dr = SqlWhereCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                       
                        form1.ShowDialog();
                        Form2 form2 = new Form2();
                        form2.Hide();
                      

                    }
                    else
                    {
                        MessageBox.Show("Böyle Bir Müşteri Yok. Lütfen Bİlgilerinizi Kontrol Edin");
                       
                    }
                    dr.Close();
                    sqlBaglantisi.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   
                    sqlBaglantisi.Close();
                }
            }




        }
    }
}
