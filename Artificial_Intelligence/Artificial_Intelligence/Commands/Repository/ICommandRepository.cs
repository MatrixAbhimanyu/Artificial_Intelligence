
namespace Artificial_Intelligence.Commands.Repository
{
    public interface ICommandRepository
    {
        /// <summary>
        /// Create command as a xml node
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        void Create(string input, string output);

        /// <summary>
        /// read command as a xml node
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string Read(string input);

        /// <summary>
        /// update command as axml node
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        void Update(string input, string output);

        /// <summary>
        /// delete command as a xml command
        /// </summary>
        /// <param name="input"></param>
        void Delete(string input);

        /// <summary>
        /// get xml command list
        /// </summary>
        /// <returns></returns>
        string[] GetCommandList();
    }
}
