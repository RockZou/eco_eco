using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class SpeciesCreator : MonoBehaviour {
	

	public List<GameObject> animalPrefabList = new List<GameObject>(); 
	public List<GameObject> treePrefabList = new List<GameObject>();// assign in inspector
	public List<GameObject> obstacleClones = new List<GameObject>();

	private int treeType;
	private int animalType;

	bool treeIsSelected=true;
	Transform oceanTransform;


	CoconutNumber coconutNumber;

	// Use this for initialization
	void Start () {
		Debug.Log ("SpeciesCreator Start is called");

		oceanTransform = GameObject.Find ("Ocean").GetComponent<Transform>();
		coconutNumber = GameObject.Find ("CoconutText").GetComponent<CoconutNumber>();

		treeType = 1;
		animalType = 0;
		
		treeIsSelected=true;
	}
	
	// Update is called once per frame
	void Update () {
		
		// generate a ray before shooting a raycast
		Ray cursorRay = Camera.main.ScreenPointToRay( Input.mousePosition);
		RaycastHit cursorRayInfo = new RaycastHit();
		
		if(Physics.Raycast(cursorRay, out cursorRayInfo, 10000f)){
			
			if (Input.GetMouseButtonUp(0)&& !EventSystem.current.IsPointerOverGameObject() ){
				makeCreature(cursorRayInfo.point);
			}
		}
	}//update

	public void makeCreature(Vector3 location){

		float seaLevel = oceanTransform.position.y;
		if (location.y<seaLevel){
			tryMakeCreatureUnderWater();
			return;
		}

		int coco = coconutNumber.coconutNum;
		int treeCost = treePrefabList [treeType].GetComponent<CreatureBehavior> ().cost;
		int animalCost = animalPrefabList [animalType].GetComponent<CreatureBehavior> ().cost;

		if (treeIsSelected){
			if (coco>= treeCost)
			{
				Instantiate( treePrefabList[treeType],location,Quaternion.Euler(0,Random.Range(0,359),0) );
				coconutNumber.sub(treeCost);
			}
			else
				notEnoughCoconut();
		}
		else{
			if (coco>= animalCost)
			{
				Instantiate( animalPrefabList[animalType], location , Quaternion.Euler(0,Random.Range(0,359),0) );
				coconutNumber.sub(animalCost);
			}
			else 
				notEnoughCoconut();
		}
	}

	public void tryMakeCreatureUnderWater(){
		Debug.Log ("SpeciesCreator tryMakeCreatureUnderWater is called");
		Debug.Log ("Can't Create Creatures Under Water!");
	}
	public void notEnoughCoconut(){
		Debug.Log ("SpeciesCreator notEnoughCoconut is called");
		Debug.Log ("Don't have enough Coconut!");
	}

	public void setTreeType(int theType){
		treeType = theType;
		treeIsSelected = true;
	}
	public void setAnimalType(int theType){
		animalType = theType;
		treeIsSelected = false;
	}


}
