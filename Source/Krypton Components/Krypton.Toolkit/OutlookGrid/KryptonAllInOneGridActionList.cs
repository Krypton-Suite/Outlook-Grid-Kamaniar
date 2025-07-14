namespace Krypton.Toolkit
{
    /// <summary>
    /// Provides the smart tag actions for the KryptonAllInOneGrid designer.
    /// </summary>
    internal class KryptonAllInOneGridActionList : DesignerActionList
    {
        #region Instance Fields
        private readonly KryptonAllInOneGridDesigner _designer;
        private readonly KryptonAllInOneGrid _allInOneGrid;
        private readonly IComponentChangeService? _service;
        private DesignerActionUIService? _actionUIService; // Cache the UI service

        // Private fields for DesignerVerbs and their dynamic text
        private DesignerVerb _dataHeaderVisibleVerb;
        private string _dataHeaderVisibleText;
        private DesignerVerb _groupBoxVisibleVerb;
        private string _groupBoxVisibleText;
        private DesignerVerb _searchToolBarVisibleVerb;
        private string _searchToolBarVisibleText;
        private DesignerVerb _enableOutlookGridDragDropVerb; // NEW: Verb for drag-drop toggle
        private string _enableOutlookGridDragDropText;       // NEW: Text for drag-drop toggle

        #endregion

        #region Identity
        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonAllInOneGridActionList"/> class.
        /// </summary>
        /// <param name="owner">Designer that owns this action list instance.</param>
        public KryptonAllInOneGridActionList(KryptonAllInOneGridDesigner owner)
            : base(owner.Component)
        {
            _designer = owner;
            _allInOneGrid = (owner.Component as KryptonAllInOneGrid)!;
            _service = GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            _actionUIService = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }
        #endregion

        #region Public Override
        /// <summary>
        /// Returns the collection of DesignerActionItem objects contained in the list.
        /// </summary>
        /// <returns>A DesignerActionItem array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var actions = new DesignerActionItemCollection();

            if (_allInOneGrid != null)
            {
                // Get current visibility states and drag state to set dynamic text for verbs
                var groupBoxCurrentlyVisible = _allInOneGrid.ShowGroupBox;
                var searchToolBarCurrentlyVisible = _allInOneGrid.ShowSearchToolBar;

                // Decide on the initial text values for the verbs
                _groupBoxVisibleText = groupBoxCurrentlyVisible ? "Hide Group Box" : "Show Group Box";
                _searchToolBarVisibleText = searchToolBarCurrentlyVisible ? "Hide Search Toolbar" : "Show Search Toolbar";
                

                // Create the DesignerVerbs with their respective handlers
                _groupBoxVisibleVerb = new DesignerVerb(_groupBoxVisibleText, OnGroupBoxVisibleClick);
                _searchToolBarVisibleVerb = new DesignerVerb(_searchToolBarVisibleText, OnSearchToolBarVisibleClick);

                // Add Group Box Configuration actions
                actions.Add(new DesignerActionHeaderItem("Group Box Configuration"));
                actions.Add(new KryptonDesignerActionItem(_groupBoxVisibleVerb, "Group Box Configuration"));


                // Add Search Toolbar Configuration actions
                actions.Add(new DesignerActionHeaderItem("Search Toolbar Configuration"));
                actions.Add(new KryptonDesignerActionItem(_searchToolBarVisibleVerb, "Search Toolbar Configuration"));

            }

            return actions;
        }
        #endregion

        #region Implementation

        private void OnGroupBoxVisibleClick(object? sender, EventArgs e)
        {
            // Use the public ShowGroupBox property for notification and serialization
            var newVisible = !_allInOneGrid.ShowGroupBox; // Use public property

            PropertyDescriptor? showGroupBoxProp = TypeDescriptor.GetProperties(_allInOneGrid)?["ShowGroupBox"];

            _service?.OnComponentChanging(_allInOneGrid, showGroupBoxProp);
            _allInOneGrid.ShowGroupBox = newVisible;
            _service?.OnComponentChanged(_allInOneGrid, showGroupBoxProp, null, null);

            _actionUIService?.Refresh(_allInOneGrid);
        }

        private void OnSearchToolBarVisibleClick(object? sender, EventArgs e)
        {
            // Use the public ShowSearchToolBar property for notification and serialization
            var newVisible = !_allInOneGrid.ShowSearchToolBar; // Use public property

            PropertyDescriptor? showSearchToolBarProp = TypeDescriptor.GetProperties(_allInOneGrid)?["ShowSearchToolBar"];

            _service?.OnComponentChanging(_allInOneGrid, showSearchToolBarProp);
            _allInOneGrid.ShowSearchToolBar = newVisible;
            _service?.OnComponentChanged(_allInOneGrid, showSearchToolBarProp, null, null);

            _actionUIService?.Refresh(_allInOneGrid);
        }

        // The drag-drop toggle is now handled by the EnableOutlookGridDragDrop property,
        // so this verb handler is no longer needed.
        // private void OnEnableOutlookGridDragDropClick(object? sender, EventArgs e)
        // {
        //     // Toggle the internal designer state
        //     EnableOutlookGridDragDrop = !EnableOutlookGridDragDrop;
        // }

        #endregion
    }
}

