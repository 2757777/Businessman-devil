using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MakeTransaction : MonoBehaviour {
    public int ProductOrder,SumPrice,SellPrice;
    public Slider TransactionSlider;
    public MarkketPro MPro;
    public Image ProductImage;
    public GameObject GM,SellTaget,Player;
    public Text PriceText, AmtText,NowText,SumText,MessageText;
    public SureSell SS;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //買う数
        NowText.text = "x" + TransactionSlider.value;
        //合計
        SumPrice = (int)(TransactionSlider.value * SellPrice);
        SumText.text = "合計          " + SumPrice + "枚";
	}
    void OpenBuyPanel()
    {
        //リセット
        TransactionSlider.value = 0;
        //最大値を取る
        if (MPro.ProductPrice[ProductOrder] * MPro.ProductAmt[ProductOrder] < Player.GetComponent<PlayerPro>().Money)
            TransactionSlider.maxValue = MPro.ProductAmt[ProductOrder];
        else
            TransactionSlider.maxValue = (int)(Player.GetComponent<PlayerPro>().Money / MPro.ProductPrice[ProductOrder]);
        //画像を取る
        ProductImage.sprite = MPro.Product[ProductOrder].GetComponent<Image>().sprite;
        SellPrice = MPro.ProductPrice[ProductOrder];
        //単価
        PriceText.text = "単価          " + MPro.ProductPrice[ProductOrder] + "枚";
        //在庫
        AmtText.text = "在庫          " + MPro.ProductAmt[ProductOrder];

    }
    void OpenSellPanel()
    {
        //リセット
        TransactionSlider.value = 0;
        TransactionSlider.maxValue = SellTaget.GetComponent<SellProductButton>().Amt;
        ProductImage.sprite = SellTaget.GetComponent<Image>().sprite;
        SellPrice =SellTaget.GetComponent<SellProductButton>().Price;
        //単価
        PriceText.text = "単価          " + SellPrice + "枚";
        //在庫
        AmtText.text = "在庫          " + SellTaget.GetComponent<SellProductButton>().Amt;
        for (int n = 0; n < 5; n++)
        {
            if (Player.GetComponent<PathFollower>().pathingTarget.GetComponent<TownPro>().Product[n] == SellTaget.GetComponent<SellProductButton>().KindOfProduct)
            {
                SellPrice /= 2;
                MessageText.text = "売り損じ注意！";
                SS.CanPlus = false;
                break;
            }else
                if (Player.GetComponent<PathFollower>().pathingTarget.GetComponent<TownPro>().Demand == SellTaget.GetComponent<SellProductButton>().KindOfProduct)
                {
                    SellPrice +=2;
                    MessageText.text = "需要物ボーナス";
                    SS.CanPlus = true;
                    break;
                }
                else
                {
                    MessageText.text = "";
                    SS.CanPlus = false;
                }
        }
        
    }
}
