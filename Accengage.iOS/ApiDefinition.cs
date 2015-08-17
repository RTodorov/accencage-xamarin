using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreLocation;

namespace Accengage.iOS
{
	// @interface A4SWebView : UIWebView
	[BaseType (typeof (UIWebView))]
	interface A4SWebView {

	}

	// @protocol BMA4SInAppNotificationDataSource
	[BaseType (typeof (NSObject))]
	[Protocol]
	interface BMA4SInAppNotificationDataSource {
		[Static, Export ("BMA4SOverlayInAppPositionForTemplate")]
		BMA4SOverlayInAppPosition BMA4SOverlayInAppPositionForTemplate (NSString templateName, CGSize templateSize);

		[Static, Export ("BMA4SOverlayInAppCustomPositionForTemplate")]
		CGPoint BMA4SOverlayInAppCustomPositionForTemplate(NSString templateName, CGSize templateSize);
	}

	// @interface BMA4SInAppNotification : NSObject
	[BaseType (typeof (NSObject))]
	interface BMA4SInAppNotification {

		// +(void)setNotificationLock:(BOOL)locked;
		[Static, Export ("setNotificationLock:")]
		void SetNotificationLock (bool locked);

		// +(BOOL)notificationLock;
		[Static, Export ("notificationLock")]
		bool NotificationLock ();

		// +(void)setNotificationTimeInterval:(NSTimeInterval)minimumTimeInterval;
		[Static, Export ("setNotificationTimeInterval:")]
		void SetNotificationTimeInterval (double minimumTimeInterval);

		// +(void)setDataSource:(id<BMA4SInAppNotificationDataSource>)datasource;
		[Static, Export ("setDataSource:")]
		void SetDataSource (BMA4SInAppNotificationDataSource datasource);

		// +(void)setDefaultBannerOriginForPortrait:(CGPoint)position;
		[Static, Export ("setDefaultBannerOriginForPortrait:")]
		void SetDefaultBannerOriginForPortrait (CGPoint position);

		// +(void)setDefaultBannerOriginForLandscape:(CGPoint)position;
		[Static, Export ("setDefaultBannerOriginForLandscape:")]
		void SetDefaultBannerOriginForLandscape (CGPoint position);

		// +(void)resetDefaultBannerOriginForPortrait;
		[Static, Export ("resetDefaultBannerOriginForPortrait")]
		void ResetDefaultBannerOriginForPortrait ();

		// +(void)resetDefaultBannerOriginForLandscape;
		[Static, Export ("resetDefaultBannerOriginForLandscape")]
		void ResetDefaultBannerOriginForLandscape ();

		// +(void)setBannerOriginForPortrait:(CGPoint)position forViewController:(UIViewController *)viewController;
		[Static, Export ("setBannerOriginForPortrait:forViewController:")]
		void SetBannerOriginForPortrait (CGPoint position, UIViewController viewController);

		// +(void)setBannerOriginForLandscape:(CGPoint)position forViewController:(UIViewController *)viewController;
		[Static, Export ("setBannerOriginForLandscape:forViewController:")]
		void SetBannerOriginForLandscape (CGPoint position, UIViewController viewController);

		// +(void)resetOriginForPortraitForViewController:(UIViewController *)viewController;
		[Static, Export ("resetOriginForPortraitForViewController:")]
		void ResetOriginForPortraitForViewController (UIViewController viewController);

		// +(void)resetOriginForLandscapeForViewController:(UIViewController *)viewController;
		[Static, Export ("resetOriginForLandscapeForViewController:")]
		void ResetOriginForLandscapeForViewController (UIViewController viewController);
	}

	// @interface BMA4SInBoxMessageContent : NSObject
	[BaseType (typeof (NSObject))]
	interface BMA4SInBoxMessageContent {

		// @property (readonly, nonatomic) BMA4SMessageContentType type;
		[Export ("type")]
		BMA4SMessageContentType Type { get; }

		// @property (readonly, nonatomic) NSString * body;
		[Export ("body")]
		string Body { get; }

