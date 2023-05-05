﻿using System;
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
    public partial class YazarAdi : Form
    {
        public YazarAdi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-TU5K6PO;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True");
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Uye(Adi,Soyadi,Kitabi,Adresi) values(@Adi,@Soyadi,@Kitabi,@Adresi)", baglanti);
            komut.Parameters.AddWithValue("@Adi", txtAdi.text);
            komut.Parameters.AddWithValue("@Soyadi", txtSoyadi.text);
            komut.Parameters.AddWithValue("@Kitabi", txtKitabi.text);
            komut.Parameters.AddWithValue("@Adresi", txtAdresi.text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ekleme Yapıldı!..");
        }

        private void YazarAdi_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Kitaplarim set Adi=@Adi,Soyadi=@Soyadi,Kitabi=@Kitabi,Adresi=@Adresi", baglanti);
            komut.Parameters.AddwithValue("@Adi", txtAdi, Text);
            komut.Parameters.AddwithValue("@Soyadi", txtSoyadi, Text);
            komut.Parameters.AddwithValue("@Kitabi", txtKitabi, Text);
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
}
