
namespace Artificial_Intelligence.Control
{
    public interface ISpeechEngine
    {
        void IntializeSpeechEngine();
        void AddCommand(string input, string output);
        void start();
        void stop();
    }
}
