using System.Windows.Forms;

using Krypton.Toolkit;

namespace OutlookGridTest
{
    // In a new file, e.g., SummaryType.cs or at the top of Form1.cs
    public enum SummaryType
    {
        None,
        Count,
        Sum,
        Average,
        Min,
        Max
    }

    public partial class Form1 : Form
    {
        object[] _products;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            GenerateSampleData();
            SetupOutlookGrid();
        }

        private void GenerateSampleData()
        {
            _products = new object[]
            {
                new object[] {1, "Laptop", "Electronics", 1200.50m, 5, new DateTime(2025, 5, 10) },
                new object[] { 2, "Mouse", "Electronics", 25.99m, 20, new DateTime(2025, 5, 15) },
                new object[] { 3, "Keyboard", "Electronics", 75.00m, 12, new DateTime(2025, 5, 20) },
                new object[] { 4, "Desk Chair", "Furniture", 150.00m, 8, new DateTime(2025, 5, 12) },
                new object[] { 5, "Monitor", "Electronics", 300.00m, 7, new DateTime(2025, 6, 1) },
                new object[] { 6, "Bookcase", "Furniture", 90.00m, 10, new DateTime(2025, 6, 5) },
                new object[] { 7, "USB Drive", "Accessories", 15.00m, 30, new DateTime(2025, 5, 25) },
                new object[] { 8, "Webcam", "Electronics", 50.00m, 15, new DateTime(2025, 6, 2) },
                new object[] { 9, "Coffee Table", "Furniture", 70.00m, 6, new DateTime(2025, 5, 28) },
                new object[] { 10, Name = "Headphones", "Electronics", 100.00m, 18, new DateTime(2025, 6, 3) }
            };
        }

