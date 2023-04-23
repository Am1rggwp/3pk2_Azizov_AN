using Newtonsoft.Json;
using PZ_11;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string jsonFile = "BookCol.json";
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new BookViewModel();
            if (File.Exists(jsonFile))
            {
                var json = File.ReadAllText(jsonFile);
                var bookList = JsonConvert.DeserializeObject<ObservableCollection<Book>>(json);
                List<String> IsData = new List<String>();
                for (int i = 0; i < bookList.Count; i++)
                {
                    IsData.Add($"Название: {bookList[i].NameBook}; Имя Автора: {bookList[i].Auvtor}; Дата Издания: {bookList[i].YearIssue};");
                    lst1.ItemsSource = IsData;
                }
            }
        }

        
    }
}
