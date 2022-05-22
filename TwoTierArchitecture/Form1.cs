using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace TwoTierArchitecture
{
    public partial class Form1 : Form
    {
        OleDbConnection cn = new OleDbConnection(@" Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\user\Desktop\Soso\TwoTierArchitecture\reservation.accdb ");
        OleDbDataAdapter Da;
        DataTable Dt = new DataTable();
        OleDbCommand cmd;

        public Form1()
        {
            InitializeComponent();
            FillDatagridView();
        }
        void FillDatagridView()
        {
            Dt.Clear();
            Da = new OleDbDataAdapter("Select * From info", cn);
            Da.Fill(Dt);
            dataGridView1.DataSource = Dt;

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand("Insert Into info Values('" + textBox1.Text + "','" + textBox2.Text + "','" + Convert.ToInt32(textBox3.Text) + "','" + Convert.ToInt32(textBox4.Text) + "')", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            FillDatagridView();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            MessageBox.Show("Added Successfully ", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand("Delete From info WHERE ID =?", cn);
            cmd.Parameters.Add("Param1", OleDbType.Integer).Value = textBox1.Text;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            FillDatagridView();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            MessageBox.Show("Deleted Successfully ", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand("Update info set FullName ='"+textBox2.Text+"', PhoneNo ='"+Convert.ToInt32(textBox3.Text)+ "',ReservationNo ='" + Convert.ToInt32(textBox4.Text) + "'Where ID =@id",cn);
            cmd.Parameters.Add("id", OleDbType.Integer).Value = textBox1.Text;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            FillDatagridView();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            MessageBox.Show("Updated Successfully ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
