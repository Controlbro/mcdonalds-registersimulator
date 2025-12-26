using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class PosDataPromptForm : Form
    {
        private const string ExampleImageUrl = "https://github.com/crashbash111/mcdonalds-registersimulator/assets/50429378/8039989a-6d26-4dc3-9048-636433143916";

        public PosDataPromptForm(string windowTitle)
        {
            Text = windowTitle;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(520, 220);

            Label promptLabel = new Label
            {
                AutoSize = false,
                Text = "This instance is not running within a store environment. In the following dialog, please provide the location of NP6 register files. This folder is typically called Posdata.",
                Dock = DockStyle.Top,
                Height = 80
            };

            LinkLabel exampleLink = new LinkLabel
            {
                Text = "View example Posdata contents (opens in browser)",
                Dock = DockStyle.Top,
                AutoSize = false,
                Height = 24
            };
            exampleLink.LinkClicked += ExampleLink_LinkClicked;

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 45,
                Padding = new Padding(10)
            };

            Button okButton = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Width = 90
            };

            Button cancelButton = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Width = 90
            };

            buttonPanel.Controls.Add(cancelButton);
            buttonPanel.Controls.Add(okButton);

            Controls.Add(buttonPanel);
            Controls.Add(exampleLink);
            Controls.Add(promptLabel);

            AcceptButton = okButton;
            CancelButton = cancelButton;
        }

        private void ExampleLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = ExampleImageUrl,
                UseShellExecute = true
            });
        }
    }
}
