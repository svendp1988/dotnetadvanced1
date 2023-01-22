using LinqExamples.Models;

namespace LinqExamples;

public class GroupExamples
{
    public IList<IGrouping<int, int>> GroupEvenAndOddNumbers(int[] numbers)
    {
        return numbers.GroupBy(number => number % 2).ToList();
    }

    public IList<PersonsOfSameBirthYearGroup> GroupPersonsByBirthYear(IList<Person> persons)
    {
        return persons.GroupBy(p => p.BirthDate.Year).Select(p => new PersonsOfSameBirthYearGroup
        {
            BirthYear = p.Key,
            Persons = p.ToList()
        }).ToList();
    }
}
