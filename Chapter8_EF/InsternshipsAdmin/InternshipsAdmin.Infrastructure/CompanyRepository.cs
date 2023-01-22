using InternshipsAdmin.AppLogic.Contracts;
using InternshipsAdmin.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace InternshipsAdmin.Infrastructure
{
    internal class CompanyRepository : ICompanyRepository
    {
        private readonly InternshipsContext _context;

        public CompanyRepository(InternshipsContext context)
        {
            _context = context;
        }

        public void Add(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public IList<Company> GetAll()
        {
            return _context.Companies.ToList();
        }

        public Contact GetContactOfCompany(int companyId)
        {
            return _context.Contacts.First(Contact => Contact.CompanyId.Equals(companyId));
        }

        public List<Supervisor> GetSupervisorsOfCompany(int companyId)
        {
            return _context.Supervisors.Where(supervisor => supervisor.CompanyId.Equals(companyId)).ToList();
        }

        public List<Student> GetStudentsOfCompany(int companyId)
        {
            var supervisorIds = _context.Supervisors.Where(supervisor => supervisor.CompanyId.Equals(companyId))
                .Select(supervisor => supervisor.Id).ToList();
            List<Student> students = new List<Student>();
            foreach (var id in supervisorIds)
            {
                students.AddRange(_context.Students.Where(student => student.SupervisorId.Equals(id)).ToList());
            }

            return students;
        }

        public void AddStudentWithSupervisorForCompany(Student student, Supervisor supervisor)
        {
            student.Supervisor = supervisor;
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void RemoveStudentFromSupervisor(Student student, Supervisor? supervisor)
        {
            supervisor.Students.Remove(student);
            _context.Update(supervisor);
            _context.SaveChanges();
        }

        private Company getCompanyById(int companyId)
        {
            return _context.Companies.First(company => company.CompanyId.Equals(companyId));
        }
    }
}