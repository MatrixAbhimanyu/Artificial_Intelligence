
namespace Artificial_Intelligence.Commands.Manager
{
    public interface ICommandManager
    {
        /// <summary>
        /// find action commond
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string FindCommand(string input);

        /// <summary>
        /// cerate and update command
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        string LearnCommand(string input, string output);

        /// <summary>
        /// get all command list
        /// </summary>
        /// <returns></returns>
        string[] GetCommandList();

        /// <summary>
        /// get internet command
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string InternetCommand(string input);
    }
}
