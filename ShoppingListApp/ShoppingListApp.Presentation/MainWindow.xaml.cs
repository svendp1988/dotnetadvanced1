using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using ShoppingListApp.Business;
using ShoppingListApp.Business.Contracts;
using ShoppingListApp.Domain;

namespace ShoppingListApp.Presentation
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly IShoppingListRepository _repository;
        private readonly List<ShoppingListSummaryDto> _allSummaries = new();
        private ShoppingListSummaryDto? _selectedSummary;
        private ShoppingList _shoppingList;

        public MainWindow(IShoppingListRepository shoppingListRepository)
        {
            InitializeComponent();
            _repository = shoppingListRepository;
            var dtos = shoppingListRepository.GetAll();
            foreach (var dto in dtos)
            {
                _allSummaries.Add(dto);
            }

            DataContext = this;
        }

        public ObservableCollection<ShoppingListSummaryDto> SummaryDtos
        {
            get
            {
                var dtos = new ObservableCollection<ShoppingListSummaryDto>();
                foreach (var dto in _allSummaries)
                {
                    dtos.Add(dto);
                }

                return dtos;
            }
        }

        public ShoppingListSummaryDto? SelectedSummary
        {
            get => _selectedSummary;
            set
            {
                _selectedSummary = value;
                OnPropertyChanged();
                ShoppingList = _repository.GetById(value.Id);
            }
        }

        public ShoppingList? ShoppingList
        {
            get => _shoppingList;
            set
            {
                _shoppingList = value;
                foreach (var item in _shoppingList.Items)
                {
                    item.Shop = _repository.GetShopById(item.ShopId);
                }
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}