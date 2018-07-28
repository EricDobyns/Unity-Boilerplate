using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsManager : MonoBehaviour {

	private string base_url = "";

	void Awake () {
		DontDestroyOnLoad(this);
		Invoke ("detectPlatform", 0);
	}

	void detectPlatform() {
		if (Application.platform == RuntimePlatform.Android) {
			base_url += "Android/";
		} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
			base_url += "iOS/";
		} else {
			base_url += "iOS/"; // Is Unity Editor
		}
	}

	void OnDestroy() {
		AssetBundleManager.UnloadAllAssets ();
		Caching.ClearCache ();
	}


	public void loadSceneButtonPressed(int levelIndex) {
		AssetBundle bundle = AssetBundleManager.getAssetBundle (base_url + levelIndex, 1);
		if (!bundle) {
			StartCoroutine (LoadScene (bundle, base_url + levelIndex));	
		} else {
			string[] scenes = bundle.GetAllScenePaths ();
		}
	}

	IEnumerator LoadScene (AssetBundle bundle, string url) {
		yield return StartCoroutine(AssetBundleManager.downloadAssetBundle (url, 1));
		bundle = AssetBundleManager.getAssetBundle (url, 1);
		string[] scenes = bundle.GetAllScenePaths ();
	}
}
