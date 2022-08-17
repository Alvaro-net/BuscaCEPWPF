using Flurl;
using Flurl.Http;
using MaterialDesignThemes.Wpf;
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

namespace BuscaCEPWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            progressBar.Visibility = Visibility.Visible;
        }
        private async void pesquisar_Click(object sender, RoutedEventArgs e) => BuscaCep();

        private async void BuscaCep()
        {
            //https://viacep.com.br/ws/01001000/json
            DialogHost.Show(pesquisar.CommandParameter, "progressBar");
            DataContext = await "https://viacep.com.br"
                .AppendPathSegment("ws")
                .AppendPathSegment(pesquisa.Text)
                .AppendPathSegment("json")
                .WithAutoRedirect(false)
                //.ProgresBar()
                .GetJsonAsync<Response>();
            if (DialogHost.IsDialogOpen("progressBar")) DialogHost.Close("progressBar");
        }
    }
}
