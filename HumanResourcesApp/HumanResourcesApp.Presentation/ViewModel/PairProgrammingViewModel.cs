using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using HumanResourcesApp.AppLogic.Contracts;
using HumanResourcesApp.Domain;
using HumanResourcesApp.Presentation.Command;

namespace HumanResourcesApp.Presentation.ViewModel;

public class PairProgrammingViewModel : ViewModelBase
{
    private readonly IPairProgrammingService _pairProgrammingService;
    private int _selectedTeamId = 1;
    private ProgrammingPair? _selectedPair;

    public PairProgrammingViewModel(IPairProgrammingService pairProgrammingService)
    {
        _pairProgrammingService = pairProgrammingService;
        GenerateCommand = new DelegateCommand(Generate);
        SwitchCommand = new DelegateCommand(Switch, IsPairSelected);
    }
    
    public DelegateCommand GenerateCommand { get;  }
    
    public DelegateCommand SwitchCommand { get; }

    public ObservableCollection<ProgrammingPair> ProgrammingPairs { get; } = new();

    public int SelectedTeamId
    {
        get => _selectedTeamId;
        set
        {
            _selectedTeamId = value;
            OnPropertyChanged();
        }
    }

    public ProgrammingPair? SelectedPair
    {
        get => _selectedPair;
        set
        {
            _selectedPair = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsPairSelected));
            SwitchCommand.RaiseCanExecuteChanged();
        }
    }

    public bool IsPairSelected(object? parameter) => SelectedPair is not null;

    private void Generate(object? parameter)
    {
        ProgrammingPairs.Clear();
        var pairs = _pairProgrammingService.GeneratePairsForTeam(SelectedTeamId);
        foreach (var pair in pairs)
        {
            ProgrammingPairs.Add(pair);
        }
    }

    private void Switch(object? parameters)
    {
        if (IsPairSelected(parameters))
        {
            SelectedPair.Switch();
        }
        else
        {
            MessageBox.Show("Please select a pair first");
        }
    }
}