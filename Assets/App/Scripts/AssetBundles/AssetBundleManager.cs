﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

static public class AssetBundleManager {

	static public WWW request = null;
	
	// A dictionary to hold the AssetBundle references
	static private Dictionary<string, AssetBundleRef> dictAssetBundleRefs;

	static AssetBundleManager () {
		dictAssetBundleRefs = new Dictionary<string, AssetBundleRef>();
	}

	// Class with the AssetBundle reference, url and version
	private class AssetBundleRef {
		public AssetBundle assetBundle = null;
		public int version;
		public string url;
		public AssetBundleRef(string strUrlIn, int intVersionIn) {
			url = strUrlIn;
			version = intVersionIn;
		}
	};

	// Get an AssetBundle
	public static AssetBundle getAssetBundle (string url, int version){
		string keyName = url + version.ToString();
		AssetBundleRef abRef;
		if (dictAssetBundleRefs.TryGetValue(keyName, out abRef))
			return abRef.assetBundle;
		else
			return null;
	}

	// Download an AssetBundle
	public static IEnumerator downloadAssetBundle (string url, int version){
		string keyName = url + version.ToString();
		if (dictAssetBundleRefs.ContainsKey(keyName))
			yield return null;
		else {
			using(WWW www = WWW.LoadFromCacheOrDownload (url, version)){
				request = www;
				yield return www;
				if (www.error != null)
					throw new Exception("WWW download:" + www.error);
				AssetBundleRef abRef = new AssetBundleRef (url, version);
				abRef.assetBundle = www.assetBundle;
				dictAssetBundleRefs.Add (keyName, abRef);
				www.Dispose ();
				request = null;
			}
		}
	}

	// Unload an AssetBundle
	public static void Unload (string url, int version, bool allObjects){
		string keyName = url + version.ToString();
		AssetBundleRef abRef;
		if (dictAssetBundleRefs.TryGetValue(keyName, out abRef)){
			abRef.assetBundle.Unload (allObjects);
			abRef.assetBundle = null;
			dictAssetBundleRefs.Remove(keyName);
			Debug.Log ("UNLOADED");
		}
	}

	public static void UnloadAllAssets() {
		List<string> keys = new List<string> (dictAssetBundleRefs.Keys);
		foreach (string keyName in keys) {
			AssetBundleRef abRef;
			if (dictAssetBundleRefs.TryGetValue(keyName, out abRef)){
				abRef.assetBundle.Unload (true);
				abRef.assetBundle = null;
				dictAssetBundleRefs.Remove(keyName);
				Debug.Log ("UNLOADED");
			}
		}
	}
}