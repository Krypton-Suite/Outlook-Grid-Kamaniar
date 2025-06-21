using System.Data;

using Krypton.Toolkit;

namespace OutlookGridTest
{
    public partial class Form1 : Form
    {
        List<object[]> _products;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            outlookGrid1.FillMode = GridFillMode.GroupsAndNodes;
            //FillWithCurrentMethod();
            SetButtonText();
        }

        private void FillWithCurrentMethod()
        {
            OutlookGridRow row = new();
            List<OutlookGridRow> l = [];
            outlookGrid1.ClearEverything();
            outlookGrid1.HideColumnOnGrouping = false;
            outlookGrid1.FillMode = GridFillMode.GroupsAndNodes;
            outlookGrid1.ShowLines = true;
            outlookGrid1.SuspendLayout();

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

        private void BtnShowSubTotal_Click(object sender, EventArgs e)
        {
            outlookGrid1.ShowSubTotal = !outlookGrid1.ShowSubTotal;
            SetButtonText();
        }

        private void BtnShowGrandTotal_Click(object sender, EventArgs e)
        {
            outlookGrid1.ShowGrandTotal = !outlookGrid1.ShowGrandTotal;
            SetButtonText();
        }

        private void BtnShowColumnFilter_Click(object sender, EventArgs e)
        {
            outlookGrid1.ShowColumnFilter = !outlookGrid1.ShowColumnFilter;
            SetButtonText();
        }

        private void BtnEnableSearch_Click(object sender, EventArgs e)
        {
            outlookGrid1.EnableSearchOnKeyPress = !outlookGrid1.EnableSearchOnKeyPress;
            SetButtonText();
        }

        private void BtnHighlightSearch_Click(object sender, EventArgs e)
        {
            outlookGrid1.HighlightSearchText = !outlookGrid1.HighlightSearchText;
            outlookGrid1.Invalidate();
            SetButtonText();
        }

        private void BtnShowIdInColumnContext_Click(object sender, EventArgs e)
        {
            // reset for testing because it's work after context menu reset
            FillWithCurrentMethod();
            var intCol = outlookGrid1.FindFromColumnName("Id")!;
            if (BtnShowIdInColumnContext.Text == "Hide Id In Col Context")
                intCol.AvailableInContextMenu = false;
            else
                intCol.AvailableInContextMenu = true;
            SetButtonText();
        }

        private void BtnSelectionMode_Click(object sender, EventArgs e)
        {
            if (outlookGrid1.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                outlookGrid1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
            else
            {
                outlookGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void SetButtonText()
        {
            if (outlookGrid1.ShowSubTotal)
                BtnShowSubTotal.Text = "Hide Sub Total";
            else
                BtnShowSubTotal.Text = "Show Sub Total";

            if (outlookGrid1.ShowGrandTotal)
                BtnShowGrandTotal.Text = "Hide Grand Total";
            else
                BtnShowGrandTotal.Text = "Show Grand Total";

            if (outlookGrid1.ShowColumnFilter)
                BtnShowColumnFilter.Text = "Hide Column Filter";
            else
                BtnShowColumnFilter.Text = "Show Column Filter";

            if (outlookGrid1.EnableSearchOnKeyPress)
                BtnEnableSearch.Text = "Disable Search";
            else
                BtnEnableSearch.Text = "Enable Search";

            BtnHighlightSearch.Text = $"Highlight Search : {outlookGrid1.HighlightSearchText}";

            if (outlookGrid1.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                BtnSelectionMode.Text = "Cell Select";
            }
            else
            {
                BtnSelectionMode.Text = "Full Row Select";
            }

            /*var intCol = outlookGrid1.FindFromColumnName("Id")!;
            if (intCol.AvailableInContextMenu)
                BtnShowIdInColumnContext.Text = "Hide Id In Col Context";
            else
                BtnShowIdInColumnContext.Text = "Show Id In Col Context";*/

        }


        private void BtnLoadDataTable_Click(object sender, EventArgs e)
        {
            LoadDataTableData();
        }

        private void LoadDataTableData()
        {
            // 1. Create a new DataTable
            DataTable productsTable = new DataTable("Products");

            // 2. Define the columns for the DataTable, specifying their types
            productsTable.Columns.Add("Id", typeof(int));
            productsTable.Columns.Add("Name", typeof(string));
            productsTable.Columns.Add("Category", typeof(string));
            productsTable.Columns.Add("Price", typeof(decimal)); // Use decimal for currency
            productsTable.Columns.Add("StockQuantity", typeof(int));
            productsTable.Columns.Add("LastRestockDate", typeof(DateTime));
            productsTable.Columns.Add("IsAvailable", typeof(bool));
            productsTable.Columns.Add("Rating", typeof(double));
            // You could add an Image column if needed, e.g.:
            // productsTable.Columns.Add("Thumbnail", typeof(Image));

            // 3. Add rows to the DataTable
            productsTable.Rows.Add(1, "Laptop Pro X", "Electronics", 1200.50m, 5, new DateTime(2025, 5, 10), true, 4.7);
            productsTable.Rows.Add(2, "Wireless Mouse", "Electronics", 25.99m, 20, new DateTime(2025, 5, 15), true, 4.2);
            productsTable.Rows.Add(3, "Mechanical Keyboard", "Electronics", 75.00m, 12, new DateTime(2025, 5, 20), false, 4.5);
            productsTable.Rows.Add(5, "27-inch Monitor", "Electronics", 300.00m, 7, new DateTime(2025, 6, 1), true, 4.8);
            productsTable.Rows.Add(4, "Ergonomic Desk Chair", "Furniture", 150.00m, 8, new DateTime(2025, 5, 12), true, 3.9);
            productsTable.Rows.Add(6, "Hardcover Bookcase", "Furniture", 90.00m, 10, new DateTime(2025, 6, 5), true, 4.1);
            productsTable.Rows.Add(7, "USB-C Hub", "Accessories", 45.00m, 30, new DateTime(2025, 5, 25), true, 4.0);
            // Example of a row with a null value for Rating
            productsTable.Rows.Add(8, "HD Webcam", "Electronics", 50.00m, 15, new DateTime(2025, 6, 2), false, DBNull.Value);
            productsTable.Rows.Add(9, "Modern Coffee Table", "Furniture", 70.00m, 6, new DateTime(2025, 5, 28), true, 4.6);
            productsTable.Rows.Add(10, "Noise-Cancelling Headphones", "Electronics", 100.00m, 18, new DateTime(2025, 6, 3), true, 4.9);

            outlookGrid1.DataSource = productsTable;
            //outlookGrid1.SetDataSource(productsTable);
        }

        private void BtnLoadListOfT_Click(object sender, EventArgs e)
        {
            LoadProductData();
        }

        private Random _random = new Random();

        private void LoadProductData()
        {
            List<ProductDto> products = new List<ProductDto>();
            int numberOfProductsToGenerate = 10000; // You can change this to 100,000 or more

            // Define possible categories and product prefixes/suffixes for more variety
            string[] categories = { "Electronics", "Furniture", "Books", "Apparel", "Home Goods", "Office Supplies", "Outdoor & Garden" };
            string[] namePrefixes = { "Super", "Mega", "Ultra", "Smart", "Eco", "Pro", "Elite", "Compact" };
            string[] nameSuffixes = { "X", "Plus", "Max", "Series", "Edition", "Go", "Connect", "Master" };
            string[] commonProductWords = { "Laptop", "Mouse", "Keyboard", "Chair", "Monitor", "Desk", "Book", "Shirt", "Lamp", "Pen", "Tablet", "Speaker", "Camera", "Headphones" };


            for (int i = 1; i <= numberOfProductsToGenerate; i++)
            {
                string category = categories[_random.Next(categories.Length)];
                string productName = $"{namePrefixes[_random.Next(namePrefixes.Length)]} {commonProductWords[_random.Next(commonProductWords.Length)]} {nameSuffixes[_random.Next(nameSuffixes.Length)]} {i}";

                decimal price = Math.Round((decimal)(_random.NextDouble() * 500) + 10, 2); // Price between 10.00 and 510.00
                int stockQuantity = _random.Next(1, 200); // Stock between 1 and 199

                // Dates within the last year or so, including current date
                DateTime lastUpdated = DateTime.Now.AddDays(-_random.Next(0, 365));
                bool isAvailable = _random.Next(0, 100) < 95; // 95% chance of being available

                double rating = Math.Round(_random.NextDouble() * 5.0, 1); // Rating between 0.0 and 5.0, one decimal place
                if (rating < 1.0) rating = 1.0; // Ensure a minimum rating of 1.0 for more realistic data

                // For the Image property:
                // For large data, setting actual image bytes for thousands of products can consume a lot of memory.
                // It's often better to leave it null or use a small placeholder/dummy byte array for testing unless
                // your test specifically involves loading/displaying these images.
                Image? productImage = null; // Most practical for large data
                                            // If you need *some* image data, you could use a tiny, fixed placeholder:
                                            // productImage = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x00, 0x00, 0x0D, 0x49, 0x48, 0x44, 0x52, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x08, 0x06, 0x00, 0x00, 0x00, 0x1F, 0x15, 0xC4, 0x89, 0x00, 0x00, 0x00, 0x0A, 0x49, 0x44, 0x41, 0x54, 0x78, 0x9C, 0x63, 0x00, 0x01, 0x00, 0x00, 0x05, 0x00, 0x01, 0x0D, 0x0A, 0x2D, 0xB4, 0x00, 0x00, 0x00, 0x00, 0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82 }; // A tiny 1x1 black PNG

                products.Add(new ProductDto(
                    i,
                    productName,
                    category,
                    price,
                    stockQuantity,
                    lastUpdated,
                    isAvailable,
                    rating,
                    productImage
                ));
            }

            // Example of setting data for your grid
            outlookGrid1.SetDataSource(products);
            outlookGrid1.AutoResizeColumnsToFit();
            kryptonExtraGrid1.OutlookGrid.SetDataSource(products);
            outlookGrid1.Columns["Price"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            outlookGrid1.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            outlookGrid1.Columns["Price"].DefaultCellStyle.Format = "N2";
            Console.WriteLine($"Generated and loaded {products.Count} products.");
        }

        private void BtnLoadListOfRawArray_Click(object sender, EventArgs e)
        {
            LoadRawArrayData();
        }

        private void LoadRawArrayData()
        {
            List<object[]> rawData = new List<object[]>
            {
                new object[] { 1, "Laptop Pro X", "Electronics", 1200.50m, 5, new DateTime(2025, 5, 10), true, 4.7 },
                new object[] { 2, "Wireless Mouse", "Electronics", 25.99m, 20, new DateTime(2025, 5, 15), true, 4.2 },
                new object[] { 3, "Mechanical Keyboard", "Electronics", 75.00m, 12, new DateTime(2025, 5, 20), false, 4.5 },
                new object[] { 4, "Ergonomic Desk Chair", "Furniture", 150.00m, 8, new DateTime(2025, 5, 12), true, 3.9 },
                new object[] { 5, "27-inch Monitor", "Electronics", 300.00m, 7, new DateTime(2025, 6, 1), true, 4.8 },
                new object[] { 6, "Hardcover Bookcase", "Furniture", 90.00m, 10, new DateTime(2025, 6, 5), true, 4.1 },
                new object[] { 7, "USB-C Hub", "Accessories", 45.00m, 30, new DateTime(2025, 5, 25), true, 4.0 },
                new object[] { 8, "HD Webcam", "Electronics", 50.00m, 15, new DateTime(2025, 6, 2), false, 3.5 },
                new object[] { 9, "Modern Coffee Table", "Furniture", 70.00m, 6, new DateTime(2025, 5, 28), true, 4.6 },
                new object[] { 10, "Noise-Cancelling Headphones", "Electronics", 100.00m, 18, new DateTime(2025, 6, 3), true, 4.9 }
            };

            outlookGrid1.SetDataSource(rawData);
        }

        private void BtnLoadDictionary_Click(object sender, EventArgs e)
        {
            LoadDictionaryData();
        }

        private void LoadDictionaryData()
        {
            List<Dictionary<string, object>> dictionaryData = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object>
                {
                    { "Id", 1 },
                    { "ProductName", "Laptop Pro X" },
                    { "ProductCategory", "Electronics" },
                    { "UnitPrice", 1200.50m },
                    { "QtyInStock", 5 },
                    { "RestockDate", new DateTime(2025, 5, 10) },
                    { "Available", true },
                    { "CustomerRating", 4.7 }
                },
                new Dictionary<string, object>
                {
                    { "Id", 2 },
                    { "ProductName", "Wireless Mouse" },
                    { "ProductCategory", "Electronics" },
                    { "UnitPrice", 25.99m },
                    { "QtyInStock", 20 },
                    { "RestockDate", new DateTime(2025, 5, 15) },
                    { "Available", true },
                    { "CustomerRating", 4.2 }
                },
                new Dictionary<string, object>
                {
                    { "Id", 3 },
                    { "ProductName", "Mechanical Keyboard" },
                    { "ProductCategory", "Electronics" },
                    { "UnitPrice", 75.00m },
                    { "QtyInStock", 12 },
                    { "RestockDate", new DateTime(2025, 5, 20) },
                    { "Available", false },
                    { "CustomerRating", 4.5 }
                },
                // Example of a row with a missing key (for "Available" and "CustomerRating")
                // The method will use DBNull.Value for these cells.
                new Dictionary<string, object>
                {
                    { "Id", 11 },
                    { "ProductName", "Smart Watch" },
                    { "ProductCategory", "Wearables" },
                    { "UnitPrice", 199.99m },
                    { "QtyInStock", 8 },
                    { "RestockDate", new DateTime(2025, 6, 10) }
                },
                // Example of a row with an extra key that won't have a column if not auto-generated
                new Dictionary<string, object>
                {
                    { "Id", 12 },
                    { "ProductName", "VR Headset" },
                    { "ProductCategory", "Gaming" },
                    { "UnitPrice", 599.00m },
                    { "QtyInStock", 3 },
                    { "RestockDate", new DateTime(2025, 6, 15) },
                    { "Available", true },
                    { "CustomerRating", 4.9 },
                    { "WarrantyYears", 2 } // This key won't create a column unless explicitly handled
                }
            };

            // Example of setting data for your grid
            outlookGrid1.SetDataSource(dictionaryData);
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

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; } // Using decimal for currency
        public int StockQuantity { get; set; }
        public DateTime LastRestockDate { get; set; }
        public bool IsAvailable { get; set; }
        public double Rating { get; set; } // For a double type
        public Image? Thumbnail { get; set; } // For an Image type (needs System.Drawing)

        // Constructor for easy initialization
        public ProductDto(int id, string name, string category, decimal price, int stockQuantity, DateTime lastRestockDate, bool isAvailable, double rating, Image? thumbnail = null)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stockQuantity;
            LastRestockDate = lastRestockDate;
            IsAvailable = isAvailable;
            Rating = rating;
            Thumbnail = thumbnail;
        }
    }

}
