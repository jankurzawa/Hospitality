namespace Hospitality.Common.FakeExamination
{
    public class Gastroskopia
    {
        public string Przelyk { get; set; }
        public string Wpust { get; set; }
        public string Trzon { get; set; }
        public string Odzwiernik { get; set; }
        public string Opuszka { get; set; }
        public string Bakteria { get; set; }

        public Gastroskopia()
        {
            Random random = new Random();
            var listZ = new List<string> { "prawidłowa", "prawidłowa", "prawidłowa", "prawidłowa", "prawidłowa", "prawidłowa", "prawidłowa", "prawidłowa", "prawidłowa", "prawidłowa", 
                "prawidłowa", "prawidłowa", "prawidłowa", "prawidłowa", "nieprawidłowa","nieprawidłowa", "prawidłowa", "prawidłowa, niewielkie zapalenie", "nieprawidłowa, duże zapalenie", 
                "nieprawidłowa, metaplazja", "nieprawidłowa, dysplazja", "nieprawidłowa, zapalenie"};
            var listM = new List<string> { "prawidłowy", "prawidłowy", "prawidłowy", "prawidłowy", "prawidłowy", "prawidłowy", "prawidłowy", "prawidłowy", "prawidłowy", "prawidłowy",
                "prawidłowy", "prawidłowy", "prawidłowy", "prawidłowy", "nieprawidłowy","nieprawidłowy", "prawidłowy", "prawidłowy, niewielkie zapalenie", "nieprawidłowy, duże zapalenie",
                "nieprawidłowy, metaplazja", "nieprawidłowy, dysplazja", "nieprawidłowy, zapalenie"};
            var listB = new List<string> { "Nie stwierdzono", "Nie stwierdzono", "Nie stwierdzono", "Nie stwierdzono", "Nie stwierdzono", "Nie stwierdzono", "Stwierdzono", 
                "Stwierdzono", "Stwierdzono",  "Stwierdzono", "Stwierdzono", "Nie stwierdzono", "Nie stwierdzono", "Nie stwierdzono"};
            
            Przelyk = listM[random.Next(listM.Count)];
            Wpust = listM[random.Next(listM.Count)];
            Trzon = listM[random.Next(listM.Count)];
            Odzwiernik = listM[random.Next(listM.Count)];
            Opuszka = listZ[random.Next(listZ.Count)];
            Bakteria = listB[random.Next(listB.Count)];
        }




    }
}
