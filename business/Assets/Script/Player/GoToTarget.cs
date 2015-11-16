using UnityEngine;
using System.Collections;

public class GoToTarget : MonoBehaviour {
    public GameObject TargetPoint,Player;
    public GameDate Date;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void MoveStart()
    {
        if (Player.GetComponent<PathFollower>().pathingTarget == TargetPoint.transform)
        {
            Player.GetComponent<OpenTownCanvas>().SendMessage("BackToTown");
        }
        else
        {
            Player.GetComponent<PathFollower>().pathingTarget = TargetPoint.transform;
            Player.GetComponent<PathFollower>().SendMessage("CanGo");
            Date.Walking = true;
        }
    }
}
