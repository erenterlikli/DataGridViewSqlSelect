using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; //Access kütüphanesi.



namespace AccessDataShowAdd
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Eren\\Documents\\Kisi.mdb");
        private void Goster()
        {
            listView1.Items.Clear();
            baglan.Open();
            OleDbCommand komut1 = new OleDbCommand();
            komut1.Connection = baglan;
            komut1.CommandText = ("Select * from kayitlar");
            OleDbDataReader oku = komut1.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Ad"].ToString();
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["Yas"].ToString());
                ekle.SubItems.Add(oku["Semt"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Goster();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 18; i <= 45; i++) //formun içine yazılacak.
            {
                comboBox2.Items.Add(i);

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand komut2 = new OleDbCommand("Insert Into kayitlar(Ad,Soyad,Yas,Semt) Values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + comboBox1.Text.ToString() + "')", baglan);
            komut2.ExecuteNonQuery();
            baglan.Close();
            Goster();
            textBox1.Text = " ";
            textBox2.Text = " ";
            comboBox1.Text = " ";
            comboBox2.Text = " ";
        }
    }
}
