using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Exercise1
{
    public partial class MainWindow : Window
    {
        private const string Key1 = "PXL";
        private const string Key2 = "ForLife";
        private const bool Key3 = true;
        private const int Key4 = 2;
        private const int Key5 = 1;
        private bool _correctAnswer = false;
        private int _attemptsLeft = 4;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_OnClick(object sender, RoutedEventArgs e)
        {
            var key1Text = Key1TextBox.Text;
            var key2Password = Key2PasswordBox.Password;
            var key3IsChecked = Key3CheckBox.IsChecked;
            var key4SelectedIndex = Key4ComboBox.SelectedIndex;

            FeedbackBorder.Visibility = Visibility.Visible;

            if (
                key1Text.Equals(Key1)
                && key2Password.Equals(Key2)
                && key3IsChecked.Equals(Key3)
                && key4SelectedIndex.Equals(Key4)
                && Key5Radio2.IsChecked.Equals(true))
            {
                FeedbackTextBlock.Text = "you cracked the code";
                _attemptsLeft--;
            } else if (_attemptsLeft != 0)
            {
                FeedbackTextBlock.Text = "invalid code, " + _attemptsLeft + " attempts left";
                _attemptsLeft--;
            }
            else
            {
                FeedbackTextBlock.Text = "game over";
                SubmitButton.IsEnabled = false;
            }
        }
    }
}
