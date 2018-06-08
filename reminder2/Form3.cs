using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace reminder2
{
    public partial class Form3 : Form

    {
        string task, time;
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HP\Documents\d_reminder.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public Form3()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            var curdt = DateTime.Now.ToString("MM-dd-yyyy");
            cmd.CommandText = "select task, time from Table2 where date='" + curdt + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
            task = dataGridView1.SelectedRows[0].Cells["task"].Value.ToString();
            time = dataGridView1.SelectedRows[0].Cells["time"].Value.ToString();
        }
        public void disp_data1()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            var curdt = DateTime.Now.ToString("MM-dd-yyyy");
            cmd.CommandText = "select task, time from Table2 where date='" + dateTimePicker1.Value.ToString("MM-dd-yyyy") + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Table2 where time='" + time + "'and task='" + task + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data1();
            MessageBox.Show("DELETED");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select task, time from Table2 where date='" + dateTimePicker1.Value.ToString("MM-dd-yyyy") + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
