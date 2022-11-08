namespace Hospitality.Common.FakeExamination
{
    public class DentalTreatment
    {
        public string Result { get; set; }

        public DentalTreatment()
        {
            Random random = new Random();
            var lista = new List<string> { "mikrourazy spowodowane bodźcami mechanicznymi, zapalenia miazgi", "martwica miazgi, próchnica wtórna", "próchnica wtórna, mikrourazy spowodowane bodźcami mechanicznymi",
                "zmiany okołowierzchołkowe, ubytek klinowy ", "martwica miazgi, ubytek klinowy , próchnica głęboka", "zmiany okołowierzchołkowe, martwica miazgi", "zmiany okołowierzchołkowe",  "martwica miazgi, zmiany okołowierzchołkowe",
                "próchnica wtórna, zapalenia miazgi", "martwica miazgi, zmiany okołowierzchołkowe", "zapalenia miazgi, mikrourazy spowodowane bodźcami mechanicznymi", "mikrourazy spowodowane bodźcami mechanicznymi",
                "próchnica wtórna, ubytek klinowy ", "zapalenia miazgi, niewielkie zapalenie", "próchnica głęboka, ubytek klinowy ", "próchnica głęboka, mikrourazy spowodowane bodźcami mechanicznymi", 
                "mikrourazy spowodowane bodźcami mechanicznymi, próchnica wtórna", "zapalenia miazgi, zmiany okołowierzchołkowe, próchnica wtórna"};
            var listSzczeka = new List<string> { "Prawy górny", "Prawy dolny", "Lewy górny"," Lewy dolny" };
           
            Result = $"\n{listSzczeka[random.Next(listSzczeka.Count)]} {random.Next(1, 8)}: {lista[random.Next(lista.Count)]}\n";

        }

    }
}
