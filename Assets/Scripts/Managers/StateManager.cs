using System;
using UnityEngine;
public class StateManager : MonoBehaviour
{

    public CNNDemo.State State;
    public GameObject USA_States;


    private bool perspectiveTransitionDone = false;
    private Animator USA_Animator;

    void Awake()
    {
        State = CNNDemo.States.UnemplpoyedViewState;
        USA_Animator = USA_States.GetComponent<Animator>();
    }
    public string NextState()
    {
        return "null";
    }

    public void TakeAction(CNNDemo.Action action)
    {

        if (action == CNNDemo.ActionTypes.swipeDownAction && !perspectiveTransitionDone)
        {
            Debug.Log("action swipe down registered; transitionsing to persepective view");

			// set the drection and trigger the animation
			USA_Animator.SetFloat("Direction", 1.0f);
            USA_Animator.SetTrigger("change");

            perspectiveTransitionDone = true;
        }
        if (action == CNNDemo.ActionTypes.swipeUpAction && perspectiveTransitionDone)
        {
            Debug.Log("action swipe up registered; transitionsing to plain view");

			USA_Animator.SetFloat("Direction", -1.0f);
            USA_Animator.SetTrigger("change");

            perspectiveTransitionDone = false;

        }

    }

}
