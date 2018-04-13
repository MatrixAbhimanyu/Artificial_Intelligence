
namespace Artificial_Intelligence.Control
{
    public interface ISpeechEngine
    {
        /// <summary>
        /// initialize speech engine
        /// </summary>
        void IntializeSpeechEngine();

        /// <summary>
        /// learn command
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        void AddCommand(string input, string output);

        /// <summary>
        /// start speech recognize engine to listen command
        /// </summary>
        void start();

        /// <summary>
        /// stop speech recognize engine to listen command
        /// </summary>
        void stop();
    }
}
