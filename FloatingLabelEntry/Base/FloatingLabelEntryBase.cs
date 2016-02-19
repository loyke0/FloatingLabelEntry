using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using FloatingLabelEntry.Enumerations;
using FloatingLabelEntry.ExtendedControls;

namespace FloatingLabelEntry.Base
{		
 	public delegate FloatingLabelEntryState InputValidatorDelegate(string inputValue);

	/// <summary>
	/// Abstract class for FloatingLabelEntry implementation
	/// </summary>
	public abstract class FloatingLabelEntryBase:RoundedCornerView
	{	
		/// <summary>
		/// The EntryText Property
		/// </summary>
		private static readonly String EntryTextPropertyName="EntryText";
		public static readonly BindableProperty EntryTextProperty =
			BindableProperty.Create(EntryTextPropertyName, typeof(string), typeof(FloatingLabelEntryBase), default(string));

		/// <summary>
		/// Get or Set the EntryText
		/// </summary>
		public string EntryText
		{
			get { return (string)GetValue(EntryTextProperty); }
			set { SetValue(EntryTextProperty, value);}
		}

		/// <summary>
		/// The FontSize Property
		/// </summary>
		private static readonly string FontSizePropertyName="FontSize";
		public static readonly BindableProperty FontSizeProperty =
			BindableProperty.Create(FontSizePropertyName, typeof(double), typeof(FloatingLabelEntryBase), Device.GetNamedSize (NamedSize.Medium, typeof(Entry)),propertyChanged: FontSizePropertyChanged);

		/// <summary>
		/// Get or Set the FontSize
		/// </summary>
		public float FontSize
		{
			get { return (float)GetValue(FontSizeProperty); }
			set { SetValue(FontSizeProperty, value);}
		}

		/// <summary>
		/// The TextColor Property
		/// </summary>
		private static readonly string TextColorPropertyName="TextColor";
		public static readonly BindableProperty TextColorProperty =
			BindableProperty.Create(TextColorPropertyName, typeof(Color), typeof(FloatingLabelEntryBase), Color.Black);

		/// <summary>
		/// Get or Set the TextColor
		/// </summary>
		public Color TextColor
		{
			get { return (Color)GetValue(TextColorProperty); }
			set { SetValue(TextColorProperty, value);}
		}

		/// <summary>
		/// The FontName Property
		/// </summary>
		private static readonly string FontNamePropertyName="FontName";
		public static readonly BindableProperty FontNameProperty =
			BindableProperty.Create(FontNamePropertyName, typeof(String), typeof(ExtendedEntry), String.Empty);

		/// <summary>
		/// Get or Set the FontName
		/// </summary>
		public String FontName {
			get{ return (String) GetValue(FontNameProperty) ;}
			set{ SetValue (FontNameProperty, value); }
		}

		/// <summary>
		/// The CustomKeyboard Property
		/// </summary>
		private static  readonly String CustomKeyboardPropertyName ="CustomKeyboard";
		public static readonly BindableProperty CustomKeyboardProperty =
			BindableProperty.Create(CustomKeyboardPropertyName, typeof(CustomKeyboardEnum), typeof(FloatingLabelEntryBase), default(CustomKeyboardEnum));

		/// <summary>
		/// Get or Set the CustomKeyboard
		/// </summary>
		public CustomKeyboardEnum CustomKeyboard {
			get { return (CustomKeyboardEnum)GetValue(CustomKeyboardProperty); }
			set { SetValue(CustomKeyboardProperty, value); }
		}

		/// <summary>
		/// The IsPassword Property
		/// Will show dots instead of Entry text if value is true.
		/// </summary>
		private static  readonly String IsPasswordPropertyName ="IsPassword";
		public static readonly BindableProperty IsPasswordProperty =
			BindableProperty.Create(IsPasswordPropertyName, typeof(bool), typeof(FloatingLabelEntryBase), false);

		/// <summary>
		/// Get or Set the IsPassword
		/// Will show dots instead of Entry text if set to true.
		/// </summary>
		public bool IsPassword
		{
			get { return (bool)GetValue(IsPasswordProperty); }
			set { SetValue(IsPasswordProperty, value);  }
		}
			
		/// <summary>
		/// The LabelText Property
		/// The string value being shown as placeholder/floating label.
		/// </summary>
		private static readonly String LabelTextPropertyName="LabelText";
		public static readonly BindableProperty LabelProperty =
			BindableProperty.Create(LabelTextPropertyName, typeof(string), typeof(FloatingLabelEntryBase), default(string));

