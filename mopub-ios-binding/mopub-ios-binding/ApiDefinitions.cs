using System;
using System.Collections.Generic;
using CoreGraphics;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace MoPubBinding
{
	#region MpNativeAd

	// @interface MPNativeAd : NSObject
	[BaseType (typeof (NSObject))]
	interface MPNativeAd
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		MPNativeAdDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MPNativeAdDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic) NSDictionary * properties;
		[Export ("properties")]
		NSDictionary Properties { get; }

		// -(instancetype)initWithAdAdapter:(id<MPNativeAdAdapter>)adAdapter;
		[Export ("initWithAdAdapter:")]
		IntPtr Constructor (MPNativeAdAdapter adAdapter);

		// -(UIView *)retrieveAdViewWithError:(NSError **)error;
		[Export ("retrieveAdViewWithError:")]
		UIView RetrieveAdViewWithError (out NSError error);

		// -(void)trackMetricForURL:(NSURL *)URL;
		[Export ("trackMetricForURL:")]
		void TrackMetricForURL (NSUrl URL);
	}

	// @protocol MPNativeAdDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MPNativeAdDelegate
	{
		// @optional -(void)willPresentModalForNativeAd:(MPNativeAd *)nativeAd;
		[Export ("willPresentModalForNativeAd:")]
		void WillPresentModalForNativeAd (MPNativeAd nativeAd);

		// @optional -(void)didDismissModalForNativeAd:(MPNativeAd *)nativeAd;
		[Export ("didDismissModalForNativeAd:")]
		void DidDismissModalForNativeAd (MPNativeAd nativeAd);

		// @optional -(void)willLeaveApplicationFromNativeAd:(MPNativeAd *)nativeAd;
		[Export ("willLeaveApplicationFromNativeAd:")]
		void WillLeaveApplicationFromNativeAd (MPNativeAd nativeAd);

		// @required -(UIViewController *)viewControllerForPresentingModalView;
		[Abstract]
		[Export ("viewControllerForPresentingModalView")]
		//[Verify (MethodToProperty)]
		UIViewController ViewControllerForPresentingModalView { get; }
	}

	// @protocol MPNativeAdAdapter <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MPNativeAdAdapter
	{
		// @required @property (readonly, nonatomic) NSDictionary * properties;
		[Abstract]
		[Export ("properties")]
		NSDictionary Properties { get; }

		// @required @property (readonly, nonatomic) NSURL * defaultActionURL;
		[Abstract]
		[Export ("defaultActionURL")]
		NSUrl DefaultActionURL { get; }

		// @optional -(void)displayContentForURL:(NSURL *)URL rootViewController:(UIViewController *)controller;
		[Export ("displayContentForURL:rootViewController:")]
		void DisplayContentForURL (NSUrl URL, UIViewController controller);

		// @optional -(BOOL)enableThirdPartyClickTracking;
		[Export ("enableThirdPartyClickTracking")]
		//[Verify (MethodToProperty)]
		bool EnableThirdPartyClickTracking { get; }

		// @optional -(void)trackClick;
		[Export ("trackClick")]
		void TrackClick ();

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		MPNativeAdAdapterDelegate Delegate { get; set; }

		// @optional @property (nonatomic, weak) id<MPNativeAdAdapterDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @optional -(void)willAttachToView:(UIView *)view;
		[Export ("willAttachToView:")]
		void WillAttachToView (UIView view);

		// @optional -(void)displayContentForDAAIconTap;
		[Export ("displayContentForDAAIconTap")]
		void DisplayContentForDAAIconTap ();

		// @optional -(UIView *)privacyInformationIconView;
		[Export ("privacyInformationIconView")]
		//[Verify (MethodToProperty)]
		UIView PrivacyInformationIconView { get; }

		// @optional -(UIView *)mainMediaView;
		[Export ("mainMediaView")]
		//[Verify (MethodToProperty)]
		UIView MainMediaView { get; }
	}

	// @protocol MPNativeAdAdapterDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MPNativeAdAdapterDelegate
	{
		// @required -(UIViewController *)viewControllerForPresentingModalView;
		[Abstract]
		[Export ("viewControllerForPresentingModalView")]
		//[Verify (MethodToProperty)]
		UIViewController ViewControllerForPresentingModalView { get; }

		// @required -(void)nativeAdWillPresentModalForAdapter:(id<MPNativeAdAdapter>)adapter;
		[Abstract]
		[Export ("nativeAdWillPresentModalForAdapter:")]
		void NativeAdWillPresentModalForAdapter (MPNativeAdAdapter adapter);

		// @required -(void)nativeAdDidDismissModalForAdapter:(id<MPNativeAdAdapter>)adapter;
		[Abstract]
		[Export ("nativeAdDidDismissModalForAdapter:")]
		void NativeAdDidDismissModalForAdapter (MPNativeAdAdapter adapter);

		// @required -(void)nativeAdWillLeaveApplicationFromAdapter:(id<MPNativeAdAdapter>)adapter;
		[Abstract]
		[Export ("nativeAdWillLeaveApplicationFromAdapter:")]
		void NativeAdWillLeaveApplicationFromAdapter (MPNativeAdAdapter adapter);

		// @optional -(void)nativeAdWillLogImpression:(id<MPNativeAdAdapter>)adAdapter;
		[Export ("nativeAdWillLogImpression:")]
		void NativeAdWillLogImpression (MPNativeAdAdapter adAdapter);

		// @optional -(void)nativeAdDidClick:(id<MPNativeAdAdapter>)adAdapter;
		[Export ("nativeAdDidClick:")]
		void NativeAdDidClick (MPNativeAdAdapter adAdapter);
	}

	#endregion

	#region MPNativeAdRequest

	// @interface MPNativeAdRequest : NSObject
	[BaseType (typeof (NSObject))]
	interface MPNativeAdRequest
	{
		// @property (nonatomic, strong) MPNativeAdRequestTargeting * targeting;
		[Export ("targeting", ArgumentSemantic.Strong)]
		MPNativeAdRequestTargeting Targeting { get; set; }

		// +(MPNativeAdRequest *)requestWithAdUnitIdentifier:(NSString *)identifier rendererConfigurations:(NSArray *)rendererConfigurations;
		[Static]
		[Export ("requestWithAdUnitIdentifier:rendererConfigurations:")]
		//todo Verify
		//[Verify (StronglyTypedNSArray)]
		MPNativeAdRequest RequestWithAdUnitIdentifier (string identifier, NSObject [] rendererConfigurations);
		//MPNativeAdRequest RequestWithAdUnitIdentifier (string identifier, NSArray rendererConfigurations);

		// -(void)startWithCompletionHandler:(MPNativeAdRequestHandler)handler;
		[Export ("startWithCompletionHandler:")]
		void StartWithCompletionHandler (MPNativeAdRequestHandler handler);
	}

	// @interface MPNativeAdRequestTargeting : NSObject
	[BaseType (typeof (NSObject))]
	interface MPNativeAdRequestTargeting
	{
		// +(MPNativeAdRequestTargeting *)targeting;
		[Static]
		[Export ("targeting")]
		//[Verify (MethodToProperty)]
		MPNativeAdRequestTargeting Targeting { get; }

		// @property (copy, nonatomic) NSString * keywords;
		[Export ("keywords")]
		string Keywords { get; set; }

		// @property (copy, nonatomic) CLLocation * location;
		[Export ("location", ArgumentSemantic.Copy)]
		CLLocation Location { get; set; }

		// @property (nonatomic, strong) NSSet * desiredAssets;
		[Export ("desiredAssets", ArgumentSemantic.Strong)]
		NSSet DesiredAssets { get; set; }
	}

	//todo Verify
	// typedef void (^MPNativeAdRequestHandler)(MPNativeAdRequest *, MPNativeAd *, NSError *);
	//delegate void MPNativeAdRequestHandler (MPNativeAdRequest arg0, MPNativeAd arg1, NSError arg2);
	// delegate void MPNativeAdRequestHandler (MPNativeAdRequest request, MPNativeAd advert, NSError error);
	//delegate void MPNativeAdRequestHandler (NSObject request, NSObject advert, NSError error);
	// delegate void MPNativeAdRequestHandler (MPNativeAdRequest request, MPNativeAd advert, NSError error);
	delegate void MPNativeAdRequestHandler (MPNativeAdRequest request, MPNativeAd responseAdvert, NSError error);

	#endregion

	#region MPNativeAdRendering

	// @protocol MPNativeAdRendering <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MPNativeAdRendering
	{
		// @optional -(UILabel *)nativeMainTextLabel;
		[Export ("nativeMainTextLabel")]
		//[Verify (MethodToProperty)]
		UILabel NativeMainTextLabel { get; }

		// @optional -(UILabel *)nativeTitleTextLabel;
		[Export ("nativeTitleTextLabel")]
		//[Verify (MethodToProperty)]
		UILabel NativeTitleTextLabel { get; }

		// @optional -(UIImageView *)nativeIconImageView;
		[Export ("nativeIconImageView")]
		//[Verify (MethodToProperty)]
		UIImageView NativeIconImageView { get; }

		// @optional -(UIImageView *)nativeMainImageView;
		[Export ("nativeMainImageView")]
		//[Verify (MethodToProperty)]
		UIImageView NativeMainImageView { get; }

		// @optional -(UIView *)nativeVideoView;
		[Export ("nativeVideoView")]
		//[Verify (MethodToProperty)]
		UIView NativeVideoView { get; }

		// @optional -(UILabel *)nativeCallToActionTextLabel;
		[Export ("nativeCallToActionTextLabel")]
		//[Verify (MethodToProperty)]
		UILabel NativeCallToActionTextLabel { get; }

		// @optional -(UIImageView *)nativePrivacyInformationIconImageView;
		[Export ("nativePrivacyInformationIconImageView")]
		//[Verify (MethodToProperty)]
		UIImageView NativePrivacyInformationIconImageView { get; }

		// @optional -(void)layoutStarRating:(NSNumber *)starRating;
		[Export ("layoutStarRating:")]
		void LayoutStarRating (NSNumber starRating);

		// @optional -(void)layoutCustomAssetsWithProperties:(NSDictionary *)customProperties imageLoader:(MPNativeAdRenderingImageLoader *)imageLoader;
		[Export ("layoutCustomAssetsWithProperties:imageLoader:")]
		void LayoutCustomAssetsWithProperties (NSDictionary customProperties, MPNativeAdRenderingImageLoader imageLoader);

		// @optional +(UINib *)nibForAd;
		[Static]
		[Export ("nibForAd")]
		//[Verify (MethodToProperty)]
		UINib NibForAd { get; }
	}

	// @interface MPNativeAdRenderingImageLoader : NSObject
	[BaseType (typeof (NSObject))]
	interface MPNativeAdRenderingImageLoader
	{
		// -(instancetype)initWithImageHandler:(MPNativeAdRendererImageHandler *)imageHandler;
		[Export ("initWithImageHandler:")]
		IntPtr Constructor (MPNativeAdRendererImageHandler imageHandler);

		// -(void)loadImageForURL:(NSURL *)url intoImageView:(UIImageView *)imageView;
		[Export ("loadImageForURL:intoImageView:")]
		void LoadImageForURL (NSUrl url, UIImageView imageView);
	}

	// @interface MPNativeAdRendererImageHandler : NSObject
	[BaseType (typeof (NSObject))]
	interface MPNativeAdRendererImageHandler
	{
		// @property (nonatomic, weak) id<MPNativeAdRendererImageHandlerDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// - (void)loadImageForURL:(NSURL *)imageURL intoImageView:(UIImageView *)imageView;
		[Export ("loadImageForURL:intoImageView:")]
		void LoadImageForURL (NSUrl url, UIImageView imageView);
	}

	#endregion

	#region MPStaticNativeAdRenderer

	// @interface MPStaticNativeAdRenderer : NSObject <MPNativeAdRenderer>
	[BaseType (typeof (NSObject))]
	interface MPStaticNativeAdRenderer : MPNativeAdRenderer
	{
		// @property (readonly, nonatomic) MPNativeViewSizeHandler viewSizeHandler;
		[Export ("viewSizeHandler")]
		MPNativeViewSizeHandler ViewSizeHandler { get; }

		// +(MPNativeAdRendererConfiguration *)rendererConfigurationWithRendererSettings:(id<MPNativeAdRendererSettings>)rendererSettings;
		[Static]
		[Export ("rendererConfigurationWithRendererSettings:")]
		//todo Verify
		MPNativeAdRendererConfiguration RendererConfigurationWithRendererSettings (MPStaticNativeAdRendererSettings rendererSettings);
	}

	// @protocol MPNativeAdRenderer <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MPNativeAdRenderer
	{
		// @required +(MPNativeAdRendererConfiguration *)rendererConfigurationWithRendererSettings:(id<MPNativeAdRendererSettings>)rendererSettings;
		//todo Verify
		//[Static, Abstract]
		//[Abstract]
		//[Export ("rendererConfigurationWithRendererSettings:")]
		//MPNativeAdRendererConfiguration RendererConfigurationWithRendererSettings (MPNativeAdRendererSettings rendererSettings);

		// @required -(instancetype)initWithRendererSettings:(id<MPNativeAdRendererSettings>)rendererSettings;
		//todo Verify
		//[Abstract]
		//[Export ("initWithRendererSettings:")]
		//IntPtr Constructor (MPNativeAdRendererSettings rendererSettings);

		// @required -(UIView *)retrieveViewWithAdapter:(id<MPNativeAdAdapter>)adapter error:(NSError **)error;
		[Abstract]
		[Export ("retrieveViewWithAdapter:error:")]
		UIView RetrieveViewWithAdapter (MPNativeAdAdapter adapter, out NSError error);

		// @optional @property (readonly, nonatomic) MPNativeViewSizeHandler viewSizeHandler;
		[Export ("viewSizeHandler")]
		MPNativeViewSizeHandler ViewSizeHandler { get; }

		// @optional -(void)adViewWillMoveToSuperview:(UIView *)superview;
		[Export ("adViewWillMoveToSuperview:")]
		void AdViewWillMoveToSuperview (UIView superview);

		// @optional -(void)nativeAdTapped;
		[Export ("nativeAdTapped")]
		void NativeAdTapped ();
	}

	// @interface MPStaticNativeAdRendererSettings : NSObject <MPNativeAdRendererSettings>
	[BaseType (typeof (NSObject))]
	interface MPStaticNativeAdRendererSettings
	{
		// @property (assign, nonatomic) Class renderingViewClass;
		[Export ("renderingViewClass", ArgumentSemantic.Assign)]
		Class RenderingViewClass { get; set; }

		// @property (readwrite, copy, nonatomic) MPNativeViewSizeHandler viewSizeHandler;
		[Export ("viewSizeHandler", ArgumentSemantic.Copy)]
		MPNativeViewSizeHandler ViewSizeHandler { get; set; }
	}

	// @protocol MPNativeAdRendererSettings <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MPNativeAdRendererSettings
	{
		// @optional @property (readwrite, copy, nonatomic) MPNativeViewSizeHandler viewSizeHandler;
		[Export ("viewSizeHandler", ArgumentSemantic.Copy)]
		MPNativeViewSizeHandler ViewSizeHandler { get; set; }
	}

	//todo Verify
	// typedef CGSize (^MPNativeViewSizeHandler)(CGFloat);
	// delegate CGSize MPNativeViewSizeHandler (CGFloat maximumWidth);
	delegate CGSize MPNativeViewSizeHandler (nfloat maximumWidth);

	#endregion

	#region MPNativeAdRendererConfiguration

	// @interface MPNativeAdRendererConfiguration : NSObject
	[BaseType (typeof (NSObject))]
	interface MPNativeAdRendererConfiguration
	{
		// @property (nonatomic, strong) id<MPNativeAdRendererSettings> rendererSettings;
		[Export ("rendererSettings", ArgumentSemantic.Strong)]
		MPNativeAdRendererSettings RendererSettings { get; set; }

		// @property (assign, nonatomic) Class rendererClass;
		[Export ("rendererClass", ArgumentSemantic.Assign)]
		Class RendererClass { get; set; }

		// @property (nonatomic, strong) NSArray * supportedCustomEvents;
		[Export ("supportedCustomEvents", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		//todo Verify
		//NSObject [] SupportedCustomEvents { get; set; }
		NSArray SupportedCustomEvents { get; set; }
	}

	#endregion


    // @interface MPAdConversionTracker : NSObject <NSURLConnectionDataDelegate>
    [BaseType (typeof(NSObject))]
    interface MPAdConversionTracker : INSUrlConnectionDataDelegate
    {
        // +(MPAdConversionTracker *)sharedConversionTracker;
        [Static]
        [Export ("sharedConversionTracker")]
        MPAdConversionTracker SharedConversionTracker { get; }

        // -(void)reportApplicationOpenForApplicationID:(NSString *)appID;
        [Export ("reportApplicationOpenForApplicationID:")]
        void ReportApplicationOpenForApplicationID (string appID);
    }

    // @interface MPAdView : UIView
    [BaseType (typeof(UIView))]
    interface MPAdView
    {
        // -(id)initWithAdUnitId:(NSString *)adUnitId size:(CGSize)size;
        [Export ("initWithAdUnitId:size:")]
        IntPtr Constructor (string adUnitId, CGSize size);

        [Wrap ("WeakDelegate")]
        [NullAllowed]
        MPAdViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MPAdViewDelegate> _Nullable delegate;
        [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (copy, nonatomic) NSString * adUnitId;
        [Export ("adUnitId")]
        string AdUnitId { get; set; }

        // @property (copy, nonatomic) NSString * keywords;
        [Export ("keywords")]
        string Keywords { get; set; }

        // @property (copy, nonatomic) CLLocation * location;
        [Export ("location", ArgumentSemantic.Copy)]
        CLLocation Location { get; set; }

        // @property (getter = isTesting, assign, nonatomic) BOOL testing;
        [Export ("testing")]
        bool Testing { [Bind ("isTesting")] get; set; }

        // -(void)loadAd;
        [Export ("loadAd")]
        void LoadAd ();

        // -(void)forceRefreshAd;
        [Export ("forceRefreshAd")]
        void ForceRefreshAd ();

        // -(void)rotateToOrientation:(UIInterfaceOrientation)newOrientation;
        [Export ("rotateToOrientation:")]
        void RotateToOrientation (UIInterfaceOrientation newOrientation);

        // -(void)lockNativeAdsToOrientation:(MPNativeAdOrientation)orientation;
        [Export ("lockNativeAdsToOrientation:")]
		void LockNativeAdsToOrientation (MPNativeAdOrientation orientation);

        // -(void)unlockNativeAdsOrientation;
        [Export ("unlockNativeAdsOrientation")]
        void UnlockNativeAdsOrientation ();

        // -(MPNativeAdOrientation)allowedNativeAdsOrientation;
        [Export ("allowedNativeAdsOrientation")]
		MPNativeAdOrientation AllowedNativeAdsOrientation { get; }

        // -(CGSize)adContentViewSize;
        [Export ("adContentViewSize")]
        CGSize AdContentViewSize { get; }

        // -(void)stopAutomaticallyRefreshingContents;
        [Export ("stopAutomaticallyRefreshingContents")]
        void StopAutomaticallyRefreshingContents ();

        // -(void)startAutomaticallyRefreshingContents;
        [Export ("startAutomaticallyRefreshingContents")]
        void StartAutomaticallyRefreshingContents ();
    }

    // @protocol MPAdViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface MPAdViewDelegate
    {
        // @required -(UIViewController *)viewControllerForPresentingModalView;
        [Abstract]
        [Export ("viewControllerForPresentingModalView")]
        UIViewController ViewControllerForPresentingModalView { get; }

        // @optional -(void)adViewDidLoadAd:(MPAdView *)view;
        [Export ("adViewDidLoadAd:")]
        void AdViewDidLoadAd (MPAdView view);

        // @optional -(void)adViewDidFailToLoadAd:(MPAdView *)view;
        [Export ("adViewDidFailToLoadAd:")]
        void AdViewDidFailToLoadAd (MPAdView view);

        // @optional -(void)willPresentModalViewForAd:(MPAdView *)view;
        [Export ("willPresentModalViewForAd:")]
        void WillPresentModalViewForAd (MPAdView view);

        // @optional -(void)didDismissModalViewForAd:(MPAdView *)view;
        [Export ("didDismissModalViewForAd:")]
        void DidDismissModalViewForAd (MPAdView view);

        // @optional -(void)willLeaveApplicationFromAd:(MPAdView *)view;
        [Export ("willLeaveApplicationFromAd:")]
        void WillLeaveApplicationFromAd (MPAdView view);
    }

    // @protocol MPBannerCustomEventDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface MPBannerCustomEventDelegate
    {
        // @required -(UIViewController *)viewControllerForPresentingModalView;
        [Abstract]
        [Export ("viewControllerForPresentingModalView")]
        UIViewController ViewControllerForPresentingModalView { get; }

        // @required -(CLLocation *)location;
        [Abstract]
        [Export ("location")]
        CLLocation Location { get; }

        // @required -(void)bannerCustomEvent:(MPBannerCustomEvent *)event didLoadAd:(UIView *)ad;
        [Abstract]
        [Export ("bannerCustomEvent:didLoadAd:")]
        void BannerCustomEvent (MPBannerCustomEvent @event, UIView ad);

        // @required -(void)bannerCustomEvent:(MPBannerCustomEvent *)event didFailToLoadAdWithError:(NSError *)error;
        [Abstract]
        [Export ("bannerCustomEvent:didFailToLoadAdWithError:")]
        void BannerCustomEvent (MPBannerCustomEvent @event, NSError error);

        // @required -(void)bannerCustomEventWillBeginAction:(MPBannerCustomEvent *)event;
        [Abstract]
        [Export ("bannerCustomEventWillBeginAction:")]
        void BannerCustomEventWillBeginAction (MPBannerCustomEvent @event);

        // @required -(void)bannerCustomEventDidFinishAction:(MPBannerCustomEvent *)event;
        [Abstract]
        [Export ("bannerCustomEventDidFinishAction:")]
        void BannerCustomEventDidFinishAction (MPBannerCustomEvent @event);

        // @required -(void)bannerCustomEventWillLeaveApplication:(MPBannerCustomEvent *)event;
        [Abstract]
        [Export ("bannerCustomEventWillLeaveApplication:")]
        void BannerCustomEventWillLeaveApplication (MPBannerCustomEvent @event);

        // @required -(void)trackImpression;
        [Abstract]
        [Export ("trackImpression")]
        void TrackImpression ();

        // @required -(void)trackClick;
        [Abstract]
        [Export ("trackClick")]
        void TrackClick ();
    }

    // @interface MPBannerCustomEvent : NSObject
    [BaseType (typeof(NSObject))]
    interface MPBannerCustomEvent
    {
        // -(void)requestAdWithSize:(CGSize)size customEventInfo:(NSDictionary *)info;
        [Export ("requestAdWithSize:customEventInfo:")]
        void RequestAdWithSize (CGSize size, NSDictionary info);

        // -(void)rotateToOrientation:(UIInterfaceOrientation)newOrientation;
        [Export ("rotateToOrientation:")]
        void RotateToOrientation (UIInterfaceOrientation newOrientation);

        // -(void)didDisplayAd;
        [Export ("didDisplayAd")]
        void DidDisplayAd ();

        // -(BOOL)enableAutomaticImpressionAndClickTracking;
        [Export ("enableAutomaticImpressionAndClickTracking")]
        bool EnableAutomaticImpressionAndClickTracking ();

        [Wrap ("WeakDelegate")]
        [NullAllowed]
        MPBannerCustomEventDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MPBannerCustomEventDelegate> _Nullable delegate;
        [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @interface MPInterstitialAdController : UIViewController
    [BaseType (typeof(UIViewController))]
    interface MPInterstitialAdController
    {
        // +(MPInterstitialAdController *)interstitialAdControllerForAdUnitId:(NSString *)adUnitId;
        [Static]
        [Export ("interstitialAdControllerForAdUnitId:")]
        MPInterstitialAdController InterstitialAdControllerForAdUnitId (string adUnitId);

        [Wrap ("WeakDelegate")]
        [NullAllowed]
        MPInterstitialAdControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MPInterstitialAdControllerDelegate> _Nullable delegate;
        [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (copy, nonatomic) NSString * adUnitId;
        [Export ("adUnitId")]
        string AdUnitId { get; set; }

        // @property (copy, nonatomic) NSString * keywords;
        [Export ("keywords")]
        string Keywords { get; set; }

        // @property (copy, nonatomic) CLLocation * location;
        [Export ("location", ArgumentSemantic.Copy)]
        CLLocation Location { get; set; }

        // @property (getter = isTesting, assign, nonatomic) BOOL testing;
        [Export ("testing")]
        bool Testing { [Bind ("isTesting")] get; set; }

        // -(void)loadAd;
        [Export ("loadAd")]
        void LoadAd ();

        // @property (readonly, assign, nonatomic) BOOL ready;
        [Export ("ready")]
        bool Ready { get; }

        // -(void)showFromViewController:(UIViewController *)controller;
        [Export ("showFromViewController:")]
        void ShowFromViewController (UIViewController controller);

        // +(void)removeSharedInterstitialAdController:(MPInterstitialAdController *)controller;
        [Static]
        [Export ("removeSharedInterstitialAdController:")]
        void RemoveSharedInterstitialAdController (MPInterstitialAdController controller);

        // +(NSMutableArray *)sharedInterstitialAdControllers;
        [Static]
        [Export ("sharedInterstitialAdControllers")]
        NSMutableArray SharedInterstitialAdControllers { get; }
    }

    // @protocol MPInterstitialAdControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface MPInterstitialAdControllerDelegate
    {
        // @optional -(void)interstitialDidLoadAd:(MPInterstitialAdController *)interstitial;
        [Export ("interstitialDidLoadAd:")]
        void InterstitialDidLoadAd (MPInterstitialAdController interstitial);

        // @optional -(void)interstitialDidFailToLoadAd:(MPInterstitialAdController *)interstitial;
        [Export ("interstitialDidFailToLoadAd:")]
        void InterstitialDidFailToLoadAd (MPInterstitialAdController interstitial);

        // @optional -(void)interstitialWillAppear:(MPInterstitialAdController *)interstitial;
        [Export ("interstitialWillAppear:")]
        void InterstitialWillAppear (MPInterstitialAdController interstitial);

        // @optional -(void)interstitialDidAppear:(MPInterstitialAdController *)interstitial;
        [Export ("interstitialDidAppear:")]
        void InterstitialDidAppear (MPInterstitialAdController interstitial);

        // @optional -(void)interstitialWillDisappear:(MPInterstitialAdController *)interstitial;
        [Export ("interstitialWillDisappear:")]
        void InterstitialWillDisappear (MPInterstitialAdController interstitial);

        // @optional -(void)interstitialDidDisappear:(MPInterstitialAdController *)interstitial;
        [Export ("interstitialDidDisappear:")]
        void InterstitialDidDisappear (MPInterstitialAdController interstitial);

        // @optional -(void)interstitialDidExpire:(MPInterstitialAdController *)interstitial;
        [Export ("interstitialDidExpire:")]
        void InterstitialDidExpire (MPInterstitialAdController interstitial);

        // @optional -(void)interstitialDidReceiveTapEvent:(MPInterstitialAdController *)interstitial;
        [Export ("interstitialDidReceiveTapEvent:")]
        void InterstitialDidReceiveTapEvent (MPInterstitialAdController interstitial);
    }

    // @protocol MPInterstitialCustomEventDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface MPInterstitialCustomEventDelegate
    {
        // @required -(CLLocation *)location;
        [Abstract]
        [Export ("location")]
        CLLocation Location { get; }

        // @required -(void)interstitialCustomEvent:(MPInterstitialCustomEvent *)customEvent didLoadAd:(id)ad;
        [Abstract]
        [Export ("interstitialCustomEvent:didLoadAd:")]
        void InterstitialCustomEvent (MPInterstitialCustomEvent customEvent, NSObject ad);

        // @required -(void)interstitialCustomEvent:(MPInterstitialCustomEvent *)customEvent didFailToLoadAdWithError:(NSError *)error;
        [Abstract]
        [Export ("interstitialCustomEvent:didFailToLoadAdWithError:")]
        void InterstitialCustomEvent (MPInterstitialCustomEvent customEvent, NSError error);

        // @required -(void)interstitialCustomEventDidExpire:(MPInterstitialCustomEvent *)customEvent;
        [Abstract]
        [Export ("interstitialCustomEventDidExpire:")]
        void InterstitialCustomEventDidExpire (MPInterstitialCustomEvent customEvent);

        // @required -(void)interstitialCustomEventWillAppear:(MPInterstitialCustomEvent *)customEvent;
        [Abstract]
        [Export ("interstitialCustomEventWillAppear:")]
        void InterstitialCustomEventWillAppear (MPInterstitialCustomEvent customEvent);

        // @required -(void)interstitialCustomEventDidAppear:(MPInterstitialCustomEvent *)customEvent;
        [Abstract]
        [Export ("interstitialCustomEventDidAppear:")]
        void InterstitialCustomEventDidAppear (MPInterstitialCustomEvent customEvent);

        // @required -(void)interstitialCustomEventWillDisappear:(MPInterstitialCustomEvent *)customEvent;
        [Abstract]
        [Export ("interstitialCustomEventWillDisappear:")]
        void InterstitialCustomEventWillDisappear (MPInterstitialCustomEvent customEvent);

        // @required -(void)interstitialCustomEventDidDisappear:(MPInterstitialCustomEvent *)customEvent;
        [Abstract]
        [Export ("interstitialCustomEventDidDisappear:")]
        void InterstitialCustomEventDidDisappear (MPInterstitialCustomEvent customEvent);

        // @required -(void)interstitialCustomEventDidReceiveTapEvent:(MPInterstitialCustomEvent *)customEvent;
        [Abstract]
        [Export ("interstitialCustomEventDidReceiveTapEvent:")]
        void InterstitialCustomEventDidReceiveTapEvent (MPInterstitialCustomEvent customEvent);

        // @required -(void)interstitialCustomEventWillLeaveApplication:(MPInterstitialCustomEvent *)customEvent;
        [Abstract]
        [Export ("interstitialCustomEventWillLeaveApplication:")]
        void InterstitialCustomEventWillLeaveApplication (MPInterstitialCustomEvent customEvent);

        // @required -(void)trackImpression;
        [Abstract]
        [Export ("trackImpression")]
        void TrackImpression ();

        // @required -(void)trackClick;
        [Abstract]
        [Export ("trackClick")]
        void TrackClick ();
    }

    // @interface MPInterstitialCustomEvent : NSObject
    [BaseType (typeof(NSObject))]
    interface MPInterstitialCustomEvent
    {
        // -(void)requestInterstitialWithCustomEventInfo:(NSDictionary *)info;
        [Export ("requestInterstitialWithCustomEventInfo:")]
        void RequestInterstitialWithCustomEventInfo (NSDictionary info);

        // -(void)showInterstitialFromRootViewController:(UIViewController *)rootViewController;
        [Export ("showInterstitialFromRootViewController:")]
        void ShowInterstitialFromRootViewController (UIViewController rootViewController);

        // -(BOOL)enableAutomaticImpressionAndClickTracking;
        [Export ("enableAutomaticImpressionAndClickTracking")]
        bool EnableAutomaticImpressionAndClickTracking ();

        [Wrap ("WeakDelegate")]
        [NullAllowed]
        MPInterstitialCustomEventDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MPInterstitialCustomEventDelegate> _Nullable delegate;
        [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @interface MoPub : NSObject
    [BaseType (typeof(NSObject))]
    interface MoPub
    {
        // +(MoPub *)sharedInstance;
        [Static]
        [Export ("sharedInstance")]
        MoPub SharedInstance { get; }

        // @property (assign, nonatomic) BOOL locationUpdatesEnabled;
        [Export ("locationUpdatesEnabled")]
        bool LocationUpdatesEnabled { get; set; }

        // -(void)initializeRewardedVideoWithGlobalMediationSettings:(NSArray *)globalMediationSettings delegate:(id)delegate;
        [Export ("initializeRewardedVideoWithGlobalMediationSettings:delegate:")]
        void InitializeRewardedVideoWithGlobalMediationSettings (NSObject[] globalMediationSettings, NSObject @delegate);

        // -(id)globalMediationSettingsForClass:(Class)aClass;
        [Export ("globalMediationSettingsForClass:")]
        NSObject GlobalMediationSettingsForClass (Class aClass);

        // -(void)start;
        [Export ("start")]
        void Start ();

        // -(NSString *)version;
        [Export ("version")]
        string Version { get; }

        // -(NSString *)bundleIdentifier;
        [Export ("bundleIdentifier")]
        string BundleIdentifier { get; }
    }

    // @interface MPRewardedVideo : NSObject
    [BaseType (typeof(NSObject))]
    interface MPRewardedVideo
    {
        // +(void)loadRewardedVideoAdWithAdUnitID:(NSString *)adUnitID withMediationSettings:(NSArray *)mediationSettings;
        [Static]
        [Export ("loadRewardedVideoAdWithAdUnitID:withMediationSettings:")]
        //[Verify (StronglyTypedNSArray)]
        void LoadRewardedVideoAdWithAdUnitID (string adUnitID, NSObject[] mediationSettings);

        // +(void)loadRewardedVideoAdWithAdUnitID:(NSString *)adUnitID keywords:(NSString *)keywords location:(CLLocation *)location mediationSettings:(NSArray *)mediationSettings;
        [Static]
        [Export ("loadRewardedVideoAdWithAdUnitID:keywords:location:mediationSettings:")]
        //[Verify (StronglyTypedNSArray)]
        void LoadRewardedVideoAdWithAdUnitID (string adUnitID, string keywords, CLLocation location, NSObject[] mediationSettings);

        // +(BOOL)hasAdAvailableForAdUnitID:(NSString *)adUnitID;
        [Static]
        [Export ("hasAdAvailableForAdUnitID:")]
        bool HasAdAvailableForAdUnitID (string adUnitID);

        // +(void)presentRewardedVideoAdForAdUnitID:(NSString *)adUnitID fromViewController:(UIViewController *)viewController;
        [Static]
        [Export ("presentRewardedVideoAdForAdUnitID:fromViewController:")]
        void PresentRewardedVideoAdForAdUnitID (string adUnitID, UIViewController viewController);
    }

    // @protocol MPRewardedVideoDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface MPRewardedVideoDelegate
    {
        // @optional -(void)rewardedVideoAdDidLoadForAdUnitID:(NSString *)adUnitID;
        [Export ("rewardedVideoAdDidLoadForAdUnitID:")]
        void RewardedVideoAdDidLoadForAdUnitID (string adUnitID);

        // @optional -(void)rewardedVideoAdDidFailToLoadForAdUnitID:(NSString *)adUnitID error:(NSError *)error;
        [Export ("rewardedVideoAdDidFailToLoadForAdUnitID:error:")]
        void RewardedVideoAdDidFailToLoadForAdUnitID (string adUnitID, NSError error);

        // @optional -(void)rewardedVideoAdDidExpireForAdUnitID:(NSString *)adUnitID;
        [Export ("rewardedVideoAdDidExpireForAdUnitID:")]
        void RewardedVideoAdDidExpireForAdUnitID (string adUnitID);

        // @optional -(void)rewardedVideoAdDidFailToPlayForAdUnitID:(NSString *)adUnitID error:(NSError *)error;
        [Export ("rewardedVideoAdDidFailToPlayForAdUnitID:error:")]
        void RewardedVideoAdDidFailToPlayForAdUnitID (string adUnitID, NSError error);

        // @optional -(void)rewardedVideoAdWillAppearForAdUnitID:(NSString *)adUnitID;
        [Export ("rewardedVideoAdWillAppearForAdUnitID:")]
        void RewardedVideoAdWillAppearForAdUnitID (string adUnitID);

        // @optional -(void)rewardedVideoAdDidAppearForAdUnitID:(NSString *)adUnitID;
        [Export ("rewardedVideoAdDidAppearForAdUnitID:")]
        void RewardedVideoAdDidAppearForAdUnitID (string adUnitID);

        // @optional -(void)rewardedVideoAdWillDisappearForAdUnitID:(NSString *)adUnitID;
        [Export ("rewardedVideoAdWillDisappearForAdUnitID:")]
        void RewardedVideoAdWillDisappearForAdUnitID (string adUnitID);

        // @optional -(void)rewardedVideoAdDidDisappearForAdUnitID:(NSString *)adUnitID;
        [Export ("rewardedVideoAdDidDisappearForAdUnitID:")]
        void RewardedVideoAdDidDisappearForAdUnitID (string adUnitID);

        // @optional -(void)rewardedVideoAdDidReceiveTapEventForAdUnitID:(NSString *)adUnitID;
        [Export ("rewardedVideoAdDidReceiveTapEventForAdUnitID:")]
        void RewardedVideoAdDidReceiveTapEventForAdUnitID (string adUnitID);

        // @optional -(void)rewardedVideoAdWillLeaveApplicationForAdUnitID:(NSString *)adUnitID;
        [Export ("rewardedVideoAdWillLeaveApplicationForAdUnitID:")]
        void RewardedVideoAdWillLeaveApplicationForAdUnitID (string adUnitID);

        // @optional -(void)rewardedVideoAdShouldRewardForAdUnitID:(NSString *)adUnitID reward:(MPRewardedVideoReward *)reward;
        [Export ("rewardedVideoAdShouldRewardForAdUnitID:reward:")]
        void RewardedVideoAdShouldRewardForAdUnitID (string adUnitID, MPRewardedVideoReward reward);
    }

    [Static]
    partial interface Constants
    {
        // extern NSString *const kMPRewardedVideoRewardCurrencyTypeUnspecified;
        [Field ("kMPRewardedVideoRewardCurrencyTypeUnspecified", "__Internal")]
        NSString kMPRewardedVideoRewardCurrencyTypeUnspecified { get; }

        // extern const NSInteger kMPRewardedVideoRewardCurrencyAmountUnspecified;
        [Field ("kMPRewardedVideoRewardCurrencyAmountUnspecified", "__Internal")]
        nint kMPRewardedVideoRewardCurrencyAmountUnspecified { get; }
    }

    // @interface MPRewardedVideoReward : NSObject
    [BaseType (typeof(NSObject))]
    interface MPRewardedVideoReward
    {
        // @property (readonly, nonatomic) NSString * currencyType;
        [Export ("currencyType")]
        string CurrencyType { get; }

        // @property (readonly, nonatomic) NSNumber * amount;
        [Export ("amount")]
        NSNumber Amount { get; }

        // -(instancetype)initWithCurrencyAmount:(NSNumber *)amount;
        [Export ("initWithCurrencyAmount:")]
        IntPtr Constructor (NSNumber amount);

        // -(instancetype)initWithCurrencyType:(NSString *)currencyType amount:(NSNumber *)amount;
        [Export ("initWithCurrencyType:amount:")]
        IntPtr Constructor (string currencyType, NSNumber amount);
    }

	[BaseType(typeof(NSObject))]
	interface FBAdSettings
	{
		// +(void)addTestDevices:(NSArray*)devices;
		[Static]
		[Export("addTestDevices:")]
		void AddTestDevices(string[] hashedDeviceID);
	}
}