        private void SetupOutlookGrid()
        {
            OutlookGridRow row = new();
            List<OutlookGridRow> l = [];
            outlookGrid1.ClearEverything();
            outlookGrid1.HideColumnOnGrouping = false;
            outlookGrid1.FillMode = GridFillMode.GroupsAndNodes;
            outlookGrid1.ShowLines = true;
            outlookGrid1.SuspendLayout();
            outlookGrid1.ClearInternalRows();

            int dispIndex = 0;
            outlookGrid1.CreateOutlookGridColumn("Id", "Id", 100, dispIndex++, false);
            outlookGrid1.CreateOutlookGridColumn("Name", "Name", 100, dispIndex++, true);
            outlookGrid1.CreateOutlookGridColumn("Cat", "Cat", 125, dispIndex++, true, false, SortOrder.Ascending, 0);
            outlookGrid1.CreateOutlookGridColumn("Price", "Price", 125, dispIndex++, true, false, SortOrder.None, -1, DataGridViewContentAlignment.MiddleRight, 2, AggregationType.Sum, "double");
            outlookGrid1.CreateOutlookGridColumn("Quantity", "Quantity", 125, dispIndex++, true, false, SortOrder.None, -1, DataGridViewContentAlignment.MiddleRight, 2, AggregationType.Sum, "double");
            outlookGrid1.CreateOutlookGridColumn("OrdDate", "OrdDate", 125, dispIndex++, true, false, SortOrder.None, -1, DataGridViewContentAlignment.MiddleLeft, -1, AggregationType.None, "datetime");
            /*outlookGrid1.Columns["Price"].ValueType = typeof(double);
            outlookGrid1.Columns["Quantity"].ValueType = typeof(double);
            outlookGrid1.Columns["OrdDate"].ValueType = typeof(DateTime);*/

            row = new OutlookGridRow();
            row.CreateCells(outlookGrid1, new object[] { 1, "Laptop", "Electronics", 1200.50m, 5, new DateTime(2025, 5, 10) });
            l.Add(row);
            row = new OutlookGridRow();
            row.CreateCells(outlookGrid1, new object[] { 2, "Mouse", "Electronics", 25.99m, 20, new DateTime(2025, 5, 15) });
            l.Add(row);
            row = new OutlookGridRow();
            row.CreateCells(outlookGrid1, new object[] { 3, "Keyboard", "Electronics", 75.00m, 12, new DateTime(2025, 5, 20) });
            l.Add(row);
            row = new OutlookGridRow();
            row.CreateCells(outlookGrid1, new object[] { 4, "Desk Chair", "Furniture", 150.00m, 8, new DateTime(2025, 5, 12) });
            l.Add(row);
            row = new OutlookGridRow();
            row.CreateCells(outlookGrid1, new object[] { 6, "Bookcase", "Furniture", 90.00m, 10, new DateTime(2025, 6, 5) });
            l.Add(row);
            row = new OutlookGridRow();
            row.CreateCells(outlookGrid1, new object[] { 7, "Monitor", "Electronics", 90.00m, 10, new DateTime(2025, 6, 5) });
            l.Add(row);

            var intCol = outlookGrid1.FindFromColumnName("Id")!;
            intCol.AvailableInContextMenu = false;

            outlookGrid1.ResumeLayout();
            outlookGrid1.AssignRows(l);
            outlookGrid1.ForceRefreshGroupBox();

            outlookGrid1.Fill();
        }

    }

    public static class GridHelper
    {
        public static void CreateOutlookGridColumn(this KryptonOutlookGrid grid, string columnName, string displayName, int width, int displayIndex, bool visible = true,
            bool showTotal = false, SortOrder sortOrder = SortOrder.None, int groupIndex = -1, DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleLeft,
            int decimalPlace = -1, AggregationType aggregationType = AggregationType.None, string dataType = "string")
        {
            try
            {
                DataGridViewColumn dataGridViewColumn = CreateGridColumn(columnName, displayName, width, displayIndex, visible, showTotal ? "S" : "", dataType, decimalPlace, (int)alignment);
                grid.Columns.Insert(displayIndex, dataGridViewColumn);
                grid.AddInternalColumn(dataGridViewColumn, new OutlookGridDefaultGroup(null), sortOrder, groupIndex, (sortOrder == SortOrder.None) ? (-1) : 0, aggregationType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static DataGridViewColumn CreateGridColumn(string columnName, string displayName, int width, int displayIndex, bool visible, string tag, string dataType, int decimalPlace, int alignment)
        {
            DataGridViewTextBoxColumn obj = new DataGridViewTextBoxColumn
            {
                HeaderText = displayName,
                Name = columnName,
                Width = width,
                DataPropertyName = columnName,
                DisplayIndex = displayIndex,
                Visible = visible,
                Tag = tag,
                SortMode = DataGridViewColumnSortMode.Programmatic,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            SetGridDefaultCellStyle(obj, dataType, decimalPlace, alignment);
            return obj;
        }

        private static void SetGridDefaultCellStyle(DataGridViewColumn dtColumn, string dataType, int decimalPlace = 0, int alignment = 16)
        {
            if (dtColumn != null)
            {
                dtColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                string text = dataType.ToLower();
                dtColumn.HeaderCell.Style.Alignment = (DataGridViewContentAlignment)alignment;
                dtColumn.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)alignment;
                switch (text)
                {
                    case "int64":
                    case "int32":
                    case "int16":
                        dtColumn.ValueType = typeof(int);
                        break;
                    case "double":
                    case "float":
                        dtColumn.ValueType = typeof(double);
                        ApplyNumberFormatting(dtColumn, decimalPlace);
                        break;
                    case "datetime":
                        dtColumn.ValueType = typeof(DateTime);
                        dtColumn.DefaultCellStyle.Format = "dd/MM/yyyy";
                        break;
                    default:
                        dtColumn.ValueType = typeof(string);
                        break;
                }
            }
        }

        private static void ApplyNumberFormatting(DataGridViewColumn dtColumn, int decimalPlace)
        {
            string text = "N" + ((decimalPlace >= 0) ? decimalPlace.ToString() : 2);
            dtColumn.DefaultCellStyle.Format = text;
        }
    }

}
