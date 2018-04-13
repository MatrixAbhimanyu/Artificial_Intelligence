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
        /// <summary>
        ///  Initializes a new instance of the <see cref="CommandManager" /> class.
        /// </summary>
        /// <param name="cmdRepo"></param>
        public CommandManager(ICommandRepository cmdRepo)
        {
            _cmdRepo = cmdRepo;
        }
        #endregion

        #region Public Member
        /// <summary>
        /// Find action commond
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string FindCommand(string input)
        {
            return GetActionCommand(input);
        }

        /// <summary>
        /// Create and update command
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get all command list
        /// </summary>
        /// <returns></returns>
        public string[] GetCommandList()
        {
            return _cmdRepo.GetCommandList();
        }

        /// <summary>
        /// Get internet command
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Get action command
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get message format
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private string GetMessageFormat(string param)
        {
            return $"it is {param}";
        }

        /// <summary>
        /// Open url for internet command
        /// </summary>
        /// <param name="webUrl"></param>
        private void OpenUrl(string webUrl)
        {
            System.Diagnostics.Process.Start(webUrl);
        }

        /// <summary>
        /// Get exist command
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string GetSavedCommand(string input)
        {
            return _cmdRepo.Read(input);
        }
        #endregion
    }
}
