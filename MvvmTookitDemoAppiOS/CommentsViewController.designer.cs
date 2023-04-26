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
	[Register ("CommentsViewController")]
	partial class CommentsViewController
	{
		[Outlet]
		UIKit.UILabel bodyLabel { get; set; }

		[Outlet]
		UIKit.UIStackView dataStackView { get; set; }

		[Outlet]
		UIKit.UILabel emailLabel { get; set; }

		[Outlet]
		UIKit.UILabel idLabel { get; set; }

		[Outlet]
		UIKit.UILabel nameLabel { get; set; }

		[Outlet]
		UIKit.UIButton requestButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (requestButton != null) {
				requestButton.Dispose ();
				requestButton = null;
			}

			if (dataStackView != null) {
				dataStackView.Dispose ();
				dataStackView = null;
			}

			if (idLabel != null) {
				idLabel.Dispose ();
				idLabel = null;
			}

			if (nameLabel != null) {
				nameLabel.Dispose ();
				nameLabel = null;
			}

			if (emailLabel != null) {
				emailLabel.Dispose ();
				emailLabel = null;
			}

			if (bodyLabel != null) {
				bodyLabel.Dispose ();
				bodyLabel = null;
			}
		}
	}
}
