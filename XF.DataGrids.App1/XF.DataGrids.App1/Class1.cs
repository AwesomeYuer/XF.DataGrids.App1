/*
   Copyright 2014-2015 Zumero, LLC

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
namespace demo
{

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.ComponentModel;
	using Zumero;
	using Xamarin.Forms;
	public class myList : IList<object>
	{
		private class myRow
		{
			private readonly double v;

			public double X { get { return v; } }
			public double Sqrt { get { return Math.Round(Math.Sqrt(v), 3); } }

			public myRow(double _v) { v = _v; }
		}

		private readonly int count;

		public myList(int _count)
		{
			count = _count;
		}

		public object this[int index]
		{
			get { return new myRow(index); }
			set { throw new NotImplementedException(); }
		}

		public int Count
		{
			get { return count; }
		}

		public bool IsReadOnly
		{
			get { return true; }
		}

		public void Add(object item) { throw new NotImplementedException(); }
		public void Clear() { throw new NotImplementedException(); }
		public void Insert(int index, object item) { throw new NotImplementedException(); }
		public void RemoveAt(int index) { throw new NotImplementedException(); }
		public bool Remove(object item) { throw new NotImplementedException(); }

		public int IndexOf(object item) { throw new NotImplementedException(); }
		public bool Contains(object item) { throw new NotImplementedException(); }
		public void CopyTo(object[] array, int arrayIndex) { throw new NotImplementedException(); }

		private class myEnumerator : IEnumerator<object>
		{
			private int count;
			private int curIndex;

			public myEnumerator(int _count)
			{
				count = _count;
				curIndex = -1;
			}

			public bool MoveNext()
			{
				if (++curIndex >= count)
				{
					return false;
				}
				else
				{
				}
				return true;
			}

			public void Reset() { curIndex = -1; }

			void IDisposable.Dispose() { }

			public object Current
			{
				get { return new myRow(curIndex); }
			}


			object IEnumerator.Current
			{
				get { return Current; }
			}

		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public IEnumerator<object> GetEnumerator()
		{
			return new myEnumerator(count);
		}

	}

	public class myButton : Button
	{
		public myButton()
		{
			this.Clicked += (object sender, EventArgs e) => {
				Action a = OneAction;
				if (a != null)
				{
					a();
				}
			};
		}

		public static readonly BindableProperty OneActionProperty =
			BindableProperty.Create<myButton, Action>(
				p => p.OneAction, null);

		public Action OneAction
		{
			get { return (Action)GetValue(OneActionProperty); }
			set { SetValue(OneActionProperty, value); }
		}
	}

	public class ColumnHeader : BindableObject
	{
		public static readonly BindableProperty TitleProperty =
			BindableProperty.Create<ColumnHeader, string>(
				p => p.Title, null);

		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}
	}

	public class myRow : INotifyPropertyChanged
	{
		private double x = 0.0;
		public event PropertyChangedEventHandler PropertyChanged;

		public double XSquared
		{
			get { return x * x; }
		}

		public double X
		{
			get { return x; }
			set
			{
				if (x != value)
				{
					x = value;
					if (PropertyChanged != null)
					{
						PropertyChanged(this, new PropertyChangedEventArgs("X"));
						PropertyChanged(this, new PropertyChangedEventArgs("XSquared"));
					}
				}
			}
		}
	}

	public class WordPair : BindableObject
	{
		public static readonly BindableProperty EnglishProperty =
			BindableProperty.Create<WordPair, string>(
				p => p.English, null);

		public string English
		{
			get { return (string)GetValue(EnglishProperty); }
			set { SetValue(EnglishProperty, value); }
		}

		public static readonly BindableProperty SpanishProperty =
			BindableProperty.Create<WordPair, string>(
				p => p.Spanish, null);

		public string Spanish
		{
			get { return (string)GetValue(SpanishProperty); }
			set { SetValue(SpanishProperty, value); }
		}

		public static readonly BindableProperty SpanishBackgroundColorProperty =
			BindableProperty.Create<WordPair, Color>(
				p => p.SpanishBackgroundColor, Color.White);

		public Color SpanishBackgroundColor
		{
			get { return (Color)GetValue(SpanishBackgroundColorProperty); }
			set { SetValue(SpanishBackgroundColorProperty, value); }
		}

		public static readonly BindableProperty ButtonTextProperty =
			BindableProperty.Create<WordPair, string>(
				p => p.ButtonText, null);

		public string ButtonText
		{
			get { return (string)GetValue(ButtonTextProperty); }
			set { SetValue(ButtonTextProperty, value); }
		}

		public static readonly BindableProperty ActionProperty =
			BindableProperty.Create<WordPair, Action>(
				p => p.Action, null);

		public Action Action
		{
			get { return (Action)GetValue(ActionProperty); }
			set { SetValue(ActionProperty, value); }
		}

		public static readonly BindableProperty ImageNameProperty =
			BindableProperty.Create<WordPair, string>(
				p => p.ImageName, null);

		public string ImageName
		{
			get { return (string)GetValue(ImageNameProperty); }
			set { SetValue(ImageNameProperty, value); }
		}

		public static readonly BindableProperty XProperty =
			BindableProperty.Create<WordPair, int>(
				p => p.X, 0);

		public int X
		{
			get { return (int)GetValue(XProperty); }
			set { SetValue(XProperty, value); }
		}

		public int DoubleX
		{
			get
			{
				return X * 2;
			}
		}

		public WordPair()
		{
			this.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => {
				if (e.PropertyName == XProperty.PropertyName)
				{
					this.OnPropertyChanged("DoubleX");
				}
			};
		}
	}


}

