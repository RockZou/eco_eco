using UnityEngine;
using System.Collections;

public class TreeBehavior : MonoBehaviour {

	private OceanController theOcean;
	private float seaLevel;

	private int underwaterFrameCount;

	// Use this for initialization
	void Start () {
		theOcean= GameObject.Find("Ocean").GetComponent<OceanController>();
		seaLevel = theOcean.transform.position.y;
		if (transform.position.y < seaLevel - 10) {
			GameObject.Destroy(this.gameObject);
		};
	}
	
	// Update is called once per frame
	void Update () {
		seaLevel = theOcean.transform.position.y;
		if (transform.position.y < seaLevel - 10) {
			underwaterFrameCount++;
		} else {
			underwaterFrameCount =0;
		}

		if (underwaterFrameCount > 30) {
			GameObject.Destroy (this.gameObject);
		}

	}
}
