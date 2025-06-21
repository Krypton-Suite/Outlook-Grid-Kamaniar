namespace Krypton.Toolkit
{
    //383, 23
    public partial class FilterValues : UserControl
    {
        private KryptonTextBox TxtValue1 = new();
        private KryptonTextBox TxtValue2 = new();
        private KryptonLabel LblAnd = new();
        private KryptonDateTimePicker dtpValue1 = new();
        private KryptonDateTimePicker dtpValue2 = new();
        private KryptonComboBox commonValues = new();

        public FilterValues()
        {
            InitializeComponent();
            InitControls();
        }

        public void UpdateValueControls(string dataType, string op)
        {
            var typ = Type.GetType($"System.{dataType}");
            if (typ == null && dataType.Equals(typeof(bool).Name, StringComparison.OrdinalIgnoreCase))
                typ = typeof(bool);
            else if (typ == null && dataType.Equals(typeof(Image).Name, StringComparison.OrdinalIgnoreCase))
                typ = typeof(Image);

            List<FilterOperators> operators;
            if (typ == typeof(string) || typ.IsNumeric())
            {
                InitTextBoxes(op);
            }
            else if (typ == typeof(DateTime))
            {
                InitDateBoxes(op);
            }
            else if (typ == typeof(bool))
            {
                operators =
                [
                    FilterOperators.True,
                    FilterOperators.False
                ];
            }
            else if (typ == typeof(Image))
            {
                operators =
                [
                    FilterOperators.IsNull,
                    FilterOperators.IsNotNull
                ];
            }
            else
            {
                operators =
                [
                    FilterOperators.Equals,
                    FilterOperators.NotEquals,
                    FilterOperators.IsNull,
                    FilterOperators.IsNotNull
                ];
            }
        }

        private void InitTextBoxes(string op)
        {
            FilterOperators filterOperators = op.ToEnum<FilterOperators>();
            TpMain.Controls.Clear();
            TpMain.Controls.Add(TxtValue1, 0, 0);
            if (filterOperators == FilterOperators.Between || filterOperators == FilterOperators.NotBetween)
            {
                TpMain.Controls.Add(LblAnd, 1, 0);
                TpMain.Controls.Add(TxtValue2, 2, 0);
            }
        }

        private void InitDateBoxes(string op)
        {
            FilterOperators filterOperators = op.ToEnum<FilterOperators>();
            TpMain.Controls.Clear();
            TpMain.Controls.Add(TxtValue1, 0, 0);
            if (filterOperators == FilterOperators.Between || filterOperators == FilterOperators.NotBetween)
            {
                TpMain.Controls.Add(LblAnd, 1, 0);
                TpMain.Controls.Add(TxtValue2, 2, 0);
            }
        }

        private void InitControls()
        {
            // 
            // TxtValue1
            // 
            TxtValue1.CueHint.CueHintText = "Value 1";
            TxtValue1.Margin = new Padding(0);
            TxtValue1.MaxLength = 255;
            TxtValue1.Size = new Size(175, 23);
            TxtValue1.StateCommon.Content.Padding = new Padding(2, 2, 2, 3);
            TxtValue1.TabIndex = 0;
            // 
            // TxtValue2
            // 
            TxtValue2.CueHint.CueHintText = "Value 2";
            TxtValue2.Margin = new Padding(0);
            TxtValue2.MaxLength = 255;
            TxtValue2.Size = new Size(175, 23);
            TxtValue2.StateCommon.Content.Padding = new Padding(2, 2, 2, 3);
            TxtValue2.TabIndex = 2;
            // 
            // LblAnd
            // 
            LblAnd.Margin = new Padding(0);
            LblAnd.Size = new Size(33, 20);
            LblAnd.TabIndex = 1;
            LblAnd.Values.Text = "And";


            // 
            // dtpValue1
            // 
            dtpValue1.Margin = new Padding(0);
            dtpValue1.Size = new Size(175, 21);
            dtpValue1.TabIndex = 0;
            // 
            // dtpValue1
            // 
            dtpValue2.Margin = new Padding(0);
            dtpValue2.Size = new Size(175, 21);
            dtpValue2.TabIndex = 0;

            // 
            // commonValues
            // 
            commonValues.Size = new Size(175, 23);
            commonValues.DropDownWidth = commonValues.Width;
            commonValues.Margin = new Padding(0);
            commonValues.TabIndex = 0;
        }

    }
}
