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
    public class ToggleSwitchGradientColorValues : GlobalId, INotifyPropertyChanged
    {
        #region Instance Fields

        private Color _startOffColor;
        private Color _endOffColor;
        private Color _startOnColor;
        private Color _endOnColor;

        #endregion

        #region Event

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="ToggleSwitchGradientColorValues" /> class.</summary>
        public ToggleSwitchGradientColorValues()
        {
            _startOffColor = Color.Red;
            _endOffColor = Color.Red;
            _startOnColor = Color.Green;
            _endOnColor = Color.Green;
        }

        #endregion

        #region Public

        /// <summary>Gets or sets the start color of the off state.</summary>
        /// <value>The start color of the off state.</value>#
        [Category("Visuals")]
        [Description("Start color of the off state.")]
        [DefaultValue(typeof(Color), "Red")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color StartOffColor
        {
            get => _startOffColor;
            set => SetField(ref _startOffColor, value);
        }

        /// <summary>Gets or sets the end color of the off state.</summary>
        /// <value>The end color of the off state.</value>
        [Category("Visuals")]
        [Description("End color of the off state.")]
        [DefaultValue(typeof(Color), "Red")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color EndOffColor
        {
            get => _endOffColor;
            set => SetField(ref _endOffColor, value);
        }

        /// <summary>Gets or sets the start color of the on state.</summary>
        /// <value>The start color of the on state.</value>
        [Category("Visuals")]
        [Description("Start color of the on state.")]
        [DefaultValue(typeof(Color), "Green")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color StartOnColor
        {
            get => _startOnColor;
            set => SetField(ref _startOnColor, value);
        }

        /// <summary>Gets or sets the end color of the on state.</summary>
        /// <value>The end color of the on state.</value>
        [Category("Visuals")]
        [Description("End color of the on state.")]
        [DefaultValue(typeof(Color), "Green")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color EndOnColor
        {
            get => _endOnColor;
            set => SetField(ref _endOnColor, value);
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

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDefault => StartOffColor == Color.Red && EndOffColor == Color.Red && StartOnColor == Color.Green && EndOnColor == Color.Green;

        #endregion

        #region Reset

        public void Reset()
        {
            StartOffColor = Color.Red;

            EndOffColor = Color.Red;

            StartOnColor = Color.Green;

            EndOnColor = Color.Green;
        }

        #endregion

        #region Public Overrides

        public override string ToString() => !IsDefault ? "Modified" : GlobalStaticValues.DEFAULT_EMPTY_STRING;

        #endregion
    }
}