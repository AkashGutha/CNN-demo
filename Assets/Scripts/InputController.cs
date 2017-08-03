using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public float speed = 0.3f;

	private Camera mainCam;

	// mouse varibales
    private bool holding = false;
    private bool leftMouseBtnDown = false;
    private bool leftMouseBtnUp =false;
    private Vector3 prevMousePosition = Vector3.zero;
    private Vector3 currMousePosition = Vector3.zero;
    private Vector3 deltaPos = Vector3.zero;


	// Raycast variables
	private Ray ray;
	private RaycastHit hit;

	// interactive object varibales
	private GameObject interactiveObj;
	private Interactable interactionComponent;

    void Awake()
    {
		mainCam = Camera.main;
        currMousePosition = Input.mousePosition;
        prevMousePosition = Input.mousePosition;
    }
    // Update is called once per frame
    void Update()
    {
        // check if the button is pressed and gather the pos information.
        leftMouseBtnDown = Input.GetMouseButtonDown(0);
        leftMouseBtnUp = Input.GetMouseButtonUp(0);
        currMousePosition = Input.mousePosition;

		// updating the states after checking for the collison.
        // set the state to holding if user is not holding and pressed the right mouse button
        if (leftMouseBtnDown == true && !holding)
        {
            holding = true;
        }
        // release as soon as the user relases the right mouse button
        if (leftMouseBtnUp == true)
        {
			//reset the state;
			ResetState();
        }

        Debug.Log(holding == true && leftMouseBtnDown==false);


        // if the right mouse button is just down fire a ray and check the cast.
		// get the interactble if collided with one.
        if (leftMouseBtnDown == true)
        {
            // as soon as the first click comes in get the mouse positions to be same
            // this will prevent from subsctraction from previous mouse positions
            prevMousePosition = currMousePosition;

            // do a raycast and findout the collisions
			ray = mainCam.ScreenPointToRay(currMousePosition);
            if (Physics.Raycast(ray, out hit, 500))
            {
				Debug.Log("ray did hit : " + hit.collider.name);

				interactiveObj = hit.collider.gameObject;
				interactionComponent = interactiveObj.GetComponent<Interactable>();

				// check for an interaction component on the object.
				if(interactionComponent != null){
					// the object does have a interaction component;
					Debug.Log("we've hit an interactive component - " + interactionComponent.name);
                    Debug.Log(interactionComponent);
				}else{
					// the object doesnt have an interaction component
					// so set the interaction obj to null
					interactiveObj = null;
					interactionComponent = null;
				}
            }
        }


        // if the user is holding the button adn hasnt just pushed the mouse button down.
        // gather delta variables and apply to holded object
        if (holding == true && leftMouseBtnDown==false)
        {
            deltaPos = currMousePosition - prevMousePosition;

            // zero out x,z values;
            deltaPos = new Vector3(0, -deltaPos.x, 0) * speed;

			//add interactions to teh interactive object.
			// Debug.Log("interacting with : "+ (interactionComponent as Rotatable ).name);

            if(interactionComponent is Rotatable){
                interactionComponent.Interact(deltaPos);
            }

            if(interactionComponent is UsState){
                interactionComponent.Interact();
            }

            prevMousePosition = currMousePosition;

        }

    }

	void ResetState(){
		interactionComponent = null;
		interactiveObj = null;

		holding = false;
		leftMouseBtnDown = false;
        leftMouseBtnUp = false;

	}
}
