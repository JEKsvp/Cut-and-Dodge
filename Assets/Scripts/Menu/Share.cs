using UnityEngine;
using System.Collections;

public class Share : MonoBehaviour
{
		public string title;
		public string content;
		static AndroidJavaClass sharePluginClass;
		static AndroidJavaClass unityPlayer;
		static AndroidJavaObject currActivity;

		void Start ()
		{
				sharePluginClass = new AndroidJavaClass ("com.ari.tool.UnityAndroidTool");
				if (sharePluginClass == null) {
						Debug.Log ("sharePluginClass is null");
				} else {
						Debug.Log ("sharePluginClass is not null");
				}
				unityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
				currActivity = unityPlayer.GetStatic<AndroidJavaObject> ("currentActivity");
		}

	void OnMouseUp() {
		content = "My record in Cut and Dodge " + System.Math.Round(SPlayerPrefs.GetFloat("Score")) + ".\n Try to beat my score\n https://play.google.com/store/apps/details?id=com.abadek.cutanddodge";
		CallShare(title, "", content);
	}
		public static void CallShare (string handline, string subject, string text)
		{

				Debug.Log ("share call start");
				sharePluginClass.CallStatic ("share", new object[] {
						handline,
						subject,
						text
				});
				Debug.Log ("share call end");
		}
}
