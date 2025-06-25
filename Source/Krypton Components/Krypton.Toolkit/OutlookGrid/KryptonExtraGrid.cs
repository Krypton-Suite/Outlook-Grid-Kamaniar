namespace Krypton.Toolkit
{
    /// <summary>
    /// Represents a composite control that integrates a <see cref="KryptonOutlookGrid"/>,
    /// a <see cref="KryptonOutlookGridGroupBox"/> for grouping, and a <see cref="KryptonOutlookGridSearchToolBar"/>
    /// for search functionality, all within a <see cref="KryptonHeaderGroup"/>.
    /// </summary>
    /// <remarks>
    /// This control acts as a container for enhanced data display and interaction,
    /// providing out-of-the-box grouping and searching capabilities for the wrapped grid.
    /// It manages the layout and initial configuration of its child controls.
    /// </remarks>
    public class KryptonExtraGrid : KryptonHeaderGroup
    {

        private readonly KryptonOutlookGrid SummaryGrid = new();

        /// <summary>
        /// Gets or sets the <see cref="KryptonOutlookGridGroupBox"/> associated with this control.
        /// </summary>
        /// <remarks>
        /// This property is marked with <see cref="DesignerSerializationVisibility.Content"/>,
        /// meaning that the properties of the <see cref="KryptonOutlookGridGroupBox"/> instance itself
        /// will be serialized by the designer, allowing its customizable settings to be saved and loaded.
        /// This group box typically provides grouping functionality for the grid.
        /// </remarks>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonOutlookGridGroupBox GroupBox { get; set; } = new();

        /// <summary>
        /// Gets or sets the <see cref="KryptonOutlookGridSearchToolBar"/> associated with this control.
        /// </summary>
        /// <remarks>
        /// This property is marked with <see cref="DesignerSerializationVisibility.Content"/>,
        /// meaning that the properties of the <see cref="KryptonOutlookGridSearchToolBar"/> instance itself
        /// will be serialized by the designer, allowing its customizable settings to be saved and loaded.
        /// This toolbar provides search capabilities for the grid.
        /// </remarks>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonOutlookGridSearchToolBar SearchToolBar { get; set; } = new();

        /// <summary>
        /// Gets or sets the <see cref="KryptonOutlookGrid"/> instance managed by this control.
        /// </summary>
        /// <remarks>
        /// This property is marked with <see cref="DesignerSerializationVisibility.Content"/>,
        /// meaning that the properties of the <see cref="KryptonOutlookGrid"/> instance itself
        /// will be serialized by the designer, allowing its customizable settings to be saved and loaded.
        /// This is the primary grid control whose appearance and behavior are being customized.
        /// </remarks>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonOutlookGrid OutlookGrid { get; set; } = new();

        private bool _showGrandTotalAtBottom = false;
        /// <summary>
        /// Gets or sets a value indicating whether the grand total row should be displayed at the bottom of the grid.
        /// </summary>
        /// <remarks>
        /// Setting this property to <c>true</c> will make the grand total row visible at the bottom of the <see cref="OutlookGrid"/>.
        /// Setting it to <c>false</c> will hide the grand total row.
        /// When visible, the <see cref="SummaryGrid"/> is used to display the grand total.
        /// </remarks>
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ShowGrandTotalAtBottom
        {
            get { return _showGrandTotalAtBottom; }
            set
            {
                if (_showGrandTotalAtBottom != value)
                {
                    _showGrandTotalAtBottom = value;
                    SummaryGrid.Visible = _showGrandTotalAtBottom;
                    if (_showGrandTotalAtBottom)
                    {
                        OutlookGrid.SummaryGrid = SummaryGrid;
                    }
                    else
                    {
                        OutlookGrid.SummaryGrid = null;
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonExtraGrid"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the initial state and layout of the composite control.
        /// It initializes the <see cref="GroupBox"/>, <see cref="SearchToolBar"/>, and <see cref="OutlookGrid"/>
        /// child controls, adding them to the control's panel.
        /// It also establishes event subscriptions, such as `OnSearchCompleted` from the <see cref="OutlookGrid"/>
        /// to update the header based on search text.
        /// </remarks>
        public KryptonExtraGrid()
        {
            this.SuspendLayout();
            this.HeaderVisibleSecondary = false;
            this.ValuesPrimary.Image = null;
            this.ValuesSecondary.Heading = string.Empty;

            // Initialize GroupBox control
            GroupBox.Name = "GroupBox";
            GroupBox.Dock = DockStyle.Top;
            GroupBox.AllowDrop = true;
            GroupBox.Visible = false;

            // Initialize SearchToolBar control
            SearchToolBar.Name = "SearchToolBar";
            SearchToolBar.Dock = DockStyle.Top;
            SearchToolBar.AllowMerge = false;
            SearchToolBar.GripStyle = ToolStripGripStyle.Hidden;
            SearchToolBar.Visible = false;

            // Initialize OutlookGrid control
            OutlookGrid.Name = "OutlookGrid";
            OutlookGrid.Dock = DockStyle.Fill;
            OutlookGrid.AllowDrop = true;
            OutlookGrid.GroupBox = GroupBox;
            OutlookGrid.ShowColumnFilter = true;
            OutlookGrid.SearchToolBar = SearchToolBar;

            // Initialize OutlookGrid for summary
            SummaryGrid.Name = "SummaryGrid";
            SummaryGrid.Dock = DockStyle.Bottom;
            SummaryGrid.ColumnHeadersVisible = false;
            SummaryGrid.Enabled = false;
            SummaryGrid.Visible = false;
            SummaryGrid.Height = 25;

            // Add controls to the Panel of the KryptonHeaderGroup in desired Z-order
            this.Panel.Controls.Add(OutlookGrid);
            this.Panel.Controls.Add(SearchToolBar);
            this.Panel.Controls.Add(GroupBox);
            this.Panel.Controls.Add(SummaryGrid);

            // Register events after controls are set up
            OutlookGrid.RegisterGroupBoxEvents();
            OutlookGrid.OnSearchCompleted += OutlookGrid_OnSearchCompleted;

            this.ResumeLayout();
        }

        /// <summary>
        /// Handles the <see cref="KryptonOutlookGrid.OnSearchCompleted"/> event to update the secondary header.
        /// </summary>
        /// <param name="sender">The source of the event, typically the <see cref="OutlookGrid"/> instance.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// When a search operation in the <see cref="OutlookGrid"/> completes, this method updates the visibility
        /// and text of the <see cref="P:Krypton.Toolkit.HeaderGroupValues.Heading"/> based on the grid's
        /// <see cref="KryptonOutlookGrid.SearchText"/>. If there's active search text, the secondary header
        /// becomes visible and displays that text, providing feedback to the user.
        /// </remarks>
        private void OutlookGrid_OnSearchCompleted(object? sender, EventArgs e)
        {
            // Show secondary header if search text is not empty, otherwise hide it
            this.HeaderVisibleSecondary = !string.IsNullOrEmpty(OutlookGrid.SearchText);
            // Set the secondary header's heading to the current search text
            this.ValuesSecondary.Heading = OutlookGrid.SearchText;
        }
    }
}