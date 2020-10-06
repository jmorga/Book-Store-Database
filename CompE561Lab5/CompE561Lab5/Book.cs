//Programmer: Joseph Morga
//RedID: 817281186
//File Name: Book.cs
//Date:02/05/2019

using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CompE561Lab5
{
    [System.Serializable]
    class Book
    {
        private string Author;
        private string ISBN;
        private string Title;
        private string Price;

        public Book()  //Default book
        {
            this.Author = "Ceddy Abner II Miller";
            this.ISBN = "0123456789";
            this.Title = "How to waste time efficiently";
            this.Price = "104.99";
        }

        public Book(string Author, string ISBN, string Title, string Price)
        {
            this.Author = Author;
            this.ISBN = ISBN;
            this.Title = Title;
            this.Price = Price;
        }

        //---------- Accessor Methods ----------

        public string getAuthor() => Author;
        public string getISBN() => ISBN;
        public string getTitle() => Title;
        public string getPrice() => Price;

        //---------- Mutator Methods ----------

        public void setPrice(string Price) { this.Price = Price; }
        public void setTitle(string title) { this.Title = title; }
        public void setAuthor(string author) { this.Author = author; }
        public void setISBN(string ISBN) { this.ISBN = ISBN; }

        //-------------------------------------
        public override string ToString() { return this.Title;  }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Book temp;
            try
            {
                temp = (Book)obj;
            }
            catch (InvalidCastException e) { return false; }

            return this.Author.Equals(temp.getAuthor()) && this.Title.Equals(temp.getTitle()) &&
                   this.ISBN.Equals(temp.getISBN()) && this.Price.Equals(temp.getPrice());
        }

        //---------- Methods to return the 3 hard coded books ----------
        public Book getHardCodedBook1() { return new Book(); }

        public Book getHardCodedBook2() { return new Book("A. M. Zagoskin", "9780521113684","Quantum engineering", "499.99"); }

        public Book getHardCodedBook3() { return new Book("Stephen J. Blundell", "9780199562091", "Concepts in Thermal Physics", "199.99"); }
    }
}