		/// <summary>
		/// Get or Set the LabelText
		/// Get or Set the text being shown as placeholder/floating label.
		/// </summary>
		public String LabelText{
			get { return (string)GetValue(LabelProperty); }
			set { SetValue(LabelProperty, value); }
		}

		/// <summary>
		/// The LabelHeight Property
		/// The height in percentage of the floating label height used by the label.
		/// </summary>
		/// <remarks>
		/// Default Value is 0.3f
		/// </remarks>
		private static  readonly String LabelHeightPropertyName ="LabelHeight";
		public static readonly BindableProperty LabelHeightProperty =
			BindableProperty.Create(LabelHeightPropertyName, typeof(float), typeof(FloatingLabelEntryBase), 0.3f);

		/// <summary>
		/// Get or Set the LabelHeight 
		/// Get or Set the height in percentage of the floating label height used by the label.
		/// </summary>
		/// <remarks>
		/// Default Value is 0.3f
		/// </remarks>
		public float LabelSize {
			get { return (float)GetValue (LabelHeightProperty); }
			set { SetValue (LabelHeightProperty, value); }
		}

		/// <summary>
		/// The InfoMessage Property
		/// </summary>
		private static  readonly String InfoMessagePropertyName ="InfoMessage";
		public static readonly BindableProperty InfoMessageProperty =
			BindableProperty.Create(InfoMessagePropertyName, typeof(string), typeof(FloatingLabelEntryBase), default(string));

		/// <summary>
		/// Get or Set the InfoMessage Property
		/// </summary>
		public string InfoMessage {
			get { return (string)GetValue(InfoMessageProperty); }
			set { SetValue(InfoMessageProperty, value);  }
		}

		/// <summary>
		/// The Icon Property
		/// </summary>
		private static  readonly String IconPropertyName ="Icon";
		public static readonly BindableProperty IconProperty =
			BindableProperty.Create(IconPropertyName, typeof(Image), typeof(FloatingLabelEntryBase), null);

		/// <summary>
		/// Get or Set the Icon
		/// </summary>
		public Image Icon {
			get { return (Image)GetValue (IconProperty); }
			set { SetValue (IconProperty, value); }
		}

		/// <summary>
		/// The MustValidate Property
		/// Indicates if a call to the InputValidator delegate must be made
		/// after the the user has finished entering a value.
		/// </summary>
		private static  readonly String MustValidatePropertyName ="MustValidate";
		public static readonly BindableProperty MustValidateProperty =
			BindableProperty.Create(MustValidatePropertyName, typeof(bool), typeof(FloatingLabelEntryBase), false);
		
		/// <summary>
		/// Get or Set MustValidate
		/// </summary>
		public bool MustValidate
		{
			get { return (bool)GetValue(MustValidateProperty); }
			set { SetValue(MustValidateProperty, value);}
		}
			
		/// <summary>
		/// The State Property
		/// Describe state of the field.
		/// Used in combination with input validator, 
		/// it allows to setup displayProperties according to validation result
		/// </summary>
		private static readonly String StatePropertyName="State";
		public static readonly BindableProperty StateProperty =
			BindableProperty.Create (StatePropertyName, typeof(FloatingLabelEntryState), typeof(FloatingLabelEntryBase), FloatingLabelEntryState.Unknown,propertyChanged: StatePropertyChanged);

		/// <summary>
		/// Get or Set State
		/// </summary>
		public FloatingLabelEntryState State {
			get { return (FloatingLabelEntryState)GetValue (StateProperty); }
			set { SetValue (StateProperty, value); }
		}

		/// <summary>
		/// Get or Set InputValidator
		/// Delegate used to validate the Entry text entrered by the user
		/// </summary>
		public InputValidatorDelegate InputValidator { get; set; } 
					
		protected ActivityIndicator _ActivityIndicator { get; set; }
		protected ContentView _DisplayView { get; set; }
		protected Label _Label { get; set;}
		protected Label _InfoMessage { get; set; }
		protected ExtendedEntry _Entry { get; set;}

		private Dictionary<FloatingLabelEntryState, FloatingLabelEntryStateProperties> StatesProperties { get; set;}

		protected FloatingLabelEntryBase ()
		{
			this.InitFloatingLabel ();
		}


