using LinqExamples.Models;

namespace LinqExamples;

public class OrderByExamples
{
    public double[] SortAnglesFromBigToSmall(double[] angles)
    {
        return angles.OrderByDescending(angle => angle).ToArray();
    }

    public IList<Person> SortPersonsFromYoungToOldAndThenOnNameAlphabetically(List<Person> persons)
    {
        return persons.OrderBy(person => person.BirthDate).ThenBy(person => person.Name).ToList();
    }
}