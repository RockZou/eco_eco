﻿using UnityEngine;
using System.Collections;

public class CreatureUnderwaterCheck : MonoBehaviour {


	GameObject theOcean;
	Vector3 seaPostions;
	Vector3 creaturePositions;

	int underwaterCount;

	// Use this for initialization
	void Start () {
		theOcean = GameObject.Find("Ocean");
		seaPostions = theOcean.transform.position;
		underwaterCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		seaPostions = theOcean.transform.position;
		creaturePositions = transform.position;
		if (seaPostions.y > transform.position.y) {
			underwaterCount++;
		} else {
			underwaterCount = 0;
		}
		if (underwaterCount > 20) {
			GameObject.Destroy(this.gameObject);
		}

	}
}