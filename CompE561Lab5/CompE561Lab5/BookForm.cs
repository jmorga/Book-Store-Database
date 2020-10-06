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
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CompE561Lab5
{
    public partial class BookForm : Form
    {
        private MenuForm menuInstance;
        private bool newBook;
        private MySqlConnection connection;
        public BookForm(MenuForm currentMenuInstance)
        {
            InitializeComponent();

            menuInstance = currentMenuInstance;
            this.newBook = false;

            //Reading data from database
            connection = new MySqlConnection("datasource = localhost; username = root; password =");
            var command = new MySqlCommand("select * from bookstore.books", connection);

            connection.Open();

            MySqlDataReader data = command.ExecuteReader();

            while (data.Read())
                this.comboBook.Items.Add(data[1]);

            connection.Close();
        }

        //Go back to main menu
        private void back_Click(object sender, EventArgs e)
        {
            this.clear();
            this.comboBook.Enabled = true;
            this.newBook = false;

            this.Hide();
            this.menuInstance.Show();
        }

        //Will clear all the fileds, disable the combo box, set the focus to the title field
        //and set a flag indicating that a new book will be added
        private void newBook_Click(object sender, EventArgs e)
        {
            this.clear();
            this.comboBook.Enabled = false;
            this.Title.Focus();
            this.newBook = true;
        }

        //if the new book flag is true, create a new book object and add it to the ArryList and combo box
        //Otherwhise, it means that an existing book was selected and its information was changed, so the new values
        //will be saved to the corresponding book object.
        //The ArrayList will be saved into a text file, the combo box will be updated and enabled, the new book flag will
        //be set to false and the data fields will be cleared.
        private void save_Click(object sender, EventArgs e)
        {
            if (checkEmptyBox()) return;
            
            MySqlCommand command;
            connection.Open();

            if (newBook)
            {
                this.comboBook.Items.Add(this.Title.Text);

                command = new MySqlCommand("INSERT INTO bookstore.books (Title, Author, ISBN, Price) VALUES (@Title, @Author, @ISBN, @Price)", connection);
                command.Parameters.AddWithValue("@Title", this.Title.Text);
                command.Parameters.AddWithValue("@Author", this.Author.Text);
                command.Parameters.AddWithValue("@ISBN", this.ISBN.Text);
                command.Parameters.AddWithValue("@Price", this.Price.Text);
                command.ExecuteNonQuery();

                connection.Close();
            }
            else
            {
                command = new MySqlCommand("bookstore.sp_UpdateBook", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("newTitle", this.Title.Text);
                command.Parameters.AddWithValue("newAuthor", this.Author.Text);
                command.Parameters.AddWithValue("theISBN", this.ISBN.Text);
                command.Parameters.AddWithValue("newPrice", this.Price.Text);
                command.ExecuteNonQuery();

                connection.Close();
            }

            //this.saveState();
            this.comboBook.Enabled = true;
            this.newBook = false;
            this.clear();
        }

        //Enable combo box, set new customer falg to false and clear the data fields
        private void cancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to cancel?",
                                                    "Cancel", MessageBoxButtons.YesNo))

            {
                this.clear();
                this.comboBook.Enabled = true;
                this.newBook = false;
            }
        }

        //When a book is selected from the comboBox, display all its information to enable editing
        private void comboBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            try { index = comboBook.SelectedIndex; }
            catch (ArgumentOutOfRangeException E) { return; }

            var command = new MySqlCommand($"select * from bookstore.books WHERE books.ID = {index + 1}", connection);

            connection.Open();

            MySqlDataReader data = command.ExecuteReader();

            data.Read();

            this.Title.Text = data[1].ToString();
            this.Author.Text = data[2].ToString();
            this.ISBN.Text = data[3].ToString();
            this.Price.Text = data[4].ToString();

            connection.Close();
        }

        //returns true if any text boox contains empty string, false otherwise
        private bool checkEmptyBox()
        {
            if(this.Title.Text.Equals(""))
            {
                MessageBox.Show("Please enter a title");
                this.Title.Focus(); return true;
            }else
            if (this.Author.Text.Equals(""))
            {
                MessageBox.Show("Please enter an author");
                this.Author.Focus(); return true;
            }
            else
            if (this.ISBN.Text.Equals(""))
            {
                MessageBox.Show("Please enter an ISBN");
                this.ISBN.Focus(); return true;
            }
            else
            if (this.Price.Text.Equals(""))
            {
                MessageBox.Show("Please enter a price");
                this.Price.Focus(); return true;
            }

            return false;
        }

        private void clear()
        {
            this.Title.Text = "";
            this.Author.Text = "";
            this.ISBN.Text = "";
            this.Price.Text = "";
        }

        //When user closes book form, go back to main menu
        protected override void OnClosed(EventArgs e)
        {
            this.Hide();
            menuInstance.Show();
            return;
        }
    }
}
