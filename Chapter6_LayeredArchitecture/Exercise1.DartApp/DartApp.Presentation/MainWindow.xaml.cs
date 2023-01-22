using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using DartApp.AppLogic.Contracts;
using DartApp.Domain;
using DartApp.Domain.Contracts;

namespace DartApp.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private IPlayer? _selectedPlayer;
        private readonly IPlayerService _service;
        private readonly List<IPlayer> _allPlayers = new();

        public ObservableCollection<IPlayer> AllPlayers
        {
            get
            {
                var players = new ObservableCollection<IPlayer>();
                foreach (var player in _allPlayers)
                {
                    players.Add(player);
                }

                return players;
            }
        }

        public Visibility ShowSelectedPlayer => SelectedPlayer == null ? Visibility.Hidden : Visibility.Visible;

        public IPlayer? SelectedPlayer
        {
            get => _selectedPlayer;
            set
            {
                _selectedPlayer = value;
                OnPropertyChanged(nameof(SelectedPlayer));
                OnPropertyChanged(nameof(ShowSelectedPlayer));
            }
        }

        public IPlayerStats? PlayerStats { get; set; }

        public MainWindow(IPlayerService playerService)
        {
            InitializeComponent();
            _service = playerService;
            var readOnlyList = playerService.GetAllPlayers();
            foreach (var player in readOnlyList)
            {
                _allPlayers.Add(player);
            }

            DataContext = this;
        }

        private void OnPlayerSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void OnAddPlayerClick(object sender, RoutedEventArgs e)
        {
            var playerName = PlayerNameTextBox.Text;
            _service.AddPlayer(playerName);
            IPlayer player = new Player(playerName);
            _allPlayers.Add(player);
            SelectedPlayer = player;
            PlayerNameTextBox.Text = "";
        }

        private void OnAddGameResultClick(object sender, global::System.Windows.RoutedEventArgs e)
        {
            var gameResult = new global::DartApp.Domain.GameResult(
                _selectedPlayer.Id, global::System.Convert.ToInt32(GameResultNumberOf180TextBox.Text),
                global::System.Convert.ToDouble(GameResultAverageTextBox.Text, CultureInfo.InvariantCulture),
                global::System.Convert.ToInt32(GameResultBestThrowTextBox.Text)
            );
            _service.AddGameResultForPlayer(SelectedPlayer, gameResult.NumberOf180, gameResult.AverageThrow,
                gameResult.BestThrow);
            GameResultNumberOf180TextBox.Text = "";
            GameResultAverageTextBox.Text = "";
            GameResultBestThrowTextBox.Text = "";
        }

        private void OnCalculateStats(object sender, RoutedEventArgs e)
        {
            _service.GetStatsForPlayer(SelectedPlayer);
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}