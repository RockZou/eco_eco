using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UIButtonFuncs : MonoBehaviour {
	private GameObject ChallengesUI;

	public AudioSource open_page;
	public Canvas theGameCanvas;

	public GameObject Onboarding;
	public GameObject Challenges;
	public GameObject WorldStatus;
	public GameObject SpeciesSelectorUI;

	// Use this for initialization
	void Start () {
		open_page = GameObject.Find ("Open_page").GetComponent<AudioSource>();
		Debug.Log ("UIButtofnFuncs Start Called");
	}
	
	public void openWindow(GameObject theWindow){
		open_page.Play();
		Debug.Log ("UIButtonFuncs openWindow is called opening "+theWindow.name+" window");
		closeAllWindows ();
		theWindow.SetActive (true);
	}

	public void closeWindow(GameObject theWindow){
		open_page.Play();
		Debug.Log ("UIButtonFuncs closeWindow is called closing "+theWindow.name+" window");
		theWindow.SetActive (false);
	}

	public void toggleWindow(GameObject theWindow){
		open_page.Play();
		Debug.Log ("UIButtonFuncs toggleWindow is called toggling "+theWindow.name+" window");
		if (!theWindow.activeSelf) {
			closeAllWindows();
		}
		theWindow.SetActive (!theWindow.activeInHierarchy);


	}
	
	public void changeCoconut(int coconutChange){
		open_page.Play();
		Text coconutText = GameObject.Find ("coconuttext").GetComponent<Text>();
		int coconutAmount = int.Parse (coconutText.text) + coconutChange;
		coconutText.text = ""+coconutAmount;
	}

	public void closeAllWindows()
	{
		
		Debug.Log("UIButtonFuncs closeAllWindows called");
		Component[] allActiveWindows;
		allActiveWindows = theGameCanvas.GetComponentsInChildren<PanelIdentifier> ();
		foreach (Component i in allActiveWindows)
		{
			Debug.Log("UIButtonFuncs closeAllWindows foreach called");
			Debug.Log(i.gameObject.name);
			i.gameObject.SetActive(false);
		}
	}

}
