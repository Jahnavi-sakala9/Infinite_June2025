using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{   
    //(Third question)
    //Create a class called Books with BookName and AuthorName as members.Instantiate the class through constructor and also write a method Display() to display the details.
    //Create an Indexer of Books Object to store 5 books in a class called BookShelf.Using the indexer method assign values to the books and display the same.
    //Hint(use Aggregation/composition)
    class Book
    {
        public string BookName;
        public string AuthorName;
        public Book(string BookName, string AuthorName)
        {
            this.BookName = BookName;
            this.AuthorName = AuthorName;
        }
        public void Display()
        {
            Console.WriteLine($"Book: {BookName}, Author: {AuthorName}");
        }
    }
    class BookShelf
    {
        private Book[] books = new Book[5];
        public Book this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }
        public void DisplayBooks()
        {
            Console.WriteLine("Books on the shelf: ");
            for(int i = 0; i < books.Length; i++)
            {
                if (books[i] != null)
                    books[i].Display();
                else
                    Console.WriteLine($"Slot {i + 1} is empty.");
            }
        }
        public static void Main()
        {
            BookShelf shelf = new BookShelf();
            shelf[0] = new Book("Wings of Fire", "A.P.J Abdul Kalam");
            shelf.DisplayBooks();
        }
    }
}
