using System.Windows;
using ShoppingListApp.Business.Contracts;

namespace ShoppingListApp.Presentation
{
    public partial class MainWindow : Window
    {

        public MainWindow(IShoppingListRepository shoppingListRepository)
        {
            InitializeComponent();
            var shoppingListSummaryDtos = shoppingListRepository.GetAll();
            var shoppingList = shoppingListRepository.GetById(1);
            var byId = shoppingListRepository.GetById(5);

            var shoppingListItems = shoppingList.Items;
        }
    }
}