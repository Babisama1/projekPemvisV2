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
using projekPemvis1;
using System.Security.Cryptography;

namespace projekPemvisV2
{
    public partial class formGUI : Form
    {
        public formGUI()
        {
            InitializeComponent();
        }

        private void label_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_Exit_MouseEnter(object sender, EventArgs e)
        {
            label_Exit.ForeColor = Color.IndianRed;
        }

        private void label_Exit_MouseLeave(object sender, EventArgs e)
        {
            label_Exit.ForeColor = Color.Red;
        }

        //melakukan koneksi
        Koneksi koneksi = new Koneksi();

        private void getTable()
        {
            string selectQuery = "SELECT * FROM barangGudang";
            SqlCommand cmd = new SqlCommand(selectQuery, koneksi.GetCon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView_Tabel.DataSource = dt;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "INSERT INTO barangGudang VALUES (" + textBox_Id.Text + ",'" + textBox_Nama.Text + "'," + textBox_Harga.Text + "," + textBox_Kuantitas.Text + ") ";
                SqlCommand command = new SqlCommand(insertQuery, koneksi.GetCon());
                koneksi.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Barang sukses ditambahkan!", "Add Informastion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseCon();
                getTable();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            try
            {
                // Cek apakah semua TextBox terisi
                if (string.IsNullOrWhiteSpace(textBox_Id.Text) || string.IsNullOrWhiteSpace(textBox_Nama.Text) ||
                    string.IsNullOrWhiteSpace(textBox_Harga.Text) || string.IsNullOrWhiteSpace(textBox_Kuantitas.Text))
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validasi tipe data
                if (!decimal.TryParse(textBox_Harga.Text, out _) || !int.TryParse(textBox_Kuantitas.Text, out _))
                {
                    MessageBox.Show("Harga harus berupa angka desimal dan kuantitas harus berupa angka!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Query Update menggunakan parameter
                string updateQuery = "UPDATE barangGudang SET nama=@nama, harga=@harga, kuantitas=@kuantitas WHERE Id=@id";
                SqlCommand command = new SqlCommand(updateQuery, koneksi.GetCon());
                command.Parameters.AddWithValue("@id", textBox_Id.Text);
                command.Parameters.AddWithValue("@nama", textBox_Nama.Text);
                command.Parameters.AddWithValue("@harga", decimal.Parse(textBox_Harga.Text)); // Parse untuk memastikan tipe sesuai
                command.Parameters.AddWithValue("@kuantitas", int.Parse(textBox_Kuantitas.Text)); // Parse untuk memastikan tipe sesuai

                koneksi.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Barang sukses diperbarui!", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseCon();
                getTable();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Clear()
        {
            textBox_Id.Clear();
            textBox_Nama.Clear();
            textBox_Harga.Clear();
            textBox_Kuantitas.Clear();
        }
        private void button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteQuery = "DELETE FROM barangGudang WHERE Id=" + textBox_Id.Text + "";
                SqlCommand command = new SqlCommand(deleteQuery, koneksi.GetCon());
                koneksi.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Barang sukses dihapus!", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseCon();
                getTable();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_Tabel_Click(object sender, EventArgs e)
        {
            textBox_Id.Text = dataGridView_Tabel.SelectedRows[0].Cells[0].Value.ToString();
            textBox_Nama.Text = dataGridView_Tabel.SelectedRows[0].Cells[1].Value.ToString();
            textBox_Harga.Text = dataGridView_Tabel.SelectedRows[0].Cells[2].Value.ToString();
            textBox_Kuantitas.Text = dataGridView_Tabel.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void formGUI_Load(object sender, EventArgs e)
        {
            getTable();
        }

        
        private void button_Print_Click(object sender, EventArgs e)
        {
            ReportBarangV2 RB = new ReportBarangV2();
            RB.Show();

            koneksi.OpenCon();
            SqlCommand cmd = new SqlCommand("SELECT * FROM barangGudang", koneksi.GetCon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "barangGudang");
            CrystalReport1 cr1 = new CrystalReport1();
            cr1.SetDataSource(ds.Tables["barangGudang"]);
            RB.crystalReportViewer_Tampil.ReportSource = cr1;
            RB.crystalReportViewer_Tampil.Refresh();
            koneksi.CloseCon();
        }
    }
}
