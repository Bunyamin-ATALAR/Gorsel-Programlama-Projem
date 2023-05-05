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

namespace WindowsFormsApp1
{
    public partial class YayinEviAdi : Form
    {
        public YayinEviAdi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-TU5K6PO;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Uye(Adi,Sayfasi,Yazar,Yayinci) values(@Adi,@Sayfasi,@Yazar,@Yayinci)", baglanti);
            komut.Parameters.AddWithValue("@Adi", txtAdi.text);
            komut.Parameters.AddWithValue("@Sayfasi", txtSayfasi.text);
            komut.Parameters.AddWithValue("@Yazar", txtYazar.text);
            komut.Parameters.AddWithValue("@Yayinci", txtYayinci.text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ekleme Yapıldı!..");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void YayinEviAdi_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Uye(YayinEviAdi,Telefon,Adresi) values(@YayinEviAdi,@Telefon,@Adresi)", baglanti);
            komut.Parameters.AddWithValue("@YayinEviAdi", txtYayinEviAdi.text);
            komut.Parameters.AddWithValue("@Telefon", txtTelefon.text);
            komut.Parameters.AddWithValue("@Adresi", txtAdresi.text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ekleme Yapıldı!..");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Kitaplarım where Kitaplar=@Kitaplar", baglanti);
            komut.Parameters.AddWithValue("@Kitaplar", DataGridView1.CurrentRow.Cells["Kitaplar"].Value.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İşlemi Başarıyla Gerçekleştirildi!..");
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }
        private void listele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Kitaplarım", baglanti);
            adtr.Fill(daset, "Kitaplarım");
            DataGridView1.DataSource = daset.Tables["Kitaplarım"];
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Kitaplarim set YayinEviAdi=@YayinEviAdi,Telefon=@Telefon,Adresi=@Adresi", baglanti);
            komut.Parameters.AddwithValue("@YayinEviAdi", txtYayinEviAdi, Text);
            komut.Parameters.AddwithValue("@Telefon", txtTelefon, Text);
            komut.Parameters.AddwithValue("@Adresi", txtAdresi, Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["Kitaplarım"].Clear();
            listele();
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

    }
}

    private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
