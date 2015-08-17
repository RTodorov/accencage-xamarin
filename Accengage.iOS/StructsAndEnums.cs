using System;
using ObjCRuntime;

namespace Accengage.iOS
{
	[Native]
	public enum BMA4SMessageContentType : ulong /* nuint */ {
		Text,
		Web
	}

	[Native]
	public enum BMA4SInBoxLoadingResult : ulong /* nuint */ {
		Cancelled,
		Failed,
		Loaded
	}

	[Native]
	public enum BMA4SOverlayInAppPosition : ulong {
		BMA4SOverlayInAppPositionDefault = 0,
		BMA4SOverlayInAppPositionTop = 1,
		BMA4SOverlayInAppPositionTopLeft = 2,
		BMA4SOverlayInAppPositionTopRight = 3,
		BMA4SOverlayInAppPositionCenter = 4,
		BMA4SOverlayInAppPositionCenterLeft = 5,
		BMA4SOverlayInAppPositionCenterRight = 6,
		BMA4SOverlayInAppPositionBottom = 7,
		BMA4SOverlayInAppPositionBottomLeft = 8,
		BMA4SOverlayInAppPositionBottomRight = 9,
		BMA4SOverlayInAppPositionCustom = 10
	}
}
