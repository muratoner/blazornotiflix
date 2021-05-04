using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorNotiflix
{
    public class NotiflixService
    {
        private readonly IJSRuntime jSRuntime;

        public NotiflixService(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        #region Loading

        public async Task ShowLoadingAsync(string message = null)
            => await jSRuntime.InvokeVoidAsync("notiflix.showLoading", message);

        public async Task HideLoadingAsync()
            => await jSRuntime.InvokeVoidAsync("notiflix.hideLoading");

        #endregion

        #region Toast

        private async Task Toast(Type Type, string message, object instance = null, string methodName = null, params object[] args)
            => await jSRuntime.InvokeVoidAsync($"notiflix.toast{Type}", message, instance != null ? DotNetObjectReference.Create(instance) : null, methodName, args);

        public async Task ToastSuccessAsync(string message)
            => await Toast(Type.Success, message);

        public async Task ToastSuccessAsync(string message, object instance, string methodName, params object[] args)
            => await Toast(Type.Success, message, instance, methodName, args);

        public async Task ToastFailureAsync(string message)
            => await Toast(Type.Failure, message);

        public async Task ToastFailureAsync(string message, object instance, string methodName, params object[] args)
            => await Toast(Type.Failure, message, instance, methodName, args);

        public async Task ToastInfoAsync(string message)
            => await Toast(Type.Info, message);

        public async Task ToastInfoAsync(string message, object instance, string methodName, params object[] args)
            => await Toast(Type.Info, message, instance, methodName, args);

        public async Task ToastWarningAsync(string message)
            => await Toast(Type.Warning, message);

        public async Task ToastWarningAsync(string message, object instance, string methodName, params object[] args)
            => await Toast(Type.Warning, message, DotNetObjectReference.Create(instance), methodName, args);

        #endregion

        #region Report

        private async Task Report(Type Type, string title, string message, string buttonName, object instance = null, string methodName = null, params object[] args)
            => await jSRuntime.InvokeVoidAsync($"notiflix.report{Type}", title, message, buttonName, instance != null ? DotNetObjectReference.Create(instance) : null, methodName, args);

        public async Task ReportSuccessAsync(string title, string message, string buttonName = "")
            => await Report(Type.Success, title, message, buttonName);

        public async Task ReportSuccessAsync(string title, string message, string buttonName, object instance, string methodName, params object[] args)
            => await Report(Type.Success, title, message, buttonName, instance, methodName, args);

        public async Task ReportFailureAsync(string title, string message, string buttonName = "")
            => await Report(Type.Failure, title, message, buttonName);

        public async Task ReportFailureAsync(string title, string message, string buttonName, object instance, string methodName, params object[] args)
            => await Report(Type.Failure, title, message, buttonName, instance, methodName, args);

        public async Task ReportInfoAsync(string title, string message, string buttonName = "")
            => await Report(Type.Info, title, message, buttonName);

        public async Task ReportInfoAsync(string title, string message, string buttonName, object instance, string methodName, params object[] args)
            => await Report(Type.Info, title, message, buttonName, instance, methodName, args);

        public async Task ReportWarningAsync(string title, string message, string buttonName = "")
            => await Report(Type.Warning, title, message, buttonName);

        public async Task ReportWarningAsync(string title, string message, string buttonName, object instance, string methodName, params object[] args)
            => await Report(Type.Warning, title, message, buttonName, instance, methodName, args);

        #endregion

        #region Confirm

        public async Task Confirm(string title, string message, string yesButtonName, string noButtonName, object instance,
            string yesMethodName, string noMethodName, params object[] args)
        {
            await jSRuntime.InvokeVoidAsync("notiflix.confirm", title, message, yesButtonName, noButtonName, instance != null ? DotNetObjectReference.Create(instance) : null, yesMethodName, noMethodName, args);
        }

        #endregion

        #region

        public async Task ShowBlock(ElementReference element, string message = "")
        {
            await jSRuntime.InvokeVoidAsync("notiflix.showBlock", element, message);
        }

        public async Task ShowBlock(string cssSelector, string message = "")
        {
            await jSRuntime.InvokeVoidAsync("notiflix.showBlock", cssSelector, message);
        }

        public async Task HideBlock(ElementReference element, int delay = 0)
        {
            await jSRuntime.InvokeVoidAsync("notiflix.hideBlock", element, delay);
        }

        public async Task HideBlock(string cssSelector, int delay = 0)
        {
            await jSRuntime.InvokeVoidAsync("notiflix.hideBlock", cssSelector, delay);
        }

        #endregion

        private enum Type
        {
            Success,
            Failure,
            Info,
            Warning
        }
    }
}
