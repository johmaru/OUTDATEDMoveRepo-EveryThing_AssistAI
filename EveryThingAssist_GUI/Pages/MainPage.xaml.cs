using System;
using System.Windows;
using System.Windows.Controls;

namespace EveryThingAssist_GUI.Pages
{
    /// <summary>
    /// MainPage.xaml の相互作用ロジック
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ConsoleTXT_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ConsolePage());
        }
    }
}
