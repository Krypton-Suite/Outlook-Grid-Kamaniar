namespace OutlookGridTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outlookGrid1 = new Krypton.Toolkit.KryptonOutlookGrid();
            this.kryptonContextMenu1 = new Krypton.Toolkit.KryptonContextMenu();
            this.kryptonContextMenuItem1 = new Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuCheckBox1 = new Krypton.Toolkit.KryptonContextMenuCheckBox();
            this.kryptonContextMenuHeading1 = new Krypton.Toolkit.KryptonContextMenuHeading();
            this.kryptonContextMenuRadioButton1 = new Krypton.Toolkit.KryptonContextMenuRadioButton();
            this.kryptonContextMenuCheckButton1 = new Krypton.Toolkit.KryptonContextMenuCheckButton();
            this.kryptonContextMenuLinkLabel1 = new Krypton.Toolkit.KryptonContextMenuLinkLabel();
            this.kryptonContextMenuColorColumns1 = new Krypton.Toolkit.KryptonContextMenuColorColumns();
            this.kryptonContextMenuImageSelect1 = new Krypton.Toolkit.KryptonContextMenuImageSelect();
            this.kryptonContextMenuMonthCalendar2 = new Krypton.Toolkit.KryptonContextMenuMonthCalendar();
            this.kryptonContextMenuMonthCalendar1 = new Krypton.Toolkit.KryptonContextMenuMonthCalendar();
            this.kryptonContextMenuItem2 = new Krypton.Toolkit.KryptonContextMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.outlookGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // outlookGrid1
            // 
            this.outlookGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outlookGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outlookGrid1.Location = new System.Drawing.Point(12, 106);
            this.outlookGrid1.Name = "outlookGrid1";
            this.outlookGrid1.ShowColumnFilter = true;
            this.outlookGrid1.ShowGrandTotal = true;
            this.outlookGrid1.ShowLines = false;
            this.outlookGrid1.ShowSubTotal = true;
            this.outlookGrid1.Size = new System.Drawing.Size(920, 384);
            this.outlookGrid1.TabIndex = 0;
            // 
            // kryptonContextMenu1
            // 
            this.kryptonContextMenu1.Items.AddRange(new Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem1,
            this.kryptonContextMenuCheckBox1,
            this.kryptonContextMenuHeading1,
            this.kryptonContextMenuRadioButton1,
            this.kryptonContextMenuCheckButton1,
            this.kryptonContextMenuLinkLabel1,
            this.kryptonContextMenuColorColumns1,
            this.kryptonContextMenuImageSelect1,
            this.kryptonContextMenuMonthCalendar2});
            // 
            // kryptonContextMenuColorColumns1
            // 
            this.kryptonContextMenuColorColumns1.SelectedColor = System.Drawing.Color.Empty;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 502);
            this.Controls.Add(this.outlookGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.outlookGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonOutlookGrid outlookGrid1;
        private Krypton.Toolkit.KryptonContextMenu kryptonContextMenu1;
        private Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem1;
        private Krypton.Toolkit.KryptonContextMenuMonthCalendar kryptonContextMenuMonthCalendar1;
        private Krypton.Toolkit.KryptonContextMenuCheckBox kryptonContextMenuCheckBox1;
        private Krypton.Toolkit.KryptonContextMenuHeading kryptonContextMenuHeading1;
        private Krypton.Toolkit.KryptonContextMenuRadioButton kryptonContextMenuRadioButton1;
        private Krypton.Toolkit.KryptonContextMenuCheckButton kryptonContextMenuCheckButton1;
        private Krypton.Toolkit.KryptonContextMenuLinkLabel kryptonContextMenuLinkLabel1;
        private Krypton.Toolkit.KryptonContextMenuColorColumns kryptonContextMenuColorColumns1;
        private Krypton.Toolkit.KryptonContextMenuImageSelect kryptonContextMenuImageSelect1;
        private Krypton.Toolkit.KryptonContextMenuMonthCalendar kryptonContextMenuMonthCalendar2;
        private Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem2;
    }
}
