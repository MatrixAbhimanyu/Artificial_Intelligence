using System;
using System.Windows.Forms;
using Artificial_Intelligence.Control;

namespace Artificial_Intelligence
{
    public partial class Form1 : Form
    {
        private readonly ISpeechEngine _speechEngine;
        public Form1(ISpeechEngine speechEngine)
        {
            _speechEngine = speechEngine;
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _speechEngine.start();
            btnStop.Enabled = true;
            btnStart.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _speechEngine.IntializeSpeechEngine();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _speechEngine.stop();
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }

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
