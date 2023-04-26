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
	[Register ("TodosViewController")]
	partial class TodosViewController
	{
		[Outlet]
		UIKit.UILabel completedLabel { get; set; }

		[Outlet]
		UIKit.UISwitch completedSwitch { get; set; }

		[Outlet]
		UIKit.UIStackView dataStackView { get; set; }

		[Outlet]
		UIKit.UIButton goToCommentsButton { get; set; }

		[Outlet]
		UIKit.UILabel idLabel { get; set; }

		[Outlet]
		UIKit.UILabel titleLabel { get; set; }

		[Outlet]
		UIKit.UIButton updateButton { get; set; }

		[Outlet]
		UIKit.UILabel userIdLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (completedLabel != null) {
				completedLabel.Dispose ();
				completedLabel = null;
			}

			if (completedSwitch != null) {
				completedSwitch.Dispose ();
				completedSwitch = null;
			}

			if (dataStackView != null) {
				dataStackView.Dispose ();
				dataStackView = null;
			}

			if (idLabel != null) {
				idLabel.Dispose ();
				idLabel = null;
			}

			if (titleLabel != null) {
				titleLabel.Dispose ();
				titleLabel = null;
			}

			if (updateButton != null) {
				updateButton.Dispose ();
				updateButton = null;
			}

			if (userIdLabel != null) {
				userIdLabel.Dispose ();
				userIdLabel = null;
			}

			if (goToCommentsButton != null) {
				goToCommentsButton.Dispose ();
				goToCommentsButton = null;
			}
		}
	}
}
