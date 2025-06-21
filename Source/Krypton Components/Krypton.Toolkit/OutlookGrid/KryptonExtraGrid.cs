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
        public KryptonOutlookGridGroupBox GroupBox { get; set; }

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
        public KryptonOutlookGridSearchToolBar SearchToolBar { get; set; }

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
        public KryptonOutlookGrid OutlookGrid { get; set; }

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
            this.HeaderVisibleSecondary = false; // Hide secondary header by default
            this.ValuesPrimary.Image = null; // No image for primary header
            this.ValuesSecondary.Heading = string.Empty; // Clear secondary header text

            // Initialize GroupBox control
            GroupBox = new KryptonOutlookGridGroupBox
            {
                Dock = DockStyle.Top, // Dock to top of the panel
                AllowDrop = true,     // Allow drag-and-drop operations
                Visible = false       // Initially hidden
            };

            // Initialize SearchToolBar control
            SearchToolBar = new KryptonOutlookGridSearchToolBar
            {
                Dock = DockStyle.Top,       // Dock to top of the panel (below GroupBox)
                AllowMerge = false,         // Prevent merging with other toolstrips
                GripStyle = ToolStripGripStyle.Hidden, // Hide the grip for a cleaner look
                Visible = false             // Initially hidden
            };

            // Initialize OutlookGrid control
            OutlookGrid = new KryptonOutlookGrid
            {
                Dock = DockStyle.Fill, // Fill the remaining space in the panel
                AllowDrop = true,      // Allow drag-and-drop operations
                GroupBox = GroupBox,   // Associate the GroupBox with the grid for grouping features
                ShowColumnFilter = true, // Enable column filtering
                SearchToolBar = SearchToolBar // Associate the SearchToolBar with the grid for search features
            };

            // Add controls to the Panel of the KryptonHeaderGroup in desired Z-order
            this.Panel.Controls.Add(OutlookGrid);    // OutlookGrid at the bottom (fills remaining space)
            this.Panel.Controls.Add(SearchToolBar); // SearchToolBar above OutlookGrid
            this.Panel.Controls.Add(GroupBox);       // GroupBox at the very top

            // Register events after controls are set up
            OutlookGrid.RegisterGroupBoxEvents(); // Assumed method to connect grid and group box events
            OutlookGrid.OnSearchCompleted += OutlookGrid_OnSearchCompleted; // Subscribe to search completion event

            this.ResumeLayout(); // Resume layout logic
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