using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace otel_takip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection bagla = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\odevvvvv.mdb");
        OleDbCommand komut = new OleDbCommand();
        private void veri()
        {
            listView1.Items.Clear();
            bagla.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bagla;
            komut.CommandText = ("Select * from otel");
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["numara"].ToString();
                ekle.SubItems.Add(oku["musteri_ismi"].ToString());
                ekle.SubItems.Add(oku["musteri_soyismi"].ToString());
                ekle.SubItems.Add(oku["kalınan_gun"].ToString());
                ekle.SubItems.Add(oku["gunluk_fiyat"].ToString());
                ekle.SubItems.Add(oku["tc"].ToString());
                ekle.SubItems.Add(oku["oda_numarasi"].ToString());
                ekle.SubItems.Add(oku["dogum_tarihi"].ToString());
                ekle.SubItems.Add(oku["cinsiyet"].ToString());
                listView1.Items.Add(ekle);
            }

            bagla.Close();
        }


        //******************************************************



        private void veriler()
        {
            listView2.Items.Clear();
            bagla.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bagla;
            komut.CommandText = ("Select * from otel1");
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["musteri_ismi"].ToString();
                ekle.SubItems.Add(oku["musteri_soyismi"].ToString());
                ekle.SubItems.Add(oku["TCkimlik"].ToString());
               
                listView2.Items.Add(ekle);
            }

            bagla.Close();
        }



        //****************************************//
        private void verilerin()
        {
            listView3.Items.Clear();
            bagla.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bagla;
            komut.CommandText = ("Select * from otel2");
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Kahvaltılık"].ToString();
                ekle.SubItems.Add(oku["Ogle"].ToString());
                ekle.SubItems.Add(oku["Akşam"].ToString());
                ekle.SubItems.Add(oku["sayı"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                listView3.Items.Add(ekle);
            }

            bagla.Close();
        }
        //*********************************//
        private void verileriniz()
        {
            listView4.Items.Clear();
            bagla.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bagla;
            komut.CommandText = ("Select * from otel3");
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["fiyat"].ToString();
                ekle.SubItems.Add(oku["sayı"].ToString());
                ekle.SubItems.Add(oku["Kahvaltı"].ToString());
                ekle.SubItems.Add(oku["ogle"].ToString());
                ekle.SubItems.Add(oku["aksam"].ToString());
                listView4.Items.Add(ekle);
            }

            bagla.Close();
        }
        //******************************//
        private void Form1_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "00/00/0000";
            veri();
            veriler();
            verilerin();
            verileriniz();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                OleDbCommand komut = new OleDbCommand("insert into otel (numara,musteri_ismi,musteri_soyismi,kalınan_gun,gunluk_fiyat,tc,oda_numarasi,dogum_tarihi,cinsiyet) values ('" + numericUpDown2.Text.ToString() + "', '" + textBox1.Text.ToString() + "', '" +textBox2.Text.ToString() + "', '" + numericUpDown1.Text.ToString() + "', '" + textBox3.Text.ToString() + "', '" + maskedTextBox2.Text.ToString() + "', '" + textBox5.Text.ToString() + "', '" + maskedTextBox1.Text.ToString() + "', '" + comboBox1.Text.ToString() + "')", bagla);
                komut.ExecuteNonQuery();
                bagla.Close();
                veri();

            }
            catch { }
            try
            {
                bagla.Open();
                OleDbCommand komut = new OleDbCommand("insert into otel1 (musteri_ismi,musteri_soyismi,TCkimlik) values ('" + textBox1.Text.ToString() + "', '" + textBox2.Text.ToString() + "', '" + maskedTextBox2.Text.ToString() + "')", bagla);
                komut.ExecuteNonQuery();
                bagla.Close();
                veriler();
            }
            catch { }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                numericUpDown2.Text = listView1.SelectedItems[0].SubItems[0].Text.ToString();
                textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text.ToString();
                textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text.ToString();
                numericUpDown1.Text = listView1.SelectedItems[0].SubItems[3].Text.ToString();
                textBox3.Text = listView1.SelectedItems[0].SubItems[4].Text.ToString();
                maskedTextBox2.Text = listView1.SelectedItems[0].SubItems[5].Text.ToString();
                textBox5.Text = listView1.SelectedItems[0].SubItems[6].Text.ToString();
                maskedTextBox1.Text = listView1.SelectedItems[0].SubItems[7].Text.ToString();
                comboBox1.Text = listView1.SelectedItems[0].SubItems[8].Text.ToString();
            }
            catch
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                button4.Text = (Convert.ToInt16(numericUpDown1.Text) * Convert.ToInt16(textBox3.Text)).ToString();

                bagla.Close();
                veri();

                komut.Connection = bagla;
                bagla.Close();
                MessageBox.Show(button4.Text.ToString() + " toplam tutar".ToString());
            }
            catch
            {
                MessageBox.Show("tablodan seçiniz!!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                komut.Connection = bagla;
                komut.CommandText = "delete from otel where numara = '" + numericUpDown2.Text + "' ";
                komut.ExecuteNonQuery();
                bagla.Close();
                veri();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                komut.Connection = bagla;
                komut.CommandText = "update otel set   musteri_ismi ='" + textBox1.Text + "', musteri_soyismi ='" + textBox2.Text + "', kalınan_gun ='" + numericUpDown1.Text + "', gunluk_fiyat ='" + textBox3.Text + "',tc ='" + maskedTextBox2.Text + "', oda_numarasi ='" + textBox5.Text + "', dogum_tarihi ='" + maskedTextBox1.Text + "', cinsiyet ='" + comboBox1.Text + "' where numara= '" + numericUpDown2.Text + "'";
                komut.ExecuteNonQuery();
                bagla.Close();
                veri();
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("oda numarınız  ".ToString() + textBox5.Text.ToString());
            MessageBox.Show("dogum tarihiniz ".ToString() + maskedTextBox1.Text.ToString());
            MessageBox.Show("cinsiyet: ".ToString() + comboBox1.Text.ToString());
            MessageBox.Show("tc kimlik numaranız ".ToString() + maskedTextBox2.Text.ToString());
            MessageBox.Show("numaranız ".ToString() + numericUpDown2.Text.ToString());
            MessageBox.Show("müşteri ismi ".ToString() + textBox1.Text.ToString());
            MessageBox.Show("müşteri soyismi ".ToString() + textBox2.Text.ToString());
            MessageBox.Show("kalınacak gün sayısı ".ToString() + numericUpDown1.Text.ToString());
            MessageBox.Show("günlük fiyat ".ToString() + textBox3.Text.ToString());

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                OleDbCommand komut = new OleDbCommand("insert into otel3 (fiyat,sayı,Kahvaltı,ogle,aksam) values ('" + textBox4.Text.ToString() + "', '" + textBox8.Text.ToString() + "', '" + textBox6.Text.ToString() + "', '" + textBox7.Text.ToString() + "', '" + textBox9.Text.ToString() + "')", bagla);
                komut.ExecuteNonQuery();
                bagla.Close();
                verileriniz();

            }
            catch { }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox10.Text = listView3.SelectedItems[0].SubItems[4].Text.ToString();
                textBox4.Text = listView3.SelectedItems[0].SubItems[4].Text.ToString();
                textBox8.Text = listView3.SelectedItems[0].SubItems[3].Text.ToString();
                textBox6.Text = listView3.SelectedItems[0].SubItems[0].Text.ToString();
                textBox7.Text = listView3.SelectedItems[0].SubItems[1].Text.ToString();
                textBox9.Text = listView3.SelectedItems[0].SubItems[2].Text.ToString();
            }
            catch { }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox8.Text = listView4.SelectedItems[0].SubItems[1].Text.ToString();
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                komut.Connection = bagla;
                komut.CommandText = "delete from otel3 where sayı = '" + textBox8.Text + "' ";
                komut.ExecuteNonQuery();
                bagla.Close();
                verileriniz();
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            decimal topla = 0;

            for (int sayi = 0; sayi <= listView4.Items.Count - 1; sayi++)
            {

                decimal sayi1;

                string sayi2;

                sayi2 = listView4.Items[sayi].SubItems[0].Text;

                sayi1 = decimal.Parse(sayi2);

                topla = topla + sayi1;

            }

            label10.Text = topla.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(textBox10.Text+" TL");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("oda numarınız  ".ToString() + textBox5.Text.ToString());
            MessageBox.Show("dogum tarihiniz ".ToString() + maskedTextBox1.Text.ToString());
            MessageBox.Show("cinsiyet: ".ToString() + comboBox1.Text.ToString());
            MessageBox.Show("tc kimlik numaranız ".ToString() + maskedTextBox2.Text.ToString());
            MessageBox.Show("numaranız ".ToString() + numericUpDown2.Text.ToString());
            MessageBox.Show("müşteri ismi ".ToString() + textBox1.Text.ToString());
            MessageBox.Show("müşteri soyismi ".ToString() + textBox2.Text.ToString());
            MessageBox.Show("kalınacak gün sayısı ".ToString() + numericUpDown1.Text.ToString());
            MessageBox.Show("günlük fiyat ".ToString() + textBox3.Text.ToString());
            MessageBox.Show("yemek fiyatı: ".ToString() + textBox4.Text.ToString());
            MessageBox.Show("kahvaltı yemeği: ".ToString() + textBox6.Text.ToString());
            MessageBox.Show("öğle yemeği: ".ToString() + textBox7.Text.ToString());
            MessageBox.Show("akşam yemeği: ".ToString() + textBox9.Text.ToString());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                button4.Text = (Convert.ToInt16(numericUpDown1.Text) * Convert.ToInt16(textBox3.Text)).ToString();

                bagla.Close();
                veri();

                komut.Connection = bagla;
                bagla.Close();
                MessageBox.Show(button4.Text.ToString() + " toplam tutar".ToString());
            }
            catch
            {
                MessageBox.Show("tablodan seçiniz!!!");
            }
            
            decimal topla = 0;
            decimal toplam = 0;
            
            for (int sayi = 0; sayi <= listView4.Items.Count - 1; sayi++)
            {

                decimal sayi1;

                string sayi2;

                sayi2 = listView4.Items[sayi].SubItems[0].Text;

                sayi1 = decimal.Parse(sayi2);

                topla = topla + sayi1;
                toplam = + topla;

            }

            label10.Text = topla.ToString();
            MessageBox.Show("yemek ücreti:"+ label10.Text);
        }
    }
}
