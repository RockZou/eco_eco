using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UIButtonFuncs : MonoBehaviour {
	private GameObject ChallengesUI;


	// Use this for initialization
	void Start () {
		Debug.Log ("UIButtofnFuncs Start Called");
	}
	
	public void openWindow(GameObject theWindow){
		Debug.Log ("UIButtonFuncs openWindow is called opening "+theWindow.name+" window");
		theWindow.SetActive (true);
	}

	public void closeWindow(GameObject theWindow){
		Debug.Log ("UIButtonFuncs closeWindow is called closing "+theWindow.name+" window");
		theWindow.SetActive (false);
	}

	public void toggleWindow(GameObject theWindow){
		Debug.Log ("UIButtonFuncs toggleWindow is called toggling "+theWindow.name+" window");
		theWindow.SetActive (!theWindow.activeInHierarchy);
	}
	
	public void changeCoconut(int coconutChange){
		Text coconutText = GameObject.Find ("coconuttext").GetComponent<Text>();
		int coconutAmount = int.Parse (coconutText.text) + coconutChange;
		coconutText.text = ""+coconutAmount;
	}

}
