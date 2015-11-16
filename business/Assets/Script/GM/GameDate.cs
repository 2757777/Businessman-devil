using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameDate : MonoBehaviour {
    public int Year, Month, Week;
    public Text Date;
    public GameObject Town;
    public float timer;
    public bool Walking;
	// Use this for initialization
	void Start () {
        Year = Month = Week = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Walking)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                OneWeek();
                timer = 0;
            }
        }
        if (Week > 4)
        {
            Month++; Week -= 4;
        }
        if (Month > 12)
        {
            Year++;
            Month -= 12;
        }
        Date.text = Year + "年" + Month + "月" + Week + "週";
	}
    void OneWeek()
    {
        Town.BroadcastMessage("OneWeek");
        Week++;
    }
}
