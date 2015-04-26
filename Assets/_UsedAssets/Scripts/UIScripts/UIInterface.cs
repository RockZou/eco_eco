using UnityEngine;
using System.Collections;

public class UIInterface : MonoBehaviour {

	public GameObject CameraRawImage;
	public GameObject MovesApiRequests;

	public void Start(){
	}

	public void startImageRecognitionApi(){
		CameraRawImage.GetComponent<CamDisplay> ().startImageRecognitionApi ();
	}
}
