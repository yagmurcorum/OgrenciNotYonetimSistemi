using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ntp300625
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DGYukle();
        }

        string query, conStr = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=..\\..\\..\\database6.accdb";
        OleDbCommand cmd;
        OleDbConnection conn;
        Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen öğrenci sayısını giriniz.");
                return;
            }
            int sayi = Convert.ToInt32(textBox1.Text);
            string silquery = "Delete from Ogrenciler";
            conn = new OleDbConnection(conStr);
            conn.Open();
            cmd = new OleDbCommand(silquery, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            for (int i = 0; i < sayi; i++)
            {
                int say = rnd.Next(1000, 2001);
                query = "Insert into Ogrenciler(ID) values (@id)";
                conn.Open();
                cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", say);
                cmd.ExecuteNonQuery();
                conn.Close();
                DGYukle();
            }
            
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            /*string aranan = textBox2.Text;
                    query = "select* from Ogrenciler where ID=" + aranan;
                    conn.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Ogrenciler");
                    dataGridView1.DataSource = ds.Tables["Ogrenciler"];
                    conn.Close();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string aranan = textBox2.Text;
            query = "select* from Ogrenciler where ID=" + aranan;
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Ogrenciler");
            dataGridView1.DataSource = ds.Tables["Ogrenciler"];
            conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        { //rastgele vize ekle
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) 
            {
                int id = Convert.ToInt32(dataGridView1[0, i].Value);
                query = "Update Ogrenciler set Vize=" + rnd.Next(101) + " where ID=" + id;
                conn.Open();
                cmd=new OleDbCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            DGYukle();
        }

        private void button8_Click(object sender, EventArgs e)
        { //Rastgele final ekle
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                int id = Convert.ToInt32(dataGridView1[0, i].Value);
                query = "Update Ogrenciler set Final=" + rnd.Next(101) + " where ID=" + id;
                conn.Open();
                cmd = new OleDbCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            DGYukle();
        }

        private void button9_Click(object sender, EventArgs e)
        { //rastgele ödev ekle
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                int id = Convert.ToInt32(dataGridView1[0, i].Value);
                query = "Update Ogrenciler set Ödev=" + rnd.Next(101) + " where ID=" + id;
                conn.Open();
                cmd = new OleDbCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            DGYukle();
        }

        List<double> gecmenotu = new List<double>();
        private void button10_Click(object sender, EventArgs e)
        { //genel ekle
            for (int i = 0; i<dataGridView1.Rows.Count-1;i++) 
            {
             int id = Convert.ToInt32(dataGridView1[0, i].Value);
             int vn= Convert.ToInt32(dataGridView1[1,i].Value);
             int fn= Convert.ToInt32(dataGridView1[2, i].Value);
             int on = Convert.ToInt32(dataGridView1[3, i].Value);
             double gn = (vn * 0.3) + (fn * 0.5) + (on * 0.2);
             gecmenotu.Add(gn);
             dataGridView1[4, i].Value = gn.ToString("0.00");
                query = "Update Ogrenciler set GeçmeNotu = @gn where ID =" + id;
                conn.Open();
                cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@gn", gn);
                cmd.ExecuteNonQuery();
                conn.Close();
                DGYukle();
            }
          
        }

        private void button11_Click(object sender, EventArgs e)
        { //ortalama üstü
            query = "select AVG(GeçmeNotu) from Ogrenciler";
            conn.Open();
            cmd = new OleDbCommand(query, conn);
            double ort= (double)cmd.ExecuteScalar();
            conn.Close();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) 
            {

                if (Convert.ToInt32(dataGridView1[4, i].Value) > ort)
                {
                int id=Convert.ToInt32(dataGridView1[0, i].Value);
                listBox1.Items.Add(" ID: " + id + " Geçme Notu: " + dataGridView1[4, i].Value + "\r\n");
                }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                int id = Convert.ToInt32(dataGridView1[0, i].Value);
                int no = Convert.ToInt32(textBox3.Text);
                if (no == id)
                {
                    MessageBox.Show("Mükerrer ID!");
                    return;
                }
            }
                    query = "Insert into Ogrenciler(ID,Vize,Final,Ödev) values (@id,@vize,@final,@odev)";
                    conn.Open();
                    cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", textBox3.Text);
                    cmd.Parameters.AddWithValue("@vize", textBox4.Text);
                    cmd.Parameters.AddWithValue("@final", textBox5.Text);
                    cmd.Parameters.AddWithValue("@odev", textBox6.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    DGYukle();
                } 

        private void button4_Click(object sender, EventArgs e)
        {
            query = "Update Ogrenciler set Vize= @vn, Final= @fn, Ödev= @on where ID = " + textBox3.Text;
            conn.Open();
            cmd=new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@vn", textBox4.Text);
            cmd.Parameters.AddWithValue("@fn", textBox5.Text);
            cmd.Parameters.AddWithValue("@on", textBox6.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            DGYukle();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
               DialogResult dr = MessageBox.Show("ID:" + dataGridView1.CurrentRow.Cells[0].Value + "Silinecek.Emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
               if(dr==DialogResult.Yes) 
                {
                int id= Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                query = "Delete from Ogrenciler where ID=" + id;
                conn.Open();
                cmd = new OleDbCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                DGYukle();

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                double gn= (double)dataGridView1.CurrentRow.Cells[4].Value;
                if (gn > 60) MessageBox.Show("ID :" + id + " Öğrencisi Geçti! Ders Notu : " + gn);
                else MessageBox.Show("ID : " + id + " nolu Öğrenci Kaldı! Ders Notu : " + gn);

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            query = " Select* from Ogrenciler where GeçmeNotu <60";
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Ogrenciler");
            dataGridView1.DataSource = ds.Tables["Ogrenciler"];
            conn.Close();
        }

        List<int> ogrNo = new List<int>();

        private void button13_Click(object sender, EventArgs e)
        {   
            if(textBox1.Text=="")
            {
                MessageBox.Show("Lütfen öğrenci sayısını giriniz.");
                return;
            }   

            string silquery = "Delete from Ogrenciler";
            conn.Open();
            cmd= new OleDbCommand(silquery, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            int ogno= Convert.ToInt32(textBox1.Text);
            for(int i = 0; i < ogno; i++) { 
                int sayi = rnd.Next(1000, 2001);
                if (!ogrNo.Contains(sayi))
                {
                    ogrNo.Add(sayi);
                    query = "Insert into Ogrenciler (ID) values (@id)";
                    conn.Open();
                    cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", sayi);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                DGYukle();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            query = "Select* from Ogrenciler";
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Ogrenciler");
            dataGridView1.DataSource = ds.Tables["Ogrenciler"];
            conn.Close();
        }

        private void DGYukle() 
        {
            query = "select* from Ogrenciler";
            conn = new OleDbConnection(conStr);
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Ogrenciler");
            dataGridView1.DataSource = ds.Tables["Ogrenciler"];
            conn.Close();
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 80;
        }
    }
}
