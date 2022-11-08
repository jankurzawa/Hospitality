namespace Hospitality.Common.FakeExamination
{
    public class RTGGlowy
    {
        public string AP { get; set; }
        public string kosciCzaszki { get; set; }

        public RTGGlowy()
        {
            Random random = new Random();
            var listAP = new List<string> { "niejednorodne, owalne zacieniowanie", "norma", "norma", "norma", "norma", "jednorodne zacieniowanie" };
            AP = listAP[random.Next(listAP.Count)];
            var listKosciCzaszki = "Kości czaszki bez zmian.";
        }
    }
}
