using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TalkText : MonoBehaviour {
    public string[] Talk = new string[10];
    public int Number;
    public GameObject Money, Inn, Marker;
	// Use this for initialization
	void Start () {
        Talk[0] = "ようこそ、うちの村へ\n何をしたいです？";
	}
	
	// Update is called once per frame
	void Update () {
        if (Money.GetComponent<Image>().color.a < 1 && Inn.GetComponent<Image>().color.a < 1 && Marker.GetComponent<Image>().color.a < 1)
        GetComponent<Text>().text = Talk[Number];
	}
}