		private void InitFloatingLabel(){

			this.StatesProperties = new Dictionary<FloatingLabelEntryState, FloatingLabelEntryStateProperties> ();
			this.Padding = new Thickness (0, 0, 0, 0);
			this.HasShadow = false;

			this._DisplayView=new ContentView();
			this._ActivityIndicator= new ActivityIndicator { IsRunning=false};
			this.Icon = new Image ();

			this._InfoMessage=new Label { 
				Text=this.InfoMessage, 
				VerticalTextAlignment=TextAlignment.End,
				VerticalOptions=LayoutOptions.CenterAndExpand,
				HorizontalTextAlignment=TextAlignment.Center,
				HorizontalOptions=LayoutOptions.FillAndExpand,
				TextColor=this.TextColor,
			};
			_InfoMessage.SetBinding (Label.TextProperty, FloatingLabelEntryBase.InfoMessageProperty.PropertyName);
			_InfoMessage.SetBinding (VisualElement.BackgroundColorProperty, VisualElement.BackgroundColorProperty.PropertyName);
			_InfoMessage.SetBinding (ExtendedLabel.FontNameProperty, FontNamePropertyName);
			_InfoMessage.SetBinding (Label.TextColorProperty, TextColorPropertyName);

			_InfoMessage.BindingContext = this;

			_Label = new Label {
				Text=this.LabelText,
				Opacity=0,
				TextColor=this.TextColor,
			};
			_Label.SetBinding (Label.TextProperty, LabelTextPropertyName);
			_Label.SetBinding (Label.BackgroundColorProperty, FloatingLabelEntryBase.BackgroundColorProperty.PropertyName);
			_Label.SetBinding (ExtendedLabel.FontNameProperty, FontNamePropertyName);
			_Label.SetBinding (ExtendedLabel.TextColorProperty, TextColorPropertyName);

			_Label.BindingContext = this;

			_Entry = new ExtendedEntry () {
				IsPassword=this.IsPassword, 
				Text=this.EntryText,
				FontName=this.FontName,
			} ;
			_Entry.SetBinding (ExtendedEntry.TextProperty, EntryTextPropertyName);
			_Entry.SetBinding (ExtendedEntry.PlaceholderProperty, LabelTextPropertyName);
			_Entry.SetBinding (ExtendedEntry.IsPasswordProperty, IsPasswordPropertyName);
			_Entry.SetBinding (ExtendedEntry.CustomKeyboardProperty, CustomKeyboardPropertyName);
			_Entry.SetBinding (ExtendedEntry.FontNameProperty, FontNamePropertyName);
			_Entry.SetBinding (ExtendedEntry.BackgroundColorProperty, FloatingLabelEntryBase.BackgroundColorProperty.PropertyName);
			_Entry.SetBinding (ExtendedEntry.TextColorProperty, TextColorPropertyName);

			_Entry.BindingContext = this;

			this._Entry.Focused+=((s, e) => {
				this._Label.Opacity=1;
				this._Entry.Placeholder=string.Empty;
			});

			this._Entry.Unfocused+=((s, e) => {
				if (String.IsNullOrWhiteSpace(this._Entry.Text)) {
					this._Label.Opacity=0;
					this._Entry.Text=null;
					this._Entry.Placeholder=this.LabelText;
					reset();
				}
				else {
					if (MustValidate) {
						Device.BeginInvokeOnMainThread(()=>this.SetActivityRunning(true));
						validate(()=> this.SetActivityRunning(false));
					}
				}
			});
			DoLayout ();

		}

		protected void DoLayout(){
			var equalsParentX = Constraint.RelativeToParent ((parent) => parent.X);
			var equalsParentY = Constraint.RelativeToParent ((parent) => parent.Y);
			var equalsParentHeight = Constraint.RelativeToParent ((parent) => parent.Height);
			var displayViewLayout = new RelativeLayout ();
			_DisplayView.WidthRequest = 0;

 			displayViewLayout.Children.Add (this._ActivityIndicator, 
				equalsParentX, 
				equalsParentY,
				Constraint.RelativeToParent ((parent) => parent.Width),
				equalsParentHeight
			);

			displayViewLayout.Children.Add (
				this.Icon, 
				Constraint.RelativeToParent ((parent) => parent.Width > 10 ? parent.X + 5 : parent.X), 
				Constraint.RelativeToParent ((parent) => parent.Height > 10 ? parent.Y + 5 : parent.Y),
				Constraint.RelativeToParent ((parent) => parent.Width > 10 ? parent.Width - 10 : parent.Width),
				Constraint.RelativeToParent ((parent) => parent.Height > 10 ? parent.Height - 10 : parent.Height));
			
			_DisplayView.Content = displayViewLayout;

			var layout = new RelativeLayout ();
			layout.Children.Add (_DisplayView, xConstraint: equalsParentX, yConstraint: equalsParentY, heightConstraint: equalsParentHeight);

			layout.Children.Add (
				_Label, 
				Constraint.RelativeToView (_DisplayView, (parent, view) => view.X + view.Width + 15), 
				Constraint.RelativeToParent ((parent) => parent.Y + this.BorderThickness + 1), 
				heightConstraint: Constraint.RelativeToParent ((parent) => parent.Height * this.LabelSize - BorderThickness - 1)
			);

			layout.Children.Add (
				_InfoMessage, 
				Constraint.RelativeToView(_Label,((Parent,View)=>View.X + View.Width)),
				Constraint.RelativeToParent ((parent) => parent.Y + this.BorderThickness + 1),
				Constraint.RelativeToView(_Label,((Parent,View)=>Parent.Width-(View.X + View.Width))),
				Constraint.RelativeToParent ((parent) => parent.Height * this.LabelSize - this.BorderThickness - 1)
			);

			layout.Children.Add (
				_Entry, 
				Constraint.RelativeToView (_DisplayView, (parent, view) => view.X + view.Width + 15), 
				Constraint.RelativeToParent ((parent) => parent.Y + (parent.Height * this.LabelSize)), 
				Constraint.RelativeToView (_DisplayView, (parent, view) => parent.Width - view.Width - 5), 
				Constraint.RelativeToParent ((parent) => parent.Height * (1 - this.LabelSize))
			);
			this.Content = layout;

		}
			
