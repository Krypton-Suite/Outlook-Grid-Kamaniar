#region Licences

/*
 *
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV), et al. 2024 - 2024. All rights reserved.
 *
 */

//--------------------------------------------------------------------------------
// Copyright (C) 2013-2021 JDH Software - <support@jdhsoftware.com>
//
// This program is provided to you under the terms of the Microsoft Public
// License (Ms-PL) as published at https://github.com/Cocotteseb/Krypton-OutlookGrid/blob/master/LICENSE.md
//
// Visit https://www.jdhsoftware.com and follow @jdhsoftware on Twitter
//
//--------------------------------------------------------------------------------

#endregion

namespace Krypton.Toolkit
{
    /// <summary>
    /// Column for the OutlookGrid
    /// </summary>
    public class OutlookGridColumn : IEquatable<OutlookGridColumn>
    {
        #region Identity
        /*/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="col">The DataGridViewColumn.</param>
        /// <param name="group">The group type for the column.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="groupIndex">The column's position in grouping and at which level.</param>
        /// <param name="sortIndex">the column's position among sorted columns.</param>
        /// <param name="comparer">The comparer if needed.</param>
        public OutlookGridColumn(DataGridViewColumn col, IOutlookGridGroup group, SortOrder sortDirection, int groupIndex, int sortIndex, IComparer? comparer)
        {
            DataGridViewColumn = col;
            Name = col?.Name;
            GroupingType = group;
            SortDirection = sortDirection;
            GroupIndex = groupIndex;
            SortIndex = sortIndex;
            RowsComparer = comparer;
            AggregationType = AggregationType.None;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="columnName">The name.</param>
        /// <param name="col">The DataGridViewColumn.</param>
        /// <param name="group">The group type for the column.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="groupIndex">The column's position in grouping and at which level.</param>
        /// <param name="sortIndex">the column's position among sorted columns.</param>
        /// <param name="comparer">The comparer if needed</param>
        public OutlookGridColumn(string? columnName, DataGridViewColumn? col, IOutlookGridGroup? group, SortOrder sortDirection, int groupIndex, int sortIndex, IComparer? comparer)
        {
            DataGridViewColumn = col!;
            Name = columnName;
            GroupingType = group;
            SortDirection = sortDirection;
            GroupIndex = groupIndex;
            SortIndex = sortIndex;
            RowsComparer = comparer;
            AggregationType = AggregationType.None;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="columnName">The name.</param>
        /// <param name="col">The DataGridViewColumn.</param>
        /// <param name="group">The group type for the column.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="groupIndex">The column's position in grouping and at which level.</param>
        /// <param name="sortIndex">the column's position among sorted columns.</param>
        public OutlookGridColumn(string columnName, DataGridViewColumn col, IOutlookGridGroup group, SortOrder sortDirection, int groupIndex, int sortIndex)
        {
            DataGridViewColumn = col;
            Name = columnName;
            GroupingType = group;
            SortDirection = sortDirection;
            GroupIndex = groupIndex;
            SortIndex = sortIndex;
            AggregationType = AggregationType.None;
        }

        /// <summary>Initializes a new instance of the <see cref="OutlookGridColumn" /> class.</summary>
        /// <param name="dataGridViewColumn">The data grid view column.</param>
        /// <param name="group">The group.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="groupIndex">Index of the group.</param>
        /// <param name="sortIndex">Index of the sort.</param>
        public OutlookGridColumn(DataGridViewColumn dataGridViewColumn, IOutlookGridGroup? group, SortOrder sortOrder, int groupIndex, int sortIndex)
        {
            DataGridViewColumn = dataGridViewColumn;
            GroupingType = group;
            SortDirection = sortOrder;
            GroupIndex = groupIndex;
            SortIndex = sortIndex;
            AggregationType = AggregationType.None;
        }*/

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="col">The DataGridViewColumn.</param>
        /// <param name="group">The group type for the column.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="groupIndex">The column's position in grouping and at which level.</param>
        /// <param name="sortIndex">the column's position among sorted columns.</param>
        /// <param name="comparer">The comparer if needed.</param>
        /// <param name="aggregationType">The type of aggregation to apply to the column.</param>
        public OutlookGridColumn(DataGridViewColumn col, IOutlookGridGroup group, SortOrder sortDirection, int groupIndex, int sortIndex, IComparer? comparer, AggregationType aggregationType = AggregationType.None)
        {
            DataGridViewColumn = col;
            Name = col?.Name;
            GroupingType = group;
            SortDirection = sortDirection;
            GroupIndex = groupIndex;
            SortIndex = sortIndex;
            RowsComparer = comparer;
            AggregationType = aggregationType;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="columnName">The name.</param>
        /// <param name="col">The DataGridViewColumn.</param>
        /// <param name="group">The group type for the column.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="groupIndex">The column's position in grouping and at which level.</param>
        /// <param name="sortIndex">the column's position among sorted columns.</param>
        /// <param name="comparer">The comparer if needed</param>
        /// <param name="aggregationType">The type of aggregation to apply to the column.</param>
        public OutlookGridColumn(string? columnName, DataGridViewColumn? col, IOutlookGridGroup? group, SortOrder sortDirection, int groupIndex, int sortIndex, IComparer? comparer, AggregationType aggregationType = AggregationType.None)
        {
            DataGridViewColumn = col!;
            Name = columnName;
            GroupingType = group;
            SortDirection = sortDirection;
            GroupIndex = groupIndex;
            SortIndex = sortIndex;
            RowsComparer = comparer;
            AggregationType = aggregationType;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="columnName">The name.</param>
        /// <param name="col">The DataGridViewColumn.</param>
        /// <param name="group">The group type for the column.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="groupIndex">The column's position in grouping and at which level.</param>
        /// <param name="sortIndex">the column's position among sorted columns.</param>
        /// <param name="aggregationType">The type of aggregation to apply to the column.</param>
        public OutlookGridColumn(string columnName, DataGridViewColumn col, IOutlookGridGroup group, SortOrder sortDirection, int groupIndex, int sortIndex, AggregationType aggregationType = AggregationType.None)
        {
            DataGridViewColumn = col;
            Name = columnName;
            GroupingType = group;
            SortDirection = sortDirection;
            GroupIndex = groupIndex;
            SortIndex = sortIndex;
            AggregationType = aggregationType;
        }

        /// <summary>Initializes a new instance of the <see cref="OutlookGridColumn" /> class.</summary>
        /// <param name="col">The data grid view column.</param>
        /// <param name="group">The group.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="groupIndex">Index of the group.</param>
        /// <param name="sortIndex">Index of the sort.</param>
        /// <param name="aggregationType">The type of aggregation to apply to the column.</param>
        public OutlookGridColumn(DataGridViewColumn col, IOutlookGridGroup? group, SortOrder sortOrder, int groupIndex, int sortIndex, AggregationType aggregationType = AggregationType.None)
        {
            DataGridViewColumn = col;
            Name = col?.Name;
            GroupingType = group;
            SortDirection = sortOrder;
            GroupIndex = groupIndex;
            SortIndex = sortIndex;
            AggregationType = aggregationType;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the column name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets if the column is grouped
        /// </summary>
        public bool IsGrouped => GroupIndex > -1;

        /// <summary>
        /// Gets or sets the sort direction
        /// </summary>
        public SortOrder SortDirection { get; set; }

        /// <summary>
        /// Gets or sets the associated DataGridViewColumn
        /// </summary>
        public DataGridViewColumn DataGridViewColumn { get; set; }

        /// <summary>
        /// Gets or sets the group
        /// </summary>
        public IOutlookGridGroup? GroupingType { get; set; }

        /// <summary>
        /// Gets or sets the column's position in grouping and at which level
        /// </summary>
        public int GroupIndex { get; set; }

        /// <summary>
        /// Gets or sets the column's position among sorted columns
        /// </summary>
        public int SortIndex { get; set; }

        /// <summary>
        /// Gets or sets the custom row comparer, if needed.
        /// </summary>
        public IComparer? RowsComparer { get; set; }

        /// <summary>
        /// Gets or sets the type of aggregation to perform on this column.
        /// </summary>
        public AggregationType AggregationType { get; set; }

        /// <summary>
        /// Gets or sets the format string for displaying the aggregated value in summary rows.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This property defines the overall text format for a cell in a summary row (group footer or grand total row).
        /// It uses standard <see cref="string.Format(string, object[])"/> indexed placeholders to embed relevant information.
        /// </para>
        /// <para>
        /// **Placeholder Convention:**
        /// <list type="table">
        ///     <listheader>
        ///         <term>Placeholder</term>
        ///         <description>Description</description>
        ///     </listheader>
        ///     <item>
        ///         <term>{0}</term>
        ///         <description>The group's identifying text (e.g., the value of the grouped column for a subtotal row, or "Grand Total" for a grand total row).</description>
        ///     </item>
        ///     <item>
        ///         <term>{1}</term>
        ///         <description>The <see cref="AggregationType"/> of the column (e.g., "Sum", "Count", "Average") as a string.</description>
        ///     </item>
        ///     <item>
        ///         <term>{2}</term>
        ///         <description>The calculated aggregated value, already formatted according to the column's <see cref="System.Windows.Forms.DataGridViewCellStyle.Format"/> property.</description>
        ///     </item>
        /// </list>
        /// </para>
        /// <para>
        /// **Examples:**
        /// <list type="bullet">
        ///     <item>
        ///         <term><c>"{1}: {2}"</c></term>
        ///         <description>Displays "Sum: 1,234.56" or "Count: 42". This is a common simple format.</description>
        ///     </item>
        ///     <item>
        ///         <term><c>"{0} - Total {1}: {2}"</c></term>
        ///         <description>Displays "Electronics - Total Sum: $1,234.56". Useful when you want to explicitly include the group name.</description>
        ///     </item>
        ///     <item>
        ///         <term><c>"({1}): {2}"</c></term>
        ///         <description>Displays "(Sum): 1,234". Often used for value columns.</description>
        ///     </item>
        ///     <item>
        ///         <term><c>"{2}"</c></term>
        ///         <description>Displays only the formatted aggregated value. Useful for <see cref="AggregationType.MinMax"/> where the value itself might already be a descriptive string like "2024-01-01 - 2024-12-31".</description>
        ///     </item>
        /// </list>
        /// </para>
        /// </remarks>
        public string? AggregationFormatString { get; set; }

        /*/// <summary>
        /// Gets or sets the format string for displaying the aggregated value in summary rows.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This property defines the overall text format for a cell in a summary row (group footer or grand total row).
        /// It supports custom named placeholders that will be replaced with the corresponding values.
        /// </para>
        /// <para>
        /// **Named Placeholder Convention:**
        /// <list type="table">
        ///     <listheader>
        ///         <term>Placeholder</term>
        ///         <description>Replacement Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term>{GroupText}</term>
        ///         <description>The group's identifying text (e.g., the value of the grouped column for a subtotal row, or "Grand Total" for a grand total row).</description>
        ///     </item>
        ///     <item>
        ///         <term>{Aggregate}</term>
        ///         <description>The <see cref="AggregationType"/> of the column (e.g., "Sum", "Count", "Average") as a string.</description>
        ///     </item>
        ///     <item>
        ///         <term>{Value}</term>
        ///         <description>The calculated aggregated value, already formatted according to the column's <see cref="System.Windows.Forms.DataGridViewCellStyle.Format"/> property.</description>
        ///     </item>
        /// </list>
        /// </para>
        /// <para>
        /// **Examples:**
        /// <list type="bullet">
        ///     <item>
        ///         <term><c>"{Aggregate}: {Value}"</c></term>
        ///         <description>Displays "Sum: 1,234.56" or "Count: 42". This is a common simple format.</description>
        ///     </item>
        ///     <item>
        ///         <term><c>"{GroupText} - Total {Aggregate}: {Value}"</c></term>
        ///         <description>Displays "Electronics - Total Sum: $1,234.56". Useful when you want to explicitly include the group name.</description>
        ///     </item>
        ///     <item>
        ///         <term><c>"({Aggregate}): {Value}"</c></term>
        ///         <description>Displays "(Sum): 1,234". Often used for value columns.</description>
        ///     </item>
        ///     <item>
        ///         <term><c>"{Value}"</c></term>
        ///         <description>Displays only the formatted aggregated value. Useful for <see cref="AggregationType.MinMax"/> where the value itself might already be a descriptive string like "2024-01-01 - 2024-12-31".</description>
        ///     </item>
        /// </list>
        /// </para>
        /// </remarks>
        public string? AggregationFormatString { get; set; }*/

        /// <summary>
        /// Gets the list of <see cref="FilterField"/> objects representing the current filter configuration.
        /// </summary>
        public List<FilterField>? Filters { get; set; }

        /// <summary>
        /// Gets or sets the type of aggregation to perform on this column.
        /// </summary>
        public bool AvailableInContextMenu { get; set; } = true;

        #endregion

        #region Implements

        /// <summary>Defines Equals method (interface IEquatable)</summary>
        /// <param name="other">The OutlookGridColumn to compare with</param>
        /// <returns></returns>
        public bool Equals(OutlookGridColumn? other)
            // Use of [DisallowNull] not possible due to interface restrictions (earlier requested change reverted)
            => DataGridViewColumn.Name.Equals(other?.DataGridViewColumn.Name);

        #endregion
    }
}