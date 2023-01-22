using System;
using System.Windows.Controls;
using Microsoft.Win32;

namespace Exercise2
{
    public class BlackBoard : IBlackBoard
    {
        public void SubscribeToStudentAdministrationEvents(IStudentAdministration administration, TextBlock outputTextBlock)
        {
            administration.NewStudentEvent += (sender, args) => outputTextBlock.Text += $"{args.Student.FirstName} {args.Student.LastName} {args.Student.Department}";
        }
    }
}
