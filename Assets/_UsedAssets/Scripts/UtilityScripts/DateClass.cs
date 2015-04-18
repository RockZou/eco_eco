using UnityEngine;
using System.Collections;

public class DateClass: MonoBehaviour {
	public string currentDateString;
	public string getCurrentDateString()
	{
		Debug.Log ("Static getDate getDateString getCurrentDateString called");
		string currentDateTimeString = System.DateTime.Now.ToString();
		Debug.Log (currentDateTimeString);
		string[] stringBits = currentDateTimeString.Split (' ');
		string t_dateString = stringBits [0];
		stringBits = t_dateString.Split ('/');
		string monthString = stringBits [0];
		string dayString = stringBits [1];
		string yearString = stringBits [2];
		string currentDateString = yearString + monthString + dayString;
		this.currentDateString=currentDateString;
		Debug.Log (currentDateString);
		return currentDateString;
	}
}
