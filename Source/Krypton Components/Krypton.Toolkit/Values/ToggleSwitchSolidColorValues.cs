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
    public class ToggleSwitchSolidColorValues : GlobalId, INotifyPropertyChanged
    {
        #region Instance Fields

        private Color _offColor;
        private Color _onColor;

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="ToggleSwitchSolidColorValues" /> class.</summary>
        public ToggleSwitchSolidColorValues()
        {
            _offColor = Color.Red;

            _onColor = Color.Green;
        }

        #endregion

        #region Event

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Public

        /// <summary>Gets or sets the color of the off state.</summary>
        /// <value>The color of the off state.</value>
        [Category("Visuals")]
        [Description("Color of the off state.")]
        [DefaultValue(typeof(Color), "Red")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color OffColor
        {
            get => _offColor;
            set => SetField(ref _offColor, value);
        }

        /// <summary>Gets or sets the color of the on state.</summary>
        /// <value>The color of the on state.</value>
        [Category("Visuals")]
        [Description("Color of the on state.")]
        [DefaultValue(typeof(Color), "Green")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color OnColor
        {
            get => _onColor;
            set => SetField(ref _onColor, value);
        }

        #endregion

        #region Implementation

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        #region IsDefault

        /// <summary>Gets a value indicating whether this instance is default.</summary>
        /// <value>
        ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDefault => OffColor == Color.Red && OnColor == Color.Green;

        #endregion

        #region Reset

        /// <summary>Resets this instance.</summary>
        public void Reset()
        {
            OffColor = Color.Red;

            OnColor = Color.Green;
        }

        #endregion

        #region Public Overrides

        /// <inheritdoc />
        public override string ToString() => !IsDefault ? "Modified" : GlobalStaticValues.DEFAULT_EMPTY_STRING;

        #endregion
    }
}