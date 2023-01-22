using LinqExamples.Models;

namespace LinqExamples
{
    public class SelectExamples
    {
        public IList<int> GetLengthOfWords(IEnumerable<string?> words)
        {
            return words.Select(word => word?.Length ?? 0).ToList();
        }

        public IList<AngleInfo> ConvertAnglesToAngleInfos(IEnumerable<double> anglesInDegrees)
        {
            return anglesInDegrees.Select(anglesInDegrees => new AngleInfo
            {
                Angle = anglesInDegrees,
                Cosinus = Math.Cos(anglesInDegrees * Math.PI / 180),
                Sinus = Math.Sin(anglesInDegrees * Math.PI / 180)
            }).ToList();
        }
    }
}