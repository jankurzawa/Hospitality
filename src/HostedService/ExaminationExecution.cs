namespace HostedService
{
    public interface IExaminationExecution
    {
        ExaminationExecutionDto executeExamination(string jsonData);
    }

    public class ExaminationExecution : IExaminationExecution
    {
        public ExaminationExecutionDto executeExamination(string jsonData)
        {
            ExaminationExecutionDto examinationExecutionDto = JsonConvert.DeserializeObject<ExaminationExecutionDto>(jsonData);
            examinationExecutionDto.Status = 1;
            Thread.Sleep(examinationExecutionDto.Duration);
            Debug.WriteLine(" Thread.Sleep is finished.");
            int examinationType = examinationExecutionDto.ExaminationTypeId;
            if (examinationType >= 1 && examinationType<= 10)
                examinationExecutionDto.Description = getFakeExaminationResult(examinationType);
            else
                examinationExecutionDto.Description = ""; 
            return examinationExecutionDto;
        }

        private string getFakeExaminationResult(int examinationType)
        {
            switch (examinationType)
            {
                case 1: return setBiohemiaResult();
                case 2: return setCardiacUltrasound();
                case 3: return setRTGGlowyResult();
                case 4: return setRTGZabObrotnik();
                case 5: return setRTGCzaszki();
                case 6: return setDentalTreatmentResult();
                case 7: return setParasiteTest();
                case 8: return setCytologiaResult();
                case 9: return setKolonoskopiaResult();
                case 10: return setGastroscopiaResult();
            }

            return "Not examination result";
        }

        private string setBiohemiaResult()
        {
            Biohemia newResult = new Biohemia();
            return ($"Leukocyty: {newResult.Leukocyty}, \nErytrocyty: {newResult.Erytrocyty}, \nHemoglobina: {newResult.Hemoglobina}, " +
                $"\nHematokryt: {newResult.Hematokryt}, \nMCV: {newResult.MCV}, \nMCHC:{newResult.MCHC}, \nPDW:{newResult.PDW}, \n" +
                $"MPV: {newResult.MPV}, \nNEU%: {newResult.NEU}, \nLYMPH%:{newResult.LYMPH}, \nMON%: {newResult.MON}");
        }

        private string setCardiacUltrasound()
        {
            CardiacUltrasound newResult = new CardiacUltrasound();
            return ($"\nLewa komora: {newResult.LewaKomora}, \nPrawa komora: {newResult.PrawaKomora}, \nPrzegroda miedzykomorkowa: {newResult.PrzegrodaMiedzykomorkowa}, " +
                $"\nLewy przedsionek: {newResult.LewyPrzedsionek}, \nPrawy przedsionek: {newResult.PrawyPrzedsionek}, \nVSD:{newResult.VSD}, \nTOF:{newResult.TOF}, \nTGA:{newResult.TGA}\n");
        }

        private string setParasiteTest()
        {
            ParasiteTest newResult = new ParasiteTest();
            return ($"\nCandida albicans: {newResult.Candida}, \nLambilia intestinalis: {newResult.Lambilia}, \nOpisthorchis felineus: {newResult.Opisthorchis}, " +
               $"\nAscaris lumbricoides: {newResult.Ascaris}, \nTrichocephalus trichiurus: {newResult.Trichocephalus}, \nHymenolipis diminuta:{newResult.Hymenolipis}, \nFasciola hepatica:{newResult.Fasciola}\n");
        }
        private string setGastroscopiaResult()
        {
            Gastroskopia newResult = new Gastroskopia();
            return ($"\nPrzełyk: {newResult.Przelyk}, \nWpust: {newResult.Wpust}, \nTrzon: {newResult.Trzon}, \nOdźwiernik: {newResult.Odzwiernik}, \nOpuszka: {newResult.Opuszka}, \n" +
                $"{newResult.Bakteria} aktywne zakażenie H.pylori\n");
        }

        private string setDentalTreatmentResult()
        {
            DentalTreatment newResult = new DentalTreatment();
            return newResult.Result;
        }

        private string setRTGGlowyResult()
        {
            RTGGlowy newResult = new RTGGlowy();
            return ($"\nPA/AP + boczne: {newResult.AP}. {newResult.kosciCzaszki}\n");
        }

        private string setRTGZabObrotnik()
        {
            RTGZabObrotnika newResult = new RTGZabObrotnika();
            return ($"\nWięzadło wierzchołka zęba: {newResult.Wierzcholek}, \nWięzadło poprzeczno-obrotowe: {newResult.PoprzecznoObrotowe}, \nWięzadło potyliczno-obrotowe pośrodkowe: {newResult.PotylicznoObrotowe}, " +
                $"\nWięzadło międzykolcowe: {newResult.Miedzykolcowe}, \nWięzadło karkowe: {newResult.Karkowe}, \nWięzadło skrzydłowate: {newResult.Skrzydlowate}, \nWięzadło podłużne przednie: {newResult.PodluznePrzednie}, \nWięzadło podłużne tylne: {newResult.PodluzneTylne}\n");
        }

        private string setCytologiaResult()
        {
            Cytologia newResult = new Cytologia();
            return ($"\nOgólna ocena rozmiaru: {newResult.Rozmiar},\nZmiany zapane: {newResult.Flora}, \nZmiany w komórkach nabłonka: {newResult.ZmianyKomorki}\n");
        }
        private string setKolonoskopiaResult()
        {
            Kolonoskopia newResult = new Kolonoskopia();
            return $"\n{newResult.Result}\n";
        }     
        private string setRTGCzaszki()
        {
            RTGCzaszki newResult = new RTGCzaszki();
            return $"\n{newResult.Result}\n";
        }
    }
}