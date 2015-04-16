using UnityEngine;
using System.Collections;

public class WeatherBehavior: MonoBehaviour {

	GameObject weatherObject;

	// Use this for initialization
	void Start () {
		weatherObject = this.gameObject;
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
		weatherObject.SetActive (!weatherObject.activeInHierarchy);
	}
	
	public bool isOn()
	{
		return weatherObject.activeInHierarchy;
	}
}
