using System;
using System.Windows.Forms;
using StoreApp.BLL.Interfaces;
using StoreApp.Entities;

namespace StoreApp
{
    public partial class MainForm : Form
    {
        private readonly IStoreService _storeService;
        private readonly IProductService _productService;
        private readonly IStoreProductService _storeProductService;

        public MainForm(IStoreService storeService, IProductService productService, IStoreProductService storeProductService)
        {
            _storeService = storeService;
            _productService = productService;
            _storeProductService = storeProductService;

            InitializeComponent();
        }

        private async void btnCreateStore_Click(object sender, EventArgs e)
        {
            var name = txtStoreName.Text;
            var address = txtStoreAddress.Text;

            var store = new Store { Name = name, Address = address };
            await _storeService.CreateStoreAsync(store);
            MessageBox.Show("Store created!");
        }

        private async void btnCreateProduct_Click(object sender, EventArgs e)
        {
            var productName = txtProductName.Text;
            var product = new Product { Name = productName };
            await _productService.CreateProductAsync(product);
            MessageBox.Show("Product created!");
        }
    }
}