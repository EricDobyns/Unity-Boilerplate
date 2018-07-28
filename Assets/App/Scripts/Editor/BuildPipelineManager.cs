using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class BuildPipelineManager {

	/*
	*   Build 
	*/
	[MenuItem ("Build/Build/iOS/Asset Bundles", false, 1)]
	static void Build_iOS_AssetBundles() {
		BuildAssetBundles ("ExportedAssetBundles/iOS", BuildTarget.iOS, () => {});	
	}

	[MenuItem ("Build/Build/iOS/Game", false, 2)]
	static void Build_iOS_Game() {
		BuildPlayer ("ExportedBuilds/iOS", BuildTarget.iOS, () => {});
	}

	[MenuItem ("Build/Build/Android/Asset Bundles", false, 1)]
	static void Build_Android_AssetBundles() {
		BuildAssetBundles ("ExportedAssetBundles/Android", BuildTarget.Android, () => {});	
	}

	[MenuItem ("Build/Build/Android/Game", false, 2)]
	static void Build_Android_Game() {
		BuildPlayer ("ExportedBuilds/Android.apk", BuildTarget.Android, () => {});
	}



	/*
	*   Helpers 
	*/
	static void BuildAssetBundles (string path, BuildTarget target, Action completion) {
		Directory.CreateDirectory (path);
		BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, target);
		completion ();
	}

	static void BuildPlayer(string path, BuildTarget target, Action completion) {
		 BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
		 buildPlayerOptions.scenes = new[] {"Assets/App/Scenes/Loading.unity"};
		 buildPlayerOptions.locationPathName = path;
		 buildPlayerOptions.target = target;
		 buildPlayerOptions.options = BuildOptions.None;
		 BuildPipeline.BuildPlayer(buildPlayerOptions);
		 completion ();
	}	

	static void Increment_Version_Minor () {
		string versionText = PlayerSettings.bundleVersion;

		if (string.IsNullOrEmpty (versionText)) {
			versionText = "0.0.1";
		} else {
			versionText = versionText.Trim ();
			string[] lines = versionText.Split ('.');

			int majorVersion = 0;
			int minorVersion = 0;
			int subMinorVersion = 0;

			if (lines.Length > 0) majorVersion = int.Parse(lines[0]);
			if (lines.Length > 1) minorVersion = int.Parse(lines[1]);
			if (lines.Length > 2) subMinorVersion = int.Parse(lines[2]);

			minorVersion = minorVersion + 1;

			versionText = majorVersion.ToString("0") + "." + minorVersion.ToString("0") + "." + subMinorVersion.ToString("0");
		}

		UnityEngine.Debug.Log( "Version Incremented to " + versionText );
		PlayerSettings.bundleVersion = versionText;

		string path = "./ExportedBuilds/version.json";

		StreamWriter writer = new StreamWriter(path, true);
		String str = "{\"version\": \"" + PlayerSettings.bundleVersion + "\", \"timestamp\": \"" + DateTime.UtcNow.ToString("o") + "\"}";
		writer.WriteLine(str);
		writer.Close();		
	}
}