		// @property (readonly, nonatomic) NSArray * buttons;
		[Export ("buttons")]
		NSObject [] Buttons { get; }
	}

	// @interface BMA4SInBoxMessage : NSObject
	[BaseType (typeof (NSObject))]
	interface BMA4SInBoxMessage {

		// @property (readonly, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; }

		// @property (readonly, nonatomic) NSString * text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSString * from;
		[Export ("from")]
		string From { get; }

		// @property (readonly, nonatomic) NSString * category;
		[Export ("category")]
		string Category { get; }

		// @property (readonly, nonatomic) NSDate * date;
		[Export ("date")]
		NSDate Date { get; }

		// @property (readonly, nonatomic) NSString * iconUrl;
		[Export ("iconUrl")]
		string IconUrl { get; }

		// @property (readonly, nonatomic) NSDictionary * customParams;
		[Export ("customParams")]
		NSDictionary CustomParams { get; }

		// @property (readonly, nonatomic) BOOL isRead;
		[Export ("isRead")]
		bool IsRead { get; }

		// @property (readonly, nonatomic) BOOL isExpired;
		[Export ("isExpired")]
		bool IsExpired { get; }

		// -(void)interactWithDisplayHandler:(BMA4SInBoxDisplayHandler)handler;
		[Export ("interactWithDisplayHandler:")]
		void InteractWithDisplayHandler (Action<BMA4SInBoxMessage, BMA4SInBoxMessageContent> handler);

		// -(void)markAsRead;
		[Export ("markAsRead")]
		void MarkAsRead ();

		// -(void)markAsUnread;
		[Export ("markAsUnread")]
		void MarkAsUnread ();

		// -(BOOL)isArchived;
		[Export ("isArchived")]
		bool IsArchived ();

		// -(void)archive;
		[Export ("archive")]
		void Archive ();

		// -(void)unarchive;
		[Export ("unarchive")]
		void Unarchive ();
	}

	// @interface BMA4SInBox : NSObject
	[BaseType (typeof (NSObject))]
	interface BMA4SInBox {

		// +(void)obtainMessagesForMembers:(NSArray *)ids withHandler:(BMA4SInBoxLoadedWithResult)handler;
		[Static, Export ("obtainMessagesForMembers:withHandler:")]
		void ObtainMessagesForMembers (NSObject [] ids, Action<BMA4SInBoxLoadingResult, BMA4SInBox> handler);

		// -(void)obtainMessageAtIndex:(NSUInteger)index loaded:(BMA4SInBoxMessageLoaded)loaded onError:(BMA4SInBoxMessageError)onError;
		[Export ("obtainMessageAtIndex:loaded:onError:")]
		void ObtainMessageAtIndex (nuint index, Action<BMA4SInBoxMessage, nuint> loaded, Action<nuint> onError);

		// -(NSUInteger)size;
		[Export ("size")]
		nuint Size ();

		// -(NSUInteger)unreadMessageCount;
		[Export ("unreadMessageCount")]
		nuint UnreadMessageCount ();
	}

	// @interface BMA4SInBoxButton : NSObject
	[BaseType (typeof (NSObject))]
	interface BMA4SInBoxButton {

		// @property (readonly, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; }

		// -(void)interact;
		[Export ("interact")]
		void Interact ();
	}

	// @interface BMA4SNotification : NSObject
	[BaseType (typeof (NSObject))]
	interface BMA4SNotification {

		// +(BMA4SNotification *)sharedBMA4S;
		[Static, Export ("sharedBMA4S")]
		BMA4SNotification SharedBMA4S ();

		// -(void)registerDeviceToken:(NSData *)deviceToken;
		[Export ("registerDeviceToken:")]
		void RegisterDeviceToken (NSData deviceToken);

		// -(void)didFinishLaunchingWithOptions:(NSDictionary *)launchOptions;
		[Export ("didFinishLaunchingWithOptions:")]
		void DidFinishLaunchingWithOptions (NSDictionary launchOptions);

