using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class CamDisplay : MonoBehaviour {
	public WebCamTexture cam;

	Texture2D picture;

	public RawImage image;

	string deviceName;

	public GameObject postImageGameObject;

	PostImage postImage;

	// Use this for initialization
	public void Awake () {
		postImageGameObject.SetActive (true);

		postImage = GameObject.Find("PostImage").GetComponent<PostImage>();

		Debug.Log ("CamDisplay Awake is called");
		image = GetComponent<RawImage>();

		deviceName = WebCamTexture.devices[0].name;
		
		cam = new WebCamTexture (deviceName);
		
		turnCamearOn ();
		
		picture = new Texture2D (cam.width,cam.height);

	}

	public void OnDisable(){

		Debug.Log ("*****************CamDisplay onDisable is called*********************");

		cam.Stop ();
	}

	public void turnCamearOn(){
		cam.Play();			
		image.texture = cam;
	}

	public void startImageRecognitionApi(){
		Debug.Log ("CamDisplay StartImageRecognitionApi is called");
		if (!cam.isPlaying) {
			turnCamearOn();
		}

		while (!cam.isPlaying) {
		
		}

		picture.SetPixels (GetAllPixels (cam));
		picture.Apply ();
	
		image.texture = picture;
	
		File.WriteAllBytes (Application.persistentDataPath + '/' + "test_image.png", picture.EncodeToPNG ());
		Debug.Log ("saving png image as test_image.png");

		cam.Stop ();

		postImage.sendImageToCloudSight ();
	
	}

	public Color[] GetAllPixels(WebCamTexture cam){
		return cam.GetPixels (0,0,cam.width,cam.height);
	}
}
