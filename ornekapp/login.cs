using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ornekapp
{
    class Login
    {
        SqlConnection sqlBaglantisi = new SqlConnection("Data Source=DESKTOP-VMQ4RDT;Initial Catalog=marketDB;Integrated Security=True");
       
       


        
        public void musteriKontrol(int id)
        {
            sqlBaglantisi.Open();


            String whereSql = "SELECT * FROM customer WHERE  id = @userid";
            SqlCommand SqlWhereCommand = new SqlCommand(whereSql, sqlBaglantisi);
            SqlWhereCommand.Parameters.AddWithValue("@userid", id);
            SqlDataReader dr = SqlWhereCommand.ExecuteReader();
           
            if (dr.HasRows)
            {
                MessageBox.Show("Bu id başka bir müşteri tarafıntan kullanılıyor.");
                Model.kayitDurum = false;
               

            }
            else
            {
                Model.kayitDurum =true;
               
            }
            dr.Close();
            sqlBaglantisi.Close();




        }
        public void musteriEkle(string kullaniciAdi,int id)
        {
            sqlBaglantisi.Open();
            try
            {
               
                String insertSql = "INSERT INTO customer (userName,id) VALUES(@kullaniciAdi,@id)";
                SqlCommand SqlCommand = new SqlCommand(insertSql, sqlBaglantisi);
                SqlCommand.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                SqlCommand.Parameters.AddWithValue("@id",id);
                SqlCommand.ExecuteNonQuery();
                MessageBox.Show("Müşteri Başarıyla Eklendi");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            sqlBaglantisi.Close();
        }
        public void musteriDbOlustur(string kullaniciAdi,int id)
        {
            sqlBaglantisi.Open();
            try
            {
                
                String createSql = "CREATE TABLE " + kullaniciAdi + id + " (id int IDENTITY(1,1) NOT NULL, Urun_Adi varchar(50), Urun_Adeti nvarchar(50),Toplam_Tutar float,Tarih nvarchar(50), PRIMARY KEY(id))";
                SqlCommand SqlCreateCommand = new SqlCommand(createSql, sqlBaglantisi);
                SqlCreateCommand.ExecuteNonQuery();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
            sqlBaglantisi.Close();
        } 
    }
}