		// -(void)didReceiveRemoteNotification:(NSDictionary *)userInfo;
		[Export ("didReceiveRemoteNotification:")]
		void DidReceiveRemoteNotification (NSDictionary userInfo);

		// -(void)synchroniseProfile:(NSDictionary *)values;
		[Export ("synchroniseProfile:")]
		void SynchroniseProfile (NSDictionary values);

		// -(void)setPushNotificationLock:(BOOL)value;
		[Export ("setPushNotificationLock:")]
		void SetPushNotificationLock (bool value);

		// -(BOOL)pushNotificationLock;
		[Export ("pushNotificationLock")]
		bool PushNotificationLock ();

		// -(void)updateLocation:(CLLocation *)location;
		[Export ("updateLocation:")]
		void UpdateLocation (CLLocation location);

		// -(void)enableGeofenceService;
		[Export ("enableGeofenceService")]
		void EnableGeofenceService ();

		// -(void)allowViewAutomaticalyOnTop:(BOOL)value;
		[Export ("allowViewAutomaticalyOnTop:")]
		void AllowViewAutomaticalyOnTop (bool value);

		// -(void)didReceiveLocalNotification:(UILocalNotification *)notification;
		[Export ("didReceiveLocalNotification:")]
		void DidReceiveLocalNotification (UILocalNotification notification);

		// -(BOOL)applicationHandleOpenUrl:(NSURL *)url;
		[Export ("applicationHandleOpenUrl:")]
		bool ApplicationHandleOpenUrl (NSUrl url);

		// -(void)resetBadgeNumber;
		[Export ("resetBadgeNumber")]
		void ResetBadgeNumber ();

		// -(void)setAllowBadgeReset:(BOOL)allow;
		[Export ("setAllowBadgeReset:")]
		void SetAllowBadgeReset (bool allow);
	}

	// @interface BMA4STracker : NSObject
	[BaseType (typeof (NSObject))]
	interface BMA4STracker {

		// +(void)trackWithPartnerId:(NSString *)partnerId privateKey:(NSString *)privateKey options:(NSDictionary *)launchOptions;
		[Static, Export ("trackWithPartnerId:privateKey:options:")]
		void TrackWithPartnerId (string partnerId, string privateKey, NSDictionary launchOptions);

		// +(void)trackEventWithType:(NSInteger)eventType parameters:(NSArray *)parameters;
		[Static, Export ("trackEventWithType:parameters:")]
		void TrackEventWithType (nint eventType, NSObject [] parameters);

		// +(void)setUserID:(NSString *)userID;
		[Static, Export ("setUserID:")]
		void SetUserID (string userID);

		// +(NSString *)userID;
		[Static, Export ("userID")]
		string UserID ();

		// +(NSString *)A4SID;
		[Static, Export ("A4SID")]
		string A4SID ();

		// +(void)updateDeviceInfo:(NSDictionary *)values;
		[Static, Export ("updateDeviceInfo:")]
		void UpdateDeviceInfo (NSDictionary values);

		// +(void)setDebugMode:(BOOL)value;
		[Static, Export ("setDebugMode:")]
		void SetDebugMode (bool value);

		// +(void)setDoNotTrack:(BOOL)value;
		[Static, Export ("setDoNotTrack:")]
		void SetDoNotTrack (bool value);

		// +(BOOL)doNotTrack;
		[Static, Export ("doNotTrack")]
		bool DoNotTrack ();

		// +(BOOL)isRestrictedConnection;
		[Static, Export ("isRestrictedConnection")]
		bool IsRestrictedConnection ();

		// +(BOOL)setRestrictedConnection:(BOOL)value;
		[Static, Export ("setRestrictedConnection:")]
		bool SetRestrictedConnection (bool value);
	}

	// @interface BMA4SPurchasedItem : NSObject <NSCoding>
	[BaseType (typeof (NSObject))]
	interface BMA4SPurchasedItem : INSCoding {

		// @property (retain, nonatomic) NSString * itemId;
		[Export ("itemId", ArgumentSemantic.Retain)]
		string ItemId { get; set; }

