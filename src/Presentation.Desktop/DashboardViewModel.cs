using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Application;
using Core.Application.Commands.CreateClient;
using Core.Domain.Entities.Astrology;

namespace Presentation.Desktop;

public partial class DashboardViewModel : ObservableObject
{
    private readonly IClientService _clientService;

    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _email = string.Empty;

    [ObservableProperty]
    private DateTime _birthDate = DateTime.Today;

    [ObservableProperty]
    private string _birthTime = "00:00";

    [ObservableProperty]
    private string _lat = "0";

    [ObservableProperty]
    private string _lon = "0";

    [ObservableProperty]
    private string _timeZone = "UTC";

    public ObservableCollection<Client> Clients { get; } = new();

    public DashboardViewModel(IClientService clientService)
    {
        _clientService = clientService;
    }

    [RelayCommand]
    private async Task LoadAsync()
    {
        var clients = await _clientService.GetClientsAsync();
        Clients.Clear();
        foreach (var c in clients)
        {
            Clients.Add(c);
        }
    }

    [RelayCommand]
    private async Task AddClientAsync()
    {
        if (string.IsNullOrWhiteSpace(Name)) return;
        if (!TimeOnly.TryParse(BirthTime, out var time)) return;
        if (!decimal.TryParse(Lat, out var lat)) return;
        if (!decimal.TryParse(Lon, out var lon)) return;

        var dto = new CreateClientDto(
            Guid.NewGuid(),
            Name,
            string.IsNullOrWhiteSpace(Email) ? null : Email,
            BirthDate,
            time,
            lat,
            lon,
            TimeZone);
        await _clientService.CreateAsync(dto);
        Name = string.Empty;
        Email = string.Empty;
        BirthDate = DateTime.Today;
        BirthTime = "00:00";
        Lat = "0";
        Lon = "0";
        TimeZone = "UTC";
        await LoadAsync();
    }
}
