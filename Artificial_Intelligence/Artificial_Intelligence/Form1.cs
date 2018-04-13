using System;
using System.Windows.Forms;
using Artificial_Intelligence.Control;

namespace Artificial_Intelligence
{
    public partial class Form1 : Form
    {
        private readonly ISpeechEngine _speechEngine;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Form1" /> class.
        /// </summary>
        /// <param name="speechEngine"></param>
        public Form1(ISpeechEngine speechEngine)
        {
            _speechEngine = speechEngine;
            InitializeComponent();
        }

        /// <summary>
        /// start AI system on start button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            _speechEngine.start();
            btnStop.Enabled = true;
            btnStart.Enabled = false;
        }

        /// <summary>
        /// Intialize AI system on form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            _speechEngine.IntializeSpeechEngine();
        }

        /// <summary>
        ///  stop AI system on stop button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            _speechEngine.stop();
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }

        /// <summary>
        /// learn new command or modified new command on save command button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveCommand_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtInput.Text))
            {
                _speechEngine.AddCommand(txtInput.Text, rtxtOutput.Text);
                txtInput.Text = string.Empty;
                rtxtOutput.Text = string.Empty;
            }
        }
    }
}
