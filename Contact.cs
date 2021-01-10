using Proiect_ContactForm.ContactClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proiect_ContactForm
{
    public partial class Contact : Form
    {
        public Contact()
        {
            InitializeComponent();
        }
        ContactClass c = new ContactClass();
       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblContactID_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //get the value from the input fields
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNo = txtBoxContactNumber.Text;
            c.Address = txtboxaddress.Text;
            c.Gender = cmbgender.Text;

            //inserting data into DB using the method we created in previous episode
            bool success = c.Insert(c);
            if(success==true)
            {
                //sucessfully inserted
                MessageBox.Show("New Contact Successfully Inserted");
                //call the method here
                Clear();
            }
            else
            {
                //Failed to add contact
                MessageBox.Show("Failed to add New Contact.Try Again.");
                
            }

            //Load Data on Data GridView 

            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;

        }

        private void Contact_Load(object sender, EventArgs e)
        {
            //Load Data on Data GridView

            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        //Method to Clear Fields

        public void Clear()
        {
            txtboxFirstName.Text = "";
            txtboxLastName.Text = "";
            txtBoxContactNumber.Text = "";
            txtboxaddress.Text = "";
            cmbgender.Text = "";
            txtboxContactID.Text = "";

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //get the data from textboxes
            c.ContactID = int.Parse(txtboxContactID.Text);
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNo = txtBoxContactNumber.Text;
            c.Address = txtboxaddress.Text;
            c.Gender = cmbgender.Text;

            //Update Data in DB
            bool success = c.Update(c);
            if (success == true)
            {
                //Update Successfully
                MessageBox.Show("Contact has been successfully updated!");
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                //call Clear Method
                Clear();
            }
            else
            {
                //Failed to Update
                MessageBox.Show("Failed to Update Contact.Try Again.");
            }

             }

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //get the data DataGrid View and Load it to the textboxes respectively
            //identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            txtboxContactID.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            txtboxFirstName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            txtboxLastName.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            txtBoxContactNumber.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            txtboxaddress.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            cmbgender.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Call Clear Method here
            Clear();
        }

        private void btndelete3_Click(object sender, EventArgs e)
        {
            //Get Data from The text Box
            c.ContactID = Convert.ToInt32(txtboxContactID.Text);
            bool success = c.Delete(c);
            if (success == true)
            {
                //Successfully Deleted
                MessageBox.Show("Contact Successfully deleted.");
                //refresh the DataGrid View
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                //Call the Clear Method
                Clear();
            }
            else
            {
                //Failed to delete
                MessageBox.Show("Failed to delete contact.Try Again.");

            }
        }

        static string myconnstr = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            // Get the value from the textbox
            string keyword = txtboxSearch.Text;

            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT *FROM Contact WHERE FirstName Like '%" + keyword + "%' OR LastName LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvContactList.DataSource = dt;
        }
    }
}
