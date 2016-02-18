using System;
using Xamarin.Forms;

namespace FloatingLabelEntry.ExtendedControls
{
	public class RoundedCornerView:Frame
	{
		/// <summary>
		/// The BorderColor Property
		/// </summary>
		private static  readonly String BorderColorPropertyName ="BorderColor";
		public static readonly BindableProperty BorderColorProperty =
			BindableProperty.Create(BorderColorPropertyName, typeof(Color), typeof(RoundedCornerView), Color.Black);

		/// <summary>
		/// Get or Set the BorderColor
		/// </summary>
		public Color BorderColor {
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value);  }
		}

		/// <summary>
		/// The BorderThickness Property
		/// </summary>
		private static  readonly String BorderThicknessPropertyName ="BorderThickness";
		public static readonly BindableProperty BorderThicknessProperty =
			BindableProperty.Create(BorderThicknessPropertyName, typeof(float), typeof(RoundedCornerView), 1f);

		/// <summary>
		/// Get or Set the BorderThickness
		/// </summary>
		public float BorderThickness {
			get { return (float)GetValue(BorderThicknessProperty); }
			set { SetValue(BorderThicknessProperty, value);  }
		}

		/// <summary>
		/// The CornerRadius Property
		/// </summary>
		private static  readonly string CornerRadiusPropertyName ="BorderThickness";
		public static readonly BindableProperty CornerRadiusProperty =
			BindableProperty.Create(CornerRadiusPropertyName, typeof(float), typeof(RoundedCornerView), 1f);

		/// <summary>
		/// Get or Set the CornerRadius
		/// </summary>
		public float CornerRadius {
			get { return (float)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value);  }
		}

		public RoundedCornerView ():base()
		{
			HasShadow = false;
		}
	}
}

