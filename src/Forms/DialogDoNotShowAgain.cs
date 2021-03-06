﻿using Nikse.SubtitleEdit.Logic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nikse.SubtitleEdit.Forms
{
    public partial class DialogDoNotShowAgain : Form
    {
        public bool DoNoDisplayAgain { get; set; }

        public DialogDoNotShowAgain(string title, string text)
        {
            InitializeComponent();

            Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
            int titleBarHeight = screenRectangle.Top - this.Top;

            if (!string.IsNullOrEmpty(Configuration.Settings.Language.Main.DoNotDisplayMessageAgain))
            {
                checkBoxDoNotDisplayAgain.Text = Configuration.Settings.Language.Main.DoNotDisplayMessageAgain;
            }
            else
            {
                checkBoxDoNotDisplayAgain.Visible = false;
            }

            this.Text = title;
            labelText.Text = text;
            FixLargeFonts();
            int width = Math.Max(checkBoxDoNotDisplayAgain.Width, labelText.Width);
            this.Width = width + buttonOK.Width + 75;
            this.Height = labelText.Top + labelText.Height + buttonOK.Height + titleBarHeight + 40;
        }

        private void FixLargeFonts()
        {
            Graphics graphics = this.CreateGraphics();
            SizeF textSize = graphics.MeasureString(buttonOK.Text, this.Font);
            if (textSize.Height > buttonOK.Height - 4)
            {
                int newButtonHeight = (int)(textSize.Height + 7 + 0.5);
                Utilities.SetButtonHeight(this, newButtonHeight, 1);
            }
        }

        private void SpellCheckCompleted_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
                DialogResult = DialogResult.Cancel;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void DialogDoNotShowAgain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DoNoDisplayAgain = checkBoxDoNotDisplayAgain.Checked;
        }

    }
}
