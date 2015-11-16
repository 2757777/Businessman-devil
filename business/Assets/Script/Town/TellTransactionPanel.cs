using UnityEngine;
using System.Collections;

public class TellTransactionPanel : MonoBehaviour {
    public int ProductOrder;
    public MakeTransaction MT;
    public GameObject TransactionPanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void SendOrder()
    {
        TransactionPanel.SetActive(true);
        MT.ProductOrder=ProductOrder;
        MT.SendMessage("OpenBuyPanel");
    }
}
