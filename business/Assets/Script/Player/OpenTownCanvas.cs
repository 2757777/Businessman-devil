using UnityEngine;
using System.Collections;

public class OpenTownCanvas : MonoBehaviour {
    public GameObject TownCanvas;
    public GameDate Date;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
    if (other.transform.name == GetComponent<PathFollower>().pathingTarget.name)
        {
            TownCanvas.GetComponent<Canvas>().enabled = true;
            Date.Walking = false;

        }
    }
    void BackToTown()
    {
        TownCanvas.GetComponent<Canvas>().enabled = true;
        Date.Walking = false;
    }
 
}
