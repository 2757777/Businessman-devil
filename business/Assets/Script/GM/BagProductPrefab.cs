using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BagProductPrefab : MonoBehaviour {
    public int KindOfProduct, Price, Amt;
    public Text PriceText, AmtText;
	// Use this for initialization
	void Start () {
	transform.localScale=new Vector3(1,1,1);
	}
	
	// Update is called once per frame
	void Update () {
        PriceText.text = Price + "枚";
        AmtText.text = Amt + "";
        if (Amt < 1)
        {
            Destroy(gameObject);
        }
	}
}
