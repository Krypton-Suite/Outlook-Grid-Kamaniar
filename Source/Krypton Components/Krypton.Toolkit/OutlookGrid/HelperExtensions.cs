using System.Data.Common;
using System.Linq.Expressions;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Krypton.Toolkit;

public static class HelperExtensions
{

    /// <summary>
    /// Converts an object to a string. If the object is null, returns an empty string.
    /// </summary>
    /// <param name="obj">The object to convert.</param>
    /// <returns>A string representation of the object, or an empty string if null.</returns>
    public static string ToStringNull(this object? obj)
    {
        return obj?.ToString() ?? "";
    }

    /*/// <summary>
    /// Converts an object to an integer. If conversion fails, returns 0.
    /// </summary>
    /// <param name="obj">The object to convert.</param>
    /// <returns>An integer representation of the object, or 0 if conversion fails.</returns>
    public static int ToInteger(this object? obj)
    {
        if (obj == null) return 0;
        if (int.TryParse(obj.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
        {
            return result;
        }
        return 0;
    }*/

    /// <summary>
    /// Converts an object to an integer. Returns 0 if the object is null, whitespace, or if the conversion to an integer fails.
    /// </summary>
    /// <param name="value">The object to attempt conversion from.</param>
    /// <returns>The integer representation of the object, or 0 if the object is null, whitespace, or cannot be parsed as an integer.</returns>
    public static int ToInteger(this object? value) =>
        value is null || string.IsNullOrWhiteSpace(value.ToStringNull())
            ? 0
            : int.TryParse(value.ToStringNull(), out int result) ? result : 0;

    /// <summary>
    /// Converts an object to a long integer. If conversion fails, returns 0L.
    /// </summary>
    /// <param name="obj">The object to convert.</param>
    /// <returns>A long integer representation of the object, or 0L if conversion fails.</returns>
    public static long ToLong(this object? obj)
    {
        if (obj == null) return 0L;
        if (long.TryParse(obj.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out long result))
        {
            return result;
        }
        return 0L;
    }

