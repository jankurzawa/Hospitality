namespace Hospitality.Common.FakeExamination
{
    public class Biohemia
    {
        public string Leukocyty { get; set; }
        public string Erytrocyty { get; set; }
        public string Hemoglobina { get; set; }
        public string Hematokryt { get; set; }
        public string MCV { get; set; }
        public string MCHC { get; set; }
        public string PDW { get; set; }
        public string MPV { get; set; }
        public string NEU { get; set; }
        public string LYMPH { get; set; }
        public string MON { get; set; }

        public Biohemia()
        {
            Random random = new Random();
            Leukocyty = (3 + random.NextDouble() * (15 - 3)).ToString("0.0");
            Erytrocyty = (2 + random.NextDouble() * (10 - 2)).ToString("0.0");
            Hemoglobina = (10 + random.NextDouble() * (22 - 10)).ToString("0.0");
            Hematokryt = (32 + random.NextDouble() * (55 - 32)).ToString("0.0");
            MCV = (70 + random.NextDouble() * (100 - 70)).ToString("0.0");
            MCHC = (29 + random.NextDouble() * (41 - 29)).ToString("0.0");
            PDW = (8 + random.NextDouble() * (20 - 8)).ToString("0.0");
            MPV = (4 + random.NextDouble() * (17 - 4)).ToString("0.0");
            NEU = (30 + random.NextDouble() * (85 - 30)).ToString("0.0");
            LYMPH = (15 + random.NextDouble() * (50 - 15)).ToString("0.0");
            MON = (3 + random.NextDouble() * (15 - 3)).ToString("0.0");
        }
    }
}