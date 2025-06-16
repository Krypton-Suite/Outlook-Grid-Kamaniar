namespace Krypton.Toolkit;

internal interface IFilterItem
{

    #region Properties

    FilterItemMenuButton.Items SelectedMenuItem { get; set; }
    string Filter { get; } // The filter string for the object
    string ReadableFilter { get; } // The readable filter for the object
    string Conjunction { get; } // The conjunction following the object
    FilterField FieldValue { get; set; } // The field for the object

    #endregion Properties

}