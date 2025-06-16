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
    public class ToggleSwitchValues : GlobalId, INotifyPropertyChanged
    {
        #region Instance Fields

        private bool _checked;

        private TintValues? _tintValues;

        private ToggleSwitchColorValues? _toggleSwitchColorValues;

        private ToggleSwitchGradientValues? _gradientValues;

        private ToggleSwitchMiscellaneousValues? _toggleSwitchMiscellaneousValues;

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="ToggleSwitchValues" /> class.</summary>
        public ToggleSwitchValues()
        {
            
        }

        #endregion

        #region Event

        /// <summary>Occurs when a property value changes.</summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Event Handler

        /// <summary>Called when [property changed].</summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>Sets the field.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
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

        #region Public

        /// <summary>Gets or sets a value indicating whether this instance is checked.</summary>
        [Description("Specifies the checked state of the switch.")]
        [Category("Behavior")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Checked
        {
            get => _checked;
            set => SetField(ref _checked, value);
        }

        /// <summary>Gets or sets the tint values.</summary>
        [Category("Appearance")]
        [Description("Specifies the tint values for the switch.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TintValues TintValues
        {
            get => _tintValues ??= new TintValues();

            set
            {
                if (_tintValues != value)
                {
                    if (_tintValues != null)
                    {
                        _tintValues.PropertyChanged -= OnTintValuesPropertiesChanged;
                    }

                    _tintValues = value ?? new TintValues();

                    _tintValues.PropertyChanged += OnTintValuesPropertiesChanged;

                    OnPropertyChanged(nameof(TintValues));
                }
            }
        }

        private bool ShouldSerializeTintValues() => !TintValues.IsDefault;

        public void ResetTintValues() => TintValues.Reset();

        /// <summary>Gets or sets the color values.</summary>
        [Category("Appearance")]
        [Description("Specifies the color values for the switch.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToggleSwitchColorValues ColorValues
        {
            get => _toggleSwitchColorValues ??= new ToggleSwitchColorValues();
            set
            {
                if (_toggleSwitchColorValues != value)
                {
                    if (_toggleSwitchColorValues != null)
                    {
                        _toggleSwitchColorValues.PropertyChanged -= OnColorValuesPropertiesChanged;
                    }
                    _toggleSwitchColorValues = value ?? new ToggleSwitchColorValues();
                    _toggleSwitchColorValues.PropertyChanged += OnColorValuesPropertiesChanged;

                    OnPropertyChanged(nameof(ColorValues));
                }
            }
        }

        /// <summary>Gets or sets the gradient values.</summary>
        [Category("Appearance")]
        [Description("Specifies the gradient values for the knob.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToggleSwitchGradientValues GradientValues
        {
            get => _gradientValues ??= new ToggleSwitchGradientValues();

            set
            {
                if (_gradientValues != value)
                {
                    if (_gradientValues != null)
                    {
                        _gradientValues.PropertyChanged -= OnGradientValuesPropertiesChanged;
                    }
                    _gradientValues = value ?? new ToggleSwitchGradientValues();
                    _gradientValues.PropertyChanged += OnGradientValuesPropertiesChanged;

                    OnPropertyChanged(nameof(GradientValues));
                }
            }
        }

        /// <summary>Gets or sets the miscellaneous values.</summary>
        [Category("Miscellaneous")]
        [Description("Specifies the miscellaneous values for the switch.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToggleSwitchMiscellaneousValues MiscellaneousValues
        {
            get => _toggleSwitchMiscellaneousValues ??= new ToggleSwitchMiscellaneousValues();
            set
            {
                if (_toggleSwitchMiscellaneousValues != value)
                {
                    if (_toggleSwitchMiscellaneousValues != null)
                    {
                        _toggleSwitchMiscellaneousValues.PropertyChanged -= OnColorValuesPropertiesChanged;
                    }
                    _toggleSwitchMiscellaneousValues = value ?? new ToggleSwitchMiscellaneousValues();
                    _toggleSwitchMiscellaneousValues.PropertyChanged += OnColorValuesPropertiesChanged;
                    OnPropertyChanged(nameof(MiscellaneousValues));
                }
            }
        }

        #endregion

        #region IsDefault

        /// <summary>Gets a value indicating whether this instance is default.</summary>
        /// <value><c>true</c> if this instance is default; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsDefault => !_checked && ColorValues.IsDefault &&
                                 GradientValues.IsDefault &&
                                 MiscellaneousValues.IsDefault &&
                                 TintValues.IsDefault;

        #endregion

        #region Reset

        /// <summary>Resets the values.</summary>
        public void Reset()
        {
            _checked = false;
            ColorValues.Reset();
            TintValues.Reset();
            GradientValues.Reset();
            MiscellaneousValues.Reset();
        }

        #endregion

        #region Implementation

        private void OnColorValuesPropertiesChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(ColorValues));
        }

        private void OnTintValuesPropertiesChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(TintValues));
        }

        private void OnGradientValuesPropertiesChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(GradientValues));
        }

        #endregion

        #region Public Overrides

        /// <inheritdoc />
        public override string ToString() => !IsDefault ? "Modified" : GlobalStaticValues.DEFAULT_EMPTY_STRING;

        #endregion
    }

}