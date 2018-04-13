
namespace Artificial_Intelligence.Commands.Manager
{
    public interface ICommandManager
    {
        string FindCommand(string input);

        string LearnCommand(string input, string output);

        string[] GetCommandList();

        string InternetCommand(string input);
    }
}
