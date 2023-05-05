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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-TU5K6PO;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True");
        private void button3_Click(object sender, EventArgs e)
        {
            YayinEviAdi YayinEvleri = new YayinEviAdi();
            YayinEvleri.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KitapAdi Kitaplar = new KitapAdi();
            Kitaplar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YazarAdi Yazarlar = new YazarAdi();
            Yazarlar.Show();
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Kitaplarim set KitapAdi=@KitapAdi,YazarAdi=@YazarAdi,YayinEviAdi=@YayinEviAdi,KitapKodu=@KitapKodu", baglanti);
            komut.Parameters.AddwithValue("@KitapAdi", txtKitapAdi, Text);
            komut.Parameters.AddwithValue("@YazarAdi", txtYazarAdi, Text);
            komut.Parameters.AddwithValue("@YayinEviAdi", txtYayinEviAdi, Text);
            komut.Parameters.AddwithValue("@KitapKodu", txtKitapKodu, Text);

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

        private void button7_Click(object sender, EventArgs e)
        {
            public void listele()
            {
                baglanti.Open();
                string sec = "SELECT * from Kitaplarım";
                SqlCommand komut = new SqlCommand(sec, baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();

            }
        }
}
}
}
