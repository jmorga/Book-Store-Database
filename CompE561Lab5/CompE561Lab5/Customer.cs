using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompE561Lab5
{
    [System.Serializable]
    internal class Customer
    {
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private string zip;
        private string phone;
        private string email;

        public Customer(string firstName, string lastName, string address, string city, string state, string zip, string phone, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phone = phone;
            this.email = email;
        }
        
        public string getFirstName() => this.firstName;
        public string getLastName() => this.lastName;
        public string getAddress() => this.address;
        public string getCity() => this.city;
        public string getState() => this.state;
        public string getZip() => this.zip;
        public string getPhone() => this.phone;
        public string getEmail() => this.email;

        public void setFirstName(string firstName) { this.firstName = firstName; }
        public void setLastName(string lastName) { this.lastName = lastName; }
        public void setAddress(string address) { this.address = address; }
        public void setCity(string city) { this.city = city; }
        public void setState(string state) { this.state = state; } 
        public void setZip(string zip) { this.zip = zip; }
        public void setEmail(string email) { this.email = email; }
        public void setPhone(string phone) { this.phone = phone; }
 
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Customer temp;
            try
            {
                temp = (Customer)obj;
            }
            catch (InvalidCastException e) { return false; }

            return this.firstName.Equals(temp.getFirstName()) && this.lastName.Equals(temp.getLastName()) &&
                   this.address.Equals(temp.getAddress()) && this.city.Equals(temp.getCity()) &&
                   this.state.Equals(temp.getState()) && this.zip.Equals(temp.getZip()) &&
                   this.email.Equals(temp.getEmail()) && this.phone.Equals(temp.getPhone());
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"{this.firstName} {this.lastName}";
        }
    }
}
