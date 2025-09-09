using DiveDeepProject.Models;

namespace DiveDeepProject.Persistence.Repo
{
    public class FAQRepository
    {
        public static List<FAQ> GetAll()
        {
            return new List<FAQ>
            {
                new FAQ { Id = 1, Question = "Sælger I rejser?", Answer = "Nej."},
                new FAQ { Id = 2, Question = "Skal jeg have et dykkercertifikat for at leje udstyr?", Answer = "Ja, for at leje fuldt dykkerudstyr kræver vi, at du har et gyldigt dykkercertifikat (f.eks. PADI Open Water eller tilsvarende). Dette er af sikkerhedsmæssige årsager. Hvis du kun ønsker snorkeludstyr, kræves der ikke certifikat." },
                new FAQ { Id = 3, Question = "Hvordan fungerer afhentning og returnering af udstyret?", Answer = "Afhentning i butik: Du henter og returnerer selv udstyret i vores fysiske lokation. Udstyret skal returneres senest 24 timer efter lejeperiodens udløb. Ved forsinket returnering kan der opkræves ekstra gebyr." }
            };
        }
    }
}