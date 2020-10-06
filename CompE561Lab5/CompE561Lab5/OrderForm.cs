//Programmer: Joseph Morga
//RedID: 817281186
//File Name: Form1.cs
//Date:02/11/2019

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

namespace CompE561Lab5
{
    public partial class OrderForm : Form
    {
        private ArrayList library;  //ArrayList to save book objects
        private string fileName;
        private string orderName;
        private string customerFileName;
        private bool orderComplete;
        private ArrayList customer;
        private string currentCustomer;
        private MenuForm menuInstance;
        public OrderForm(MenuForm menuInstance)
        {
            InitializeComponent();

            this.menuInstance = menuInstance;
            fileName = "book.txt";
            orderName = "order.txt";
            customerFileName = "customer.txt";
            orderComplete = true;

            var book = new Book();

            library = this.getLibrary();              //Adding books to arrayList and comboBox

            if (library == null)                      //If library is null, add the 3 hard coded books into the arrayList
            {
                library = new ArrayList();
                library.Add(book.getHardCodedBook1());
                library.Add(book.getHardCodedBook2());
                library.Add(book.getHardCodedBook3());
            }

            foreach(Book theBook in library)
                this.masterBox.Items.Add(theBook);

            File.Delete(orderName);     //Delete receipt from previous transaction

            customer = getCustomer();  //Get array list of customers from text file

            if (customer == null) customer = new ArrayList();  //if file doesnt exist or it's empty, create a new array list

            else
                foreach (Customer temp in customer)  //Add customers to combo box
                    this.customerCombo.Items.Add(temp);
        }

        //When an item is selected in the comboBox, the information of the item will be
        //displayed in the corresponding text box.
        private void masterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book book;
            try
            {
                book = (Book)library[masterBox.SelectedIndex];

                this.authorText.Text = book.getAuthor();
                this.isbnText.Text = book.getISBN();
                this.PriceText.Text = $"${book.getPrice()}";
            }
            catch (ArgumentOutOfRangeException E) { return; }
        }

        //When this button is clicked, the dataGridView will be filled with the information of
        //the item selected in the comboBox and the quantities wanted. It also displays the amount due.
        private void addButton_Click(object sender, EventArgs e)
        {
            int quantity;

            Customer dummy;
            try
            {
                dummy = (Customer)customer[customerCombo.SelectedIndex];
            }
            catch (ArgumentOutOfRangeException E)
            {
                MessageBox.Show("Please choose a customer");
                this.customerCombo.Focus();
                return;
            }

            if (!orderComplete && !this.currentCustomer.Equals(dummy.ToString()))
            {
                MessageBox.Show("Please complete the order before changing customer");
                this.Confirmation.Focus();
                return;
            }

            if (orderComplete)
            {
                try
                {
                    dummy = (Customer)customer[customerCombo.SelectedIndex];

                    currentCustomer = dummy.ToString();
                }
                catch (ArgumentOutOfRangeException E)
                {
                    MessageBox.Show("Please choose a customer");
                    this.customerCombo.Focus();
                    return;
                }
                FileStream stream = new FileStream(orderName, FileMode.Append);

                var write = new StreamWriter(stream);
                write.WriteLine("-------------------------------------------");
                write.WriteLine($"Customer: {currentCustomer}\n");
                write.Dispose();
                orderComplete = false;
            }

            Book book;

            try
            {
                book = (Book)library[masterBox.SelectedIndex];
                quantity = Convert.ToInt32(this.quantityText.Text);
            }
            catch (FormatException E)   //When no quantity provided, ask to enter one
            {
                quantity = 0; book = null;

                MessageBox.Show("Please enter a quantity.");
                this.quantityText.Focus();
            }
            catch (ArgumentOutOfRangeException E) //When no book selected, ask to choose one
            {
                quantity = 0; book = null;

                MessageBox.Show("Please select a title.");
                this.masterBox.Show();
            }
            if(quantity == 0)
            { 
                MessageBox.Show("Please enter a quantity.");
                this.quantityText.Focus();
            }

            if (quantity != 0 && book != null)  //Set payment information
            {
                this.dataGrid.Rows.Add(book.getTitle(), $"${book.getPrice()}", quantity, $"${Convert.ToDouble(book.getPrice()) * quantity}");
                this.setCheckout(quantity * Convert.ToDouble(book.getPrice()));

                FileStream stream = new FileStream(orderName, FileMode.Append);  //Adding order to receipt
                var write = new StreamWriter(stream);

                if(!orderComplete)


                write.WriteLine($"Title: {book.getTitle()}\nPrice: ${Convert.ToDouble(book.getPrice())} Quantity: {quantity}\n");
                write.Dispose();
            }
        }
        
        private void Confirmation_Click(object sender, EventArgs e)
        {
            if (this.dataGrid.RowCount <= 0)
                MessageBox.Show("Please add a book to the shopping cart.");
            else
            {
                MessageBox.Show("Thank you for shopping without entering your credit card information," +
                                "\nyour order will be delivered soon to the address you did not provide");

                this.saveOrder();
                this.reset();
                this.orderComplete = true;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to cancel yout order?",
                                                    "Cancel Order", MessageBoxButtons.YesNo))
                this.reset();
        }

        //Displays the amount due
        private void setCheckout(double subtotal)
        {
            if (this.subtotalText.Text.Equals(""))
                this.subtotalText.Text = "0";
            
            subtotal += Convert.ToDouble(this.subtotalText.Text.Replace("$", ""));

            this.subtotalText.Text = $"${subtotal}";
            this.taxtBox.Text = $"${Convert.ToDouble(this.subtotalText.Text.Replace("$", "")) * 0.1}";
            this.totalText.Text = $"${(Convert.ToDouble(this.subtotalText.Text.Replace("$", "")) * 0.1) + Convert.ToDouble(this.subtotalText.Text.Replace("$", ""))}";
        }

        //Sets all values to default
        private void reset()
        {
            this.authorText.Text = "";
            this.isbnText.Text = "";
            this.PriceText.Text = "";
            this.quantityText.Text = "";
            this.subtotalText.Text = "";
            this.taxtBox.Text = "";
            this.totalText.Text = "";
            this.dataGrid.Rows.Clear();
            this.masterBox.SelectedIndex = -1;
        }

        //When user closes order form, go back to main menu
        protected override void OnClosed(EventArgs e)
        {
            this.saveLibrary(this.library);  //Save ArrayList library before closing the form
            this.Hide();
            menuInstance.Show();
            return;
        }

        //Adds the total amount due into order.txt
        public void saveOrder()
        {
            FileStream stream = new FileStream(orderName, FileMode.Append);
            var write = new StreamWriter(stream);

            write.WriteLine($"Subtotal: {this.subtotalText.Text} Tax: {this.taxtBox.Text} Total: {this.totalText.Text}\n");

            write.Dispose();
        }

        //Returns arrayList of Book objects if it exist, null otherwise
        public ArrayList getLibrary()
        {
            ArrayList library = null;

            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                library = (ArrayList)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (FileNotFoundException e) { return null; }

            return library;
        }

        //Saves the current instance of ArrayList of Book objects into book.txt
        public void saveLibrary(ArrayList library)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, library);
            stream.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.saveLibrary(this.library);
            this.Hide();
            this.menuInstance.Show();
        }

        //Will open the customer.txt file and obtain the saved ArrayList from it and return it, if the file does not exist
        //or the file is empty, it will return null
        private ArrayList getCustomer()
        {
            ArrayList temp = null;

            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(customerFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                temp = (ArrayList)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (FileNotFoundException e) { return null; }

            return temp;
        }
    }
}
