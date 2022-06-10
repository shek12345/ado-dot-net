using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ado_dot_net
{
    public partial class Form4 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder scb;
        public Form4()
        {
            InitializeComponent();
            string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con = new SqlConnection(strConnection);
        }
        private DataSet GetemployeeData()
        {
            da = new SqlDataAdapter("select * from employee", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            scb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "employee");
            return ds;
        }

            private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetemployeeData();
                DataRow row = ds.Tables["employee"].NewRow();
                row["id"] = txtid.Text;
                row["Name"] = txtemployeename.Text;
                row["salary"] = txtsalary.Text;
                ds.Tables["employee"].Rows.Add(row);
                int result = da.Update(ds.Tables["employee"]);
                if (result == 1)
                {
                    MessageBox.Show("data inserted");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetemployeeData();
                DataRow row = ds.Tables["employee"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    row["Name"] = txtemployeename.Text;
                    row["salary"] = txtsalary.Text;
                    int result = da.Update(ds.Tables["employee"]);



                    if (result == 1)
                    {
                        MessageBox.Show("data updated");
                    }


                    else
                    {
                        MessageBox.Show("id does not exixts to update");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetemployeeData();
                DataRow row = ds.Tables["employee"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    row.Delete();
                    int result = da.Update(ds.Tables["employee"]);



                    if (result == 1)
                    {
                        MessageBox.Show("data updated");
                    }


                    else
                    {
                        MessageBox.Show("id does not exixts to update");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetemployeeData();
                DataRow row = ds.Tables["employee"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    txtemployeename.Text = row["name"].ToString();
                    txtsalary.Text = row["salary"].ToString();

                }
                else
                {
                    MessageBox.Show("record does not exixt");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnshoeallemployess_Click(object sender, EventArgs e)
        {
            ds = GetemployeeData();
            dataGridView1.DataSource = ds.Tables["employee"];
        }
    }
}
    
    


