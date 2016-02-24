using System.Windows;
using WPFApplication;

namespace XamlApp
{
    public partial class MainWindow : Window
    {
        TlSharpCl t = new TlSharpCl();


        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            t.AuthUser();
        }


        private async void Button_Click2(object sender, RoutedEventArgs e)
        {

            string text = textBox1.Text;
            if (text != "")
            {
                await t.EnterCode(text);
            }
        }


    }
}