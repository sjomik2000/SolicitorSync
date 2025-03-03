using legalcases.EntityModels;
using System.Linq;

namespace Cases.GetData 
{
    public class Data
    {
        public static void GetData()
        {
            try
            {
                using (var context = new LegalCasesContext())
                {
                    var cases = context.Cases.ToList();
                    foreach (var caseItem in cases)
                    {
                        WriteLine($"Case Name: {caseItem.case_name}, Attorney: {caseItem.assigned_attorney}, Date: {caseItem.court_date}");
                    }
                }
                WriteLine("Press any key to exit..");
                ReadKey();
            }
            catch (Exception ex)
            {
                WriteLine($"An error occurred: {ex.Message}");
                WriteLine("Press any key to exit..");
                ReadKey();
            }
        }
    }
}
