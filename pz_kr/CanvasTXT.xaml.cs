using System.Windows;

namespace pz_kr
{
    public partial class CanvasTXT : Window
    {
        public CanvasTXT(string t)
        {
            InitializeComponent();
            this.DataContext = t;
            TxtViewModel tx = new TxtViewModel();
            tb2.Text = tx.LoadText();

        }
        public CanvasTXT()
        {
            InitializeComponent();
            this.DataContext = new TxtViewModel();
        }
    }
}