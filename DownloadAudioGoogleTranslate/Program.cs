namespace DownloadAudioGoogleTranslate
{
    class Program
    {
        static void Main(string[] args)
        {
            var excelProvider = new ExcelProvider();
            var words = excelProvider.ReadColumn("C:\\Users\\StephanyHenrique\\Documents\\planilha2.xls");
            var googleProvider = new GoogleProvider();

            foreach (var word in words)
                googleProvider.SaveAudio(word);    

        }
    }
}
