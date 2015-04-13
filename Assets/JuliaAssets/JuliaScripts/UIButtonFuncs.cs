using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UIButtonFuncs : MonoBehaviour {
	public GameObject challengemodal1;
	public GameObject challengemodal3;
	public GameObject sealevelmodal;
	public GameObject leafpanel;
	public GameObject animalpanel;

	public Button closebutton;
	public Button closebutton1;
	public Button closebutton2;
	public Button cancelbutton1;
	public Button cancelbutton2;

	public GameObject Backgroundplant;
	public GameObject Backgroundkiwi;

	// Use this for initialization
	void Start () {
		Debug.Log ("UIButtofnFuncs Start Called");
		//challengemodal1 = GameObject.Find("challengemodal1");
	}

	public void openChallengeWindow1(){
		Debug.Log ("UIButtonFuncs openChallengeWindow1 called");
		challengemodal1.SetActive (true);
	}

	public void closeChallengeWindow(){
		Debug.Log ("closeChallengeWIndow called");
		challengemodal1.SetActive (false);
	}
	//use this for challengewindow3 after API call
	public void openChallengeWindow3(){
		Debug.Log ("UIButtonFuncs openChallengeWindow1 called");
		challengemodal3.SetActive (true);
	}
	
	public void closeChallengeWindow3(){
		challengemodal3.SetActive (false);
	}
	//use this for plant window
	public void openPlantWindow(){
		Debug.Log ("UIButtonFuncs openPlantWindow called");
		leafpanel.SetActive (true);
		animalpanel.SetActive (false);
	}

	public void closePlantWindow(){
		leafpanel.SetActive (false);
		animalpanel.SetActive (false);
	}

	//use this for animal window
	public void openAnimalWindow(){
		Debug.Log ("UIButtonFuncs openAnimalWindow called");
		animalpanel.SetActive (true);
	}
	
	public void closeAnimalWindow(){
		animalpanel.SetActive (false);
	}

	//sea level window creator
	public void openSeaLevelWindow(){
		Debug.Log ("UIButtonFuncs openSeaLevelWindow called");
		sealevelmodal.SetActive (true);
	}
	
	public void closeSeaLevelWindow(){
		sealevelmodal.SetActive (false);
	}

	//select a plant and have a border around it
	public void togglePlantOn(){
		Backgroundplant.SetActive (true);
	}

	public void increaseCoconut(){
		Text coconutText = GameObject.Find ("coconuttext").GetComponent<Text>();
		coconutText.text ="400";
	}

	//select an animal and have a border around it
	public void toggleAnimalOn(){
		Backgroundkiwi.SetActive (true);
	}

}
