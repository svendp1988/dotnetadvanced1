namespace Exercise1;

public static class CompositionFilters
{
    public static CompositionFilterDelegate QuickFilter =>
        (Composition composition, String searchKeyword) =>
            composition.Title.Contains(searchKeyword);

    public static CompositionFilterDelegate DetailedFilter =>
        (Composition composition, String searchKeyword) =>
            composition.Title.Contains(searchKeyword) || composition.Description.Contains(searchKeyword);

    public static CompositionFilterDelegate ReleaseYearFilter =>
        (Composition composition, String searchKeyword) =>
            composition.ReleaseDate.Year.ToString().Equals(searchKeyword);
}