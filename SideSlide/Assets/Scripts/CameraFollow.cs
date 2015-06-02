﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform player;
	public int distance;
	
	void Update () {
		transform.position = new Vector3(player.position.x + distance, 0, -10);
	}
}