using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CompE561Lab5
{
    public partial class CustomerForm : Form
    {
        private string validName;
        private string validEmail;
        private string validPhone;
        private bool newCustomer;
        private MenuForm menuInstance;
        private MySqlConnection connection;

        public CustomerForm(MenuForm menuInstance)
        {
            InitializeComponent();

            this.menuInstance = menuInstance;
            this.validName = "[^A-Za-z']";
            this.validPhone = "^((1-([(]{0-9]{3}[)]|[0-9]{3})-)[0-9]{3}-[0-9]{4})$";
            this.validEmail = "^[A-Z0-9._%+-]+@[A-Z0-9.-]+[.][A-Z]{2,4}$";
            this.newCustomer = false;
            
            //Reading data from database
            connection = new MySqlConnection("datasource = localhost; username = root; password =");
            var command = new MySqlCommand("select * from bookstore.customers", connection);

            connection.Open();

            MySqlDataReader data = command.ExecuteReader();

            while (data.Read())
                this.comboBox.Items.Add($"{data[1]} {data[2]}");

            connection.Close();
        }
        
        //Go back to main menu
        private void Back_Click(object sender, EventArgs e)
        {
            this.clear();
            this.comboBox.Enabled = true;
            this.newCustomer = false;
            this.Hide();
            this.menuInstance.Show();
        }

        //Will clear all the fileds, disable the combo box, set the focus to the first name field
        //and set a flag indicating that a new customer will be added
        private void NewCustomer_Click(object sender, EventArgs e)
        {
            this.clear();
            this.comboBox.Enabled = false;
            this.FirstName.Focus();
            this.newCustomer = true;
        }

        //Self explanatory
        private void clear()
        {
            this.FirstName.Text = "";
            this.LastName.Text = "";
            this.Address.Text = "";
            this.City.Text = "";
            this.StateBox.Text = "";
            this.Zip.Text = "";
            this.Phone.Text = "";
            this.Email.Text = "";
        }

        //Enable combo box, set new customer falg to false and clear the data fields
        private void Cancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to cancel?",
                                                    "Cancel", MessageBoxButtons.YesNo))

            { 
                this.clear();
                this.comboBox.Enabled = true;
                this.newCustomer = false;
            }
        }

        //It is going to check if the values entered are valid
        //if the new customer flag is true, create a new customer object and add it to the ArryList and combo box
        //Otherwhise, it means what an existing customer was selected and its information was changed, so the new values
        //will be saved to the corresponding costumer object.
        //The ArrayList will be saved into a text file, the combo box will be updated and enabled, the new customer flag will
        //be set to false and the data fields will be cleared.
        private void Save_Click(object sender, EventArgs e)
        {
            if(this.checkTextBoxes()) return; //If intput was invalid, don't save anything

            MySqlCommand command;
            connection.Open();

            if (newCustomer)
            {
                this.comboBox.Items.Add($"{this.FirstName.Text} {this.LastName.Text}");

                command = new MySqlCommand("INSERT INTO bookstore.customers (FName, LName, Address, City, State, Zip, Phone, Email) VALUES (@FName, @LName, @Address, @City, @State, @Zip, @Phone, @Email)", connection);
                command.Parameters.AddWithValue("@FName", this.FirstName.Text);
                command.Parameters.AddWithValue("@LName", this.LastName.Text);
                command.Parameters.AddWithValue("@Address", this.Address.Text);
                command.Parameters.AddWithValue("@City", this.City.Text);
                command.Parameters.AddWithValue("@State", this.StateBox.Text);
                command.Parameters.AddWithValue("@Zip", this.Zip.Text);
                command.Parameters.AddWithValue("@Phone", this.Phone.Text);
                command.Parameters.AddWithValue("@Email", this.Email.Text);
                command.ExecuteNonQuery();

                connection.Close();
            }
            else
            {
                command = new MySqlCommand("bookstore.sp_UpdateCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("theID", comboBox.SelectedIndex + 1);
                command.Parameters.AddWithValue("newFName", this.FirstName.Text);
                command.Parameters.AddWithValue("newLName", this.LastName.Text);
                command.Parameters.AddWithValue("newAddress", this.Address.Text);
                command.Parameters.AddWithValue("newCity", this.City.Text);
                command.Parameters.AddWithValue("newState", this.StateBox.Text);
                command.Parameters.AddWithValue("newZip", this.Zip.Text);
                command.Parameters.AddWithValue("newPhone", this.Phone.Text);
                command.Parameters.AddWithValue("newEmail", this.Email.Text);
                command.ExecuteNonQuery();

                connection.Close();
            }

            this.comboBox.Enabled = true;
            this.newCustomer = false;
            this.clear();
        }

        //Used to make sure that the inputs are valid
        private bool checkTextBoxes()
        {
            if (this.FirstName.Text == "" || Regex.IsMatch(this.FirstName.Text, validName))
            {
                MessageBox.Show("Please enter a first name");
                this.FirstName.Focus(); return true;
            } else
            if(this.LastName.Text == "" || Regex.IsMatch(this.LastName.Text, validName))
            {
                MessageBox.Show("Please enter a last name");
                this.LastName.Focus(); return true;
            }
            else
            if (this.Address.Text == "")
            {
                MessageBox.Show("Please enter an address");
                this.Address.Focus(); return true;
            }
            else
            if (this.City.Text == "")
            {
                MessageBox.Show("Please enter a city");
                this.City.Focus(); return true;
            }
            else
            if (this.StateBox.Text == "")
            {
                MessageBox.Show("Please enter a state");
                this.StateBox.Focus(); return true;
            }
            else
            if (this.Zip.Text == "")
            {
                MessageBox.Show("Please enter a zip");
                this.Zip.Focus(); return true;
            }
            else
            if (this.Phone.Text == "" || Regex.IsMatch(this.Phone.Text, validPhone))
            {
                MessageBox.Show("Please enter a phone number");
                this.Phone.Focus(); return true;
            }
            else
            if (this.Email.Text == "" || Regex.IsMatch(this.Email.Text, validEmail))
            {
                MessageBox.Show("Please enter an email");
                this.Email.Focus(); return true;
            }

            return false;
        }

        //When a customer is selected from the comboBox, display all its information to enable editing
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            try { index = comboBox.SelectedIndex; }
            catch (ArgumentOutOfRangeException E) { return; }

            var command = new MySqlCommand($"select * from bookstore.customers WHERE customers.ID = {index + 1}", connection);

            connection.Open();

            MySqlDataReader data = command.ExecuteReader();

            data.Read();

            this.FirstName.Text = data[1].ToString();
            this.LastName.Text = data[2].ToString();
            this.Address.Text = data[3].ToString();
            this.City.Text = data[4].ToString();
            this.StateBox.Text = data[5].ToString();
            this.Zip.Text = data[6].ToString();
            this.Phone.Text = data[7].ToString();
            this.Email.Text = data[8].ToString();

            connection.Close();
        }
        
        //When user closes customer form, go back to main menu
        protected override void OnClosed(EventArgs e)
        {
            this.Hide();
            menuInstance.Show();
            return;
        }
    }
}