		public void validate(Action validationDone){
			if (InputValidator!=null) {
				Task.Run (() => {
					var tmpstate = InputValidator (_Entry.Text);
					Device.BeginInvokeOnMainThread (() => {this.State = tmpstate;validationDone();});
				});
			} 
		}


			
		public void AddPropertiesForState(FloatingLabelEntryStateProperties property, FloatingLabelEntryState state){
			RemovePropertyForState (state);
			this.StatesProperties.Add (state, property);
		}

		public void RemovePropertyForState(FloatingLabelEntryState state){
			if (this.StatesProperties.ContainsKey(state)) {
				this.StatesProperties.Remove (state);
			}
		}
			
	 void SetActivityRunning(bool isRunning){
			if (!this._ActivityIndicator.IsRunning && isRunning) {
				this.Icon.Opacity = 0;
				this._ActivityIndicator.Opacity = 1;
				this._ActivityIndicator.IsRunning = true;
				var b = _DisplayView.Bounds;
				b.Width = this.Height;
				Device.BeginInvokeOnMainThread(async () => await _DisplayView.LayoutTo(b,500,Easing.SinOut));
			} else if (this._ActivityIndicator.IsRunning&&!isRunning) {
				this._ActivityIndicator.Opacity = 0;
				this._ActivityIndicator.IsRunning = false;
				this.Icon.Opacity = 1;
				if (this.Icon.Source==null) {
					var b = _DisplayView.Bounds;
					b.Width = 0;
					Device.BeginInvokeOnMainThread(async () => await _DisplayView.LayoutTo(b,500,Easing.SinOut));
				} 
			}
		}

		public void reset(){
			if (StatesProperties.ContainsKey(FloatingLabelEntryState.Neutral)){
				this.State=FloatingLabelEntryState.Neutral;
			}
		}

		private static void StatePropertyChanged(BindableObject bindableobject, Object oldValue, Object newValue){
			FloatingLabelEntryStateProperties stateProperties = null;
			var fl = bindableobject as FloatingLabelEntryBase;
			if (fl.StatesProperties.TryGetValue((FloatingLabelEntryState)newValue,out stateProperties)) {
				fl.InfoMessage=stateProperties.InfoMessage;
				fl.Icon.Source = stateProperties.IconSource;
				if (stateProperties.IconSource != null) {
					fl._DisplayView.WidthRequest = fl.Height;
					fl.Icon.Opacity = 1;
				} else {
					fl.Icon.Opacity = 0;
					fl._DisplayView.WidthRequest = 0;
				}
				if (stateProperties.BackgroundColor!=fl.BackgroundColor) {
					fl.BackgroundColor=stateProperties.BackgroundColor;
				}
				if (stateProperties.BorderColor!=fl.BorderColor) {
					fl.BorderColor=stateProperties.BorderColor;
				}
				if (stateProperties.BorderThickness!=fl.BorderThickness) {
					fl.BorderThickness=stateProperties.BorderThickness;
				}
			}
		}

		private static void FontSizePropertyChanged(BindableObject bindableobject, Object oldValue, Object newValue){
			var newFontSize = Convert.ToDouble (newValue);
			var fl = bindableobject as FloatingLabelEntryBase;
			var SizeDivider= (1-fl.LabelSize)/fl.LabelSize;
			fl._Entry.FontSize = newFontSize;
			fl._InfoMessage.FontSize =  newFontSize / SizeDivider;
			fl._Label.FontSize =  newFontSize / SizeDivider;
		}
	}
}

