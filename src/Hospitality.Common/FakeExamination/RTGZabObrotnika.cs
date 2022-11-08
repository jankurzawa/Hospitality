namespace Hospitality.Common.FakeExamination
{
    public class RTGZabObrotnika
    {
        public string Wierzcholek { get; set; }
        public string PoprzecznoObrotowe { get; set; }
        public string PotylicznoObrotowe { get; set; }
        public string Miedzykolcowe { get; set; }
        public string Karkowe { get; set; }
        public string Skrzydlowate { get; set; }
        public string PodluzneTylne { get; set; }
        public string PodluznePrzednie { get; set; }

        public RTGZabObrotnika()
        {
            Random random = new Random();
            var listAP = new List<string> { "przerwanie", "rotacyjne podwichnięcie", "norma", "norma", "norma", "rozciągnięcie", "przekrwienie", "uszkodzenie", 
                "skostnienie", "norma", "norma", "norma", "norma", "norma", "norma", };
            Wierzcholek = listAP[random.Next(listAP.Count)];
            PoprzecznoObrotowe = listAP[random.Next(listAP.Count)];
            PotylicznoObrotowe = listAP[random.Next(listAP.Count)];
            Miedzykolcowe = listAP[random.Next(listAP.Count)];
            Karkowe = listAP[random.Next(listAP.Count)];
            Skrzydlowate = listAP[random.Next(listAP.Count)];
            PodluzneTylne = listAP[random.Next(listAP.Count)];
            PodluznePrzednie = listAP[random.Next(listAP.Count)];
        }
    }
}
