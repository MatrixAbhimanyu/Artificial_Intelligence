using System;
using Artificial_Intelligence.Commands.Repository;

namespace Artificial_Intelligence.Commands.Manager
{
    public class CommandManager : ICommandManager
    {
        #region Properties
        private readonly ICommandRepository _cmdRepo;
        private const string CommandAccepted = "Command Accepted";
        private const string CommandNotAccepted = "Command not Accepted";
        #endregion

        #region Cunstructor
        public CommandManager(ICommandRepository cmdRepo)
        {
            _cmdRepo = cmdRepo;
        }
        #endregion

        #region Public Member
        public string FindCommand(string input)
        {
            return GetActionCommand(input);
        }

        public string LearnCommand(string input, string output)
        {
            var outputFilter = string.IsNullOrWhiteSpace(output) ? CommandNotAccepted : output;
            if (string.IsNullOrWhiteSpace(GetSavedCommand(input)))
            {
                _cmdRepo.Create(input, outputFilter);
            }
            else
            {
                _cmdRepo.Update(input, outputFilter);
            }
            return CommandAccepted;
        }

        public string[] GetCommandList()
        {
            return _cmdRepo.GetCommandList();
        }

        public string InternetCommand(string input)
        {
            var output = GetSavedCommand(input);
            var message = CommandNotAccepted;
            if (output != CommandAccepted)
            {
                OpenUrl(output);
                message = CommandAccepted;
            }

            return message;
        }
        #endregion

        #region Private Member
        private string GetActionCommand(string input)
        {
            var message = CommandAccepted;
            switch (input.ToLowerInvariant())
            {
                case "time":
                    message = GetMessageFormat(DateTime.Now.ToString("hh:mm tt"));
                    break;
                case "date":
                    message = GetMessageFormat(DateTime.Now.ToString("dd-MMM-yyyy"));
                    break;
                default:
                    message = GetSavedCommand(input);
                    break;
            }

            return message;
        }

        private string GetMessageFormat(string param)
        {
            return $"it is {param}";
        }

        private void OpenUrl(string webUrl)
        {
            System.Diagnostics.Process.Start(webUrl);
        }

        private string GetSavedCommand(string input)
        {
            return _cmdRepo.Read(input);
        }
        #endregion
    }
}
