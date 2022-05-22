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
        OleDbConnection cn = new OleDbConnection(@" Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\user\Desktop\Soso  ");
        OleDbDataAdapter Da;
        DataTable Dt = new DataTable();
        OleDbCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
