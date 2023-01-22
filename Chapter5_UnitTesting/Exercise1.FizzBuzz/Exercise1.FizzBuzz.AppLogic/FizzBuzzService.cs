using System.Text;

namespace Exercise1.FizzBuzz.AppLogic;

public class FizzBuzzService : IFizzBuzzService
{
    public const int MinimumFactor = 2;
    public const int MaximumFactor = 10;
    public const int MinimumLastNumber = 1;
    public const int MaximumLastNumber = 250;
    private const string Fizz = "Fizz";
    private const string Buzz = "Buzz";

    public string GenerateFizzBuzzText(int fizzFactor, int buzzFactor, int lastNumber)
    {
        Validate(fizzFactor, buzzFactor, lastNumber);
        var elements = new List<string>();
        for (var i = 1; i < lastNumber + 1; i++)
        {
            switch (i % fizzFactor)
            {
                case 0 when i % buzzFactor == 0:
                    elements.Add(Fizz + Buzz);
                    break;
                case 0:
                    elements.Add(Fizz);
                    break;
                default:
                {
                    elements.Add(i % buzzFactor == 0 ? Buzz : i.ToString());
                    break;
                }
            }
        }
        return string.Join(" ", elements);
    }

    public void Validate(int fizzFactor, int buzzFactor, int lastNumber)
    {
        if (fizzFactor is < MinimumFactor or > MaximumFactor)
        {
            throw new FizzBuzzValidationException("fizzFactor should be within range 2 and 10.");
        }

        if (buzzFactor is < MinimumFactor or > MaximumFactor)
        {
            throw new FizzBuzzValidationException("buzzFactor should be within range 2 and 10.");
        }

        if (lastNumber is < MinimumLastNumber or > MaximumLastNumber)
        {
            throw new FizzBuzzValidationException("lastNumber should be within range 1 and 250.");
        }
    }
}