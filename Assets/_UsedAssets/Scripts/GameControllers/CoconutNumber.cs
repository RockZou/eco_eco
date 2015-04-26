using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoconutNumber : MonoBehaviour {

	public int coconutNum = 100;

	public void Awake(){
		GetComponent<Text> ().text = coconutNum.ToString();
	}

	public int get(){
		
		GetComponent<Text> ().text = coconutNum.ToString();
		return coconutNum;
	}

	public int set(int newCoconutNum){
		coconutNum = newCoconutNum;
		
		GetComponent<Text> ().text = coconutNum.ToString();
		return newCoconutNum;
	}

	public int add(int addedCoconutNum){
		coconutNum += addedCoconutNum;
		
		GetComponent<Text> ().text = coconutNum.ToString();
		return coconutNum;
	}

	public int sub(int subCoconutNum){
		coconutNum -= subCoconutNum;
		if (coconutNum < 0) {
			coconutNum=0;
		}
		
		GetComponent<Text> ().text = coconutNum.ToString();
		return coconutNum;
	}

}
