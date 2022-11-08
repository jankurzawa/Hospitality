namespace Hospitality.Common.FakeExamination
{
    public class ParasiteTest
    {
        public string Candida { get; set; }
        public string Lambilia { get; set; }
        public string Opisthorchis { get; set; }
        public string Ascaris { get; set; }
        public string Trichocephalus { get; set; }
        public string Hymenolipis { get; set; }
        public string Fasciola { get; set; }

        public ParasiteTest()
        {
            Random random = new Random();
            var list = new List<string> { "tak", "tak", "nie", "nie", "nie", "nie", "nie", "nie", "nie", "nie", "nie", "nie", "nie", "nie", "nie", "nie", "nie", "nie", "nie",
                "nie", "nie" };
            Candida = list[random.Next(list.Count)];
            Lambilia = list[random.Next(list.Count)];
            Opisthorchis = list[random.Next(list.Count)];
            Ascaris = list[random.Next(list.Count)];
            Trichocephalus = list[random.Next(list.Count)];
            Hymenolipis = list[random.Next(list.Count)];
            Fasciola = list[random.Next(list.Count)];
        }
    }
}
