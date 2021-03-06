﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using System.Text.RegularExpressions;

public class MapHandler : MonoBehaviour
{
	public GameObject playerPrefab;
	public GameObject winPrefab;
	public GameObject box1Prefab;
	public GameObject ground1Prefab;
	public GameObject ground2Prefab;
	public GameObject ground3Prefab;
	public GameObject ground4Prefab;
	public GameObject ground5Prefab;
	public GameObject ground6Prefab;
	public GameObject ground7Prefab;
	public GameObject ground8Prefab;
	public GameObject ground9Prefab;

	public GameObject doorPrefab;
	public GameObject doorFramePrefab;
	public GameObject trapDoorPrefab;
	public GameObject pressurePrefab;
	public GameObject heavyPressurePrefab;
	public GameObject leverPrefab;
	public GameObject deathFountainPrefab;

	public GameObject BG1;
	public GameObject BG2;
	public GameObject BG3;
	public GameObject BG4;
	public GameObject BG5;
	public GameObject BG6;
	public GameObject BG7;
	public GameObject BG8;
	public GameObject BG9;

	public const int map_width = 39;
	public const int map_height = 21;
	public GameObject levelController;

	private string mapsPath;

	// 0 air, 1-9 "ground", D doors, S switch, X spawnpoint, B box
	private string[,] levelData = new string[map_height, map_width];
	private GameObject worldObject;

