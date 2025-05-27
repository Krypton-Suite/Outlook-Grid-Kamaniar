#region BSD License
/*
 * 
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV), et al. 2024 - 2025. All rights reserved. 
 *  
 */
#endregion

namespace TestForm
{
    partial class TextBoxEventTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnClearKryptonEvents = new Krypton.Toolkit.KryptonButton();
            this.kbtnClearNormalEvents = new Krypton.Toolkit.KryptonButton();
            this.klbKryptonTextBoxEvents = new Krypton.Toolkit.KryptonListBox();
            this.lbNormalTextBoxEvents = new System.Windows.Forms.ListBox();
            this.ktxtKryptonTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.txtNormalTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnClearKryptonEvents);
            this.kryptonPanel1.Controls.Add(this.kbtnClearNormalEvents);
            this.kryptonPanel1.Controls.Add(this.klbKryptonTextBoxEvents);
            this.kryptonPanel1.Controls.Add(this.lbNormalTextBoxEvents);
            this.kryptonPanel1.Controls.Add(this.ktxtKryptonTextBox);
            this.kryptonPanel1.Controls.Add(this.txtNormalTextBox);
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(530, 312);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnClearKryptonEvents
            // 
            this.kbtnClearKryptonEvents.Location = new System.Drawing.Point(281, 275);
            this.kbtnClearKryptonEvents.Name = "kbtnClearKryptonEvents";
            this.kbtnClearKryptonEvents.Size = new System.Drawing.Size(262, 25);
            this.kbtnClearKryptonEvents.TabIndex = 5;
            this.kbtnClearKryptonEvents.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kbtnClearKryptonEvents.Values.Text = "Clear Events";
            this.kbtnClearKryptonEvents.Click += new System.EventHandler(this.kbtnClearKryptonEvents_Click);
            // 
            // kbtnClearNormalEvents
            // 
            this.kbtnClearNormalEvents.Location = new System.Drawing.Point(13, 275);
            this.kbtnClearNormalEvents.Name = "kbtnClearNormalEvents";
            this.kbtnClearNormalEvents.Size = new System.Drawing.Size(262, 25);
            this.kbtnClearNormalEvents.TabIndex = 4;
            this.kbtnClearNormalEvents.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kbtnClearNormalEvents.Values.Text = "Clear Events";
            this.kbtnClearNormalEvents.Click += new System.EventHandler(this.kbtnClearNormalEvents_Click);
            // 
            // klbKryptonTextBoxEvents
            // 
            this.klbKryptonTextBoxEvents.Location = new System.Drawing.Point(282, 43);
            this.klbKryptonTextBoxEvents.Name = "klbKryptonTextBoxEvents";
            this.klbKryptonTextBoxEvents.Size = new System.Drawing.Size(261, 225);
            this.klbKryptonTextBoxEvents.TabIndex = 3;
            // 
            // lbNormalTextBoxEvents
            // 
            this.lbNormalTextBoxEvents.FormattingEnabled = true;
            this.lbNormalTextBoxEvents.Location = new System.Drawing.Point(13, 43);
            this.lbNormalTextBoxEvents.Name = "lbNormalTextBoxEvents";
            this.lbNormalTextBoxEvents.Size = new System.Drawing.Size(262, 225);
            this.lbNormalTextBoxEvents.TabIndex = 2;
            // 
            // ktxtKryptonTextBox
            // 
            this.ktxtKryptonTextBox.Location = new System.Drawing.Point(281, 13);
            this.ktxtKryptonTextBox.Name = "ktxtKryptonTextBox";
            this.ktxtKryptonTextBox.Size = new System.Drawing.Size(262, 23);
            this.ktxtKryptonTextBox.TabIndex = 1;
            this.ktxtKryptonTextBox.TabStop = false;
            this.ktxtKryptonTextBox.Click += new System.EventHandler(this.ktxtKryptonTextBox_Click);
            this.ktxtKryptonTextBox.DoubleClick += new System.EventHandler(this.ktxtKryptonTextBox_DoubleClick);
            this.ktxtKryptonTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ktxtKryptonTextBox_KeyDown);
            this.ktxtKryptonTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ktxtKryptonTextBox_KeyPress);
            this.ktxtKryptonTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ktxtKryptonTextBox_KeyUp);
            this.ktxtKryptonTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ktxtKryptonTextBox_MouseClick);
            this.ktxtKryptonTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ktxtKryptonTextBox_MouseDoubleClick);
            this.ktxtKryptonTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ktxtKryptonTextBox_PreviewKeyDown);
            this.ktxtKryptonTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ktxtKryptonTextBox_Validating);
            this.ktxtKryptonTextBox.Validated += new System.EventHandler(this.ktxtKryptonTextBox_Validated);
            // 
            // txtNormalTextBox
            // 
            this.txtNormalTextBox.Location = new System.Drawing.Point(13, 13);
            this.txtNormalTextBox.Name = "txtNormalTextBox";
            this.txtNormalTextBox.Size = new System.Drawing.Size(262, 20);
            this.txtNormalTextBox.TabIndex = 0;
            this.txtNormalTextBox.Click += new System.EventHandler(this.txtNormalTextBox_Click);
            this.txtNormalTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNormalTextBox_MouseClick);
            this.txtNormalTextBox.DoubleClick += new System.EventHandler(this.txtNormalTextBox_DoubleClick);
            this.txtNormalTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNormalTextBox_KeyDown);
            this.txtNormalTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNormalTextBox_KeyPress);
            this.txtNormalTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNormalTextBox_KeyUp);
            this.txtNormalTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtNormalTextBox_MouseDoubleClick);
            this.txtNormalTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtNormalTextBox_PreviewKeyDown);
            this.txtNormalTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.txtNormalTextBox_Validating);
            this.txtNormalTextBox.Validated += new System.EventHandler(this.txtNormalTextBox_Validated);
            // 
            // TextBoxEventTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(591, 288);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "TextBoxEventTest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TextBoxEventTest";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TextBox txtNormalTextBox;
        private Krypton.Toolkit.KryptonTextBox ktxtKryptonTextBox;
        private System.Windows.Forms.ListBox lbNormalTextBoxEvents;
        private Krypton.Toolkit.KryptonListBox klbKryptonTextBoxEvents;
        private Krypton.Toolkit.KryptonButton kbtnClearNormalEvents;
        private Krypton.Toolkit.KryptonButton kbtnClearKryptonEvents;
    }
}