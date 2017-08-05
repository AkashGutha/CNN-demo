using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour {

	public StateManager StatesManager;

	// Use this for initialization
	void Start () {

		// // testing
		// foreach(var data in  UnemploymentDataService.UnemploymentDataList){
		// 	Debug.Log(data.Name);
		// }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnSwipeDown(){
		StatesManager.TakeAction(CNNDemo.ActionTypes.swipeDownAction);
	}

	void OnSwipeUp(){
		StatesManager.TakeAction(CNNDemo.ActionTypes.swipeUpAction);
	}
}
