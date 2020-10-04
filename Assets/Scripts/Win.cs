using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
	private GameObject levelController;

	private void Awake()
	{
		levelController = GameObject.FindGameObjectWithTag("LevelController");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			levelController.GetComponent<LevelController>().NextMap();
		}
	}
}
