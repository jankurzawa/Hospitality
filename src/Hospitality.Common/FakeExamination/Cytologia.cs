namespace Hospitality.Common.FakeExamination
{
    public class Cytologia
    {
        public string Rozmiar { get; set; }
        public string Flora { get; set; }
        public string ZmianyKomorki { get; set; }

        public Cytologia()
        {
            Random random = new Random();
            var listR = new List<string> {"norma", "norma", "norma", "norma","z cechami neoplacji" };
            var listF = new List<string> { "norma", "norma", "norma", "norma", "norma", "norma", "norma", "norma", "norma", 
                "obfita flora bakteryjna", "flora grzybicza", "infekcja wirusem Herpes", "zapalenie" };
            var listZK = new List<string> { "norma", "norma", "norma", "norma",  "norma", "norma", "norma", "norma", "nietypowe komórki nabłonka płaskiego",
                "nietypowe komórki nabłonka gruczołowego", "zmiany śródnabłonkowe" };
            Rozmiar = listR[random.Next(listR.Count)];
            Flora = listF[random.Next(listF.Count)];
            ZmianyKomorki = listZK[random.Next(listZK.Count)];
        }

    }
}
