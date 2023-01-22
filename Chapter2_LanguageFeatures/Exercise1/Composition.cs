namespace Exercise1
{
    public class Composition
    {
        public Composition()
        {
            Title = "";
            Description = "";
            ReleaseDate = DateTime.MinValue;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string? Composer { get; set; }
        public DateTime ReleaseDate { get; set; }

        public override string ToString()
        {
            return
                $"Title: {Title}\r\nDescription: {Description}\r\nComposer: {Composer ?? "/"}\r\nRelease: {ReleaseDate.Date.ToString("dd/MM/yyyy")} -  {ReleaseDate.ToCentury()}° Century";
        }
    }
}
