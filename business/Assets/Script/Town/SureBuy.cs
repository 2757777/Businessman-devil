using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SureBuy : MonoBehaviour {
    public GameObject NewProduct, GM, Bag, Player, NewSellProduct,SellPanle;
    public MakeTransaction MT;
    public MarkketPro MP;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Sure()
    {
        //パラメータを取る
        int Kind = MP.ProductKind[MT.ProductOrder];
        string TargetObjectName = GM.GetComponent<ProductImage>().Product[Kind].name;
        GameObject TargetObject = GameObject.Find(TargetObjectName);
        string TragetObjectBUttonName = "Sell" + GM.GetComponent<ProductImage>().Product[Kind].name;
        GameObject TragetObjectBUtton = GameObject.Find(TragetObjectBUttonName);
        //金が減る
        Player.GetComponent<PlayerPro>().Money -= MT.SumPrice;
        if (TargetObject == null)
        {
            //BagPrefabを作る
            GameObject MakeNewProduct = Instantiate(NewProduct);
            MakeNewProduct.transform.SetParent(Bag.transform);
            MakeNewProduct.transform.name = GM.GetComponent<ProductImage>().Product[Kind].name;
            MakeNewProduct.GetComponent<BagProductPrefab>().Price = (int)GM.GetComponent<ProductImage>().ProductPrice[Kind];
            MakeNewProduct.GetComponent<BagProductPrefab>().KindOfProduct = Kind;
            MakeNewProduct.GetComponent<BagProductPrefab>().Amt = (int)MT.TransactionSlider.value;
            MakeNewProduct.GetComponent<Image>().sprite = GM.GetComponent<ProductImage>().Product[Kind];
            //SellPrefabを作る
            GameObject MakeSellProduct = Instantiate(NewSellProduct);
            MakeSellProduct.transform.SetParent(SellPanle.transform);
            MakeSellProduct.transform.name = "Sell"+GM.GetComponent<ProductImage>().Product[Kind].name;
            MakeSellProduct.GetComponent<SellProductButton>().Price = (int)GM.GetComponent<ProductImage>().ProductSellPrice[Kind];
            MakeSellProduct.GetComponent<SellProductButton>().KindOfProduct = Kind;
            MakeSellProduct.GetComponent<SellProductButton>().Amt = (int)MT.TransactionSlider.value;
            MakeSellProduct.GetComponent<Image>().sprite = GM.GetComponent<ProductImage>().Product[Kind];
        }
        else
        {
            TargetObject.GetComponent<BagProductPrefab>().Amt += (int)MT.TransactionSlider.value;
            TragetObjectBUtton.GetComponent<SellProductButton>().Amt += (int)MT.TransactionSlider.value;
        }
        //在庫減る
        Player.GetComponent<PathFollower>().pathingTarget.GetComponent<TownPro>().ProductAmt[MT.ProductOrder] -= (int)MT.TransactionSlider.value;
        Player.GetComponent<PathFollower>().pathingTarget.GetComponent<TownPro>().TownMoney += MT.SumPrice;
        MP.SendMessage("Refesh");
    }
}
