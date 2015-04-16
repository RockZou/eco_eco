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

		isRaining = true;
		isSnowing = false;


		if (rain == null)
			rain = GameObject.Find ("MainCamera/WeatherController/Rain");
		if (snow == null)
			snow = GameObject.Find ("MainCamera/WeatherController/Snow");

	}

	void setWeatherStates()
	{
		rain.SetActive (isRaining);
		snow.SetActive (isSnowing);
	}

	public void toggleWeather(GameObject weatherObject){

		Debug.Log ("toggleWeather Called");

		if (weatherObject == rain) {
			Debug.Log("Passed object is rain");
			rain.GetComponent<WeatherBehavior>().toggle();
		}
		
		if (weatherObject == snow) {
			Debug.Log("Passed object is snow");
			snow.GetComponent<WeatherBehavior>().toggle();
		}
	}

}
