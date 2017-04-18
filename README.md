This repository is used to create the mopub xamarin bindings for iOS.

Version info:
* MoPub version 4.11.0 [github](https://github.com/mopub/mopub-ios-sdk)
* AdColony version 3.1.1 [github](https://github.com/AdColony/AdColony-iOS-SDK)
* Facebook Audience Network 4.22.0 [website](https://developers.facebook.com/docs/ios)
* Google AdMob version 7.19.1 [website](https://firebase.google.com/docs/admob/ios/download)
* myTarget 4.6.11 [github](https://github.com/myTargetSDK/mytarget-ios/releases)

To use MoPub in your project, follow these directions:

1. Within Terminal, navigate to the mopub-framework folder
2. Run 'sh universal-framework.sh' in that directory
3. Open mopub-ios-binding/mopub-ios-binding.sln in Xamarin
4. Rebuild that solution.
5. Copy the resulting bin/<BuildType>/MoPubSDK.dll to your own Xamarin project.