using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Totext
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string apiKey = "AIzaSyAZikiShbldxKcv6qcvKELHF3_P5ixVkIg";

            // Ses dosyasının yolunu ve adını buraya yazın
            string audioFilePath = @"C:\Users\enes.sara\source\repos\mert-al\merthaber\HaberSitesiAdmin\Storage\Video\AudioFile\atv.mp3";

            string credential_path = @"C:\denem\deneme.json";
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);
          

            // Ses dosyasını metin dosyasına dönüştürme işlemini yapın
            string transcribedText = await SpeechToTextAsync(apiKey, audioFilePath);

            // Dönüştürülen metni ekranda gösterin
            transcribedTextTextBox.Text = transcribedText;
        }
        public static async Task<string> SpeechToTextAsync(string apiKey, string audioFilePath)
        {
            // Ses tanıma konfigürasyonunu oluşturun
            var config = new RecognitionConfig
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.EncodingUnspecified,
                SampleRateHertz = 16000,
                EnableWordConfidence = true,
                
                EnableWordTimeOffsets=true,
                LanguageCode = "tr-TR", // Türkçe dilini seçin
                EnableAutomaticPunctuation = true,
                Model = "command_and_search"
            };

            // Ses dosyasını okuyucuyu oluşturun
            var audio = RecognitionAudio.FromFile(audioFilePath);

            // Ses tanıma istemcisini oluşturun
            var client = SpeechClient.Create();

            // Ses tanıma işlemini başlatın
            var response = await client.RecognizeAsync(config, audio);

            // İşlemin başarılı bir şekilde tamamlandıysa, dönüştürülen metni döndürün
            if (response.Results.Count > 0)
            {
                return response.Results[0].Alternatives[0].Transcript;
            }
            else
            {
                MessageBox.Show("hata");
                return null;
            }

        }
    }
}

