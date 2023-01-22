using LinqExamples.Models;

namespace LinqExamples;

public class JoinExamples
{
    public int[] GetEvenNumbersOfIntersection(int[] firstList, int[] secondList) => firstList.IntersectBy(secondList.Where(x => x % 2 == 0), x => x).ToArray();

    public IList<string> MatchPersonsOnBirthMonth(IList<Person> group1, IList<Person> group2) =>
        group1.Join(group2,
            person1 => person1.BirthDate.Month,
            person2 => person2.BirthDate.Month,
            (r1, r2) => $"{r1.Name} and {r2.Name}").ToList();
}