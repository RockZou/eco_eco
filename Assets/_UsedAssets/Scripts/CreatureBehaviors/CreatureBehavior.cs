using UnityEngine;
using System.Collections;

public class CreatureBehavior:MonoBehaviour{
	public int cost;
	public int happiness;
	public string type;
	public string name;
	public GameObject TextBox;

	void Awake(){
		TextBox = GameObject.Find ("TextBox");
	}

	public void setCost(int cost)
	{
		this.cost = cost;
	}

	void OnMouseUp(){
		TextBox.GetComponent<TextBox> ().setText ("This is your "+ name+". Keep the sea level down to keep it happy!|reward");
	}
}
