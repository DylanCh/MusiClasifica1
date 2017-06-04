using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;

using Foundation;
using UIKit;

namespace MusiClasifica1
{
	public partial class ViewController : UIViewController
	{

		readonly string URL = "https://testloopbackvis.mybluemix.net/VisualRec?imageurl=";
		readonly string LYRICS_URL = "http://api.musixmatch.com/ws/1.1/matcher.lyrics.get?q_track=";

		string images;
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			analyzeBtn.TouchUpInside += delegate
			{
				stickerView.Image = null;
				var request = WebRequest.Create(URL + imageurl.Text);
				request.ContentType = "application/json";
				request.Method = "GET";


				// Get response from server/JSON file
				using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
				{
					// Check if Response Status is 200
					if (response.StatusCode != HttpStatusCode.OK)
					{
						// Display Error message
						UIAlertView alert = new UIAlertView()
						{
							Title = "Error",
							Message = response.StatusCode.ToString()
						};
						alert.Show();
					}

					// Keep Stream opened
					using (StreamReader reader = new StreamReader(response.GetResponseStream()))
					{
						// read JSON string
						var content = reader.ReadToEnd();

						// Check if JSON string is undefined or null
						if (string.IsNullOrWhiteSpace(content))
						{
							new UIAlertView()
							{
								Title = "No response or empty response",
								Message = response.StatusCode.ToString()
							}.Show();
						}
						else
						{
							images = new Model(content).Images.Trim();
							StringBuilder sb = new StringBuilder(images.Substring(1, images.Length - 2));
							sb.Replace("\"", "");
							sb.Replace("{", "");
							sb.Replace("}", "");
							sb.Replace("\"", "");
							sb.Replace(",", "");
							string sbToStr = sb.ToString();

							//classificationTxt.Text = sbToStr;

							List<string> labelList = new List<string>();
							if (sbToStr.Contains("Terrorism"))
								labelList.Add("Terrorism");

							if (sbToStr.Contains("Violence"))
								labelList.Add("Violence");

							if (sbToStr.Contains("Porn"))
								labelList.Add("Nudity");

							if (sbToStr.Contains("Drug"))
								labelList.Add("Drug abuse");

							classificationTxt.Text = string.Join("\n", labelList);

							if (sb.ToString().Contains("classifiers\":[]") || labelList.Count == 0)
							{
								labelLbl.Text = "No Parental Advisory Label Needed";
								displayAlbumCover();
							}

							else
							{
								labelLbl.Text = "Parental Advisory Label needed\n" + string.Join(", ", labelList);
								stickerView.Image = UIImage.FromBundle("sticker");
								displayAlbumCover();
							}
						}
					}
				}
			}; // end analyze button

			lyricsAnalyzeBtn.TouchUpInside += delegate
			{
				UIApplication.SharedApplication.OpenUrl(new NSUrl("https://musiclasificaversion2.mybluemix.net/Home/Lyrics"));
			};

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		void displayAlbumCover()
		{
			try
			{
				albumCover.Image = FromUrl(imageurl.Text);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.Print(ex.Message);
			}
		}

		UIImage FromUrl(string uri)
		{
			using (var url = new NSUrl(uri))
			using (var data = NSData.FromUrl(url))
				return UIImage.LoadFromData(data);
		}


	}
}
