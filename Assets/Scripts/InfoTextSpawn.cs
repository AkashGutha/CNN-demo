using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTextSpawn : MonoBehaviour
{

    public string infoToDisplay = "put in string here";
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
        info.GetComponentInChildren<Text>().text = infoToDisplay;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, Anchor.transform.localScale.y/2+YOffset,0 ) );
        info.transform.position = screenPos;
    }

    public void SetText(string text){
    }
}
