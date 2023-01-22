using System;
using System.Windows;

namespace Exercise2
{
    public partial class MainWindow : Window
    {

        private IStudentAdministration _administration;
        public MainWindow(IStudentAdministration administration, IBlackBoard blackBoard)
        {
            InitializeComponent();
            _administration = administration;
            blackBoard.SubscribeToStudentAdministrationEvents(administration, blackBoardTextBlock);
        }

        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var firstName = firstNameTextBox.Text;
            var lastName = lastNameTextBox.Text;
            var department = departmentTextBox.Text;
            Student student = new Student(firstName, lastName, department);
            _administration.RegisterStudent(student);
        }
    }
}
