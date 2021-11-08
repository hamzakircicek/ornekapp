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
    public partial class Form1 : Form
    {
        SatisIslemleri _satisİslemleri = new SatisIslemleri();
        Login _login=new Login();
       


        double urunFiyat=0;
        SqlConnection sqlBaglantisi = new SqlConnection("Data Source=DESKTOP-VMQ4RDT;Initial Catalog=marketDB;Integrated Security=True");


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            panel1.Visible = true;
          
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            adet.Text="1";
            hesap();
            label2.Text =Convert.ToString(urunFiyat);

        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            adet.Text = Convert.ToString(_satisİslemleri.adetArti(Convert.ToInt32(adet.Text)));
            hesap();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            adet.Text = Convert.ToString(_satisİslemleri.adetEksi(Convert.ToInt32(adet.Text)));
            hesap();
           
        }

        private void adet_Click(object sender, EventArgs e)
        {
             
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
           

        }

        private void button7_Click(object sender, EventArgs e)
        {
     
         
        }
       
        private  void button8_Click(object sender, EventArgs e)
        {
           
           _satisİslemleri.sqlCommand(Convert.ToString(listBox1.SelectedItem), Convert.ToInt32(adet.Text), _satisİslemleri.tutarFiyat(label2.Text,urunFiyat),DateTime.Now);
            MessageBox.Show(Model.name);
            String sql = "SELECT * FROM "+ Model.name;
            sqlBaglantisi.Open();
           
            SqlCommand sqlCommand = new SqlCommand(sql, sqlBaglantisi);
            SqlDataAdapter dataAdaptor = new SqlDataAdapter(sqlCommand);
            DataTable table = new DataTable();
            dataAdaptor.Fill(table);
            dataGridView1.DataSource = table;
            sqlBaglantisi.Close();


        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }
        public void hesap()
        {
            if (listBox1.SelectedItem == "Çikolata")
            {
                urunFiyat = _satisİslemleri.urunFiyatları("Çikolata");

            }
            else if (listBox1.SelectedItem == "Deterjan")
            {

                urunFiyat = _satisİslemleri.urunFiyatları("Deterjan");
            }
            else if (listBox1.SelectedItem == "Kahve")
            {

                urunFiyat = _satisİslemleri.urunFiyatları("Kahve");
            }
            else if (listBox1.SelectedItem == "Cips")
            {

                urunFiyat = _satisİslemleri.urunFiyatları("Cips");
            }
            else if (listBox1.SelectedItem == "Soda")
            {

                urunFiyat = _satisİslemleri.urunFiyatları("Soda");
            }
            else
            {
                MessageBox.Show("Lütfen Bir Ürün Seçin");
            }
            int intAdet = Convert.ToInt32(adet.Text);
            label2.Text = Convert.ToString(urunFiyat * intAdet);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            _login.musteriGiris(Convert.ToInt32(textBox1.Text),textBox2.Text);
        }
    }
}