    /// <summary>
    /// Converts an object to a double. If conversion fails, returns 0.0.
    /// </summary>
    /// <param name="obj">The object to convert.</param>
    /// <returns>A double representation of the object, or 0.0 if conversion fails.</returns>
    public static double ToDouble(this object? obj)
    {
        if (obj == null) return 0.0;
        if (double.TryParse(obj.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
        {
            return result;
        }
        return 0.0;
    }

    /// <summary>
    /// Converts an object to a decimal. If conversion fails, returns 0m.
    /// </summary>
    /// <param name="obj">The object to convert.</param>
    /// <returns>A decimal representation of the object, or 0m if conversion fails.</returns>
    public static decimal ToDecimal(this object? obj)
    {
        if (obj == null) return 0m;
        if (decimal.TryParse(obj.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
        {
            return result;
        }
        return 0m;
    }

    /// <summary>
    /// Converts an object to a boolean. If conversion fails, returns false.
    /// </summary>
    /// <param name="obj">The object to convert.</param>
    /// <returns>A boolean representation of the object, or false if conversion fails.</returns>
    public static bool ToBoolean(this object? obj)
    {
        if (obj == null) return false;
        if (bool.TryParse(obj.ToString(), out bool result))
        {
            return result;
        }
        return false;
    }

    /// <summary>
    /// Converts an object to a DateTime. If conversion fails, returns DateTime.MinValue.
    /// </summary>
    /// <param name="obj">The object to convert.</param>
    /// <returns>A DateTime representation of the object, or DateTime.MinValue if conversion fails.</returns>
    public static DateTime ToDateTime(this object? obj)
    {
        if (obj == null) return DateTime.MinValue;
        if (DateTime.TryParse(obj.ToString(), CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
        {
            return result;
        }
        return DateTime.MinValue;
    }

    /// <summary>
    /// Converts an object to a Guid. If conversion fails, returns Guid.Empty.
    /// </summary>
    /// <param name="obj">The object to convert.</param>
    /// <returns>A Guid representation of the object, or Guid.Empty if conversion fails.</returns>
    public static Guid ToGuid(this object? obj)
    {
        if (obj == null) return Guid.Empty;
        if (Guid.TryParse(obj.ToString(), out Guid result))
        {
            return result;
        }
        return Guid.Empty;
    }


    /// <summary>
    /// Retrieves the description of an <see cref="Enum"/> value using the <see cref="DescriptionAttribute"/>.
    /// If the attribute is not present, it returns the enum value's name.
    /// </summary>
    /// <param name="value">The enum value to get the description for.</param>
    /// <returns>The description of the enum value, or its name if no description is found.</returns>
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? value.ToString();
    }

    /// <summary>
    /// A HashSet containing all the non-nullable integer types in .NET.
    /// </summary>
    private static readonly HashSet<Type> numericTypes = new()
    {
        typeof(sbyte), typeof(byte), typeof(short), typeof(ushort),
        typeof(int), typeof(uint), typeof(long), typeof(ulong),
        typeof(Int16), typeof(UInt16), typeof(Int32), typeof(UInt32),
        typeof(Int64), typeof(UInt64),
        typeof(double), typeof(float), typeof(decimal)
    };

    /// <summary>
    /// Determines whether the specified <see cref="DataGridViewColumn"/> contains numeric data.
    /// This method checks the column's <see cref="DataGridViewColumn.ValueType"/> to see if it
    /// is one of the common numeric types (byte, sbyte, short, ushort, int, uint, long, ulong, float, double, decimal).
    /// </summary>
    /// <param name="column">The <see cref="DataGridViewColumn"/> to check.</param>
    /// <returns>
    /// <c>true</c> if the column's <see cref="DataGridViewColumn.ValueType"/> is a numeric type;
    /// otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNumericColumn(this DataGridViewColumn? column)
    {
        if (column == null || column.ValueType == null) return false;
        Type nonNullableType = Nullable.GetUnderlyingType(column.ValueType) ?? column.ValueType;
        return numericTypes.Contains(nonNullableType);
    }

    /// <summary>
    /// Checks if a given <see cref="Type"/> represents an numeric type. This method
    /// considers both nullable (e.g., <c>int?</c>) and non-nullable (e.g., <c>int</c>)
    /// integer types.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> to check.</param>
    /// <returns><c>true</c> if the <paramref name="type"/> is an numeric type (or a nullable numeric type); otherwise, <c>false</c>.</returns>
    public static bool IsNumeric(this Type? type) =>
        type is not null && numericTypes.Contains(Nullable.GetUnderlyingType(type) ?? type);

    /// <summary>
    /// Converts a string value to an enum of the specified type <typeparamref name="T"/>.
    /// The comparison is case-insensitive.
    /// </summary>
    /// <typeparam name="T">The enum type to convert to. This must be a struct.</typeparam>
    /// <param name="value">The string value to parse.</param>
    /// <returns>The parsed enum value of type <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="value"/> is null or empty.</exception>
    /// <exception cref="ArgumentException">Thrown if the <paramref name="value"/> is not a valid name or value for the enum <typeparamref name="T"/>.</exception>
    public static T ToEnum<T>(this string value) where T : struct
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(nameof(value), "Value cannot be null or empty.");
        return Enum.TryParse(value, out T result) ? result : throw new ArgumentException($"Invalid value for enum {typeof(T)}.");
    }

    #region Generate Sql Filter String

    /// <summary>
    /// Gets a human-readable filter string for a single filter condition.
    /// </summary>
    /// <param name="columnName">The name of the column being filtered.</param>
    /// <param name="columnDataType">The data type of the column.</param>
    /// <param name="filterOperator">The filter operator (e.g., "=", "StartsWith").</param>
    /// <param name="value1">The first filter value.</param>
    /// <param name="value2">The second filter value (for operators like "Between").</param>
    /// <param name="formatValue">A boolean value indicating whether to format the filter values based on the data type.</param>
    /// <returns>A human-readable string representing the filter condition.</returns>
    public static string GetReadableFilterString(string columnName, string columnDataType, string filterOperator, string value1, string value2, bool formatValue = true)
    {
        return GetFilterString(string.Empty, columnName, columnDataType, filterOperator, value1, value2, formatValue, true);
    }

    /// <summary>
    /// Gets a human-readable filter string for a single filter condition with a specified table name.
    /// </summary>
    /// <param name="tableName">The name of the table containing the column.</param>
    /// <param name="columnName">The name of the column being filtered.</param>
    /// <param name="columnDataType">The data type of the column.</param>
    /// <param name="filterOperator">The filter operator (e.g., "=", "StartsWith").</param>
    /// <param name="value1">The first filter value.</param>
    /// <param name="value2">The second filter value (for operators like "Between").</param>
    /// <param name="formatValue">A boolean value indicating whether to format the filter values based on the data type.</param>
    /// <returns>A human-readable string representing the filter condition.</returns>
    public static string GetReadableFilterString(string tableName, string columnName, string columnDataType, string filterOperator, string value1, string value2, bool formatValue = true)
    {
        return GetFilterString(tableName, columnName, columnDataType, filterOperator, value1, value2, formatValue, true);
    }

    /// <summary>
    /// Gets a SQL filter string for a single filter condition.
    /// </summary>
    /// <param name="columnName">The name of the column being filtered.</param>
    /// <param name="columnDataType">The data type of the column.</param>
    /// <param name="filterOperator">The filter operator (e.g., "=", "StartsWith").</param>
    /// <param name="value1">The first filter value.</param>
    /// <param name="value2">The second filter value (for operators like "Between").</param>
    /// <param name="formatValue">A boolean value indicating whether to format the filter values based on the data type for SQL.</param>
    /// <returns>A SQL string representing the filter condition.</returns>
    public static string GetFilterString(string columnName, string columnDataType, string filterOperator, string value1, string value2, bool formatValue = true)
    {
        return GetFilterString(string.Empty, columnName, columnDataType, filterOperator, value1, value2, formatValue);
    }

    /// <summary>
    /// Gets a SQL filter string for a single filter condition with a specified table name.
    /// </summary>
    /// <param name="tableName">The name of the table containing the column.</param>
    /// <param name="columnName">The name of the column being filtered.</param>
    /// <param name="columnDataType">The data type of the column.</param>
    /// <param name="filterOperator">The filter operator (e.g., "=", "StartsWith").</param>
    /// <param name="value1">The first filter value.</param>
    /// <param name="value2">The second filter value (for operators like "Between").</param>
    /// <param name="formatValue">A boolean value indicating whether to format the filter values based on the data type for SQL.</param>
    /// <returns>A SQL string representing the filter condition.</returns>
    public static string GetFilterString(string tableName, string columnName, string columnDataType, string filterOperator, string value1, string value2, bool formatValue = true)
    {
        return GetFilterString(tableName, columnName, columnDataType, filterOperator, value1, value2, formatValue, false);
    }

    /// <summary>
    /// Gets a filter string (either human-readable or SQL) for a single filter condition.
    /// </summary>
    /// <param name="tableName">The name of the table containing the column.</param>
    /// <param name="columnName">The name of the column being filtered.</param>
    /// <param name="columnDataType">The data type of the column.</param>
    /// <param name="filterOperator">The filter operator (e.g., "=", "StartsWith").</param>
    /// <param name="value1">The first filter value.</param>
    /// <param name="value2">The second filter value (for operators like "Between").</param>
    /// <param name="formatValue">A boolean value indicating whether to format the filter values based on the data type.</param>
    /// <param name="readable">A boolean value indicating whether to return a human-readable string (true) or a SQL string (false).</param>
    /// <returns>A string representing the filter condition.</returns>
    public static string GetFilterString(string tableName, string columnName, string columnDataType, string filterOperator, string value1, string value2, bool formatValue, bool readable)
    {
        FilterOperators Operator = filterOperator.ToEnum<FilterOperators>();

        string op = Operator.GetDescription();
        if (readable)
            op = Operator.ToString();

        string formattedValue1 = readable ? value1 : CleanCriteriaForFilter(value1);
        string formattedValue2 = readable ? value2 : CleanCriteriaForFilter(value2);

        switch (Operator)
        {
            case FilterOperators.BeginsWith:
            case FilterOperators.NotBeginsWith:
                formattedValue1 = $"{formattedValue1}";
                break;
            case FilterOperators.Contains:
            case FilterOperators.NotContains:
                formattedValue1 = $"{formattedValue1}";
                break;
            case FilterOperators.EndsWith:
            case FilterOperators.NotEndsWith:
                formattedValue1 = $"{formattedValue1}";
                break;
            case FilterOperators.IsEmpty:
            case FilterOperators.IsNotEmpty:
                formattedValue1 = string.Empty;
                break;
            case FilterOperators.IsNull:
            case FilterOperators.IsNotNull:
                formattedValue1 = "null";
                break;
            case FilterOperators.In:
            case FilterOperators.NotIn:
                formattedValue1 = $"( {formattedValue1} )";
                break;
            default:
                break;
        }

        // Apply formatting AFTER appending %, if required
        if (formatValue)
        {
            formattedValue1 = FormatValue(columnDataType, formattedValue1);
            formattedValue2 = FormatValue(columnDataType, formattedValue2);
        }

        string column = string.IsNullOrEmpty(tableName) ? columnName : $"{tableName}.{columnName}";

        if (Operator == FilterOperators.Between || Operator == FilterOperators.NotBetween)
        {
            if (string.IsNullOrEmpty(value2.ToStringNull().Trim()))
            {
                throw new Exception("value2 is required for Between and NotBetween condition");
            }
            return $"{column} {op} {formattedValue1} AND {formattedValue2}";
        }
        else if (Operator == FilterOperators.IsNull || Operator == FilterOperators.IsNotNull)
        {
            return $"{column} {op}";
        }
        else
        {
            return $"{column} {op} {formattedValue1}";
        }
    }

    /// <summary>
    /// Formats a filter value based on its data type for use in a SQL query.
    /// </summary>
    /// <param name="dataType">The data type of the column.</param>
    /// <param name="value">The value to format.</param>
    /// <returns>The formatted value as a string.</returns>
    private static string FormatValue(string dataType, string value)
    {
        if (string.IsNullOrEmpty(value) && !dataType.Equals(typeof(string).Name, StringComparison.OrdinalIgnoreCase))
            return value;

        if (dataType.Equals(typeof(string).Name, StringComparison.OrdinalIgnoreCase))
            return $"'{value}'";
        else if (dataType.Equals(typeof(DateTime).Name, StringComparison.OrdinalIgnoreCase))
            return $"'{DateTime.Parse(value):yyyy-MM-dd}'";
        else
            return value;
    }

    /// <summary>
    /// Cleans input text for use in an 'expression' (DataColumn.Expression on msdn) or cleaning
    /// criteria for a rowfilter of a data.
    /// </summary>
    /// <param name="input">The string to clean.</param>
    /// <returns>A cleaned up version of the input string.</returns>
    public static string CleanCriteriaForFilter(string input)
    {
        string output = input.Replace("[", "[[]");
        output = output.Replace("]", "[]]");
        output = output.Replace("[[[]]", "[[]");
        output = output.Replace("*", "[*]");
        output = output.Replace("%", "[%]");
        return output;
    }

    #endregion Generate Sql Filter String


}


