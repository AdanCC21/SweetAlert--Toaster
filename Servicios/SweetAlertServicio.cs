using Microsoft.JSInterop;
using System.Threading.Tasks;



    public class SweetAlertServicio
    {
        private readonly IJSRuntime _jsRuntime;

        public SweetAlertServicio(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task ShowAlert(string title, string text, string icon = "info")
        {
            await _jsRuntime.InvokeVoidAsync("sweetAlertHelper.showAlert", title, text, icon);
        }

        public async Task<bool> ShowConfirm(string title, string text, string icon = "question")
        {
            return await _jsRuntime.InvokeAsync<bool>("sweetAlertHelper.showConfirm", title, text, icon);
        }
    }

