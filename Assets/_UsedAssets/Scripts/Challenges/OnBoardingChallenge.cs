using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnBoardingChallenge : MonoBehaviour {

	public int rewardCoconut = 100;
	public int rewardSealevelDrop = 50;
	public GameObject TextBox;

	public AudioSource achievement;

	public GameObject CoconutText;
	public int status;
	OceanController theOcean;

	public void Awake(){
		theOcean = GameObject.Find ("Ocean").GetComponent<OceanController> ();
	}

	public void giveReward(){
		TextBox.GetComponent<TextBox> ().setText ("Congratualations!Complete more challenges to build your eco-system and save the planet!|reward");;

		Debug.Log ("OnBoardingChallenge give reward");
		achievement.Play ();
		Vector3 seaLevel = theOcean.transform.position;
		theOcean.changeSeaLevel (seaLevel.y - rewardSealevelDrop);
		
		CoconutText.GetComponent<CoconutNumber>().add (rewardCoconut);
		PlayerPrefs.SetInt ("ONBOARDING",1);
	}
}
