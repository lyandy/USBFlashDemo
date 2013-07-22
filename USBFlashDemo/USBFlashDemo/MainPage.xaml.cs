using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Devices.Enumeration;
using Windows.Devices.Portable;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace USBFlashDemo {
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page {
		public MainPage() {
			this.InitializeComponent();
		}

		/// <summary>
		/// Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">Event data that describes how this page was reached.  The Parameter
		/// property is typically used to configure the page.</param>
		async protected override void OnNavigatedTo(NavigationEventArgs e) {
			var devs = await DeviceInformation.FindAllAsync(DeviceClass.PortableStorageDevice);
			foreach (var each in devs) {
				var removableStorage = StorageDevice.FromId(each.Id);

				if (removableStorage != null) {
					GetFile(removableStorage);
				}
			}
		}

		async private void GetFile(StorageFolder removableStorage) {
			var files = await removableStorage.GetFilesAsync();
			foreach (var item in files) {
				data.Add(item.DisplayName);
			}
		}

		private List<string> data = new List<string>();
	}
}
