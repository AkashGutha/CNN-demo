using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorizer : MonoBehaviour
{
    public Dictionary<string, Transform> States = new Dictionary<string, Transform>();
  
    void Awake()
    {
        var states = this.transform.GetComponentsInChildren<Transform>();
        foreach (var state in states)
        {
            if (state == this.transform) continue;
            this.States.Add(state.name.Trim(), state);
            // Debug.Log(state.name.Trim());
        }

        // just for debugging
        ColorizeByUnemployment();
    }
    public void ColorizeByUnemployment()
    {
        var dataList = UnemploymentDataService.UnemploymentDataList;

        foreach (var state in dataList)
        {
            // Debug.Log(state.Name);
            float strength = ((float)state.UnemploymentDecile / 5);
            States[state.Name].GetComponent<Renderer>().material.color = new Color(.8f, .8f , 0.45f * strength);
        }
    }

}
