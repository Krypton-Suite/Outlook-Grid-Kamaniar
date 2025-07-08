namespace Krypton.Toolkit
{
    /// <summary>
    /// Provides a designer for the KryptonExtraGrid control, ensuring
    /// internal controls are designable but not directly removable.
    /// </summary>
    internal class KryptonExtraGridDesigner : KryptonHeaderGroupDesigner
    {
        private KryptonExtraGrid? _extraGrid;

        #region Public

        /// <summary>
        /// Initializes the designer with the specified component.
        /// </summary>
        /// <param name="component">The IComponent to associate the designer with.</param>
        public override void Initialize([DisallowNull] IComponent component)
        {
            // Call the base designer's Initialize FIRST.
            // This ensures the Panel is made designable by KryptonHeaderGroupDesigner.
            base.Initialize(component);

            Debug.Assert(component != null);

            _extraGrid = component as KryptonExtraGrid;

            if (_extraGrid != null && _extraGrid.OutlookGrid != null)
            {
                EnableDesignMode(_extraGrid.OutlookGrid, "OutlookGrid");
            }
        }

        /// <summary>
        /// Gets the collection of components associated with the component managed by the designer.
        /// </summary>
        public override ICollection AssociatedComponents
        {
            get
            {
                ArrayList list = new(base.AssociatedComponents);

                if (_extraGrid != null)
                {
                    if (_extraGrid.OutlookGrid != null && !list.Contains(_extraGrid.OutlookGrid))
                        list.Add(_extraGrid.OutlookGrid);

                    if (_extraGrid.BorderTop != null && !list.Contains(_extraGrid.BorderTop))
                        list.Add(_extraGrid.BorderTop);
                    if (_extraGrid.SearchToolBar != null && !list.Contains(_extraGrid.SearchToolBar))
                        list.Add(_extraGrid.SearchToolBar);
                    if (_extraGrid.GroupBox != null && !list.Contains(_extraGrid.GroupBox))
                        list.Add(_extraGrid.GroupBox);
                    if (_extraGrid.SummaryGrid != null && !list.Contains(_extraGrid.SummaryGrid))
                        list.Add(_extraGrid.SummaryGrid);
                    if (_extraGrid.BorderBottom != null && !list.Contains(_extraGrid.BorderBottom))
                        list.Add(_extraGrid.BorderBottom);
                }
                return list;
            }
        }

        #endregion Public

    }

}
