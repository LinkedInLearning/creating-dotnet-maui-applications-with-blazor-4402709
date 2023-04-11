namespace ServiceWorkerTest;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        blazorWebView.UrlLoading += BlazorWebView_UrlLoading;

    }

    private void BlazorWebView_UrlLoading(object sender, Microsoft.AspNetCore.Components.WebView.UrlLoadingEventArgs e)
    {
        e.UrlLoadingStrategy = Microsoft.AspNetCore.Components.WebView.UrlLoadingStrategy.OpenInWebView;
    }
}
