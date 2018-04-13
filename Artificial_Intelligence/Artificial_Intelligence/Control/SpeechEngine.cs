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
        /// <summary>
        ///  Initializes a new instance of the <see cref="SpeechEngine" /> class.
        /// </summary>
        /// <param name="icmdManager"></param>
        public SpeechEngine(ICommandManager icmdManager)
        {
            _icmdManager = icmdManager;
            _speechEngine = new SpeechRecognitionEngine();
            _speaker = new SpeechSynthesizer();
        }
        #endregion

        #region Public Member
        /// <summary>
        /// initialize speech engine
        /// </summary>
        public void IntializeSpeechEngine()
        {
            IntializeCommandsAndGrammer();
            RegisterIOAndEventHandler();
        }

        /// <summary>
        /// learn command
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        public void AddCommand(string input, string output)
        {
            var message = _icmdManager.LearnCommand(input, output);
            _speaker.Speak(message);
            IntializeCommandsAndGrammer();
        }

        /// <summary>
        /// start speech recognize engine to listen command
        /// </summary>
        public void start()
        {
            _speechEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        /// <summary>
        /// stop speech recognize engine to listen command
        /// </summary>
        public void stop()
        {
            _speechEngine.RecognizeAsyncStop();
        }
        #endregion

        #region Private Member
        /// <summary>
        /// filter command based on speech
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// intialize command and language grammmer
        /// </summary>
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

        /// <summary>
        /// register I/O and event handler
        /// </summary>
        private void RegisterIOAndEventHandler()
        {
            _speechEngine.SetInputToDefaultAudioDevice();
            _speechEngine.SpeechRecognized += sr_SpeechRecognized;
        }
        #endregion
    }
}
