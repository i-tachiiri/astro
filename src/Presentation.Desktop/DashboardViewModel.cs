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
        var dto = new CreateClientDto(Guid.NewGuid(), Name, null, DateTime.Today, new TimeOnly(0, 0), 0m, 0m, "UTC");
        await _clientService.CreateAsync(dto);
        Name = string.Empty;
        await LoadAsync();
    }
}
