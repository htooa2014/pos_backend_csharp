﻿using DotNet8.PosFrontendBlazor.Server.Models.Tax;
using DotNet8.PosFrontendBlazor.Server.Services;

namespace DotNet8.PosFrontendBlazor.Server.Pages.Tax;

public partial class P_DeleteTaxDialog
{
    [CascadingParameter] MudDialogInstance? MudDialog { get; set; }

    [Parameter] public int id { get; set; }

    public async Task DeleteAsync()
    {
        if (id != 0)
        {
            var response = await HttpClientService.ExecuteAsync<TaxResponseModel>($"{Endpoints.Tax}/{id}", EnumHttpMethod.Delete);
            if (response.IsError)
            {
                InjectService.ShowMessage(response.Message, EnumResponseType.Error);
                return;
            }

            InjectService.ShowMessage(response.Message, EnumResponseType.Success);
            MudDialog?.Close();
        }
    }

    void Cancel() => MudDialog?.Cancel();
}
