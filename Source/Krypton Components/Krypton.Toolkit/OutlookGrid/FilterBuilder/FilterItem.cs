namespace Krypton.Toolkit
{

    internal partial class FilterItem : UserControl, IFilterItem
    {

        #region Enums

        public enum FieldTypes
        {
            NumberExpression,
            DateExpression,
            StringExpression,
            DropDownExpression
        }

        #endregion Enums

        #region Delegates And Events

        public event SelectedAndOrEventHandler? SelectedAndOr;
        public event SelectedEndEventHandler? SelectedEnd;
        public event SelectedDeleteEventHandler? SelectedDelete;
        public event SelectedInsertEventHandler? SelectedInsert;
        public event SelectedMakeSubgroupEventHandler? SelectedMakeSubgroup;
        public event FilterChangedEventHandler? FilterChanged;

        #endregion Delegates And Events

        #region Private Variables

        private FilterField _fieldValue = null!;
        private List<SourceColumn> _columns = null!;
        private string _dataType = string.Empty;

        private string _filter = string.Empty;
        private string _readableFilter = string.Empty;

        #endregion Private Variables

        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<SourceColumn> Columns
        {
            get { return (List<SourceColumn>)ColumnsList.DataSource!; }
            set
            {
                _columns = value;
                ColumnsList.DataSource = _columns;
                ColumnsList.DisplayMember = nameof(SourceColumn.Name);
                ColumnsList.ValueMember = nameof(SourceColumn.Alias);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FilterField FieldValue
        {
            get
            {
                GetValues();
                return _fieldValue;
            }
            set
            {
                _fieldValue = value;
                SetValues();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Filter
        {
            get
            {
                SetFilterString();
                return _filter;
            }
        }

        /// <summary>
        ///  A human readable filter string that represents the actual filter string
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ReadableFilter
        {
            get
            {
                SetFilterString();
                return _readableFilter;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FilterItemMenuButton.Items SelectedMenuItem
        {
            get
            {
                return FilterMenu.Item;
            }
            set
            {
                FilterMenu.Item = value;
            }
        }

        /// <summary>
        ///   The boolean conjunction to follow the filter
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Conjunction
        {
            get
            {
                if (this.SelectedMenuItem == FilterItemMenuButton.Items.AndItem)
                {
                    return "AND";
                }
                else if (this.SelectedMenuItem == FilterItemMenuButton.Items.OrItem)
                {
                    return "OR";
                }
                else
                {
                    return "";
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string IntConjunction
        {
            get
            {
                if (this.SelectedMenuItem == FilterItemMenuButton.Items.AndItem)
                {
                    return Convert.ToString((int)FilterItemMenuButton.Items.AndItem);
                }
                else if (this.SelectedMenuItem == FilterItemMenuButton.Items.OrItem)
                {
                    return Convert.ToString((int)FilterItemMenuButton.Items.OrItem);
                }
                else
                {
                    return "";
                }
            }
        }

        #endregion Properties

        #region Constructors

        public FilterItem()
        {
            InitializeComponent();
            Margin = new Padding(0, 0, 0, 0);
            FilterMenu.Height = TxtValue1.Height;
            FilterMenu.Menu.Opening += FilterMenu_Opening;
            FilterMenu.SelectionChanged += FilterMenu_SelectionChanged;
            FilterMenu.SelectionChanging += FilterMenu_SelectionChanging;
            this.SelectedMenuItem = FilterItemMenuButton.Items.EndItem;
        }

        public FilterItem(List<SourceColumn> columns) : this()
        {
            Columns = columns;
            if (columns.Count == 1)
                ColumnsList.Visible = false;
        }

        public FilterItem(List<SourceColumn> columns, FilterField field) : this(columns)
        {
            _fieldValue = field;
            SetValues();
        }

        #endregion Constructors

        #region Control Events

        private void ColumnsList_SelectedValueChanged(object sender, EventArgs e)
        {
            KryptonComboBox cb = (KryptonComboBox)sender;
            try
            {
                SourceColumn? columnItem = (SourceColumn?)cb.SelectedItem;
                if (columnItem != null)
                {
                    _dataType = columnItem.DataType;
                    UpdateOperatorComboBox(columnItem.DataType);
                }
                FilterChanged?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception) { }
        }

        private void OperatorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            KryptonComboBox cb = (KryptonComboBox)sender;
            try
            {
                FilterOperators Operator = cb.SelectedItem.ToStringNull().ToEnum<FilterOperators>();
                TxtValue2.Enabled = Operator == FilterOperators.Between || Operator == FilterOperators.NotBetween;
                TxtValue1.Enabled = Operator switch
                {
                    FilterOperators.IsEmpty or FilterOperators.IsNotEmpty or FilterOperators.IsNull or FilterOperators.IsNotNull or FilterOperators.True or FilterOperators.False => false,
                    _ => true,
                };
                FilterChanged?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception) { }
        }

        private void TxtValue1_TextChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void TxtValue2_TextChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void FilterMenu_Opening(object? sender, CancelEventArgs e)
        {
            if (!IsValid())
                e.Cancel = true;
        }

        private void FilterMenu_SelectionChanged(object sender, MenuButtonSelectionChangedEventArgs e)
        {
            switch (e.NewSelectedIndex)
            {
                case (int)FilterItemMenuButton.Items.AndItem:
                case (int)FilterItemMenuButton.Items.OrItem:
                    SelectedAndOr?.Invoke(this, e);
                    break;

                case (int)FilterItemMenuButton.Items.EndItem:
                    SelectedEnd?.Invoke(this, e);
                    break;
            }
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void FilterMenu_SelectionChanging(object sender, MenuButtonSelectionChangingEventArgs e)
        {
            switch (e.NewSelectedIndex)
            {
                case (int)FilterItemMenuButton.Items.Delete:
                    e.Cancel = true;
                    SelectedDelete?.Invoke(this, e);
                    break;

                case (int)FilterItemMenuButton.Items.Insert:
                    e.Cancel = true;
                    SelectedInsert?.Invoke(this, e);
                    break;

                case (int)FilterItemMenuButton.Items.MakeSubgroup:
                    e.Cancel = true;
                    SelectedMakeSubgroup?.Invoke(this, e);
                    break;
            }
        }

        #endregion Control Events

        #region Private Methods

        private void SetValues()
        {
            ColumnsList.Text = _fieldValue.ColumnName;
            OperatorsList.Text = _fieldValue.ReadableOperator;
            TxtValue1.Text = _fieldValue.Value1;
            TxtValue2.Text = _fieldValue.Value2;
            SelectedMenuItem = (FilterItemMenuButton.Items)_fieldValue.ColumnConjunctionItem;
            FilterMenu.Item = (FilterItemMenuButton.Items)_fieldValue.ColumnConjunctionItem;
            FilterMenu.Text = SelectedMenuItem.GetDescription();
            _dataType = _fieldValue.DataType;
        }

        private void GetValues()
        {
            if (!IsValid(false))
            {
                _fieldValue = null!;
                return;
            }
            SourceColumn fieldItem = (SourceColumn)ColumnsList.SelectedItem!;
            string op = OperatorsList.SelectedItem.ToStringNull();
            var opEnum = op.ToEnum<FilterOperators>();

            _fieldValue = new()
            {
                DataType = _dataType,
                Operator = opEnum.GetDescription(),
                ReadableOperator = op,
                Value1 = TxtValue1.Text.Trim(),
                Value2 = TxtValue2.Enabled ? TxtValue2.Text.Trim() : string.Empty,
                ColumnConjunction = SelectedMenuItem == FilterItemMenuButton.Items.AndItem || SelectedMenuItem == FilterItemMenuButton.Items.OrItem ? SelectedMenuItem.GetDescription() : string.Empty,
                ColumnConjunctionItem = (int)SelectedMenuItem,
                Filter = _filter,
                ColumnName = fieldItem.Name
            };
        }

        private void UpdateOperatorComboBox(string dataType)
        {
            var typ = Type.GetType($"System.{dataType}");
            if (typ == null && dataType.Equals(typeof(bool).Name, StringComparison.OrdinalIgnoreCase))
                typ = typeof(bool);
            else if (typ == null && dataType.Equals(typeof(Image).Name, StringComparison.OrdinalIgnoreCase))
                typ = typeof(Image);

            List<FilterOperators> operators;
            if (typ == typeof(string))
            {
                operators =
                [
                    FilterOperators.Equals,
                    FilterOperators.NotEquals,
                    FilterOperators.BeginsWith,
                    FilterOperators.NotBeginsWith,
                    FilterOperators.Contains,
                    FilterOperators.NotContains,
                    FilterOperators.EndsWith,
                    FilterOperators.NotEndsWith,
                    FilterOperators.IsEmpty,
                    FilterOperators.IsNotEmpty,
                    FilterOperators.IsNull,
                    FilterOperators.IsNotNull
                ];
            }
            else if (typ == typeof(DateTime) ||
                typ.IsNumeric())
            {
                operators =
                [
                    FilterOperators.Equals,
                    FilterOperators.NotEquals,
                    FilterOperators.LessThan,
                    FilterOperators.LessThanOrEqual,
                    FilterOperators.GreaterThan,
                    FilterOperators.GreaterThanOrEqual,
                    FilterOperators.Between,
                    FilterOperators.NotBetween,
                    FilterOperators.IsNull,
                    FilterOperators.IsNotNull
                ];
                /*if (typ != typeof(DateTime))
                {
                    operators.Add(FilterOperators.In);
                    operators.Add(FilterOperators.NotIn);
                }*/
            }
            else if (typ == typeof(bool))
            {
                operators =
                [
                    FilterOperators.True,
                    FilterOperators.False
                ];
            }
            else if (typ == typeof(Image))
            {
                operators =
                [
                    FilterOperators.IsNull,
                    FilterOperators.IsNotNull
                ];
            }
            else
            {
                operators =
                [
                    FilterOperators.Equals,
                    FilterOperators.NotEquals,
                    FilterOperators.IsNull,
                    FilterOperators.IsNotNull
                ];
            }

            OperatorsList.DataSource = operators;
        }

        private void SetFilterString()
        {
            try
            {
                SourceColumn fieldItem = (SourceColumn)ColumnsList.SelectedItem!;

                string op = OperatorsList.SelectedItem.ToStringNull();
                if (string.IsNullOrEmpty(op))
                    op = FilterOperators.Equals.ToString();

                string colName = fieldItem == null || fieldItem.Alias != ColumnsList.Text ? ColumnsList.Text : fieldItem != null ? fieldItem.Alias : string.Empty;
                _dataType = fieldItem == null ? _dataType : fieldItem.DataType;

                _readableFilter = HelperExtensions.GetReadableFilterString(string.Empty, colName, _dataType, op, TxtValue1.Text, TxtValue2.Text, true);
                if (IsValid(false))
                    _filter = HelperExtensions.GetFilterString(string.Empty, colName, _dataType, op, TxtValue1.Text, TxtValue2.Text);
                else
                    _filter = "";
            }
            catch (Exception)
            {
                _filter = "";
            }
        }

        private bool IsValid(bool showMsg = true)
        {
            SourceColumn fieldItem = (SourceColumn)ColumnsList.SelectedItem!;

            string colName = fieldItem.Name;

            if (string.IsNullOrEmpty(colName))
            {
                if (showMsg)
                {
                    KryptonMessageBox.Show("Select a column", "Validation Error");
                    ColumnsList.Focus();
                }
                return false;
            }
            string op = OperatorsList.SelectedItem.ToStringNull();
            if (string.IsNullOrEmpty(op))
            {
                if (showMsg)
                {
                    KryptonMessageBox.Show("Select an operator", "Validation Error");
                    OperatorsList.Focus();
                }
                return false;
            }
            var opEnum = op.ToEnum<FilterOperators>();
            switch (opEnum)
            {
                case FilterOperators.IsEmpty:
                case FilterOperators.IsNotEmpty:
                case FilterOperators.IsNull:
                case FilterOperators.IsNotNull:
                case FilterOperators.True:
                case FilterOperators.False:
                    break;
                default:
                    if (TxtValue1.Text.Trim().Length == 0)
                    {
                        if (showMsg)
                        {
                            KryptonMessageBox.Show("Enter a value", "Validation Error");
                            TxtValue1.Focus();
                        }
                        return false;
                    }
                    break;
            }

            if (opEnum == FilterOperators.Between || opEnum == FilterOperators.NotBetween)
            {
                if (TxtValue2.Text.Trim().Length == 0)
                {
                    if (showMsg)
                    {
                        KryptonMessageBox.Show("Enter a value2", "Validation Error");
                        TxtValue2.Focus();
                    }
                    return false;
                }
            }

            return true;
        }

        #endregion Private Methods

    }
}
