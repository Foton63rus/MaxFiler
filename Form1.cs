using MaxFiler;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AppEvents.LogAction += addLog;
            AppEvents.ClearLog += clearLog;
        }

        private void btnInspect_Click(object sender, EventArgs e)
        {
            string directory = this.directoryTextBox.Text;
            AppEvents.InspectDirectoryInvoke(directory);
        }

        private void btnDirectoryOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ValidateNames = false;
            dialog.CheckFileExists = false;
            dialog.CheckPathExists = true;

            dialog.FileName = "Выбор папки";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string directoryPath = Path.GetDirectoryName(dialog.FileName);
                this.directoryTextBox.Text = directoryPath;
            }
        }

        private void clearLog()
        {
            this.logTextBox.Text = "Логи:\n";
        }

        async private void addLog(object sender, string msg)
        {
            this.logTextBox.Text += $"{DateTime.Now.ToString("HH:mm:ss")} {msg}\n";
        }
    }
}