	public void LoadMap(int mapNum, bool backwards = false)
	{
		worldObject = GameObject.FindGameObjectWithTag("WorldObject");
		mapsPath = "Maps/";
		levelData = ReadMap(mapsPath + "map" + mapNum.ToString());

		var xoffset = 0.0f + map_width / 2;
		var yoffset = 0.0f + map_height / 2;
		var doors = new Dictionary<string, GameObject>();
		var triggers = new List<KeyValuePair<string, GameObject>>();

		//Debug.LogFormat("Offsets: x:{0} y:{1}", xoffset, yoffset);
		//Debug.LogFormat("Mapfolder: {0}", mapsPath);

		for (var y = 0; y < map_height; y++)
		{
			for (var x = 0; x < map_width; x++)
			{
				var spawnx = x - xoffset;
				var spawny = -y + yoffset;
				// Trigger variant, could be a dict or w/e... smh
				var variant = levelData[y, x] == "P" ? "D" : // P switch match with D doors etc...
							  levelData[y, x] == "O" ? "F" :
							  levelData[y, x] == "I" ? "G" :
							  levelData[y, x] == "E" ? "D" :
							  levelData[y, x] == "R" ? "F" :
							  levelData[y, x] == "T" ? "G" :
							  levelData[y, x] == "." ? "_" :
							  levelData[y, x] == "H" ? "D" : "";

				switch (levelData[y, x])
				{
					case "0": // Air
						break;
					case "1":
					{
						var instance = Instantiate(ground1Prefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						instance.transform.SetParent(worldObject.transform);
						break;
					}
					case "2":
					{
						var instance = Instantiate(ground2Prefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						instance.transform.SetParent(worldObject.transform);
						break;
					}
					case "3":
					{
						var instance = Instantiate(ground3Prefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						instance.transform.SetParent(worldObject.transform);
						break;
					}
					case "4":
					{
						var instance = Instantiate(ground4Prefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						instance.transform.SetParent(worldObject.transform);
						break;
					}
					case "5":
					{
						var instance = Instantiate(ground5Prefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						instance.transform.SetParent(worldObject.transform);
						break;
					}
					case "6":
					{
						var instance = Instantiate(ground6Prefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						instance.transform.SetParent(worldObject.transform);
						break;
					}
					case "7":
					{
						var instance = Instantiate(ground7Prefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						instance.transform.SetParent(worldObject.transform);
						break;
					}
					case "8":
					{
						var instance = Instantiate(ground8Prefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						instance.transform.SetParent(worldObject.transform);
						break;
					}
					case "9":
					{
						var instance = Instantiate(ground9Prefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						instance.transform.SetParent(worldObject.transform);
						break;
					}
					case "B": // Box
					{
						var instance = Instantiate(box1Prefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						instance.transform.SetParent(worldObject.transform);
						break;
					}
					case "X":
					{
						if (backwards) break;
						var instance = Instantiate(playerPrefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						instance.transform.SetParent(worldObject.transform);
						break;
					}
					case "Z":
					{
						if (!backwards) break;
						var instance = Instantiate(playerPrefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						instance.transform.SetParent(worldObject.transform);
						break;
					}
					case "D": case "F": case "G": // Door
					{
						var door = Instantiate(doorPrefab, new Vector3(spawnx, spawny + 0.75f, 0), Quaternion.identity);
						var frame = Instantiate(doorFramePrefab, new Vector3(spawnx, spawny + 2.25f, 0), Quaternion.identity);
						door.transform.SetParent(worldObject.transform);
						frame.transform.SetParent(worldObject.transform);
						doors.Add(levelData[y, x], door);
						break;
					}
					case "P": case "O": case "I": // Pressure plate
					{
						var plate = Instantiate(pressurePrefab, new Vector3(spawnx, spawny - 0.375f, 0), Quaternion.identity);
						plate.transform.SetParent(worldObject.transform);
						var plateelement = new KeyValuePair<string, GameObject>(variant, plate);
						triggers.Add(plateelement);
						break;
					}
					case "E": case "R": case "T": case ".": // Lever
					{
						var lever = Instantiate(leverPrefab, new Vector3(spawnx, spawny + 0.75f, 0), Quaternion.identity);
						lever.transform.SetParent(worldObject.transform);
						var buttonelement = new KeyValuePair<string, GameObject>(variant, lever);
						triggers.Add(buttonelement);
						break;
					}
					case "H": // Heavy pressure
					{
						var plate = Instantiate(heavyPressurePrefab, new Vector3(spawnx, spawny - 0.375f, 0), Quaternion.identity);
						plate.transform.SetParent(worldObject.transform);
						var buttonelement = new KeyValuePair<string, GameObject>(variant, plate);
						triggers.Add(buttonelement);
						break;
					}
					case "_": // Trapdoor
					{
						var door = Instantiate(trapDoorPrefab, new Vector3(spawnx + 2.5f, spawny - 1.625f, 0), Quaternion.identity);
						door.transform.SetParent(worldObject.transform);
						doors.Add(levelData[y, x], door);
						break;
					}
					case "!":
                    {
						var deatFountain = Instantiate(deathFountainPrefab, new Vector3(spawnx, spawny + 1.5f, 0), Quaternion.identity);
						deatFountain.transform.SetParent(worldObject.transform);
						break;
                    }
					default:
						Debug.LogFormat("Unhandled Level data: {0},  pos: {1},{2}", levelData[y, x], x, y);
						break;
				}
			}
		}

		// Add triggers to doors
		foreach (KeyValuePair<string, GameObject> door in doors)
		{
			foreach (var trigger in triggers)
			{
				//Debug.LogFormat("have trigger Variant from {0} to {1}", trigger.Key, door.Key);
				// Matching variants
				if (trigger.Key == door.Key)
				{
					//Debug.LogFormat("adding trigger {0} {1}", trigger.Key, door.Key);
					door.Value.GetComponent<Reciver>().triggers.Add(trigger.Value.GetComponent<Trigger>());
				}
			}
			if (door.Value.GetComponent<Door>())
			{
				door.Value.GetComponent<Door>().Awake(); // this should probably call an "refresh triggers" method instead
			}
			if (door.Value.GetComponent<TrapDoor>())
			{
				door.Value.GetComponent<TrapDoor>().Awake(); // this should probably call an "refresh triggers" method instead
			}
		}
	}


	private string[,] ReadMap(string file)
	{
		var ret = new string[map_height, map_width];

		var textAsset = Resources.Load<TextAsset>(file);
		var text = Regex.Split(textAsset.text, "\r\n|\r|\n");

		var y = 0;
		foreach (var line in text)
		{
			var x = 0;
			if (line[0] == '#') // If first char is hash line is the text
			{
				var introText = line.Substring(1).Trim();
				levelController.GetComponent<LevelController>().storyText = introText;
			} else if (line[0] == '*') {
				var bgName = line.Substring(1).Trim();

				GameObject prefab = null;

				switch (bgName) {

					case "BG1":
						prefab = BG1;
						break;

					case "BG2":
						prefab = BG2;
						break;

					case "BG3":
						prefab = BG3;
						break;

					case "BG4":
						prefab = BG4;
						break;

					case "BG5":
						prefab = BG5;
						break;

					case "BG6":
						prefab = BG6;
						break;

					case "BG7":
						prefab = BG7;
						break;

					case "BG8":
						prefab = BG8;
						break;

					case "BG9":
						prefab = BG9;
						break;

					default:
						Debug.Log("Could not find Background");
						break;

				}

				var bg = Instantiate(prefab);
				bg.transform.SetParent(worldObject.transform);
			}
			else
			{
				foreach (var tile in line)
				{
					if (tile.ToString() == " " || tile.ToString() == Environment.NewLine || string.IsNullOrEmpty(tile.ToString())) continue;
					ret[y, x++] = tile.ToString();
				}
				y++;
			}
		}

		return ret;
	}

}
