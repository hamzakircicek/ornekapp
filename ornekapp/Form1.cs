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
     


        double urunFiyat=0;
        SqlConnection sqlBaglantisi = new SqlConnection("Data Source=DESKTOP-VMQ4RDT;Initial Catalog=marketDB;Integrated Security=True;");


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
            panel2.Visible = false;
          
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
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

       
       
        private  void button8_Click(object sender, EventArgs e)
        {
           _satisİslemleri.sqlCommand(Convert.ToString(listBox1.SelectedItem), Convert.ToInt32(adet.Text), _satisİslemleri.tutarFiyat(label2.Text,urunFiyat), DateTime.Now.ToString("dd.MM.yyyy"));
            veriGoster();
            label6.Text = _satisİslemleri.toplamTutarHesapla();
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

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            veriGoster();
            label6.Text=_satisİslemleri.toplamTutarHesapla();
            
        }


        private void label6_Click(object sender, EventArgs e)
        {
          
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label3.Text = monthCalendar1.SelectionRange.Start.ToString("dd.MM.yyyy");
           
           
        }
        private void veriGoster()
        {
            String sql = "SELECT * FROM " + Model.name + Model.id;
            sqlBaglantisi.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, sqlBaglantisi);
            SqlDataAdapter dataAdaptor = new SqlDataAdapter(sqlCommand);
            DataTable table = new DataTable();
            dataAdaptor.Fill(table);
            dataGridView1.DataSource = table;
            sqlBaglantisi.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                String whereSql = "SELECT * FROM " + Model.name + Model.id + " WHERE Tarih=@date";
                sqlBaglantisi.Open();
                SqlCommand SqlWhereCommand = new SqlCommand(whereSql, sqlBaglantisi);
                SqlWhereCommand.Parameters.AddWithValue("@date", monthCalendar1.SelectionRange.Start.ToString("dd.MM.yyyy"));
                SqlWhereCommand.ExecuteNonQuery();
                SqlDataAdapter dataAdaptor = new SqlDataAdapter(SqlWhereCommand);
                    DataTable table = new DataTable();
                    dataAdaptor.Fill(table);
                    dataGridView2.DataSource = table;
                sqlBaglantisi.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          



        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
