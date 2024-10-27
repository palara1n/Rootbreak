using System;
using System.Collections.Generic;
using System.Management;
using System.Threading.Tasks;
using System.Windows;

namespace Rootbreak
{
    public partial class MainWindow : Window
    {
        private readonly List<string> fakeCodeLines = new List<string>
        {
            "Initializing root access...",
            "Checking device compatibility...",
            "Loading kernel modules...",
            "Exploiting memory overflow...",
            "Gaining root privileges...",
            "Patching security protocols...",
            "Decrypting system files...",
            "Injecting payload...",
            "Verifying system integrity...",
            "Bypassing root checks...",
            "Writing files to /system/...",
            "Granting superuser permissions...",
            "Modifying boot sequence...",
            "Flushing temporary data...",
            "Cleaning up residual files...",
            "Rechecking root status...",
            "Finalizing process...",
            "Operation complete.",
        };

        public MainWindow()
        {
            InitializeComponent();
            InitializeDeviceWatcher();
            JailbreakButton.Visibility = Visibility.Hidden;
            RootButton.Visibility = Visibility.Hidden;
            StatusLabel.Content = "Device Status: Not Connected";
        }

        private void InitializeDeviceWatcher()
        {
            // Set up a WMI watcher to detect USB connections
            ManagementEventWatcher watcher = new ManagementEventWatcher();
            watcher.Query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2"); // EventType = 2 is device connected
            watcher.EventArrived += DeviceConnectedEvent;
            watcher.Start();
        }

        private void DeviceConnectedEvent(object sender, EventArrivedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                StatusLabel.Content = "Device Status: Mobile Device Connected";
                JailbreakButton.Visibility = Visibility.Visible;
                RootButton.Visibility = Visibility.Visible;
            });
        }

        private async void JailbreakButton_Click(object sender, RoutedEventArgs e)
        {
            await SimulateFakeProcess("Starting Jailbreak process...", "Jailbreaking...");
        }

        private async void RootButton_Click(object sender, RoutedEventArgs e)
        {
            await SimulateFakeProcess("Starting Root process...", "Rooting...");
        }

        private async Task SimulateFakeProcess(string startMessage, string processMessage)
        {
            OutputTextBox.Clear();
            OutputTextBox.AppendText(startMessage + Environment.NewLine);
            ProgressBar.Visibility = Visibility.Visible;
            ProgressBar.Value = 0;

            int totalLines = 50;
            int interval = 100; // Milliseconds between each line

            // Loop to simulate 50 lines of "code"
            for (int i = 0; i < totalLines; i++)
            {
                // Generate a random fake line from the list
                string codeLine = fakeCodeLines[i % fakeCodeLines.Count] + $" (Step {i + 1}/50)";
                OutputTextBox.AppendText(codeLine + Environment.NewLine);

                // Update progress bar
                ProgressBar.Value = (i + 1) * 100 / totalLines;

                // Delay to simulate processing time
                await Task.Delay(interval);
            }

            OutputTextBox.AppendText("Process Complete!" + Environment.NewLine);
            ProgressBar.Visibility = Visibility.Hidden;
        }
    }
}
