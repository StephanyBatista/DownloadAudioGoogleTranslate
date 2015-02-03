using System.IO;

namespace DownloadAudioGoogleTranslate
{
    public class GoogleProvider
    {
        public void SaveAudio(string word)
        {
            try
            {
                var googleTranslateUrl = @"http://translate.google.com/translate_tts?tl=en&q=" + word;
                System.Net.WebRequest req = System.Net.WebRequest.Create(googleTranslateUrl);

                string a = req.GetResponse().ContentType;

                using (var webStream = req.GetResponse().GetResponseStream())
                {
                    var stream = new FileStream(@"C:\\Plavras ingles\\" + word + ".wav", FileMode.Create,
                        System.Security.AccessControl.FileSystemRights.FullControl, FileShare.ReadWrite, 100,
                        FileOptions.None);

                    if (webStream != null)
                    {
                        webStream.CopyTo(stream);
                        stream.Close();
                        webStream.Close();
                    }
                }
            }
            finally
            {
                
            }
            
        }
    }
}
