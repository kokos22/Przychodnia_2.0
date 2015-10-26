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
using System.Windows.Shapes;

namespace Przychodnia
{
    /// <summary>
    /// Interaction logic for OknoLogowania.xaml
    /// </summary>
    public partial class OknoLogowania : Window
    {
        bool zalogowany = false;
        public OknoLogowania()
        {
            InitializeComponent();
        }

        private void btnZaloguj_Click(object sender, RoutedEventArgs e)
        {
            zalogowany = true;
            //TworzenieZapytan.
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!zalogowany) { e.Cancel = true; }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
