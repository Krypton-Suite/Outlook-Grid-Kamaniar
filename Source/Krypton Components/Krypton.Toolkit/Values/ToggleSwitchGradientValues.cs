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
    public class ToggleSwitchGradientValues : GlobalId, INotifyPropertyChanged
    {
        #region Instance Fields

        private bool _enableEmbossEffect;
        private bool _animateGradientEffect;
        private bool _enableKnobGradient;
        private bool _useGradientTints;
        private float _gradientStartIntensity;
        private float _gradientEndIntensity;
        private LinearGradientMode _gradientDirection;

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="ToggleSwitchGradientValues" /> class.</summary>
        public ToggleSwitchGradientValues()
        {
            _enableEmbossEffect = false;
            _animateGradientEffect = false;
            _enableKnobGradient = false;
            _useGradientTints = false;
            _gradientStartIntensity = 0.8f;
            _gradientEndIntensity = 0.6f;
            _gradientDirection = LinearGradientMode.ForwardDiagonal;
        }

        #endregion#

        #region Event

        /// <inheritdoc />
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Event Handlers

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
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        #region Public

        /// <summary>Gets or sets a value indicating whether [enable emboss effect].</summary>
        /// <value><c>true</c> if [enable emboss effect]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [Description("Indicates whether the emboss effect should be applied.")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EnableEmbossEffect
        {
            get => _enableEmbossEffect;
            set => SetField(ref _enableEmbossEffect, value);
        }

        /// <summary>Gets or sets a value indicating whether [animate gradient effect].</summary>
        [Category("Appearance")]
        [Description("Indicates whether the gradient effect should be animated.")]
        [DefaultValue(false)]
        public bool AnimateGradientEffect
        {
            get => _animateGradientEffect;
            set => SetField(ref _animateGradientEffect, value);
        }

        /// <summary>Gets or sets a value indicating whether [enable knob gradient].</summary>
        /// <value><c>true</c> if [enable knob gradient]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [Description("Indicates whether the knob should have a gradient effect.")]
        [DefaultValue(false)]
        public bool EnableKnobGradient
        {
            get => _enableKnobGradient;
            set => SetField(ref _enableKnobGradient, value);
        }

        /// <summary>Gets or sets a value indicating whether [use gradient tints].</summary>
        [Category("Appearance")]
        [Description("Indicates whether the gradient tints should be used.")]
        [DefaultValue(false)]
        public bool UseGradientTints
        {
            get => _useGradientTints;
            set => SetField(ref _useGradientTints, value);
        }

        /// <summary>Gets or sets the gradient start intensity.</summary>
        /// <value>The gradient start intensity.</value>
        [Category("Appearance")]
        [Description("Specifies the gradient intensity for the knob.")]
        [DefaultValue(0.8f)]
        public float GradientStartIntensity
        {
            get => _gradientStartIntensity;
            set => SetField(ref _gradientStartIntensity, value);
        }

        /// <summary>Gets or sets the gradient end intensity.</summary>
        /// <value>The gradient end intensity.</value>
        [Category("Appearance")]
        [Description("Specifies the gradient intensity for the knob.")]
        [DefaultValue(0.6f)]
        public float GradientEndIntensity
        {
            get => _gradientEndIntensity;
            set => SetField(ref _gradientEndIntensity, value);
        }

        /// <summary>Gets or sets the gradient direction.</summary>
        /// <value>The gradient direction.</value>
        [Category("Appearance")]
        [Description("Specifies the direction of the gradient.")]
        [DefaultValue(LinearGradientMode.ForwardDiagonal)]
        public LinearGradientMode GradientDirection
        {
            get => _gradientDirection;
            set => SetField(ref _gradientDirection, value);
        }

        #endregion

        #region IsDefault

        [Browsable(false)]
        public bool IsDefault => !_enableEmbossEffect && !_animateGradientEffect && !_enableKnobGradient && !_useGradientTints &&
                                  _gradientStartIntensity.Equals(0.8f) && _gradientEndIntensity.Equals(0.6f) &&
                                  _gradientDirection == LinearGradientMode.ForwardDiagonal;

        #endregion

        #region Reset

        /// <summary>Resets the properties to their default values.</summary>
        public void Reset()
        {
            EnableEmbossEffect = false;
            AnimateGradientEffect = false;
            EnableKnobGradient = false;
            UseGradientTints = false;
            GradientStartIntensity = 0.8f;
            GradientEndIntensity = 0.6f;
            GradientDirection = LinearGradientMode.ForwardDiagonal;
        }

        #endregion

        #region Public Overrides

        /// <inheritdoc />
        public override string ToString() => !IsDefault ? "Modified" : GlobalStaticValues.DEFAULT_EMPTY_STRING;

        #endregion
    }
}
