using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour {

	public StateManager StatesManager;

	// Use this for initialization
	void Start () {
		
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
