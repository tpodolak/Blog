using System;
using System.Windows;
using AudioLib.Proxies;

namespace AudioLib.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var client = new AudioClientProxy();
            var result = client.GetPlaylist(Guid.NewGuid().ToString());
            MessageBox.Show(result.Name);
        }
    }
}
