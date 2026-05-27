```csharp
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PCFPSTuningApp
{
    public partial class MainForm : Form
    {
        private const int FPS_TARGET = 60;
        private Timer processCheckTimer;
        private Process gameProcess;
        private bool isRunning;

        public MainForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            processCheckTimer = new Timer();
            processCheckTimer.Interval = 1000; // Check every second
            processCheckTimer.Tick += OnProcessCheckTimerTick;

            Button startButton = new Button { Text = "Start FPS Uncapper", Location = new System.Drawing.Point(30, 30) };
            startButton.Click += StartButton_Click;

            Button stopButton = new Button { Text = "Stop FPS Uncapper", Location = new System.Drawing.Point(30, 70) };
            stopButton.Click += StopButton_Click;

            Controls.Add(startButton);
            Controls.Add(stopButton);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (isRunning)
                return;

            gameProcess = Process.GetProcessesByName("YourGameProcessName").FirstOrDefault();
            if (gameProcess != null)
            {
                isRunning = true;
                processCheckTimer.Start();
                MessageBox.Show("FPS uncapping started!");
            }
            else
            {
                MessageBox.Show("Game process not found. Please start the game first.");
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (!isRunning)
                return;

            processCheckTimer.Stop();
            isRunning = false;
            MessageBox.Show("FPS uncapping stopped.");
            gameProcess = null;
        }

        private void OnProcessCheckTimerTick(object sender, EventArgs e)
        {
            if (gameProcess == null || gameProcess.HasExited)
            {
                StopButton_Click(sender, e); // Stop if game has exited
            }
            else
            {
                // Implement FPS uncap logic here
                // For example: Adjust settings based on FPS_TARGET or post-processing hooks
                CheckAndUncapFPS();
            }
        }

        private void CheckAndUncapFPS() 
        {
            // Placeholder for FPS uncapping logic
            // This method can interact with the game's API or modify its behavior to uncap the FPS
        }
    }
}
```