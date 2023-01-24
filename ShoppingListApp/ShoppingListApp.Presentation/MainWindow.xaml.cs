using System.Windows;
using ShoppingListApp.Business.Contracts;

namespace ShoppingListApp.Presentation
{
    public partial class MainWindow : Window
    {

        public MainWindow(IShoppingListRepository shoppingListRepository)
        {
            InitializeComponent();
        }
    }
}