using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {


	private bool isTouchSupported;
	// Use this for initialization
	void Start () {
		isTouchSupported = Input.touchSupported;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0){

			

		}
	}
}
