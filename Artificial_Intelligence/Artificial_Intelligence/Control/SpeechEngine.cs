using System.Speech.Recognition;
using System.Speech.Synthesis;
using Artificial_Intelligence.Commands.Manager;

namespace Artificial_Intelligence.Control
{
    public class SpeechEngine : ISpeechEngine
    {
        #region Properties
        private readonly ICommandManager _icmdManager;
        // Create a new SpeechRecognizer instance.
        private readonly SpeechRecognitionEngine _speechEngine;
        private readonly SpeechSynthesizer _speaker;
        #endregion

        #region Constructor
        public SpeechEngine(ICommandManager icmdManager)
        {
            _icmdManager = icmdManager;
            _speechEngine = new SpeechRecognitionEngine();
            _speaker = new SpeechSynthesizer();
        }
        #endregion

        #region Public Member
        public void IntializeSpeechEngine()
        {
            IntializeCommandsAndGrammer();
            RegisterIOAndEventHandler();
        }

        public void AddCommand(string input, string output)
        {
            var message = _icmdManager.LearnCommand(input, output);
            _speaker.Speak(message);
            IntializeCommandsAndGrammer();
        }

        public void start()
        {
            _speechEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        public void stop()
        {
            _speechEngine.RecognizeAsyncStop();
        }
        #endregion

        #region Private Member
        private void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string message;
            if (e.Result.Text.ToLowerInvariant().StartsWith("internet"))
            {
                message =_icmdManager.InternetCommand(e.Result.Text);
            }
            else
            {
                 message = _icmdManager.FindCommand(e.Result.Text);
            }
            _speaker.Speak(message);
        }

        private void IntializeCommandsAndGrammer()
        {
            var commands = new Choices();
            commands.Add(_icmdManager.GetCommandList());
            var grammerBuilder = new GrammarBuilder();
            grammerBuilder.Append(commands);

            // Create the Grammar instance.
            var grammar = new Grammar(grammerBuilder);
            _speechEngine.LoadGrammar(grammar);
        }

        private void RegisterIOAndEventHandler()
        {
            _speechEngine.SetInputToDefaultAudioDevice();
            _speechEngine.SpeechRecognized += sr_SpeechRecognized;
        }
        #endregion
    }
}
