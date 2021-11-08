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
        

        public void musteriGiris(int id, string userName)
        {
            if (id == null || userName == "")
            {
                MessageBox.Show("Lütfen Alanları Doldurunuz");
            }
            else
            {
                try
                {
                    Model.id = id;
                    Model.name=userName;
                    sqlBaglantisi.Open();
                    String whereSql = "SELECT * FROM costumer WHERE  id = @userid AND userName = @userName";
                    SqlCommand SqlWhereCommand = new SqlCommand(whereSql, sqlBaglantisi);
                    SqlWhereCommand.Parameters.AddWithValue("@userid", id);
                    SqlWhereCommand.Parameters.AddWithValue("@userName", userName);
                    SqlDataReader dr = SqlWhereCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        MessageBox.Show("Hoşgeldiniz: "+Model.name);
                        
                    }
                    else
                    {
                        MessageBox.Show("Böyle Bir Müşteri Yok. Lütfen Bİlgilerinizi Kontrol Edin");
                    }
                    sqlBaglantisi.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }
    }
}
