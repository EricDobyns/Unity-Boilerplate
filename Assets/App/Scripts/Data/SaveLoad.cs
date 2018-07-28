using UnityEngine;
using System;
using System.IO;


public static class SaveLoad {

	// Public Variables
	// public static SettingsData settingsData;
	// public static GameData gameData;



	// Private Variables
	// private static string settingsDataFilePath = Application.persistentDataPath + "/settingsData.gd";
	// private static string gameDataFilePath = Application.persistentDataPath + "/gameData.gd";

	// public static bool doesExist() {
	// 	if (File.Exists(Application.persistentDataPath + "/settingsData.gd")) {
	// 		return true;
	// 	} else {
	// 		return false;
	// 	}
	// }


	// SaveLoad Methods
	// public static void LoadSettingsData(Action completionHandler) {
	// 	if (File.Exists (settingsDataFilePath)) {
	// 		string settingsDataAsJson = File.ReadAllText (settingsDataFilePath);
	// 		settingsData = JsonUtility.FromJson<SettingsData> (settingsDataAsJson);
	// 	} else {
	// 		settingsData = new SettingsData();
	// 	}

	// 	completionHandler ();
	// }

	// public static void LoadGameData(Action completionHandler) {
	// 	if (File.Exists (gameDataFilePath)) {
	// 		string gameDataAsJson = File.ReadAllText (gameDataFilePath);
	// 		gameData = JsonUtility.FromJson<GameData> (gameDataAsJson);
	// 	} else {
	// 		gameData = new GameData();
	// 		string gameDataAsJson = JsonUtility.ToJson (gameData);
	// 		File.WriteAllText (gameDataFilePath, gameDataAsJson);
	// 	}

	// 	completionHandler ();
	// }

	// public static void SaveSettingsData(Action completionHandler) {
	// 	string settingsDataAsJson = JsonUtility.ToJson (settingsData);
	// 	File.WriteAllText (settingsDataFilePath, settingsDataAsJson);
	// 	completionHandler ();
	// }

	// public static void SaveGameData(Action completionHandler) {
	// 	string gameDataAsJson = JsonUtility.ToJson (gameData);
	// 	File.WriteAllText (gameDataFilePath, gameDataAsJson);
	// 	completionHandler ();
	// }

	// public static void DeleteSettingsData(Action completionHandler) {
	// 	if (File.Exists(settingsDataFilePath)) {
	// 		File.Delete(settingsDataFilePath);
	// 		SaveLoad.settingsData = null;
	// 		completionHandler ();
	// 	}
	// }

	// public static void DeleteGameData(Action completionHandler) {
	// 	if (File.Exists(gameDataFilePath)) {
	// 		File.Delete(gameDataFilePath);
	// 		SaveLoad.gameData = null;
	// 		completionHandler ();
	// 	}
	// }
}


