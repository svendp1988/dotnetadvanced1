namespace Exercise2
{
    public class Student
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string? _department;
        
        public string FirstName => _firstName;
        public string LastName => _lastName;

        public string? Department => _department;

        public Student(string firstName, string lastName, string? department)
        {
            _firstName = firstName;
            _lastName = lastName;
            _department = department;
        }

        public override string ToString()
        {
            var departmentInfo = Department ?? "/";
            return $"{FirstName} {LastName} - {departmentInfo}";
        }
    }
}

