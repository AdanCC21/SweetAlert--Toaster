using Microsoft.JSInterop;
using System.Threading.Tasks;

public class ToasterServicio
{
    private readonly IJSRuntime _jsRuntime;

    public ToasterServicio(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task ShowSuccess(string message, string title = "")
    {
        await _jsRuntime.InvokeVoidAsync("toastrHelper.showSuccess", message, title);
    }

    public async Task ShowError(string message, string title = "")
    {
        await _jsRuntime.InvokeVoidAsync("toastrHelper.showError", message, title);
    }

    public async Task ShowInfo(string message, string title = "")
    {
        await _jsRuntime.InvokeVoidAsync("toastrHelper.showInfo", message, title);
    }

    public async Task ShowWarning(string message, string title = "")
    {
        await _jsRuntime.InvokeVoidAsync("toastrHelper.showWarning", message, title);
    }
}
