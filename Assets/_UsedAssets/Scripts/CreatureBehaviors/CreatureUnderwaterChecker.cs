using UnityEngine;
using System.Collections;

public class CreatureUnderwaterChecker : MonoBehaviour {


	GameObject theOcean;
	GameObject TextBox;

	Vector3 seaPostions;

	int underwaterCount;

	// Use this for initialization
	void Start () {
		theOcean = GameObject.Find("Ocean");
		TextBox = GameObject.Find ("TextBox");
		seaPostions = theOcean.transform.position;
		underwaterCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		seaPostions = theOcean.transform.position;
		if (seaPostions.y > transform.position.y) {
			underwaterCount++;
		} else {
			underwaterCount = 0;
		}
		if (underwaterCount > 20) {
			Debug.Log("This object is destroyed becaouse of water: " + this.gameObject.name);
			TextBox.GetComponent<TextBox> ().setText ("Your creatures are being destroyed by the rising sea level!|warning");

			GameObject.Destroy(this.gameObject);
			
		}

	}
}
