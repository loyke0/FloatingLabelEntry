using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using FloatingLabelEntry.iOS;

namespace FloatingLabelEntry.Demo.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();
			FloatingLabelEntryBaseRenderer.Register ();

			foreach (var font in UIFont.FamilyNames)
			{
				foreach (var item in UIFont.FontNamesForFamilyName(font))
				{
					Console.WriteLine(item);
				}
				Console.WriteLine("-----------");
			}

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

