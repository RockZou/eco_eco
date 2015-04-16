using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimalAI: MonoBehaviour {

	public AnimalRaycast npcPrefab;
	public List<AnimalRaycast> allMyNpcs = new List<AnimalRaycast>();


	// Use this for initialization
	void Start () {
		Debug.Log ("NPCCommand Start Called");
	}
	
	// Update is called once per frame
	void Update () {


		Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition);
		RaycastHit rayHit = new RaycastHit();

		if ( Physics.Raycast ( ray, out rayHit, 100f ) ){
			if (Input.GetMouseButton(0) && rayHit.collider.tag != "Player"){
				AnimalRaycast newNPC = Instantiate(npcPrefab, rayHit.point, Quaternion.Euler(0f,0f,0f)) as AnimalRaycast;
				allMyNpcs.Add(newNPC);
			}
		}

	}
}
