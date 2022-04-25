using HogeBlazor.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HogeBlazor.Client.Components.ProductTable
{
    public partial class ProductTable
    {
        [Parameter]
        public List<Product> Products { get; set; } = new List<Product>();
        [Parameter]
        public EventCallback<Guid> OnDeleted { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;
        [Inject]
        public IJSRuntime Js { get; set; } = default!;

        private void RedirectToUpdate(Guid id)
        {
            var url = Path.Combine("/updateProduct/", id.ToString());
            NavigationManager.NavigateTo(url);
        }

        private async Task Delete(Guid id)
        {
            var product = Products.FirstOrDefault(p => p.Id.Equals(id));
            var confirmed = await Js.InvokeAsync<bool>("confirm", $"Are you sure you want to delete {product?.Name} product?");
            if (confirmed)
            {
                await OnDeleted.InvokeAsync(id);
            }
        }
    }
}