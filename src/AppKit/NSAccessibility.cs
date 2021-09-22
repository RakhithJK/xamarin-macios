//
// NSAccessibility.cs
//
// Author:
//  Chris Hamons <chris.hamons@xamarin.com>
//
// Copyright 2016 Xamarin Inc. (http://xamarin.com)

#if !__MACCATALYST__

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

using CoreFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace AppKit
{
#if !NET
	[Mac (10,10)] // protocol added in 10.10
#endif
	public partial interface INSAccessibility {}

#if !NET
	[Mac (10,9)] // but the field/notifications are in 10.9
#endif
	public partial class NSAccessibility
	{
#if !COREBUILD
#if !NET
		[Mac (10,10)]
#endif
		[DllImport (Constants.AppKitLibrary)]
		static extern CGRect NSAccessibilityFrameInView (NSView parentView, CGRect frame);

		public static CGRect GetFrameInView (NSView parentView, CGRect frame)
		{
			return NSAccessibilityFrameInView (parentView, frame);
		}

#if !NET
		[Mac (10,10)]
#endif
		[DllImport (Constants.AppKitLibrary)]
		static extern CGPoint NSAccessibilityPointInView (NSView parentView, CGPoint point);

		public static CGPoint GetPointInView (NSView parentView, CGPoint point)
		{
			return NSAccessibilityPointInView (parentView, point);
		}

		[DllImport (Constants.AppKitLibrary)]
		static extern void NSAccessibilityPostNotificationWithUserInfo (IntPtr element, IntPtr notification, IntPtr userInfo);

		public static void PostNotification (NSObject element, NSString notification, NSDictionary userInfo)
		{
			if (element == null)
				throw new ArgumentNullException ("element");

			if (notification == null)
				throw new ArgumentNullException ("notification");

			IntPtr userInfoHandle;
			if (userInfo == null)
				userInfoHandle = IntPtr.Zero;
			else
				userInfoHandle = userInfo.Handle;

			NSAccessibilityPostNotificationWithUserInfo (element.Handle, notification.Handle, userInfoHandle);
		}

		[DllImport (Constants.AppKitLibrary)]
		static extern void NSAccessibilityPostNotification (IntPtr element, IntPtr notification);

		public static void PostNotification (NSObject element, NSString notification)
		{
			if (element == null)
				throw new ArgumentNullException ("element");

			if (notification == null)
				throw new ArgumentNullException ("notification");

			NSAccessibilityPostNotification (element.Handle, notification.Handle);
		}

		[DllImport (Constants.AppKitLibrary)]
		static extern IntPtr NSAccessibilityRoleDescription (IntPtr role, IntPtr subrole);

		public static string GetRoleDescription (NSString role, NSString subrole)
		{
			if (role == null)
				throw new ArgumentNullException ("role");

			IntPtr subroleHandle;
			if (subrole == null)
				subroleHandle = IntPtr.Zero;
			else
				subroleHandle = subrole.Handle;

			IntPtr handle = NSAccessibilityRoleDescription (role.Handle, subroleHandle);
			return CFString.FromHandle (handle);
		}

		[DllImport (Constants.AppKitLibrary)]
		static extern IntPtr NSAccessibilityRoleDescriptionForUIElement (IntPtr element);

		public static string GetRoleDescription (NSObject element)
		{
			if (element == null)
				throw new ArgumentNullException ("element");

			IntPtr handle = NSAccessibilityRoleDescriptionForUIElement (element.Handle);
			return CFString.FromHandle (handle);
		}

		[DllImport (Constants.AppKitLibrary)]
		static extern IntPtr NSAccessibilityActionDescription (IntPtr action);

		public static string GetActionDescription (NSString action)
		{
			if (action == null)
				throw new ArgumentNullException ("action");

			IntPtr handle = NSAccessibilityActionDescription (action.Handle);
			return CFString.FromHandle (handle);
		}

		[DllImport (Constants.AppKitLibrary)]
		static extern IntPtr NSAccessibilityUnignoredAncestor (IntPtr element);

		public static NSObject GetUnignoredAncestor (NSObject element)
		{
			if (element == null)
				throw new ArgumentNullException ("element");

			var handle = NSAccessibilityUnignoredAncestor (element.Handle);
			return Runtime.GetNSObject (handle);
		}

		[DllImport (Constants.AppKitLibrary)]
		static extern IntPtr NSAccessibilityUnignoredDescendant (IntPtr element);

		public static NSObject GetUnignoredDescendant (NSObject element)
		{
			if (element == null)
				throw new ArgumentNullException ("element");

			var handle = NSAccessibilityUnignoredDescendant (element.Handle);

			return Runtime.GetNSObject (handle);
		}

		[DllImport (Constants.AppKitLibrary)]
		static extern IntPtr NSAccessibilityUnignoredChildren (IntPtr originalChildren);

		public static NSObject[] GetUnignoredChildren (NSArray originalChildren)
		{
			if (originalChildren == null)
				throw new ArgumentNullException ("originalChildren");

			var handle = NSAccessibilityUnignoredChildren (originalChildren.Handle);

			return NSArray.ArrayFromHandle<NSObject> (handle);
		}

		[DllImport (Constants.AppKitLibrary)]
		static extern IntPtr NSAccessibilityUnignoredChildrenForOnlyChild (IntPtr originalChild);

		public static NSObject[] GetUnignoredChildren (NSObject originalChild)
		{
			if (originalChild == null)
				throw new ArgumentNullException ("originalChild");

			var handle = NSAccessibilityUnignoredChildrenForOnlyChild (originalChild.Handle);

			return NSArray.ArrayFromHandle<NSObject> (handle);
		}

		[DllImport (Constants.AppKitLibrary)]
		[return: MarshalAs (UnmanagedType.I1)]
		static extern bool NSAccessibilitySetMayContainProtectedContent ([MarshalAs (UnmanagedType.I1)] bool flag);

		public static bool SetMayContainProtectedContent (bool flag)
		{
			return NSAccessibilitySetMayContainProtectedContent (flag);
		}
#endif
	}
}
#endif // !__MACCATALYST__
