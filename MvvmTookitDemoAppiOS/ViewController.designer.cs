// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MvvmTookitDemoAppiOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIStackView dataStackView { get; set; }

		[Outlet]
		UIKit.UILabel emailLabel { get; set; }

		[Outlet]
		UIKit.UIButton fetchDataButton { get; set; }

		[Outlet]
		UIKit.UILabel idLabel { get; set; }

		[Outlet]
		UIKit.UILabel nameLabel { get; set; }

		[Outlet]
		UIKit.UIActivityIndicatorView progressActivityIndicator { get; set; }

		[Outlet]
		UIKit.UIButton updateButton { get; set; }

		[Outlet]
		UIKit.UILabel usernameLabel { get; set; }

		[Outlet]
		UIKit.UILabel usersCountLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (fetchDataButton != null) {
				fetchDataButton.Dispose ();
				fetchDataButton = null;
			}

			if (progressActivityIndicator != null) {
				progressActivityIndicator.Dispose ();
				progressActivityIndicator = null;
			}

			if (usersCountLabel != null) {
				usersCountLabel.Dispose ();
				usersCountLabel = null;
			}

			if (dataStackView != null) {
				dataStackView.Dispose ();
				dataStackView = null;
			}

			if (nameLabel != null) {
				nameLabel.Dispose ();
				nameLabel = null;
			}

			if (usernameLabel != null) {
				usernameLabel.Dispose ();
				usernameLabel = null;
			}

			if (emailLabel != null) {
				emailLabel.Dispose ();
				emailLabel = null;
			}

			if (idLabel != null) {
				idLabel.Dispose ();
				idLabel = null;
			}

			if (updateButton != null) {
				updateButton.Dispose ();
				updateButton = null;
			}
		}
	}
}
