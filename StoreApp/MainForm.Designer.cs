namespace StoreApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListBox listBoxStores;
        private System.Windows.Forms.TextBox textBoxStoreName;
        private System.Windows.Forms.TextBox textBoxStoreAddress;
        private System.Windows.Forms.Button buttonAddStore;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.TextBox textBoxStockProductName;
        private System.Windows.Forms.TextBox textBoxStockQuantity;
        private System.Windows.Forms.TextBox textBoxStockPrice;
        private System.Windows.Forms.Button buttonAddStock;
        private System.Windows.Forms.TextBox textBoxFindCheapestProduct;
        private System.Windows.Forms.Button buttonFindCheapestStore;
        private System.Windows.Forms.TextBox textBoxPurchaseProduct;
        private System.Windows.Forms.TextBox textBoxPurchaseQuantity;
        private System.Windows.Forms.Button buttonPurchase;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxStores = new System.Windows.Forms.ListBox();
            this.textBoxStoreName = new System.Windows.Forms.TextBox();
            this.textBoxStoreAddress = new System.Windows.Forms.TextBox();
            this.buttonAddStore = new System.Windows.Forms.Button();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.textBoxStockProductName = new System.Windows.Forms.TextBox();
            this.textBoxStockQuantity = new System.Windows.Forms.TextBox();
            this.textBoxStockPrice = new System.Windows.Forms.TextBox();
            this.buttonAddStock = new System.Windows.Forms.Button();
            this.textBoxFindCheapestProduct = new System.Windows.Forms.TextBox();
            this.buttonFindCheapestStore = new System.Windows.Forms.Button();
            this.textBoxPurchaseProduct = new System.Windows.Forms.TextBox();
            this.textBoxPurchaseQuantity = new System.Windows.Forms.TextBox();
            this.buttonPurchase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // listBoxStores
            this.listBoxStores.FormattingEnabled = true;
            this.listBoxStores.Location = new System.Drawing.Point(12, 12);
            this.listBoxStores.Name = "listBoxStores";
            this.listBoxStores.Size = new System.Drawing.Size(200, 160);
            this.listBoxStores.TabIndex = 0;

            // textBoxStoreName
            this.textBoxStoreName.Location = new System.Drawing.Point(230, 12);
            this.textBoxStoreName.Name = "textBoxStoreName";
            this.textBoxStoreName.PlaceholderText = "Название магазина";
            this.textBoxStoreName.Size = new System.Drawing.Size(150, 23);
            this.textBoxStoreName.TabIndex = 1;

            // textBoxStoreAddress
            this.textBoxStoreAddress.Location = new System.Drawing.Point(230, 41);
            this.textBoxStoreAddress.Name = "textBoxStoreAddress";
            this.textBoxStoreAddress.PlaceholderText = "Адрес магазина";
            this.textBoxStoreAddress.Size = new System.Drawing.Size(150, 23);
            this.textBoxStoreAddress.TabIndex = 2;

            // buttonAddStore
            this.buttonAddStore.Location = new System.Drawing.Point(230, 70);
            this.buttonAddStore.Name = "buttonAddStore";
            this.buttonAddStore.Size = new System.Drawing.Size(150, 23);
            this.buttonAddStore.TabIndex = 3;
            this.buttonAddStore.Text = "Добавить магазин";
            this.buttonAddStore.UseVisualStyleBackColor = true;
            this.buttonAddStore.Click += new System.EventHandler(this.ButtonAddStore_Click);

            // textBoxProductName
            this.textBoxProductName.Location = new System.Drawing.Point(230, 110);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.PlaceholderText = "Название товара";
            this.textBoxProductName.Size = new System.Drawing.Size(150, 23);
            this.textBoxProductName.TabIndex = 4;

            // buttonAddProduct
            this.buttonAddProduct.Location = new System.Drawing.Point(230, 139);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(150, 23);
            this.buttonAddProduct.TabIndex = 5;
            this.buttonAddProduct.Text = "Добавить товар";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.ButtonAddProduct_Click);

            // textBoxStockProductName
            this.textBoxStockProductName.Location = new System.Drawing.Point(12, 190);
            this.textBoxStockProductName.Name = "textBoxStockProductName";
            this.textBoxStockProductName.PlaceholderText = "Название товара";
            this.textBoxStockProductName.Size = new System.Drawing.Size(150, 23);
            this.textBoxStockProductName.TabIndex = 6;

            // textBoxStockQuantity
            this.textBoxStockQuantity.Location = new System.Drawing.Point(12, 219);
            this.textBoxStockQuantity.Name = "textBoxStockQuantity";
            this.textBoxStockQuantity.PlaceholderText = "Количество";
            this.textBoxStockQuantity.Size = new System.Drawing.Size(150, 23);
            this.textBoxStockQuantity.TabIndex = 7;

            // textBoxStockPrice
            this.textBoxStockPrice.Location = new System.Drawing.Point(12, 248);
            this.textBoxStockPrice.Name = "textBoxStockPrice";
            this.textBoxStockPrice.PlaceholderText = "Цена";
            this.textBoxStockPrice.Size = new System.Drawing.Size(150, 23);
            this.textBoxStockPrice.TabIndex = 8;

            // buttonAddStock
            this.buttonAddStock.Location = new System.Drawing.Point(12, 277);
            this.buttonAddStock.Name = "buttonAddStock";
            this.buttonAddStock.Size = new System.Drawing.Size(150, 23);
            this.buttonAddStock.TabIndex = 9;
            this.buttonAddStock.Text = "Добавить поставку";
            this.buttonAddStock.UseVisualStyleBackColor = true;
            this.buttonAddStock.Click += new System.EventHandler(this.ButtonAddStock_Click);

            // textBoxFindCheapestProduct
            this.textBoxFindCheapestProduct.Location = new System.Drawing.Point(230, 190);
            this.textBoxFindCheapestProduct.Name = "textBoxFindCheapestProduct";
            this.textBoxFindCheapestProduct.PlaceholderText = "Название товара";
            this.textBoxFindCheapestProduct.Size = new System.Drawing.Size(150, 23);
            this.textBoxFindCheapestProduct.TabIndex = 10;

            // buttonFindCheapestStore
            this.buttonFindCheapestStore.Location = new System.Drawing.Point(230, 219);
            this.buttonFindCheapestStore.Name = "buttonFindCheapestStore";
            this.buttonFindCheapestStore.Size = new System.Drawing.Size(150, 
