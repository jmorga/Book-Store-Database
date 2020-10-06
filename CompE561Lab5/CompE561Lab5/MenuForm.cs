using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompE561Lab5
{
    public partial class MenuForm : Form
    {
        BookForm bookInstance;
        CustomerForm customerInstance;
        OrderForm orderInstance;
        public MenuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customerInstance = new CustomerForm(this);
            this.customerInstance.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bookInstance = new BookForm(this);
            this.bookInstance.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            orderInstance = new OrderForm(this);
            this.orderInstance.Show();
            this.Hide();
        }
    }
}
