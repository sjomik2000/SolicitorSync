using legalcases.EntityModels;

public class Program
{
    public static void Main()
    {
        using(var context = new LegalCasesContext())
        {
            var cases = context.Cases.ToList();
            foreach (var caseItem in cases)
            {
                WriteLine($"Case Name: {caseItem.CaseName}, Attourney: {caseItem.AssignedAttorney}, Date: {caseItem.CourtDate}");
            }
        }

        WriteLine("Press any key to exit..");
        ReadKey();
    }
}
