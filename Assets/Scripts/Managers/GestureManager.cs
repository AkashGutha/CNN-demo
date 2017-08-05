using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lean.Touch;
using System;

public class GestureManager : MonoBehaviour
{
    public ApplicationManager AppManager;
    private Camera mainCam;
    private Ray ray;
	private RaycastHit hit;

    void Awake()
    {
        // get the camera ref.
        mainCam = Camera.main;
    }
    protected virtual void OnEnable()
    {
        // Hook into the events we need
        LeanTouch.OnFingerSwipe += OnFingerSwipe;
        LeanTouch.OnFingerTap += OnFingerTap;
    }

    protected virtual void OnDisable()
    {
        // Unhook the events
        LeanTouch.OnFingerSwipe -= OnFingerSwipe;
        LeanTouch.OnFingerTap -= OnFingerTap;
    }

    private void OnFingerTap(LeanFinger finger)
    {
        // do a raycast and findout the collisions
        ray = mainCam.ScreenPointToRay(finger.ScreenPosition);
        if (Physics.Raycast(ray, out hit, 500))
        {
            Debug.Log("ray did hit : " + hit.collider.name);
            AppManager.SendMessage("SelectState", hit.collider.gameObject, SendMessageOptions.RequireReceiver);
        }

    }

    private void OnFingerSwipe(LeanFinger finger)
    {

        // Store the swipe delta in a temp variable
        var swipe = finger.SwipeScreenDelta;

        if (swipe.x < -Mathf.Abs(swipe.y))
        {
            Debug.Log("You swiped left!");
        }

        if (swipe.x > Mathf.Abs(swipe.y))
        {
            Debug.Log("You swiped right!");
        }

        if (swipe.y < -Mathf.Abs(swipe.x))
        {
            Debug.Log("You swiped down!");
            AppManager.SendMessage("OnSwipeDown", SendMessageOptions.RequireReceiver);
        }

        if (swipe.y > Mathf.Abs(swipe.x))
        {
            Debug.Log("You swiped up!");
            AppManager.SendMessage("OnSwipeUp", SendMessageOptions.RequireReceiver);
        }
    }
}
