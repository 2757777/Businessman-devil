using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CleanImage : MonoBehaviour {
    public bool CanClean;
    float A;
	// Use this for initialization
	void Start () {
        A = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (CanClean)
        {
            //透明になる
            A-=0.02f;
            GetComponent<Image>().color = new Color(1, 1, 1, A);
            if (A < 0)
            {
                GetComponent<Image>().enabled = false;
                CanClean = false;
                A = 1;
            }
        }
	}
    void Clean()
    {
        CanClean = true;
    }
}
