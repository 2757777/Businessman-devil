using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SellProductButton : MonoBehaviour {
    public int KindOfProduct, Price, Amt;
    public Text PriceText, AmtText;
    public MakeTransaction MT;
    // Use this for initialization
	void Start () {
        transform.localScale = new Vector3(1, 1, 1);
        
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
    void OnClick()
    {
        GameObject.Find("GameManager").GetComponent<ProductImage>().TransactionSellPanel.SetActive(true);
        MT = GameObject.Find("TransactionSellPanel").GetComponent<MakeTransaction>();
        MT.SellTaget = this.gameObject;
        MT.SendMessage("OpenSellPanel");
    }
}
