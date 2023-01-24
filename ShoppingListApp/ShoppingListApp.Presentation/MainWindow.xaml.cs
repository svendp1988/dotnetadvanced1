using System.Collections.ObjectModel;
using System.Windows;
using ShoppingListApp.Business;
using ShoppingListApp.Business.Contracts;
using ShoppingListApp.Domain;

namespace ShoppingListApp.Presentation
{
    public partial class MainWindow : Window
    {
        private readonly IShoppingListRepository _repository;
        private ShoppingListSummaryDto? _selectedSummary;
        private ShoppingList _shoppingList;

        public MainWindow(IShoppingListRepository shoppingListRepository)
        {
            InitializeComponent();
            foreach (var dto in shoppingListRepository.GetAll())
            {
                SummaryDtos.Add(dto);
            }

            _repository = shoppingListRepository;
            DataContext = this;
        }

        public ObservableCollection<ShoppingListSummaryDto> SummaryDtos { get; } = new();

        public ShoppingListSummaryDto? SelectedSummary
        {
            get => _selectedSummary;
            set
            {
                _selectedSummary = value;
                ShoppingList = _repository.GetById(value.Id);
                
            }
        }

        public ShoppingList ShoppingList
        {
            get => _shoppingList;
            set
            {
                _shoppingList = value;
            }
        }
    }
}