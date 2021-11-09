using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ornekapp
{   
   class SatisIslemleri
    {


       
        public int GlobalAdet = 0;
        SqlConnection sqlBaglantisi = new SqlConnection("Data Source=DESKTOP-VMQ4RDT;Initial Catalog=marketDB;Integrated Security=True");


        public void sqlCommand( String urun_adi, int urunAdeti, double toplamTutar, String tarih)
        {
           
            
            try
            {
                    sqlBaglantisi.Open();
                    String insertSql = "INSERT INTO " + Model.name+Model.id + "(Urun_Adi,Urun_Adeti,Toplam_Tutar,Tarih) VALUES(@urunAdi,@urunAdeti,@toplamTutar,@tarih)";
                    SqlCommand SqlCommand = new SqlCommand(insertSql, sqlBaglantisi);
                    SqlCommand.Parameters.AddWithValue("@urunadi", urun_adi);
                    SqlCommand.Parameters.AddWithValue("@urunAdeti", urunAdeti);
                    SqlCommand.Parameters.AddWithValue("@toplamTutar", toplamTutar);
                    SqlCommand.Parameters.AddWithValue("@tarih", tarih);
                    SqlCommand.ExecuteNonQuery();
                    sqlBaglantisi.Close();      
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }
      
    


       public int adetArti(int adet)
        {       
             GlobalAdet= adet + 1;
            return GlobalAdet;
        }
        public int adetEksi(int adet)
        {
            if (adet > 1)
            {
                GlobalAdet = adet - 1;
            }
            return GlobalAdet;
           
           
        }
      
        public double urunFiyatları(String urun)
        {
            if (urun == "Çikolata")
            {
                return 1.25;
            }
            if (urun == "Deterjan")
            {
                return 25.00;
            }
            if (urun == "Kahve")
            {
                return 10.25;
            }
            if (urun == "Cips")
            {
                return 3.50;
            }
            if (urun == "Soda")
            {
                return 1.25;
            }
            else
            {
                return 0;
            }
           

        }
        public double tutarFiyat(string deger,double urunFiyat)
        {
            if (deger == "---")
            {
                return urunFiyat;
            }
            else
            {
                return Convert.ToDouble(deger);
            }
        }
        public string toplamTutarHesapla()
        {
            string tutar="";
                sqlBaglantisi.Open();
                string tutarSql = "SELECT sum(Toplam_Tutar) FROM " + Model.name + Model.id;
                SqlCommand tutarCommand = new SqlCommand(tutarSql, sqlBaglantisi);
                SqlDataReader read = tutarCommand.ExecuteReader();
                while (read.Read())
                    {
                         tutar = read[0].ToString();
                    }
                read.Close();
                sqlBaglantisi.Close();
                 return tutar;

        }
     









    }
}
