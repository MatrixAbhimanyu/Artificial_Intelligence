using Artificial_Intelligence.Commands.Manager;
using Artificial_Intelligence.Commands.Repository;
using Artificial_Intelligence.Control;
using Microsoft.Practices.Unity;

namespace Artificial_Intelligence.Container
{
    public static class DependencyInjector
    {
        /// <summary>
        /// build unity container to resolve dependancy
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ICommandRepository, CommandRepository>();
            currentContainer.RegisterType<ICommandManager, CommandManager>();
            currentContainer.RegisterType<ISpeechEngine, SpeechEngine>();
            return currentContainer;
        }
    }
}
