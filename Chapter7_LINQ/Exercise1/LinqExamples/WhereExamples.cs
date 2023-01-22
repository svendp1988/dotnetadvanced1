using LinqExamples.Models;

namespace LinqExamples;

public class WhereExamples
{
    public int[] FilterOutNumbersDivisibleByTen(int[] numbers)
    {
        return numbers.Where(number => number % 10 == 0).ToArray();
    }

    public IList<Person> FilterOutPersonsThatAreEighteenOrOlder(List<Person> persons)
    {
        return persons.Where(person =>
        {
            var age = DateTime.Today.Year - person.BirthDate.Year;
            return age > 18;
        }).ToArray();
    }
}