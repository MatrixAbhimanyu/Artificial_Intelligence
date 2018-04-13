using System;
using System.Linq;
using System.Xml.Linq;
using Artificial_Intelligence.Commands.Model;

namespace Artificial_Intelligence.Commands.Repository
{
    public class CommandRepository : ICommandRepository
    {
        #region Properties
        private readonly XDocument _xmldoc;
        private readonly CommandModel _commandModel;
        private static string xmlFilePath = "AppData/XMLCommands.xml";

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRepository" /> class.
        /// </summary>
        /// <param name="commandModel"></param>
        public CommandRepository(CommandModel commandModel)
        {
            _commandModel = commandModel;
            _xmldoc = XDocument.Load(xmlFilePath);
        }
        #endregion

        #region Public Member
        /// <summary>
        /// Create command as a xml node
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        public void Create(string input, string output)
        {
            var command = new XElement(_commandModel.Command,
                new XElement(_commandModel.Text, input),
                new XElement(_commandModel.Message, output));
            _xmldoc.Root.Add(command);
            _xmldoc.Save(xmlFilePath);
        }

        /// <summary>
        /// read command as a xml node
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Read(string input)
        {
            var command = GetCommandXElement(input);
            return command?.Element(_commandModel.Message).Value;
        }

        /// <summary>
        /// update command as axml node
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        public void Update(string input, string output)
        {
            var command = GetCommandXElement(input);
            command.Element(_commandModel.Message).Value = output;
            _xmldoc.Save(xmlFilePath);
        }

        /// <summary>
        /// delete command as a xml command
        /// </summary>
        /// <param name="input"></param>
        public void Delete(string input)
        {
            var command = GetCommandXElement(input);
            command.Remove();
            _xmldoc.Save(xmlFilePath);
        }

        /// <summary>
        /// get xml command list
        /// </summary>
        /// <returns></returns>
        public string[] GetCommandList()
        {
            return _xmldoc.Descendants(_commandModel.Command).Select(s => s.Element(_commandModel.Text).Value).ToArray();
        }
        #endregion

        #region Private Member
        /// <summary>
        /// get xml node element
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private XElement GetCommandXElement(string input)
        {
            var command =
                _xmldoc.Descendants(_commandModel.Command)
                .FirstOrDefault(p => string.Equals(p.Element(_commandModel.Text).Value, input,
                StringComparison.InvariantCultureIgnoreCase));
            return command;
        }
        #endregion
    }
}
