using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

namespace MauiApp10;

public class MyItem
{
	public string Title { get; set; } = "Test";
}

public partial class MainPage : ContentPage
{
	//[DllImport("NativeTap.dll")]
	//private static extern int Bootstrap();

	//private ManagedTap managedTap;
	MethodInfo getBoundingBox;
	MethodInfo getViewTransform;

	public MainPage()
	{
		//internal static System.Numerics.Matrix4x4 GetViewTransform(this IView view) => new System.Numerics.Matrix4x4();
		//internal static Graphics.Rectangle GetBoundingBox(this IView view) => view.Frame;
		Type type = typeof(Microsoft.Maui.Platform.ViewExtensions);
		BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic;
		this.getBoundingBox = type.GetMethod("GetBoundingBox", flags, new Type[] { typeof(IView) });
		this.getViewTransform = type.GetMethod("GetViewTransform", flags, new Type[] { typeof(IView) });

		InitializeComponent();
		//OnLoadTapClicked(null, EventArgs.Empty);

	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		Microsoft.Maui.Dispatching.IDispatcherTimer timer = this.HelloLabel.Dispatcher.CreateTimer();
		timer.Interval = TimeSpan.FromMilliseconds(500);
		Stopwatch watch = new Stopwatch();
        timer.Tick += OnDispatcherTimer;
		timer.Stop();
		//timer.IsRepeating = true;


		watch.Start();
		timer.Start();
		
		void OnDispatcherTimer(object sender, EventArgs e)
		{
			timer.Stop();
			watch.Stop();

			//timer.Tick -= OnDispatcherTimer;
			this.HelloLabel.Text = $"Timer interval is {timer.Interval.TotalMilliseconds}ms. It ticked after {Math.Round(watch.Elapsed.TotalMilliseconds, 3)}ms";

			watch.Reset();
			watch.Start();
			timer.Start();
		}
	}


    public static IWindow GetVisualElementWindow(IVisualTreeElement element)
	{
		if (element is IWindow window)
			return window;

		var parent = element.GetVisualParent();
		if (parent != null)
			return GetVisualElementWindow(parent);

		return null;
	}

	string FormatRect(Rect r)
	{
		return $"{Math.Round(r.X, 1)},{Math.Round(r.Y, 1)}; size={Math.Round(r.Width, 1)}x{Math.Round(r.Height, 1)}";
	}

	Matrix4x4 GetTransfromToParent(IView view)
	{
		Matrix4x4 tr = (Matrix4x4)this.getViewTransform.Invoke(null, new object[] { view });
		return tr;
	}

	Matrix4x4 GetTransfromToAncestor(IView view, IView ancestor)
	{
		Matrix4x4 result = this.GetTransfromToParent(view);
		IView parent = this.GetParent(view);
		while (parent != null && parent != ancestor)
		{
			Matrix4x4 m = this.GetTransfromToParent(parent);
			result *= m;
			parent = this.GetParent(parent);
		}

		return result;
	}

	private IView GetParent(IView view)
	{
		IVisualTreeElement parent = null;
		if (view is IVisualTreeElement treeView)
        {
			parent = treeView.GetVisualParent();
        }
			
		return parent as IView;
	}

	private void OnLoadTapClicked(object sender, EventArgs e)
	{
		try
		{
			//Bootstrap();

			//this.managedTap ??= new ManagedTap();
			//TapInteropHelper.NativeTap?.SetManagedTap(this.managedTap);
		} catch { }
	}

	private void OnTestTapClicked(object sender, EventArgs e)
	{
		//object target = this.HelloLabel;
		//TapInteropHelper.NativeTap?.HighlightElement_IUnknown(target, false);

		//target = this.HelloLabel.Handler.PlatformView;
		//TapInteropHelper.NativeTap?.HighlightElement_IUnknown(target, false);

		//TapInteropHelper.NativeTap?.HighlightElement_IInspectable(target, true);
		//target = null;
	}
}

