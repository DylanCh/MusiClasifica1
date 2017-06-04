// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MusiClasifica1
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIImageView albumCover { get; set; }

		[Outlet]
		UIKit.UIButton analyzeBtn { get; set; }

		[Outlet]
		UIKit.UITextView classificationTxt { get; set; }

		[Outlet]
		UIKit.UITextField imageurl { get; set; }

		[Outlet]
		UIKit.UITextView labelLbl { get; set; }

		[Outlet]
		UIKit.UIButton lyricsAnalyzeBtn { get; set; }

		[Outlet]
		UIKit.UIImageView stickerView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lyricsAnalyzeBtn != null) {
				lyricsAnalyzeBtn.Dispose ();
				lyricsAnalyzeBtn = null;
			}

			if (albumCover != null) {
				albumCover.Dispose ();
				albumCover = null;
			}

			if (analyzeBtn != null) {
				analyzeBtn.Dispose ();
				analyzeBtn = null;
			}

			if (classificationTxt != null) {
				classificationTxt.Dispose ();
				classificationTxt = null;
			}

			if (imageurl != null) {
				imageurl.Dispose ();
				imageurl = null;
			}

			if (labelLbl != null) {
				labelLbl.Dispose ();
				labelLbl = null;
			}

			if (stickerView != null) {
				stickerView.Dispose ();
				stickerView = null;
			}
		}
	}
}
