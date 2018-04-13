
namespace Artificial_Intelligence.Commands.Manager
{
    public interface ICommandManager
    {
        /// <summary>
        /// Find action commond
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string FindCommand(string input);

        /// <summary>
        /// Create and update command
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        string LearnCommand(string input, string output);

        /// <summary>
        /// Get all command list
        /// </summary>
        /// <returns></returns>
        string[] GetCommandList();

        /// <summary>
        /// Get internet command
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string InternetCommand(string input);
    }
}
