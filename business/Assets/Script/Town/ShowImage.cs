using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowImage : MonoBehaviour {
    public bool CanShow;
    float A;
	// Use this for initialization
	void Start () {
        //透明
        A = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (CanShow)
        {
            //透明感なくなる
            A += 0.02f;
            GetComponent<Image>().color = new Color(1, 1, 1, A );
            if (A > 1)
            {
                A = 0;
                CanShow = false;
            }
        }
	
	}
    void Show()
    {
        CanShow = true;
    }
    
}
