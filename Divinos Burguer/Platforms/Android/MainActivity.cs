using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Java.Security;
using Plugin.Firebase.Auth.Google;

namespace Divinos_Burguer;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        //PrintHashKey(this);
    }

    protected override void OnActivityResult(int requestCode, Result resultCode, Intent? data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
        //FirebaseAuthFacebookImplementation.HandleActivityResultAsync(requestCode, resultCode, data);
        FirebaseAuthGoogleImplementation.HandleActivityResultAsync(requestCode, resultCode, data);
    }

    //public static void PrintHashKey(Context pContext)
    //{
    //    try
    //    {
    //        PackageInfo info = Android.App.Application.Context.PackageManager.GetPackageInfo(Android.App.Application.Context.PackageName, PackageInfoFlags.Signatures);
    //        foreach (var signature in info.Signatures)
    //        {
    //            MessageDigest md = MessageDigest.GetInstance("SHA");
    //            md.Update(signature.ToByteArray());

    //            System.Diagnostics.Debug.WriteLine(BitConverter.ToString(md.Digest()).Replace("-", ":"));
    //        }
    //    }
    //    catch (NoSuchAlgorithmException e)
    //    {
    //        System.Diagnostics.Debug.WriteLine(e);
    //    }
    //    catch (Exception e)
    //    {
    //        System.Diagnostics.Debug.WriteLine(e);
    //    }
    //}


}
