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
	Text DebugText;

	// Use this for initialization
	public void Start () {
		postImageGameObject.SetActive (true);

		postImage = GameObject.Find("PostImage").GetComponent<PostImage>();
		DebugText = GameObject.Find ("DebugText").GetComponent<Text> ();;

		Debug.Log ("CamDisplay Start is called");
		image = GetComponent<RawImage>();
		deviceName = WebCamTexture.devices[0].name;
		
		cam = new WebCamTexture (deviceName);
		cam.Play ();

		picture = new Texture2D (cam.width,cam.height);

		image.texture = cam;

	}
	
	// Update is called once per frame
	public void Update () {

	}

	public void startImageRecognitionApi(){
		DebugText.text = "key Pressed";
		
		picture.SetPixels(GetAllPixels(cam));
		picture.Apply();
		
		image.texture = picture;
		
		File.WriteAllBytes(Application.persistentDataPath+'/'+"test_image.png",picture.EncodeToPNG());
		Debug.Log("saving png image as test_image.png");
		DebugText.text +=" saving png image as test_image.png";
		
		postImage.sendImageToCloudSight();
	}

	public Color[] GetAllPixels(WebCamTexture cam){
		return cam.GetPixels (0,0,cam.width,cam.height);
	}
}
