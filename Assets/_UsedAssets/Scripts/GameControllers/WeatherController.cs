using UnityEngine;
using System.Collections;

public class WeatherController : MonoBehaviour {

	public GameObject rain;
	public GameObject snow;


	public bool isRaining;
	public bool isSnowing;

	// Use this for initialization
	void Start () {
		Debug.Log ("Weather Controller Start is Called");

		getWeatherStates ();
		setWeatherStates ();
	}

	void getWeatherStates()
	{
		//replace with getting isRanging from playerprefs
		
		//		rainStatus = PlayerPrefs.GetInt (weatherObject.name);

		isRaining = false;
		isSnowing = false;

		if (rain == null) {
			Debug.Log("rain is null");
			rain = GameObject.Find ("MainCamera/WeatherController/Rain");
		}
		if (snow == null) {
			Debug.Log("snow is null");
			snow = GameObject.Find ("MainCamera/WeatherController/Snow");
		}

	}

	void setWeatherStates()
	{
		rain.SetActive (isRaining);
		snow.SetActive (isSnowing);
	}

	public void toggleWeather(GameObject weatherObject){

		WeatherBehavior weatherBehavior = weatherObject.GetComponent<WeatherBehavior> ();
		Debug.Log ("toggleWeather Called");
		weatherBehavior.toggle ();
//		if (weatherObject == rain) {
//			Debug.Log("Passed object is rain");
//			weatherObject.GetComponent<>().toggle();
//		}
//		
//		if (weatherObject == snow) {
//			Debug.Log("Passed object is snow");
//			snow.GetComponent<WeatherBehavior>().toggle();
//		}
	}

}
