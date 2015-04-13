using UnityEngine;
using System.Collections;

public class Bridge{


	public static void doRequestMovesAuthInApp(){

		using (AndroidJavaClass ajc = new AndroidJavaClass("com.rock.moves_api.Bridge")) {
			Debug.Log ("before doRequestMovesAuthInApp in java");
			ajc.CallStatic ("doRequestMovesAuthInApp");
			Debug.Log ("after doRequestMovesAuthInApp in java");
		}
	}

	//Test Functions
	public static void exampleFunc(){
		using (AndroidJavaObject ajo = new AndroidJavaObject("com.rock.moves_api.Bridge")) {
			Debug.Log("before exampleFunc");
			ajo.Call ("exampleFunc");
			Debug.Log("after exampleFunc");
		}
	}
		
	public static void bridgeSimpleFunc(){
		using (AndroidJavaObject ajo = new AndroidJavaObject("com.rock.moves_api.Bridge")) {
			Debug.Log("before bridgeSimpleFunc");
			ajo.Call("bridgeSimpleFunc");
			Debug.Log("after bridgeSimpleFunc");
		}
	}
	
	public static void ShowCamera(){
		using (AndroidJavaClass ajc = new AndroidJavaClass("com.rock.moves_api.Bridge")) {
			Debug.Log("before Showcamera");
			ajc.CallStatic("ShowCamera",12345);
			Debug.Log("after ShowCamera");
		}//using
	}//ShowCamera

	public static void startCloudSight(){
//		using (AndroidJavaClass ajc = new AndroidJavaClass("XXXXXXXXXXX")) {
//			Debug.Log("Unity Bridge startCloudSight called");
//			ajc.CallStatic("XXXX",XXXXX);
//		}
	}

}//Bridge

