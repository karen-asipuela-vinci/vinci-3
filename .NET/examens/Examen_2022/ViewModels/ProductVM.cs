using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Examen_2022.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen_2022.ViewModels
{
    internal class ProductVM : INotifyPropertyChanged
    {
        private readonly NorthwindContext _context = new();

        // Liste observable des produits (pour le binding avec la ListBox)
        public ObservableCollection<ProductModel> ProductsList { get; private set; }
        // Liste du total des ventes par produit
        public ObservableCollection<OrderDetailModel> SalesList { get; private set; }


        // Produit sélectionné
        private ProductModel _selectedProduct;
        public ProductModel SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        // Commande pour mettre à jour le produit
        public ICommand UpdateProductCommand { get; }

        public ProductVM()
        {
            ProductsList = new ObservableCollection<ProductModel>();
            LoadProducts();

            SalesList = new ObservableCollection<OrderDetailModel>();
            LoadTotalSales();

            // Utilisation de DelegateCommand
            UpdateProductCommand = new DelegateCommand(UpdateProduct);
        }

        // Charger les produits depuis la DB
        private void LoadProducts()
        {
            foreach (var product in _context.Products.Include(p => p.Supplier))
            {
                ProductsList.Add(new ProductModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    SupplierContactName = product.Supplier.ContactName,
                    QuantityPerUnit = product.QuantityPerUnit
                });
            }
        }

        // Méthode pour mettre à jour le produit sélectionné
        private void UpdateProduct()
        {
            if (SelectedProduct == null) return;

            var productToUpdate = _context.Products.FirstOrDefault(p => p.ProductId == SelectedProduct.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.ProductName = SelectedProduct.ProductName;
                productToUpdate.QuantityPerUnit = SelectedProduct.QuantityPerUnit;

                _context.SaveChanges();
                MessageBox.Show("Produit mis à jour avec succès !");
            }
        }

        // Implémentation de l'interface INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // Méthode pour calculer le total des ventes par produit
        private void LoadTotalSales()
        {
            var salesData = _context.OrderDetails
                .GroupBy(od => od.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    TotalSales = g.Sum(od => od.UnitPrice * od.Quantity)
                })
                .OrderBy(s=>s.ProductId);

            foreach (var sale in salesData)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == sale.ProductId);
                if (product != null)
                {
                    SalesList.Add(new OrderDetailModel
                    {
                        ProductId = product.ProductId,
                        Total = sale.TotalSales
                    });
                }
            }
        }



    }
}
