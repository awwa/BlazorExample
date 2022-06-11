using System.Reflection;
using HogeBlazor.Client.Helpers;
using HogeBlazor.Client.Repositories;
// using HogeBlazor.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace HogeBlazor.Client.Pages;
public partial class Cars
{
    public List<Car> CarList { get; set; } = new List<Car>();

    public string TitleMakerName { get; set; } = CommentHelper.GetCommentAttribute<HogeBlazor.Shared.Models.Car>("MakerName");
    public string TitleModelName { get; set; } = CommentHelper.GetCommentAttribute<HogeBlazor.Shared.Models.Car>("ModelName");
    public string TitleGradeName { get; set; } = CommentHelper.GetCommentAttribute<HogeBlazor.Shared.Models.Car>("GradeName");
    public string TitleModelCode { get; set; } = CommentHelper.GetCommentAttribute<HogeBlazor.Shared.Models.Car>("ModelCode");
    public string TitlePrice { get; set; } = CommentHelper.GetCommentAttribute<HogeBlazor.Shared.Models.Car>("Price");
    public string TitleModelChangeFull { get; set; } = CommentHelper.GetCommentAttribute<HogeBlazor.Shared.Models.Car>("ModelChangeFull");

    [Inject]
    public ICarHttpRepository CarRepo { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        await GetCars();
    }

    private async Task SelectedPage(int page)
    {
        await GetCars();
    }

    private async Task GetCars()
    {
        CarList = await CarRepo.GetCars();
    }
}
