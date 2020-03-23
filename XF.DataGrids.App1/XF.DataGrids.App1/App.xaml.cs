using demo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microshaoft;

namespace XF.DataGrids.App1
{
	public partial class App : Application
	{
		Dictionary<string, ContentPage> pages = new Dictionary<string, ContentPage>();
		public App()
		{
			InitializeComponent();

			var dg = new DataGrid
			{
				  VerticalOptions = LayoutOptions.FillAndExpand
				, HorizontalOptions = LayoutOptions.FillAndExpand
				, BackgroundColor = Color.White
				, RowHeight = 50
				, RowSpacing = 1
				, ColumnSpacing = 1
				, HeaderHeight = 200
			};

			dg.Columns = new ObservableCollection<Column>
			{
				new Column
				{
					Width = 100
					, HeaderView = new Label
					{
						Text = "English"
						, BackgroundColor = Color.Green
						, HorizontalTextAlignment = TextAlignment.Center
						, VerticalTextAlignment = TextAlignment.Center
					
					}
					
					, Template = new DataTemplate
					(
						() =>
						{
							var v = new Label
							{ 
								  BackgroundColor = Color.Green
								, TextColor = Color.Black
								, HorizontalTextAlignment = TextAlignment.Center
								, VerticalTextAlignment = TextAlignment.Center
								,
							};
							v.SetBinding(Label.TextProperty, "English");
							return v;
						}
					),
				},
				new Column {
					Width = 100,
					HeaderView = new Label {
						Text = "Spanish",
						BackgroundColor = Color.Green,
						HorizontalTextAlignment = TextAlignment.Center,
						VerticalTextAlignment = TextAlignment.Center,
					},
					Template = new DataTemplate (() => {
						var v = new Label {
							TextColor = Color.Black,
							BackgroundColor = Color.Green,
							HorizontalTextAlignment = TextAlignment.Center,
							VerticalTextAlignment = TextAlignment.Center,
						};
						v.SetBinding(Label.TextProperty, "Spanish");
						//v.SetBinding(Label.BackgroundColorProperty, "SpanishBackgroundColor");
						return v;
					}),
				}
				//,
				//new Column
				//{
				//	Width = 100,
				//	Template = new DataTemplate (() => {
				//		var v = new Image();
				//		v.SetBinding(Image.SourceProperty, "ImageName");
				//		return v;
				//	}),
				//}
				,
				new Column {
					Width = 200,
					HeaderView = new Label {
						Text = "Button",
						BackgroundColor = Color.Green,
						HorizontalTextAlignment = TextAlignment.Center,
						VerticalTextAlignment = TextAlignment.Center,
					},
					Template = new DataTemplate (() => {
						var v = new myButton {
							BackgroundColor = Color.Green,
							TextColor = Color.White,
							Font = Font.SystemFontOfSize(18, FontAttributes.Bold),
						};
						v.SetBinding(myButton.TextProperty, "ButtonText");
						v.SetBinding(myButton.OneActionProperty, "Action");
						return v;
					}),
				},
				new Column {
					Width = 100,
					HeaderView = new Label {
						Text = "X",
						BackgroundColor = Color.Gray,
						HorizontalTextAlignment = TextAlignment.Center,
						VerticalTextAlignment = TextAlignment.Center,
					},
					Template = new DataTemplate (() => {
						
						var v = new Entry();
						v.BackgroundColor = Color.Green;
						v.SetBinding(Entry.TextProperty, "X");
						return v;
					}),
				},
				new Column {
					Width = 100,
					HeaderView = new Label {
						Text = "X*2",
						BackgroundColor = Color.Gray,
						HorizontalTextAlignment = TextAlignment.Center,
						VerticalTextAlignment = TextAlignment.Center,
					},
					Template = new DataTemplate (() => {
						var v = new Label {
							BackgroundColor = Color.Green,
							TextColor = Color.Black,
							HorizontalTextAlignment = TextAlignment.Center,
							VerticalTextAlignment = TextAlignment.Center,
						};
						v.SetBinding(Label.TextProperty, "DoubleX");
						return v;
					}),
				},
			};

			dg.FrozenColumn = new Column
			{
				Width = 80,
				HeaderView = new Label
				{
					Text = "Corner",
					BackgroundColor = Color.Yellow,
					//HeightRequest = dg.RowHeight - dg.RowSpacing - dg.RowSpacing
				},
				Template = new DataTemplate(() => {
					var v = new Label
					{
						BackgroundColor = Color.Green,
						TextColor = Color.Black,
						HorizontalTextAlignment = TextAlignment.Center,
						VerticalTextAlignment = TextAlignment.Center,
					};
					v.SetBinding(Label.TextProperty, "Spanish");
					return v;
				}),
			};

			dg.HeaderHeight = 50;
			//dg.SelectionMode = SelMode.Row;

			dg.Rows = TestData.createLotsOfWordPairsWithButtons(dg);


			//MainPage = new MainPage();
			//return;


			//MainPage = new ContentPage
			//{
			//	Content = dg
			//};
			//dg = null;

			pages["Test Frozen Column, Button Column, Entry Column"] = new ContentPage
			{
				Content = dg
			};
			dg = null;

			//return;

			pages["Test Xaml"] = new MainPage();

			pages["No Columns, No Rows"] = new ContentPage
			{
				Content = new Microshaoft.DataGrid
				{
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,

					BackgroundColor = Color.Black,

					RowHeight = 50,
					RowSpacing = 2,
					ColumnSpacing = 2,
					HeaderHeight = 50,
				}
			};

			pages["No Columns, Four Rows"] = new ContentPage
			{
				Content = new Microshaoft.DataGrid
				{
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,

					BackgroundColor = Color.Black,

					RowHeight = 50,
					RowSpacing = 2,
					ColumnSpacing = 2,
					HeaderHeight = 50,

					Rows = TestData.createFourSimpleWordPairs(),
				}
			};

			pages["Two Columns, Four Rows"] = new ContentPage
			{
				Content = new Microshaoft.DataGrid
				{
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,

					BackgroundColor = Color.Black,

					RowHeight = 50,
					RowSpacing = 2,
					ColumnSpacing = 2,
					HeaderHeight = 50,

					Columns = TestData.createTwoSimpleColumns(),
					Rows = TestData.createFourSimpleWordPairs(),
				}
			};

			pages["Two Columns, No Rows"] = new ContentPage
			{
				Content = new Microshaoft.DataGrid
				{
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,

					BackgroundColor = Color.Black,

					RowHeight = 50,
					RowSpacing = 2,
					ColumnSpacing = 2,
					HeaderHeight = 50,

					Columns = TestData.createTwoSimpleColumns(),
				}
			};

			pages["XSquared"] =
			new ContentPage
			{
				Content = new Microshaoft.DataGrid
				{
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,

					BackgroundColor = Color.Black,

					RowHeight = 50,
					RowSpacing = 2,
					ColumnSpacing = 2,
					HeaderHeight = 50,

					Columns = new ObservableCollection<Column> {
						new Column {
							Width = 80,
							HeaderView = new Label {
								Text = "X",
								BackgroundColor = Color.Gray,
								HorizontalTextAlignment = TextAlignment.Center,
								VerticalTextAlignment = TextAlignment.Center,
							},
							Template = new DataTemplate (() => {
								var v = new Label {
									BackgroundColor = Color.White,
									TextColor = Color.Black,
									HorizontalTextAlignment = TextAlignment.Center,
									VerticalTextAlignment = TextAlignment.Center,
								};
								v.SetBinding (Label.TextProperty, "X");
								return v;
							}),
						},
						new Column {
							Width = 80,
							HeaderView = new Label {
								Text = "X^2",
								BackgroundColor = Color.Gray,
								HorizontalTextAlignment = TextAlignment.Center,
								VerticalTextAlignment = TextAlignment.Center,
							},
							Template = new DataTemplate (() => {
								var v = new Label {
									BackgroundColor = Color.White,
									TextColor = Color.Black,
									HorizontalTextAlignment = TextAlignment.Center,
									VerticalTextAlignment = TextAlignment.Center,
								};
								v.SetBinding (Label.TextProperty, "XSquared");
								return v;
							}),
						},
						new Column {
							Width = 120,
							HeaderView = new Label {
								Text = "Slider",
								BackgroundColor = Color.Gray,
								HorizontalTextAlignment = TextAlignment.Center,
								VerticalTextAlignment = TextAlignment.Center,
							},
							Template = new DataTemplate (() => {
								var v = new Slider {
									BackgroundColor = Color.White,
									Minimum = -20,
									Maximum = 20,
								};
								v.SetBinding (Slider.ValueProperty, "X", BindingMode.TwoWay);
								return v;
							}),
						},
					},

					Rows = new ObservableCollection<object> {
						new myRow {X = 1},
						new myRow {X = 2},
						new myRow {X = 3},
						new myRow {X = 4},
						new myRow {X = 5},
						new myRow {X = 6},
						new myRow {X = 7},
					},
				}
			};

			pages["Million"] =
				new ContentPage
				{
					Content = new DataGrid
					{
						VerticalOptions = LayoutOptions.FillAndExpand,
						HorizontalOptions = LayoutOptions.FillAndExpand,

						BackgroundColor = Color.Black,

						RowHeight = 40,
						RowSpacing = 2,
						ColumnSpacing = 2,
						HeaderHeight = 40,

						SelectionMode = SelectionModeEnum.Row,

						Columns = new ObservableCollection<Column> {
						new Column {
							Width = 120,
							HeaderView = new Label {
								Text = "X",
								BackgroundColor = Color.Gray,
								HorizontalTextAlignment = TextAlignment.Center,
								VerticalTextAlignment = TextAlignment.Center,
							},
							Template = new DataTemplate (() => {
								var v = new Label {
									BackgroundColor = Color.White,
									TextColor = Color.Black,
									HorizontalTextAlignment = TextAlignment.End,
									VerticalTextAlignment = TextAlignment.Center,
								};
								v.SetBinding (Label.TextProperty, "X");
								return v;
							}),
						},
						new Column {
							Width = 120,
							HeaderView = new Label {
								Text = "Sqrt(X)",
								BackgroundColor = Color.Gray,
								HorizontalTextAlignment = TextAlignment.Center,
								VerticalTextAlignment = TextAlignment.Center,
							},
							Template = new DataTemplate (() => {
								var v = new Label {
									BackgroundColor = Color.White,
									TextColor = Color.Black,
									HorizontalTextAlignment = TextAlignment.End,
									VerticalTextAlignment = TextAlignment.Center,
								};
								v.SetBinding (Label.TextProperty, "Sqrt");
								return v;
							}),
						},
					},

						Rows = new DataList(1000000),
					}
				};

			var lst = new ListView();
			lst.ItemsSource = pages.Keys;

			var mainPage = new ContentPage
			{
				Content = lst
			};

			var nav = new NavigationPage(mainPage);

			lst.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
				nav.PushAsync(pages[e.SelectedItem.ToString()]);
			};

			MainPage = nav;
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
