﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MidTerm991667498NoopurPatel
{
    /// <summary>
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        private List<Book> books;
        private Book editingBook;

        public AddBookWindow(List<Book> books, Book bookToEdit = null)
        {
            InitializeComponent();
            this.books = books;
            this.editingBook = bookToEdit;

            if (editingBook != null)
            {
                TitleTextBox.Text = editingBook.Title;
                AuthorTextBox.Text = editingBook.Author;
                YearTextBox.Text = editingBook.PublicationYear.ToString();
                PriceTextBox.Text = editingBook.Price.ToString();

                if (editingBook is FictionBook)
                    FictionRadioButton.IsChecked = true;
                else if (editingBook is NonFictionBook)
                    NonFictionRadioButton.IsChecked = true;
                else if (editingBook is ReferenceBook)
                    ReferenceRadioButton.IsChecked = true;

                this.Title = "Edit Book";
            }
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string author = AuthorTextBox.Text;
            int publicationYear = int.Parse(YearTextBox.Text);
            decimal price = decimal.Parse(PriceTextBox.Text);

            Book newBook = null;

            if (FictionRadioButton.IsChecked == true)
            {
                newBook = new FictionBook(title, author, publicationYear, price);
            }
            else if (NonFictionRadioButton.IsChecked == true)
            {
                newBook = new NonFictionBook(title, author, publicationYear, price);
            }
            else if (ReferenceRadioButton.IsChecked == true)
            {
                newBook = new ReferenceBook(title, author, publicationYear, price);
            }

            if (newBook != null)
            {
                if (editingBook != null)
                {
                    books.Remove(editingBook);
                }
                books.Add(newBook);

                MessageBox.Show(editingBook == null ? "Book added successfully!" : "Book edited successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a book category.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
