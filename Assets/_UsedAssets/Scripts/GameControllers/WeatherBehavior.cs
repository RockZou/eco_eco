using UnityEngine;
using System.Collections;

public class WeatherBehavior: MonoBehaviour {

	private GameObject weatherObject;


	void Awake(){
		
		weatherObject = this.gameObject;
		Debug.Log ("WeahterBehavior " + weatherObject.name + "Awake is called");
	}
	// Use this for initialization
	void Start () {

		
		Debug.Log ("WeahterBehavior " + weatherObject.name + "Start is called");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setStatus(bool theStatus)
	{
		weatherObject.SetActive (theStatus);
	}

	public void toggle()
	{
		Debug.Log ("WeatherBehavior for "+ weatherObject.name + " toggle is called");
		weatherObject.SetActive (!weatherObject.activeSelf);
	}
	
	public bool isOn()
	{
		return weatherObject.activeInHierarchy;
	}
}
