
# Blazor Notiflix

This package uses [javascript notiflix library](https://www.notiflix.com/). It is a package prepared for the integration on the blazor side and as a service on the blazor side.

<center>
  <img src="https://user-images.githubusercontent.com/4863567/117047221-4ac34c00-ad1a-11eb-83ef-a2c2859ba0a3.png" width="250" />
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
