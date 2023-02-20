using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Syncfusion.Maui.Core.Hosting;
using Todo.Viewmodel;

namespace Todo;

public static class MauiProgram
{

    public static MauiApp CreateMauiApp()
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHRqVVhlXFpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jS3xTdkZmXn1ZeHFcRw==;Mgo+DSMBPh8sVXJ0S0J+XE9BdlRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TdEdjWXxbd3ZSTmdaUA==;ORg4AjUWIQA/Gnt2VVhkQlFac19JXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkdhWX9ddXNXQWlaU0U=;MTE2MjcwMUAzMjMwMmUzNDJlMzBNZjErQ0NMdjY1YTFyMzN4VzdyenErZHVlZVNUemNmdnVMV2xHM0IzbUtFPQ==;MTE2MjcwMkAzMjMwMmUzNDJlMzBGODQ3dGVvbi9lUUhSc2R0VjFUR1luNDRmZWNIOE83OFpHclBBdmRiYnl3PQ==;NRAiBiAaIQQuGjN/V0Z+WE9EaFpCVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdUVhW39ec3FSRGhdU0N0;MTE2MjcwNEAzMjMwMmUzNDJlMzBvUk9WV0U2a3E5THcwV3pGUURxZGlSK25URC9JOWYzMFJjclhYOElYOTA4PQ==;MTE2MjcwNUAzMjMwMmUzNDJlMzBCcUU1djlFQ3ZkM2NvWVRieUVrOFJqYUk2OTU3V29tQXNGMkh3NHp5eFY0PQ==;Mgo+DSMBMAY9C3t2VVhkQlFac19JXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkdhWX9ddXNXTmFVV0Y=;MTE2MjcwN0AzMjMwMmUzNDJlMzBLM2JOaHJsNVNPVUYxZVlqNHNSZ2hzeXlTR1Qrb3cwM2VNVUV0SEN4Mk8wPQ==;MTE2MjcwOEAzMjMwMmUzNDJlMzBvODNVSXh0ZGNKVWN2ZXNpbGNzNE54YWhNU0lGSVo2TnFBZW1tWWxsVENrPQ==;MTE2MjcwOUAzMjMwMmUzNDJlMzBvUk9WV0U2a3E5THcwV3pGUURxZGlSK25URC9JOWYzMFJjclhYOElYOTA4PQ==");
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseSkiaSharp()
            .ConfigureSyncfusionCore()
            .ConfigureMopups()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("6-Free-Regular-400.otf", "FARegular");
                fonts.AddFont("6-Brands-Regular-400.otf", "FABrands");
                fonts.AddFont("6-Free-Solid-900.otf", "FASolid");
            });

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
