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

	void SelectState(GameObject obj){
		StatesManager.TakeAction(CNNDemo.ActionTypes.tapAction, obj);
	}

	void OnSwipeDown(){
		StatesManager.TakeAction(CNNDemo.ActionTypes.swipeDownAction, null);
	}

	void OnSwipeUp(){
		StatesManager.TakeAction(CNNDemo.ActionTypes.swipeUpAction, null);
	}
}
