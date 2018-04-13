
namespace Artificial_Intelligence.Commands.Repository
{
    public interface ICommandRepository
    {
        void Create(string input, string output);
        string Read(string input);
        void Update(string input, string output);
        void Delete(string input);
        string[] GetCommandList();
    }
}
