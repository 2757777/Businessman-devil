using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SureSell : MonoBehaviour {
    public MakeTransaction MT;
    public Slider SellSlider;
    public ProductImage GM;
    public GameObject Player;
    public MarkketPro MP;
    public int SellDemandAmt;
    public bool CanPlus;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        SellDemandAmt =(int) MT.TransactionSlider.value;
	}
    void Sure()
    {
        if(CanPlus)
        Player.GetComponent<PathFollower>().pathingTarget.GetComponent<TownPro>().DemandAmt += SellDemandAmt;
        Player.GetComponent<PlayerPro>().Money += MT.SumPrice;
        MT.SellTaget.GetComponent<SellProductButton>().Amt -= (int)SellSlider.value;
        GameObject.Find(GM.Product[MT.SellTaget.GetComponent<SellProductButton>().KindOfProduct].name).GetComponent<BagProductPrefab>().Amt -= (int)SellSlider.value;
        MP.SendMessage("Refesh");

    }
}
