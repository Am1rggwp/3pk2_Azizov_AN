using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Input;
using WpfApp1;

namespace PZ_11
{
    class BookViewModel
    {
        public ObservableCollection<Book> Books { get; set; }
        private string jFile = "BookCol.json";
        public ICommand AddBoCom { get; set; }

        private void SaveBook()
        {
            var json = JsonConvert.SerializeObject(Books);
            File.AppendAllText(jFile, json);
        }
        private void LoadBook()
        {
            if (File.Exists(jFile))
            {
                var json = File.ReadAllText(jFile);
                var bookList = JsonConvert.DeserializeObject<ObservableCollection<Book>>(json);
                Books = bookList;
            }
        }
        private void AddBook(string bookTitle, string year, string author)
        {
            Books.Add(new Book(bookTitle, year, author));
            SaveBook();
        }
        public BookViewModel()
        {
            Books = new ObservableCollection<Book>();
            LoadBook();
            AddBoCom = new RelayCommand
                ((b) =>
                {
                    var BookAdd = b as MainWindow;
                    string _title = BookAdd.name.Text;
                    string _year = BookAdd.year.Text;
                    string _author = BookAdd.autor.Text;
                    if (!string.IsNullOrEmpty(_title) && !string.IsNullOrEmpty(_year))
                    {
                        AddBook(_title, _year, _author);
                        BookAdd.name.Text = _title;
                        BookAdd.year.Text = _year;
                        BookAdd.autor.Text = _author;
                    }
                    
                });
        }



    }
}
