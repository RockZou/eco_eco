using UnityEngine;
using System.Collections;

public class SnowBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startSnowing(int SnowSpeed){
		
		GetComponent<EllipsoidParticleEmitter> ().maxEmission = SnowSpeed;
		
		GetComponent<EllipsoidParticleEmitter> ().minEmission = SnowSpeed;

	}
}