		// @property (retain, nonatomic) NSString * label;
		[Export ("label", ArgumentSemantic.Retain)]
		string Label { get; set; }

		// @property (retain, nonatomic) NSString * category;
		[Export ("category", ArgumentSemantic.Retain)]
		string Category { get; set; }

		// @property (assign, nonatomic) double price;
		[Export ("price", ArgumentSemantic.UnsafeUnretained)]
		double Price { get; set; }

		// @property (assign, nonatomic) long quantity;
		[Export ("quantity", ArgumentSemantic.UnsafeUnretained)]
		nint Quantity { get; set; }

		// +(BMA4SPurchasedItem *)itemWithId:(NSString *)itemId label:(NSString *)label category:(NSString *)category price:(double)price quantity:(long)quantity;
		[Static, Export ("itemWithId:label:category:price:quantity:")]
		BMA4SPurchasedItem ItemWithId (string itemId, string label, string category, double price, nint quantity);
	}

	// @interface Analytics (BMA4STracker)
	[Category]
	[BaseType (typeof (BMA4STracker))]
	interface Analytics {

		// +(void)trackCartWithId:(NSString *)cartId forArticleWithId:(NSString *)articleId andLabel:(NSString *)label category:(NSString *)category price:(double)price currency:(NSString *)currency quantity:(long)quantity;
		[Static, Export ("trackCartWithId:forArticleWithId:andLabel:category:price:currency:quantity:")]
		void TrackCartWithId (string cartId, string articleId, string label, string category, double price, string currency, nint quantity);

		// +(void)trackPurchaseWithId:(NSString *)purchaseId currency:(NSString *)currency items:(NSArray *)items;
		[Static, Export ("trackPurchaseWithId:currency:items:")]
		void TrackPurchaseWithId (string purchaseId, string currency, NSObject [] items);

		// +(void)trackPurchaseWithId:(NSString *)purchaseId currency:(NSString *)currency totalPrice:(double)totalPrice;
		[Static, Export ("trackPurchaseWithId:currency:totalPrice:")]
		void TrackPurchaseWithId (string purchaseId, string currency, double totalPrice);

		// +(void)trackPurchaseWithId:(NSString *)purchaseId currency:(NSString *)currency items:(NSArray *)items totalPrice:(double)totalPrice;
		[Static, Export ("trackPurchaseWithId:currency:items:totalPrice:")]
		void TrackPurchaseWithId (string purchaseId, string currency, NSObject [] items, double totalPrice);

		// +(void)trackLeadWithLabel:(NSString *)label value:(NSString *)value;
		[Static, Export ("trackLeadWithLabel:value:")]
		void TrackLeadWithLabel (string label, string value);
	}

	// @interface Members (BMA4STracker)
	[Category]
	[BaseType (typeof (BMA4STracker))]
	interface Members {

		// +(void)login:(NSString *)memberId;
		[Static, Export ("login:")]
		void Login (string memberId);

		// +(void)logout;
		[Static, Export ("logout")]
		void Logout ();

		// +(NSString *)getActiveMember;
		[Static, Export ("getActiveMember")]
		string GetActiveMember ();

		// +(void)listMembers:(BMA4SMemberListHandler)onSucceeded usingRemoteInformation:(BOOL)remote;
		[Static, Export ("listMembers:usingRemoteInformation:")]
		void ListMembers (Action<NSArray, bool> onSucceeded, bool remote);

		// +(void)removeMembers:(NSArray *)members;
		[Static, Export ("removeMembers:")]
		void RemoveMembers (NSObject [] members);

		// +(void)updateMemberInfo:(NSDictionary *)values;
		[Static, Export ("updateMemberInfo:")]
		void UpdateMemberInfo (NSDictionary values);
	}

	// @interface BMA4SViewController : UIViewController
	[BaseType (typeof (UIViewController))]
	[Protocol]
	interface BMA4SViewController {

		// @property (retain, nonatomic) NSString * A4SViewControllerAlias;
		[Export ("A4SViewControllerAlias", ArgumentSemantic.Retain)]
		string A4SViewControllerAlias { get; set; }
	}
}
