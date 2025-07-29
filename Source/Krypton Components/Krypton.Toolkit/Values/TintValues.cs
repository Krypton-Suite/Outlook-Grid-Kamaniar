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
    public class TintValues : GlobalId, INotifyPropertyChanged
    {
        #region Instance Fields

        private bool _useHoverGlow;
        private bool _useTopTint;
        private bool _useInnerShadow;
        private bool _useSpecularSparkle;
        private Color _sparkleColor;
        private int _sparkleBrightness;

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="TintValues" /> class.</summary>
        public TintValues()
        {
            _sparkleColor = Color.White;
            _sparkleBrightness = 200;
            _useHoverGlow = false;
            _useTopTint = false;
            _useInnerShadow = false;
            _useSpecularSparkle = false;
        }

        #endregion

        #region Events

        /// <inheritdoc />
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Implementation

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        #region Public

        [Category("Appearence")]
        [Description("Color of the sparkle effect.")]
        [DefaultValue(typeof(Color), "White")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color SparkleColor
        {
            get => _sparkleColor;

            set
            {
                if (_sparkleColor != value)
                {
                    _sparkleColor = value;

                    OnPropertyChanged(nameof(SparkleColor));
                }
            }
        }

        [Category("Appearence")]
        [Description("Brightness of the sparkle effect.")]
        [DefaultValue(200)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SparkleBrightness
        {
            get => _sparkleBrightness;
            set
            {
                if (_sparkleBrightness != value)
                {
                    _sparkleBrightness = value;
                    OnPropertyChanged(nameof(SparkleBrightness));
                }
            }
        }

        [Category("Appearence")]
        [Description("Use the hover glow effect.")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UseHoverGlow
        {
            get => _useHoverGlow;
            set
            {
                if (_useHoverGlow != value)
                {
                    _useHoverGlow = value;
                    OnPropertyChanged(nameof(UseHoverGlow));
                }
            }
        }

        [Category("Appearence")]
        [Description("Use the top tint effect.")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UseTopTint
        {
            get => _useTopTint;
            set
            {
                if (_useTopTint != value)
                {
                    _useTopTint = value;
                    OnPropertyChanged(nameof(UseTopTint));
                }
            }
        }

        [Category("Appearence")]
        [Description("Use the inner shadow effect.")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UseInnerShadow
        {
            get => _useInnerShadow;
            set
            {
                if (_useInnerShadow != value)
                {
                    _useInnerShadow = value;
                    OnPropertyChanged(nameof(UseInnerShadow));
                }
            }
        }

        [Category("Appearence")]
        [Description("Use the specular sparkle effect.")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UseSpecularSparkle
        {
            get => _useSpecularSparkle;
            set
            {
                if (_useSpecularSparkle != value)
                {
                    _useSpecularSparkle = value;
                    OnPropertyChanged(nameof(UseSpecularSparkle));
                }
            }
        }

        #endregion

        #region IsDefault

        /// <summary>Gets a value indicating whether this instance is default.</summary>
        /// <value><c>true</c> if this instance is default; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsDefault => _sparkleColor == Color.White && _sparkleBrightness == 200 && !_useHoverGlow && !_useTopTint && !_useInnerShadow && !_useSpecularSparkle;

        #endregion

        #region Reset

        /// <summary>Resets this instance.</summary>
        public void Reset()
        {
            SparkleColor = Color.White;
            SparkleBrightness = 200;
            UseHoverGlow = false;
            UseTopTint = false;
            UseInnerShadow = false;
            UseSpecularSparkle = false;
        }

        #endregion

        #region Public Overrides

        /// <inheritdoc />
        public override string ToString() => !IsDefault ? "Modified" : GlobalStaticValues.DEFAULT_EMPTY_STRING;

        #endregion
    }
}
