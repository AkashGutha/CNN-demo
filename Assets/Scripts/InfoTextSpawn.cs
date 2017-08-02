using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTextSpawn : MonoBehaviour
{

    public GameObject infoText;
    public Canvas mainCanvas;
    public GameObject Anchor;

    public float YOffset;
    private GameObject info;
    // Use this for initialization
    void Start()
    {
        info = GameObject.Instantiate(infoText);
        info.transform.SetParent(mainCanvas.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, Anchor.transform.localScale.y/2+YOffset,0 ) );
        info.transform.position = screenPos;

    }
}
