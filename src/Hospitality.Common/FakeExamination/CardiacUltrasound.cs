namespace Hospitality.Common.FakeExamination
{
    public class CardiacUltrasound
    {
        public string Examination { get; set; }
        public string LewaKomora { get; set; }
        public string PrawaKomora { get; set; }
        public string PrzegrodaMiedzykomorkowa { get; set; }
        public string PrawyPrzedsionek { get; set; }
        public string LewyPrzedsionek { get; set; }
        public string VSD { get; set; }
        public string TGA { get; set; }
        public string TOF { get; set; }


        public CardiacUltrasound()
        {
            Random random = new Random();
            Examination = "USG serca";
            LewaKomora = random.Next(15, 60).ToString("0.0") + "/" + random.Next(15, 60).ToString("0.0");
            PrawaKomora = random.Next(15, 60).ToString("0.0") + "/" + random.Next(15, 60).ToString("0.0");
            PrzegrodaMiedzykomorkowa = random.Next(8, 15).ToString("0.0") + "/" + random.Next(5, 13).ToString("0.0");
            LewyPrzedsionek = random.Next(27, 42).ToString("0.0");
            PrawyPrzedsionek = random.Next(27, 42).ToString("0.0");
            VSD = random.Next(5, 27).ToString("0.0");
            TGA = random.Next(1, 10).ToString("0.0");
            TOF = random.Next(2, 14).ToString("0.0");
        }
    }
}
