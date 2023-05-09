using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Ink;
using Path = System.IO.Path;

namespace pz_kr
{
    public partial class MainWindow : Window
    {
        public TxtViewModel TxtViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = TxtViewModel;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            CanvasImage cnv1 = new CanvasImage();
            CanvasTXT cnv2 = new CanvasTXT();
            if (MessageBox.Show("Выберите вид заметки (Да - Граф./ Нет - Текст.)", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                cnv2.Show();
            }
            else
            {
                cnv1.Show();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            File.Delete($"{lV.SelectedItem.ToString()}");
        }

        private void SelectNote(object sender, RoutedEventArgs e)
        {
            if (lV.SelectedValue.ToString().Contains(".gif"))
            {
                CanvasImage ni = new CanvasImage();
                ni.Show();
                FileStream fs = File.Open($"{lV.SelectedItem.ToString()}", FileMode.Open);
                StrokeCollection myStrk = new StrokeCollection(fs);
                ni.inkCanvas.Strokes = myStrk;
                fs.Close();
            }
            else
            {
                CanvasTXT tx = new CanvasTXT(lV.SelectedValue.ToString());
                tx.Show();
            }

        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            List<string> AllElements = new List<string>();

            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach (var i in files)
            {
                if (i.Contains(".txt")) AllElements.Add(Path.GetFileName(i));
                if (i.Contains(".gif")) AllElements.Add(Path.GetFileName(i));
            }
            lV.ItemsSource = AllElements;
        }
    }
}
