using System;
using System.Windows;
using System.Windows.Controls;
using EveryThingAssist_GUI.Class.APP;

namespace EveryThingAssist_GUI.Pages
{
    public partial class ConsolePage : Page
    {
        Python_Sync pS = new Python_Sync();
        public ConsolePage()
        {
            InitializeComponent();
            pS.OutputUpdated += UpdateLabel;
            pS.Process_Start();
        }

        private void UpdateLabel(string UpdatedOutput)
        {
            Dispatcher.Invoke(() =>
            {
                    ListBoxItem newItem = new ListBoxItem();
                    newItem.Content = UpdatedOutput;
                    consoleListBox.Items.Add(newItem);

                    if (consoleListBox.Items.Count >0)
                    {
                        var lastItem = consoleListBox.Items[consoleListBox.Items.Count - 1];
                        consoleListBox.ScrollIntoView(lastItem);
                    }
            });
        }

        private void InputTextButton_OnClick(object sender, RoutedEventArgs e)
        {
            string inputData = InputTextBlock.Text;
            
            ListBoxItem newItem = new ListBoxItem();
            newItem.Content = inputData;
            consoleListBox.Items.Add(newItem);
            
            pS.SendInput(inputData);
            
            
            InputTextBlock.Text = null;
        }
    }
}