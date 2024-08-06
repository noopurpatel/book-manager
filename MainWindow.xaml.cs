using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MidTerm991667498NoopurPatel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Book> books = new List<Book>();

        public MainWindow()
        {
            InitializeComponent();
            CategoryComboBox.SelectedIndex = 0;
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow(books);
            addBookWindow.ShowDialog();
            RefreshBookList();
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            if (BookListBox.SelectedItem != null)
            {
                Book selectedBook = (Book)BookListBox.SelectedItem;
                AddBookWindow editBookWindow = new AddBookWindow(books, selectedBook);
                editBookWindow.ShowDialog();
                RefreshBookList();
            }
            else
            {
                MessageBox.Show("Please select a book to edit.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (BookListBox.SelectedItem != null)
            {
                Book selectedBook = (Book)BookListBox.SelectedItem;
                books.Remove(selectedBook);
                RefreshBookList();
            }
            else
            {
                MessageBox.Show("Please select a book to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ViewBooks_Click(object sender, RoutedEventArgs e)
        {
            RefreshBookList();
        }

        private void RefreshBookList()
        {
            BookListBox.Items.Clear();
            string selectedCategory = ((ComboBoxItem)CategoryComboBox.SelectedItem)?.Content.ToString();

            var filteredBooks = books.Where(b => b.GetCategory() == selectedCategory).ToList();
            foreach (var book in filteredBooks)
            {
                BookListBox.Items.Add(book);
            }
        }
    }
}
