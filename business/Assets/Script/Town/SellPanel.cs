using UnityEngine;
using System.Collections;

public class SellPanel : MonoBehaviour {
    public int Count;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Count = transform.childCount;
        if (Count > 5)
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2((Count - 5) * 110, 180);
        }
	}
}
