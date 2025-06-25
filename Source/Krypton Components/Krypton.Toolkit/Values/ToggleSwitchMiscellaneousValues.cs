#region BSD License
/*
 *
 * Original BSD 3-Clause License (https://github.com/ComponentFactory/Krypton/blob/master/LICENSE)
 *  © Component Factory Pty Ltd, 2006 - 2016, (Version 4.5.0.0) All rights reserved.
 *
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner (aka Wagnerp), Simon Coghlan (aka Smurf-IV), Giduac & Ahmed Abdelhameed et al. 2025 - 2025. All rights reserved.
 *
 */
#endregion

namespace Krypton.Toolkit
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ToggleSwitchMiscellaneousValues : GlobalId, INotifyPropertyChanged
    {
        #region Instance Fields

        private bool _onlyShowColorOnKnob;
        private bool _showText;
        private int _cornerRadius;
        private bool _useThemeColors;

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="ToggleSwitchMiscellaneousValues" /> class.</summary>
        public ToggleSwitchMiscellaneousValues()
        {
            _onlyShowColorOnKnob = true;
            _showText = true;
            _cornerRadius = 10;
            _useThemeColors = true;
        }

        #endregion

        #region Event

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Implementation

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        #region Public

        /// <summary>Gets or sets a value indicating whether [show color only on knob].</summary>
        [Category("Appearance")]
        [Description("Indicates whether the color should be only shown on the knob.")]
        [DefaultValue(true)]
        public bool OnlyShowColorOnKnob
        {
            get => _onlyShowColorOnKnob;
            set => SetField(ref _onlyShowColorOnKnob, value);
        }

        /// <summary>Gets or sets a value indicating whether [show text].</summary>
        [Category("Appearance")]
        [Description("Indicates whether the text should be shown.")]
        [DefaultValue(true)]
        public bool ShowText
        {
            get => _showText;
            set => SetField(ref _showText, value);
        }

        /// <summary>Gets or sets the corner radius.</summary>
        [Category("Appearance")]
        [Description("Indicates the corner radius.")]
        [DefaultValue(10)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set => SetField(ref _cornerRadius, value);
        }

        /// <summary>Gets or sets a value indicating whether [use theme colors].</summary>
        [Category("Appearance")]
        [Description("Indicates whether the theme colors should be used.")]
        [DefaultValue(true)]
        public bool UseThemeColors
        {
            get => _useThemeColors;
            set => SetField(ref _useThemeColors, value);
        }

        #endregion

        #region Implementation

        /// <summary>Called when [property changed].</summary>

        #endregion

        #region IsDefault

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDefault
        {
            get
            {
                return _onlyShowColorOnKnob == true &&
                       _showText == true &&
                       _cornerRadius == 10 &&
                       _useThemeColors == true;
            }
        }

        #endregion

        #region Reset

        public void Reset()
        {
            OnlyShowColorOnKnob = true;
            ShowText = true;
            CornerRadius = 10;
            UseThemeColors = true;
        }

        #endregion

        #region Public Overrides

        /// <summary>Returns a <see cref="T:System.String" /> that represents the current object.</summary>
        public override string ToString() => !IsDefault ? "Modified" : GlobalStaticValues.DEFAULT_EMPTY_STRING;

        #endregion
    }
}
