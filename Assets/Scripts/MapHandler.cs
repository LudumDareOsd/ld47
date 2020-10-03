using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
	public GameObject playerPrefab;
	public GameObject box1Prefab;
	public GameObject ground1Prefab;

	public GameObject doorPrefab;
	public GameObject pressurePrefab;
	public GameObject buttonPrefab;

	public const int map_width = 26;
	public const int map_height = 14;

	private string mapsPath;

	// 0 air, 1-9 "ground", D doors, S switch, X spawnpoint, B box
	private string[,] levelData = new string[map_height, map_width];
	//private GameObject worldObject;

	// Start is called before the first frame update
	void Start()
	{
		//worldObject = GameObject.FindGameObjectsWithTag("WorldObject");
		mapsPath = Application.dataPath + "/Maps/";
		levelData = ReadMap(mapsPath + "map1.txt");

		var xoffset = -0.5f + map_width / 2;
		var yoffset = 0f + map_height / 2;
		Debug.LogFormat("Offsets: x:{0} y:{1}", xoffset, yoffset);
		Debug.LogFormat("Mapfolder: {0}", mapsPath);
		var doors = new List<GameObject>();
		var triggers = new List<GameObject>();
		for (var y = 0; y < map_height; y++)
		{
			for (var x = 0; x < map_width; x++)
			{
				var spawnx = x - xoffset;
				var spawny = -y + yoffset;
				switch (levelData[y, x])
				{
					case "1":
						Instantiate(ground1Prefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						break;
					case "B":
						Instantiate(box1Prefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						break;
					case "X":
						Instantiate(playerPrefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						break;
					case "D": case "F": // Door
						var door = Instantiate(doorPrefab, new Vector3(spawnx, spawny + 0.75f, 0), Quaternion.identity);
						// set variant of door
						doors.Add(door);
						break;
					case "P": case "O": // Pressure plate
						var trigger = Instantiate(pressurePrefab, new Vector3(spawnx, spawny - 0.375f, 0), Quaternion.identity);
						//set variant of trigger
						triggers.Add(trigger);
						break;
					case "E": case "R": // Button
						//var trigger = Instantiate(playerPrefab, new Vector3(spawnx, spawny, 0), Quaternion.identity);
						// set variant of trigger
						//triggers.Add(trigger);
						break;
					default:
						//Debug.Log(levelData[y, x]);
						break;

				}
			}
		}

		// Add triggers
		foreach (var door in doors)
		{
			foreach (var trigger in triggers)
			{
				door.GetComponent<Door>().triggers.Add(trigger.GetComponent<PressurePlate>());
			}
		}
	}

	private string[,] ReadMap(string file)
	{
		var ret = new string[map_height, map_width];
		var text = System.IO.File.ReadAllLines(file);
		var y = 0;
		foreach (var line in text)
		{
			var x = 0;
			var stringsOfLine = line.Split(' ');
			foreach (var tile in line)
			{
				if (tile.ToString() == " " || string.IsNullOrEmpty(tile.ToString())) continue;
				ret[y, x++] = tile.ToString();
			}
			y++;
		}

		return ret;
	}

}
