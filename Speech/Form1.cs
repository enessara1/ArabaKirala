using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Speech;

namespace Speech
{

    public partial class Form1 : Form
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer Sara = new SpeechSynthesizer();
        SpeechRecognitionEngine startListening = new SpeechRecognitionEngine();
        Random rnd = new Random();
        int RecTimeOut = 0;
        DateTime TimeNow = DateTime.Now;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);

            startListening.SetInputToDefaultAudioDevice();
            startListening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            startListening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startListening_SpeechRecognized);

        }
        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int ranNum;
            string speech = e.Result.Text;


            if (speech == "Hello")
            {
                Sara.SpeakAsync("Hello , I am Here");
            }
            if (speech == "How are you ")
            {
                Sara.SpeakAsync(" I am working normally");
            }

            if (speech == "What time is it")
            {
                Sara.SpeakAsync(DateTime.Now.ToString("h mm tt"));
            }

            if (speech == "Stop talking")
            {
                Sara.SpeakAsyncCancelAll();
                ranNum = rnd.Next(1, 2);
                if (ranNum == 1)
                {
                    Sara.SpeakAsync("Yes sir");
                }
                if (ranNum == 2)
                {
                    Sara.SpeakAsync("I am sorry I will be quiet");


                }

            }
            if (speech=="Stop listening")
            {
                Sara.SpeakAsync("if you need me just ask ");
                _recognizer.RecognizeAsyncCancel();
                startListening.RecognizeAsync(RecognizeMode.Multiple);
            }
            if (speech == "Show Commands")
            {
                string[] commands = (File.ReadAllLines(@"DefaultCommands"));
                LstCommands.Items.Clear();
                LstCommands.SelectionMode = SelectionMode.None;
                LstCommands.Visible = true;

                foreach (string command in commands)
                {
                    LstCommands.Items.Add(command);
                }


            }
            if (speech == "Hide Commands")
            {
                LstCommands.Visible = false;
            }
        }
        private void _recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            RecTimeOut = 0;
        }
        private void startListening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == "Wake up")
            {
                startListening.RecognizeAsyncCancel();
                Sara.SpeakAsync("Yes , I am here");
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }

        }

        private void TmrSpeaking_Tick(object sender, EventArgs e)
        {
            if (RecTimeOut == 10)
            {
                _recognizer.RecognizeAsyncCancel();

            }
            else if (RecTimeOut == 11)
            {
                TmrSpeaking.Stop();
                startListening.RecognizeAsync(RecognizeMode.Multiple);
                RecTimeOut = 0;

            }
        }
    }
}
