﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpeciesCreator : MonoBehaviour {
	
	
	public GameObject dudePrefab; 
	public GameObject treePrefab;// assign in inspector
	public List<GameObject> obstacleClones = new List<GameObject>();
	
	// Use this for initialization
	void Start () {
		Debug.Log ("SpeciesCreator Start Called");
	}
	
	// Update is called once per frame
	void Update () {
		
		// generate a ray before shooting a raycast
		Ray cursorRay = Camera.main.ScreenPointToRay( Input.mousePosition);
		RaycastHit cursorRayInfo = new RaycastHit();
		
		if(Physics.Raycast(cursorRay, out cursorRayInfo, 10000f)){
		
			
			if (Input.GetMouseButtonDown(0) ){
				GameObject cloneWall = (GameObject)Instantiate( dudePrefab, cursorRayInfo.point, Quaternion.Euler(0,Random.Range(0,359),0) );
				obstacleClones.Add(cloneWall);
			}

			if (Input.GetMouseButtonDown(2) ){
				GameObject cloneWall = (GameObject)Instantiate( dudePrefab, cursorRayInfo.point, Quaternion.Euler(0,-90f,0) );
				obstacleClones.Add(cloneWall);
			}
			
			if (Input.GetMouseButton(1) ){

				Vector2 randomPosition = Random.insideUnitCircle;
				GameObject cloneWall = (GameObject)Instantiate( treePrefab, 
				                                               (new Vector3( cursorRayInfo.point.x  + randomPosition.x * 10, 
				             												 cursorRayInfo.point.y , 
				            								                 cursorRayInfo.point.z  + randomPosition.y * 10 )),
				                                               Quaternion.Euler(0,Random.Range(0,359),0) );
				obstacleClones.Add(cloneWall);
			}
			
		}
		
		
	}
}
