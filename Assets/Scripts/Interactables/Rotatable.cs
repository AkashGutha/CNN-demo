using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatable : Interactable {

	void Rotate(Vector3 angle){
		this.transform.Rotate( angle, Space.World );
	}

	public override void Interact(Vector3 input){
		Rotate(input);
	}
	
}
