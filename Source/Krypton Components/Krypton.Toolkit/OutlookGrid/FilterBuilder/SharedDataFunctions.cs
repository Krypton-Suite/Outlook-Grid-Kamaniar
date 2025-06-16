using System.Data;

namespace Krypton.Toolkit;

/// <summary>
/// Provides shared utility functions for data manipulation, particularly for extracting data
/// from UI controls and performing common data operations like finding distinct values.
/// </summary>
public static class SharedDataFunctions
{

    #region Public Functions

    /// <summary>
    /// Extracts the source <see cref="DataTable"/> from a <see cref="DataGridView"/>.
    /// This method attempts to retrieve the underlying data table regardless of whether
    /// the <see cref="DataGridView"/> is bound to a <see cref="DataView"/>, <see cref="DataTable"/>,
    /// <see cref="DataSet"/>, or <see cref="BindingSource"/>.
    /// </summary>
    /// <param name="gridView">The <see cref="DataGridView"/> from which to extract the table.</param>
    /// <returns>A <see cref="DataTable"/> if the grid view is tied to an appropriate data source;
    /// otherwise, <c>null</c>.</returns>
    public static DataTable? GetSourceTable(DataGridView gridView)
    {
        return GetSourceTable(gridView.DataSource, gridView.DataMember);
    }

    /// <summary>
    /// Extracts the source <see cref="DataTable"/> from a data source object and its data member.
    /// This method is robust in handling various common data source types such as <see cref="DataView"/>,
    /// <see cref="DataTable"/>, <see cref="DataSet"/>, and <see cref="BindingSource"/>.
    /// </summary>
    /// <param name="dataSource">The data source object (e.g., <see cref="DataView"/>, <see cref="DataTable"/>, <see cref="DataSet"/>, <see cref="BindingSource"/>).</param>
    /// <param name="dataMember">The name of the data member within the data source (e.g., table name in a <see cref="DataSet"/>).</param>
    /// <returns>A <see cref="DataTable"/> if the data source is tied to an appropriate source;
    /// otherwise, <c>null</c>.</returns>
    public static DataTable? GetSourceTable(object? dataSource, string dataMember)
    {
        DataTable? table = null;
        if (dataSource == null) return table;
        //' Extracts the underlying datatable from either the dataview, dataset, or datatable
        //' that the gridview is bound to.
        try
        {
            table = ((DataView)dataSource).Table;
        }
        catch
        {
            try
            {
                table = (DataTable)dataSource;
            }
            catch
            {
                try
                {
                    table = ((DataSet)dataSource).Tables[dataMember];
                }
                catch
                {
                    try
                    {
                        BindingSource? bs = (BindingSource)dataSource;

                        //' First try to cast the datasource to a dataset
                        try
                        {
                            table = ((DataSet)bs.DataSource!).Tables[bs.DataMember];
                        }
                        catch (Exception)
                        {
                            //' Try to cast the datasource to a datatable
                            try
                            {
                                table = (DataTable)bs.DataSource!;
                            }
                            catch (Exception)
                            {
                                //' Try to cast the datasource to a dataview
                                try
                                {
                                    table = ((DataView)bs.DataSource!).Table;
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        return table;
    }

    /// <summary>
    /// Retrieves a list of distinct string values from a specified column within a <see cref="DataTable"/>.
    /// The values are trimmed and <see cref="DBNull.Value"/> entries are excluded.
    /// </summary>
    /// <param name="SourceTable">The <see cref="DataTable"/> in which the column resides.</param>
    /// <param name="FieldName">The name of the column from which to count distinct entries.</param>
    /// <returns>A <see cref="List{T}"/> of distinct string values from the specified column.</returns>
    public static List<string> CountDistinct(DataTable SourceTable, string FieldName)
    {
        List<string> fields = [];
        object? LastValue = null;
        // Select rows and sort by FieldName to easily find distinct values
        foreach (DataRow dr in SourceTable.Select("", FieldName))
        {
            // Check if the current value is different from the last encountered distinct value
            if (LastValue == null || !ColumnEqual(LastValue, dr[FieldName]))
            {
                LastValue = dr[FieldName];
                // Add the value to the list if it's not DBNull
                if (LastValue != DBNull.Value)
                {
                    fields.Add(LastValue.ToString()!.Trim());
                }
            }
        }
        return fields;
    }

    #endregion Public Functions

    #region Private Void And Functions

    /// <summary>
    /// Compares two objects to determine if they are equal, handling <see cref="DBNull.Value"/>
    /// and providing a case-insensitive comparison for string and char types.
    /// </summary>
    /// <param name="A">The first object to compare.</param>
    /// <param name="B">The second object to compare.</param>
    /// <returns><c>true</c> if the objects are equal; otherwise, <c>false</c>.</returns>
    private static bool ColumnEqual(object A, object B)
    {
        // Both are DBNull.Value.
        if (A == DBNull.Value && B == DBNull.Value)
        {
            return true;
        }
        // Only one is DBNull.Value.
        if (A == DBNull.Value || B == DBNull.Value)
        {
            return false;
        }

        // If both are string or char, perform a case-insensitive comparison.
        if ((A.GetType().Equals(typeof(string)) || A.GetType().Equals(typeof(char))) &&
            (B.GetType().Equals(typeof(string)) || B.GetType().Equals(typeof(char))))
        {
            return string.Equals(A.ToString(), B.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        // For other types, use the standard equality comparison.
        return A.Equals(B);
    }

    #endregion Private Void And Functions

}