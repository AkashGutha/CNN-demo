using System;
using UnityEngine;
using UnityEngine.UI;
using CNNDemo;
using Lean.Touch;
public class StateManager : MonoBehaviour
{

  public CNNDemo.State State;
  public GameObject USA_States;
  public GameObject Bars;
  public Animator VotesPanelAnimator;
  public Animator GlobeAnimtor;

  private Canvas canvas;
  private GameObject selectedState;
  private Vector3 selectedState_PreviousPosition;
  private Vector3 selectedState_PreviousScale;
  private Quaternion selectedState_PreviousRotation;
  private bool perspectiveTransitionDone = false;
  private bool stateSelected = false;
  private Animator USA_Animator;

  void Awake()
  {
    State = CNNDemo.States.UnemplpoyedViewState;
    USA_Animator = USA_States.GetComponent<Animator>();
    canvas = GameObject.FindObjectOfType<Canvas>();
  }

  void Start()
  {
    // check the state and apply the colors accordingly
  }
  public string NextState()
  {
    return "null";
  }

  public void TakeAction(CNNDemo.Action action, System.Object obj)
  {
    if (action == CNNDemo.ActionTypes.swipeDownAction && !perspectiveTransitionDone)
    {
      Debug.Log("action swipe down registered; transitionsing to persepective view");

      // set the drection and trigger the animation
      USA_Animator.SetFloat("Direction", 1.0f);
      USA_Animator.SetTrigger("change");

      perspectiveTransitionDone = true;
    }
    else if (action == CNNDemo.ActionTypes.swipeUpAction && perspectiveTransitionDone)
    {
      Debug.Log("action swipe up registered; transitionsing to plain view");

      USA_Animator.SetFloat("Direction", -1.0f);
      USA_Animator.SetTrigger("change");

      perspectiveTransitionDone = false;

    }

    if (action == ActionTypes.tapAction && !stateSelected)
    {
      stateSelected = true;

      var GO = (GameObject)obj;

      //save the state
      selectedState_PreviousPosition = GO.transform.localPosition;
      selectedState_PreviousScale = GO.transform.localScale;
      selectedState_PreviousRotation = GO.transform.localRotation;

      selectedState = GO;

      // unpoarent it from USA
      GO.transform.SetParent(null);


      // bring the state into view and set parameters
      GO.transform.position = new Vector3(0, -2, 0);
      GO.transform.rotation = Quaternion.Euler(45, 0, -45);
      GO.transform.localScale *= 3;

      //add the rotate interaction component
      GO.AddComponent<LeanRotate>();
      var bars = Instantiate(Bars, GO.transform.position, GO.transform.rotation);
      bars.transform.parent = GO.transform;

      // set the appropriate local rotation
      bars.transform.localRotation = Quaternion.Euler(-90, 0, 0);

      // update the Panel UI
      canvas.transform.Find("Top Panel").Find("TopText").GetComponent<Text>().text = GO.name;

      // disable USA
      USA_Animator.Play("show_state");
      USA_States.SetActive(false);

      // switch on different metrics UI
      VotesPanelAnimator.SetTrigger("SlideIn"); ;
      GlobeAnimtor.SetTrigger("ZoomOut"); ;

    }
    else if (action == ActionTypes.tapAction && stateSelected)
    {
      // do nothing.
    }

    if (action == ActionTypes.swipeUpAction && stateSelected)
    {

      // reset the current state
      stateSelected = false;

      var GO = selectedState.gameObject;
      // reparent teh child state
      GO.transform.parent = USA_States.transform;

      // restore the previous state
      GO.transform.localPosition = selectedState_PreviousPosition;
      GO.transform.localRotation = selectedState_PreviousRotation;
      GO.transform.localScale = selectedState_PreviousScale;

      // remove the rot script form the state
      var rot = GO.GetComponent<LeanRotate>();
      Destroy(rot);


      // destroy the bars and panels
      var bars = GO.transform.Find("Bars(Clone)");
      bars.SetParent(null);
      Destroy(bars.gameObject);

      var panels = canvas.transform.Find("Panel(Clone)");
      panels.SetParent(null);
      Destroy(panels.gameObject);
      panels = canvas.transform.Find("Panel(Clone)");
      panels.SetParent(null);
      Destroy(panels.gameObject);

      // update the Panel UI
      canvas.transform.Find("Top Panel").Find("TopText").GetComponent<Text>().text = "UNEMPLOYMENT DETAILS";

      // enable the USA obvject
      USA_States.SetActive(true);
      USA_Animator.Play("Idle");
      VotesPanelAnimator.SetTrigger("SlideOut");
      GlobeAnimtor.SetTrigger("ZoomIn");

    }


  }

}
