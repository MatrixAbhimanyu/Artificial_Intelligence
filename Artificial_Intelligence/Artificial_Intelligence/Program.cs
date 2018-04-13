using System.Windows.Forms;
using Artificial_Intelligence.Container;
using Artificial_Intelligence.Control;
using Microsoft.Practices.Unity;

namespace Artificial_Intelligence
{
     class Program
     {
        /// <summary>
        /// Initialize AI system
        /// </summary>
        static void Main()
        {
            var container = DependencyInjector.BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(container.Resolve<ISpeechEngine>()));
        }
    }
}
