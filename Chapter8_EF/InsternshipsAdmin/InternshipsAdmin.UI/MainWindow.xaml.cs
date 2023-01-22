using InternshipsAdmin.AppLogic.Contracts;
using InternshipsAdmin.Domain;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace InternshipsAdmin.UI
{
    public partial class MainWindow : Window
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IStudentsRepository _studentsRepository;
        
        public MainWindow(ICompanyRepository companyRepository, IStudentsRepository studentsRepository)
        {
            InitializeComponent();
            _companyRepository = companyRepository;
            _studentsRepository = studentsRepository;
            CompanyDataGrid.ItemsSource = _companyRepository.GetAll();
            rowToHide.Height = new GridLength(0);
        }


        private void UpdateComboboxes()
        {
            var studentsWithoutSupervisor = _studentsRepository.GetStudentsWithoutSupervisor();
            StudentsComboBox.ItemsSource = studentsWithoutSupervisor;
            var supervisorsOfCompany = _companyRepository.GetSupervisorsOfCompany(((Company) CompanyDataGrid.SelectedItem).CompanyId);
            SupervisorsComboBox.ItemsSource = supervisorsOfCompany;
        }

        private void CompanyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var company = ((Company) CompanyDataGrid.SelectedItem);
            var studentsOfCompany = _companyRepository.GetStudentsOfCompany(company.CompanyId);
            StudentDataGrid.ItemsSource = studentsOfCompany;
            rowToHide.Height = GridLength.Auto;
            UpdateComboboxes();
        }


        private void AddStudentForCompanyButton_Click(object sender, RoutedEventArgs e)
        {
           _companyRepository.AddStudentWithSupervisorForCompany((Student) StudentDataGrid.SelectedItem, (Supervisor) SupervisorsComboBox.SelectedItem);
        }

        private void RemoveStudentFromSupervisorButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }

}


