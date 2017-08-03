using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsState : Interactable
{
    private bool triggered = false;
    private Animator stateAnimator;
    void Awake()
    {
        stateAnimator = this.GetComponent<Animator>();
    }
    public override void Interact()
    {
        if (!triggered)
        {
            stateAnimator.SetTrigger("clicked");
        }

        triggered = true;
        StartCoroutine(DelayTrigger(0.5f));
    }

    private IEnumerator DelayTrigger(float time)
    {
        yield return new WaitForSeconds(time);
        triggered = false;
    }
}
