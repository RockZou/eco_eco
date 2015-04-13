using UnityEngine;
using System.Collections;

public class PalmBehavior : MonoBehaviour {

	private OceanController theOcean;

	// Use this for initialization
	void Start () {
		theOcean= GameObject.Find("Ocean").GetComponent<OceanController>();
		float seaLevel = theOcean.transform.position.y;
		if (transform.position.y < seaLevel - 10) {
			GameObject.Destroy(this.gameObject);
		};
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
