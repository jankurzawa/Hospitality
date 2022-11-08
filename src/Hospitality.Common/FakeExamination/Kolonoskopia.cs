namespace Hospitality.Common.FakeExamination
{
    public class Kolonoskopia
    {
        public string Result { get; set; }

        public Kolonoskopia()
        {
            Random random = new Random();
            var listAP = new List<string> {"Podejrzenie wrzodziejącego zapalenia jelita. Proszę zwrócić się do lekarza.", "Zapalenie błony śluzowej. Proszę zwrócić się do lekarza.", "Zapalenie błony śluzowej. Proszę zwrócić się do lekarza.", "Bez zmian zapalnych",
                "Zapalenia nadżerek. Proszę zwrócić się do lekarza.", "Bez zmian zapalnych", "Krwawienia z przewodu pokarmowego. Proszę zwrócić się do lekarza.", "Bez zmian zapalnych" };

            Result = listAP[random.Next(listAP.Count)];
        }
    }
}
