
# Blazor Notiflix

This package uses [javascript notiflix library](https://www.notiflix.com/). It is a package prepared for the integration on the blazor side and as a service on the blazor side.

Notiflix is a pure JavaScript library for client-side non-blocking notifications, popup boxes, loading indicators, and more to that makes your web projects much better.

<center>
  <img src="https://user-images.githubusercontent.com/4863567/117049917-71cf4d00-ad1d-11eb-9e82-5af5d47c187f.png" width="250" />
</center>

## Installation

### Step 1

With Package Manager
```
Install-Package BlazorNotiflix
```

With .NET CLI
```
dotnet add package BlazorNotiflix
```

If you want see other installation options then visit https://www.nuget.org/packages/BlazorNotiflix nuget page.

### Step 2
Add js and css definitions in _Host.cshtml file

````
    <link href="_content/BlazorNotiflix/notiflix.min.css" rel="stylesheet" />
    <script src="_content/BlazorNotiflix/notiflix.min.js"></script>
````

## Demo

Add BlazorNotiflix namespace to _Imports.razor file 
```c#
....
using BlazorNotiflix
....
```

Inject NotificationService in component or page code.

```c#
// You can use with @inject directive
@inject NotiflixService NotificationService

@code {
    // Or you can use with [Inject] attribute
    [Inject]
    private NotiflixService NotificationService { get; set; }
}
```


You can use below any different NotificationService methods.

```c#

<h3>Component1</h3>

@code {
    [Inject]
    private NotiflixService NotificationService { get; set; }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            NotificationService.ToastWarningAsync("[message]");
            NotificationService.ToastWarningAsync("[message]", this, nameof(CallbackMethodSuccess), "param 1 value", 2222);
            
            NotificationService.ToastInfoAsync("[message]");
            NotificationService.ToastInfoAsync("[message]", this, nameof(CallbackMethodSuccess), "param 1 value", 2222);
            
            NotificationService.ToastFailureAsync("[message]");
            NotificationService.ToastFailureAsync("[message]", this, nameof(CallbackMethodSuccess), "param 1 value", 2222);
            
            NotificationService.ToastSuccessAsync("[message]");
            NotificationService.ToastSuccessAsync("[message]", this, nameof(CallbackMethodSuccess), "param 1 value", 2222);
            
            NotificationService.Confirm("[title]", "[message]", "Yes", "No", this, nameof(CallbackMethodSuccess), nameof(CallbackMethodNo), "param1", 1515);
            
            NotificationService.ReportFailureAsync("[title]", "[message]");
            NotificationService.ReportFailureAsync("[title]", "[message]", "OK",  this, nameof(CallbackMethodSuccess),  "param1", 1515);
            
            NotificationService.ReportInfoAsync("[title]", "[message]");
            NotificationService.ReportInfoAsync("[title]", "[message]", "OK",  this, nameof(CallbackMethodSuccess),  "param1", 1515);
            
            NotificationService.ReportSuccessAsync("[title]", "[message]");
            NotificationService.ReportSuccessAsync("[title]", "[message]", "OK",  this, nameof(CallbackMethodSuccess),  "param1", 1515);
            
            NotificationService.ReportWarningAsync("[title]", "[message]");
            NotificationService.ReportWarningAsync("[title]", "[message]", "OK",  this, nameof(CallbackMethodSuccess),  "param1", 1515);

            NotificationService.ShowBlock("css_selector");
            NotificationService.ShowBlock("css_selector", "[message]");
            NotificationService.HideBlock("css_selector", 500);

            NotificationService.ShowLoadingAsync();
            NotificationService.HideLoadingAsync();
        }

        return base.OnAfterRenderAsync(firstRender);
    }

    [JSInvokable]
    public void CallbackMethodSuccess(string param1, int param2)
    {
        // This block run when click button in notiflix toast or dialog
    }
    
    [JSInvokable]
    public void CallbackMethodNo(string param1, int param2)
    {
        // This block run when click negative(No,Cancel etc.) button in notiflix toast or dialog
    }
}
```
