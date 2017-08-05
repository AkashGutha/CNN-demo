using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeHeights : MonoBehaviour
{
    public float heightOffset;
    void Awake()
    {
        var children = gameObject.GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] == this.transform) continue;

            // got all children excluding the parent
            var r = Random.Range(-0.2f, 0.1f);
            children[i].transform.position += new Vector3(0, 0, r);
        }
    }
}
