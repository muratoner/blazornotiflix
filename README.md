
# Blazor Notiflix

This package uses [javascript notiflix library](https://www.notiflix.com/). It is a package prepared for the integration on the blazor side and as a service on the blazor side.

Notiflix says "Notiflix is a pure JavaScript library for client-side non-blocking notifications, popup boxes, loading indicators, and more to that makes your web projects much better."

<center>
  <img src="https://user-images.githubusercontent.com/4863567/117049917-71cf4d00-ad1d-11eb-9e82-5af5d47c187f.png" width="250" />
</center>

## Demo

Add BlazorNotiflix namespace to _Imports.razor file 
```csharp
....
using BlazorNotiflix
....
```

Inject NotificationService in component or page code.

```csharp
// You can use with @inject directive
@inject NotiflixService NotificationService

@code {
    // Or you can use with [Inject] attribute
    [Inject]
    private NotiflixService NotificationService { get; set; }
}
```


You can use below any different NotificationService methods.

```csharp
<h3>Component1</h3>

@code {
    [Inject]
    private NotiflixService NotificationService { get; set; }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            NotificationService.ToastSuccessAsync("[message]", this, nameof(CallbackMethod), "param 1 value", 2222);
        }

        return base.OnAfterRenderAsync(firstRender);
    }

    [JSInvokable]
    public void CallbackMethod(string param1, int param2)
    {
        // This block run when click button in toast success message
    }
}
```
