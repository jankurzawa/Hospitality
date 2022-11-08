namespace Hospitality.Common.FakeExamination
{
    public class RTGCzaszki
    {
        public string Result { get; set; }

        public RTGCzaszki()
        {
            Random random = new Random();
            var listAP = new List<string> { "Ubytki kostne środkowego i tylnego dotu czaszki o średnicy powyżej 2,5 cm. Proszę zwrócić się do lekarza.", "Uszkodzenie powłok czaszki (bez ubytków kostnych). Proszę zwrócić się do lekarza.", "Ropne zapalenie kości. Proszę zwrócić się do lekarza.", "Bez zmian zapalnych",
                "Gruczolak przysadki mózgowej. Proszę zwrócić się do lekarza.", "Bez zmian zapalnych", "Zwapnienia wewnątrzczaszkowe. Proszę zwrócić się do lekarza.", "Bez zmian zapalnych" };

            Result = listAP[random.Next(listAP.Count)];
        }
    }
}
