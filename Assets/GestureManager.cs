using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lean.Touch;
using System;

public class GestureManager : MonoBehaviour
{
    public ApplicationManager AppManager;
    protected virtual void OnEnable()
    {
        // Hook into the events we need
        LeanTouch.OnFingerSwipe += OnFingerSwipe;
    }

    protected virtual void OnDisable()
    {
        // Unhook the events
        LeanTouch.OnFingerSwipe -= OnFingerSwipe;
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
