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
    public class ToggleSwitchColorValues : GlobalId, INotifyPropertyChanged
    {
        #region Instance Fields

        private ToggleSwitchGradientColorValues? _gradientColorValues;

        private ToggleSwitchSolidColorValues? _solidColorValues;

        /*private Color _offColor;
        private Color _offColor2;
        private Color _onColor;
        private Color _onColor2;*/

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="ToggleSwitchColorValues" /> class.</summary>
        public ToggleSwitchColorValues()
        {
            /*_offColor = Color.Red;
            _onColor = Color.Green;*/
        }

        #endregion
        
        #region Event
      
        /// <inheritdoc />
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Public

        /// <summary>Gets or sets the gradient color values.</summary>
        /// <value>The gradient color values.</value>
        [Category("Visuals")]
        [Description("Gradient color values.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToggleSwitchGradientColorValues? GradientColorValues
        {
            get => _gradientColorValues ??= new ToggleSwitchGradientColorValues();
            set
            {
                if (_gradientColorValues != value)
                {
                    if (_gradientColorValues != null)
                    {
                        _gradientColorValues.PropertyChanged -= OnGradientColorValuesPropertiesChanged;
                    }

                    _gradientColorValues = value ?? new ToggleSwitchGradientColorValues();

                    _gradientColorValues.PropertyChanged += OnGradientColorValuesPropertiesChanged;
                    
                    OnPropertyChanged(nameof(GradientColorValues));
                }
            }
        }

        /// <summary>Gets or sets the solid color values.</summary>
        /// <value>The solid color values.</value>
        [Category("Visuals")]
        [Description("Solid color values.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToggleSwitchSolidColorValues? SolidColorValues
        {
            get => _solidColorValues ??= new ToggleSwitchSolidColorValues();
            set
            {
                if (_solidColorValues != value)
                {
                    if (_solidColorValues != null)
                    {
                        _solidColorValues.PropertyChanged -= OnSolidColorValuesPropertiesChanged;
                    }
                    _solidColorValues = value ?? new ToggleSwitchSolidColorValues();
                    _solidColorValues.PropertyChanged += OnSolidColorValuesPropertiesChanged;
                    
                    OnPropertyChanged(nameof(SolidColorValues));
                }
            }
        }

        private void OnGradientColorValuesPropertiesChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(GradientColorValues));
        }

        private void OnSolidColorValuesPropertiesChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SolidColorValues));
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
        /// <value><c>true</c> if this instance is default; otherwise, <c>false</c>.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDefault => (GradientColorValues?.IsDefault ?? true) && (SolidColorValues?.IsDefault ?? true);

        #endregion

        #region Reset

        /// <summary>Resets this instance.</summary>
        public void Reset()
        {
            GradientColorValues?.Reset();

            SolidColorValues?.Reset();
        }

        #endregion

        #region Public Overrides

        /// <inheritdoc />
        public override string ToString() => !IsDefault ? "Modified" : GlobalStaticValues.DEFAULT_EMPTY_STRING;

        #endregion
    }
}
