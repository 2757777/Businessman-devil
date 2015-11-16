using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {
    public int NowState;
    public bool Open1, Open2, Close1, Close2,Close3;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Open1 && transform.localPosition.x > 398 && Close2 == false)
        {
            transform.position = new Vector2(transform.position.x - 5f, transform.position.y);

        }


        if (Close1 && transform.localPosition.x < 595)
        {
            transform.position = new Vector2(transform.position.x + 5f, transform.position.y);

        }
        if(Open2&&transform.localPosition.x > -245)
        {
            transform.position = new Vector2(transform.position.x - 10f, transform.position.y);
        }
        if (Close2 && transform.localPosition.x < 400)
        {
            transform.position = new Vector2(transform.position.x + 10f, transform.position.y);
        }
        if (Close3 && transform.localPosition.x < 595)
        {
            transform.position = new Vector2(transform.position.x +15f, transform.position.y);

        }
    }
    void CheckThis()
    {
        if (Open1 == false && Open2 == false)
        {
            Open1 = true;
            Close1 = false;
            Close2 = false;
            Close3 = false;


        }
        else
            if (Open1 && Open2 == false)
            {
                Open1 = false;
                Open2 = false;
                Close1 = true;
            }
            else
                if (Open2 && Open1)
                {
                    Close3 = true;
                    Open1 = false;
                    Open2 = false;
                }

    }
    void CheckBox()
    {
        if (Open1 && Open2 == false)
        {
            Open2 = true;
            Close1 = false;
            Close2 = false;
            Close3 = false;

        }else
        if (Open1 && Open2)
        {
            
            Open2 = false;
            Close2 = true;
        }
    }
    }
    