/*namespace Krypton.Toolkit
{
    /// <summary>
    /// Provides the smart tag actions for the KryptonAllInOneGrid designer.
    /// </summary>
    internal class KryptonAllInOneGridActionList : DesignerActionList
    {
        #region Instance Fields
        private readonly KryptonAllInOneGridDesigner _designer;
        private readonly KryptonAllInOneGrid _allInOneGrid;
        private readonly IComponentChangeService? _service;
        private DesignerActionUIService? _actionUIService; // Cache the UI service

        // Private fields for DesignerVerbs and their dynamic text, mirroring KryptonHeaderGroupActionList
        private DesignerVerb _dataHeaderVisibleVerb;
        private string _dataHeaderVisibleText;
        private DesignerVerb _groupBoxVisibleVerb;
        private string _groupBoxVisibleText;
        private DesignerVerb _searchToolBarVisibleVerb;
        private string _searchToolBarVisibleText;

        #endregion

        #region Identity
        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonAllInOneGridActionList"/> class.
        /// </summary>
        /// <param name="owner">Designer that owns this action list instance.</param>
        public KryptonAllInOneGridActionList(KryptonAllInOneGridDesigner owner)
            : base(owner.Component)
        {
            _designer = owner;
            _allInOneGrid = (owner.Component as KryptonAllInOneGrid)!;
            _service = GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            _actionUIService = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether new controls can be dragged onto the control's OutlookGrid panel.
        /// </summary>
        public bool EnableOutlookGridDragDrop
        {
            get => _designer.EnableOutlookGridDragging;
            set => _designer.EnableOutlookGridDragging = value;
        }

        /// <summary>
        /// Gets and sets the heading text for the DataHeader.
        /// </summary>
        public string DataHeaderHeading
        {
            get => _allInOneGrid.DataHeader?.Values.Heading ?? string.Empty;
            set
            {
                if (_allInOneGrid.DataHeader != null)
                {
                    // Get the PropertyDescriptor for the DataHeader property on the _allInOneGrid itself
                    PropertyDescriptor? dataHeaderProp = TypeDescriptor.GetProperties(_allInOneGrid)?["DataHeader"];

                    _service?.OnComponentChanging(_designer.Component, dataHeaderProp);
                    _allInOneGrid.DataHeader.Values.Heading = value;
                    _service?.OnComponentChanged(_designer.Component, dataHeaderProp, null, null);
                }
            }
        }

        #endregion

        #region Public Override
        /// <summary>
        /// Returns the collection of DesignerActionItem objects contained in the list.
        /// </summary>
        /// <returns>A DesignerActionItem array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var actions = new DesignerActionItemCollection();

            if (_allInOneGrid != null)
            {
                // Get current visibility states to set dynamic text for verbs
                var dataHeaderCurrentlyVisible = _allInOneGrid.ShowHeader;
                var groupBoxCurrentlyVisible = _allInOneGrid.GroupBox?.Visible ?? false;
                var searchToolBarCurrentlyVisible = _allInOneGrid.SearchToolBar?.Visible ?? false;

                // Decide on the initial text values for the verbs
                _dataHeaderVisibleText = dataHeaderCurrentlyVisible ? "Hide Data Header" : "Show Data Header";
                _groupBoxVisibleText = groupBoxCurrentlyVisible ? "Hide Group Box" : "Show Group Box";
                _searchToolBarVisibleText = searchToolBarCurrentlyVisible ? "Hide Search Toolbar" : "Show Search Toolbar";

                // Create the DesignerVerbs with their respective handlers
                _dataHeaderVisibleVerb = new DesignerVerb(_dataHeaderVisibleText, OnDataHeaderVisibleClick);
                _groupBoxVisibleVerb = new DesignerVerb(_groupBoxVisibleText, OnGroupBoxVisibleClick);
                _searchToolBarVisibleVerb = new DesignerVerb(_searchToolBarVisibleText, OnSearchToolBarVisibleClick);

                // Add Header Configuration actions
                actions.Add(new DesignerActionHeaderItem("Header Configuration"));
                actions.Add(new DesignerActionPropertyItem(
                    nameof(DataHeaderHeading),
                    "Header Text",
                    "Header Configuration",
                    "Sets the heading text for the Data Header."
                ));
                actions.Add(new KryptonDesignerActionItem(_dataHeaderVisibleVerb, "Header Configuration")); // Use KryptonDesignerActionItem


                // Add Group Box Configuration actions
                actions.Add(new DesignerActionHeaderItem("Group Box Configuration"));
                actions.Add(new KryptonDesignerActionItem(_groupBoxVisibleVerb, "Group Box Configuration"));


                // Add Search Toolbar Configuration actions
                actions.Add(new DesignerActionHeaderItem("Search Toolbar Configuration"));
                actions.Add(new KryptonDesignerActionItem(_searchToolBarVisibleVerb, "Search Toolbar Configuration"));
            }

            return actions;
        }
        #endregion

        #region Implementation

        private void OnDataHeaderVisibleClick(object? sender, EventArgs e)
        {
            // The new visible value should be the opposite of the current value
            var newVisible = !_allInOneGrid.ShowHeader;
            
            PropertyDescriptor? dataHeaderProp = TypeDescriptor.GetProperties(_allInOneGrid)?["ShowHeader"];

            _service?.OnComponentChanging(_designer.Component, dataHeaderProp);
            _allInOneGrid.ShowHeader = newVisible;
            _service?.OnComponentChanged(_designer.Component, dataHeaderProp, null, null);

            // Refresh the smart tag UI to reflect the updated text
            _actionUIService?.Refresh(_designer.Component);

        }

        private void OnGroupBoxVisibleClick(object? sender, EventArgs e)
        {
            var newVisible = !(_allInOneGrid.GroupBox?.Visible ?? false);

            if (_allInOneGrid.GroupBox != null)
            {
                PropertyDescriptor? groupBoxProp = TypeDescriptor.GetProperties(_allInOneGrid)?["GroupBox"];

                _service?.OnComponentChanging(_designer.Component, groupBoxProp);
                _allInOneGrid.GroupBox.Visible = newVisible;
                _service?.OnComponentChanged(_designer.Component, groupBoxProp, null, null);

                _actionUIService?.Refresh(_designer.Component);
            }
        }

        private void OnSearchToolBarVisibleClick(object? sender, EventArgs e)
        {
            var newVisible = !(_allInOneGrid.SearchToolBar?.Visible ?? false);

            if (_allInOneGrid.SearchToolBar != null)
            {
                PropertyDescriptor? searchToolBarProp = TypeDescriptor.GetProperties(_allInOneGrid)?["SearchToolBar"];

                _service?.OnComponentChanging(_designer.Component, searchToolBarProp);
                _allInOneGrid.SearchToolBar.Visible = newVisible;
                _service?.OnComponentChanged(_designer.Component, searchToolBarProp, null, null);

                _actionUIService?.Refresh(_designer.Component);
            }
        }

        #endregion
    }
}
*/