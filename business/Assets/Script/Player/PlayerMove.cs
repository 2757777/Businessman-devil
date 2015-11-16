using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {
    public /*protected*/ Animator animator;
    public Transform Target;
    public float directionX = 0f;
    public float directionY = 0f;
    public bool walking = false,CanWalk;
    public float speed;
    public float h;
    public float v;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        if (CanWalk)
        {
            Target = GetComponent<PathFollower>().pathingTarget;
            /*距離計算
            Vector2 Apos = Target.transform.position;
            Vector2 Bpos = transform.position;
            Debug.Log( Vector3.Distance(Apos, Bpos));
            */
            if (PointDistance_2D(Target.position.x , transform.position.x) > PointDistance_2D(Target.position.y , transform.position.y))
            {
                
                if (Target.position.x - transform.position.x > 0)
                {
                    directionX = 1;
                    directionY = 0f;
                }
                else if (Target.position.x - transform.position.x < 0)
                {
                    directionX = -1;
                    directionY = 0f;
                }
            }
            else
            {
                Debug.Log("Y");
                if (Target.position.y - transform.position.y < 0)
                {
                    directionX = 0;
                    directionY = -1f;
                }
                else if (Target.position.y - transform.position.y > 0)
                {
                    directionX = 0;
                    directionY = 1f;
                }
            }
            animator.SetFloat("DirectionX", directionX);
            animator.SetFloat("DirectionY", directionY);

        }
      
	}
    float PointDistance_2D(float X1, float X2)
    {
      //  距離計算
        if (X1 > X2)
        {
            return (X1 - X2);
        }
        else
        {
            return (X2 - X1);
        }
    }
}
