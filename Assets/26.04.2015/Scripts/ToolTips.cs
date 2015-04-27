using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToolTips : MonoBehaviour {

/*
	// Use this for initialization
	public GameObject player;
	public PlayerUpgradeManager playerUpgrades;

	public MeshRenderer upgradeHighlightChild;
	public bool onMenu=false;
	public bool upgradeEnabled=false;
	public float scaleFactor=1.2f;

	int tooltipWidth  = 100 ;
	int tooltipHeight = 30;


	bool renderToolTip = false;
	void Start () {

		player = GameObject.Find("Player");
		playerUpgrades = player.gameObject.GetComponent<PlayerUpgradeManager>();
		upgradeHighlightChild = transform.GetChild(0).GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(player.GetComponent<WorkbenchTrigger>().onMenu){
			onMenu=true;
		}
		else{
			onMenu=false;
		}
	}

	void Enable(){
		upgradeHighlightChild.enabled=true;
		playerUpgrades.currentUpgrades.Add(gameObject);
		playerUpgrades.UpdateTheStats();
	}
	void Disable(){
		upgradeHighlightChild.enabled=false;
		playerUpgrades.currentUpgrades.Remove(gameObject);
		playerUpgrades.UpdateTheStats();
	}


	void OnMouseEnter(){
		renderToolTip = true;
		if(onMenu){
			transform.localScale*=scaleFactor;
		}
	}

	void OnMouseOver(){
		if( Input.GetMouseButtonDown(0) &&onMenu){
		if(!upgradeEnabled){
			upgradeEnabled=true;
			Enable ();
			}

		else{
			upgradeEnabled=false;
			Disable();
			}
		}
	}

	void OnMouseExit(){
		renderToolTip = false;
		if(onMenu){
			transform.localScale/=scaleFactor;
		}
	}

	void OnGUI() {

		string tooltipText = "Placeholder text \n placeholder text.";

		if (renderToolTip){
			GUI.Box(new Rect(Input.mousePosition.x + Screen.width / 50, 
			                 Screen.height - Input.mousePosition.y + Screen.height / 50, 
			                 tooltipWidth, tooltipHeight), 
			        new GUIContent(tooltipText));
			}
		}
*/
}
