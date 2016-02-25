using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using System.Drawing;
using FloatingLabelEntry.ExtendedControls;
using FloatingLabelEntry.Enumerations;
using FloatingLabelEntry.iOS.ExtendedControls;
using System.Collections.Generic;
using System.IO;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]

namespace FloatingLabelEntry.iOS.ExtendedControls
{
	public class ExtendedEntryRenderer:EntryRenderer
	{
		/// <summary>
		/// Used for registration with dependency service
		/// </summary>
		public static void Register() { }

		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement==null && e.NewElement!=null) {
				var entry = e.NewElement as ExtendedEntry;
				this.SetKeyboard (entry.CustomKeyboard);
				this.SetFont (entry);
				this.Control.AutocorrectionType = UITextAutocorrectionType.No;
				this.Control.SpellCheckingType = UITextSpellCheckingType.No;
				this.Control.BorderStyle = UITextBorderStyle.None;
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			var entry = Element as ExtendedEntry;
			if (e.PropertyName == ExtendedEntry.CustomKeyboardProperty.PropertyName) {
				SetKeyboard (entry.CustomKeyboard);
			}
			else if (e.PropertyName==ExtendedEntry.FontNameProperty.PropertyName) {
				SetFont (entry);
			}
			//Workaround for bug #1
			else if (e.PropertyName==ExtendedEntry.PlaceholderProperty.PropertyName && !String.IsNullOrWhiteSpace(entry.FontName)) {
				ResetPlaceholderFont (entry);
			}
		}
			
		private void SetFont (ExtendedEntry entry){
			if (!String.IsNullOrWhiteSpace(entry.FontName)) {
				var font = UIFont.FromName (entry.FontName, (nfloat)entry.FontSize);
				if (font != null)
				{
					this.Control.Font = font;
				}
			} else {
				this.Control.Font = Font.Default.ToUIFont().WithSize((nfloat)entry.FontSize);
			}
		}


		//Workaround for bug #1
		private void ResetPlaceholderFont(ExtendedEntry entry){
			this.Control.Font = Font.Default.ToUIFont().WithSize((nfloat)entry.FontSize);
			SetFont (entry);
		}


		private void SetKeyboard(CustomKeyboardEnum keyboard){
			switch (keyboard) {
			case CustomKeyboardEnum.Chat:
				Control.ApplyKeyboard (Keyboard.Chat);
				SetNumericToolbar (false);
				break;

			case CustomKeyboardEnum.Email:
				Control.ApplyKeyboard (Keyboard.Email);
				SetNumericToolbar (false); 
				break;

			case CustomKeyboardEnum.EmailAndNumeric:
				Control.ApplyKeyboard (Keyboard.Email);
				SetNumericToolbar (true);
				break;

			case CustomKeyboardEnum.Numeric:
				SetNumericToolbar (false);
				Control.ApplyKeyboard (Keyboard.Numeric);
				break;

			case CustomKeyboardEnum.Phone:
				SetNumericToolbar (false);
				Control.ApplyKeyboard (Keyboard.Telephone);
				break;

			case CustomKeyboardEnum.Text:
				SetNumericToolbar (false);
				Control.ApplyKeyboard (Keyboard.Text);
				break;

			case CustomKeyboardEnum.Url:
				SetNumericToolbar (false);
				Control.ApplyKeyboard (Keyboard.Url);
				break;

			default:
				break;
			}
		}

		private void SetNumericToolbar(bool isSet) {
			if (isSet) {
				UIToolbar toolbar = new UIToolbar (new RectangleF(0.0f, 0.0f, 10.0f, 44.0f));
				var buttonBarItems = new List<UIBarButtonItem> ();
				for (int i = 1; i < 10; i++) {
					buttonBarItems.Add (new UIBarButtonItem (i.ToString(), UIBarButtonItemStyle.Plain, AddBarButtonText));
				}
				buttonBarItems.Add (new UIBarButtonItem ("0", UIBarButtonItemStyle.Plain, AddBarButtonText));
				toolbar.Items = buttonBarItems.ToArray();
				Control.InputAccessoryView = toolbar;
			} else {
				Control.InputAccessoryView = null;
			}
		}

		public void AddBarButtonText(object sender, EventArgs e)
		{
			var barButtonItem = sender as UIBarButtonItem;
			if (barButtonItem != null)
				Control.Text += barButtonItem.Title;
		}
	}
}

