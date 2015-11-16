using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MarkketPro : MonoBehaviour {
    public Text TalkText;
    public Text[] ProductPriceText=new Text[5],
                   ProductAmtText=new Text[5];
   
    public Image NPC;
    public Sprite NpcChange, NormalNPC;
    public GameObject NowTown,Player,GM,MarketSystem;
    public GameObject[] Product=new GameObject[5];
    public int[]
        ProductKind = new int[5],
        ProductPrice= new int[5],
        ProductAmt=new int [5],
        ProductSellPrice= new int [5];
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Image>().color.a > 1)
        {
            NPC.sprite = NpcChange;
            MarketSystem.SetActive(true);
            TalkText.text = "はりきって～\n商売！商売！";

        }
        if (GetComponent<Image>().color.a < 0)
        {
            NPC.sprite = NormalNPC;
          //  TalkText.text = "次は何をします？";
        }


	}
    void Refesh()
    {
        NowTown = Player.GetComponent<PathFollower>().pathingTarget.gameObject;
        TalkText.text = "はりきって～\n商売！商売！";
        
        for (int n = 0; n < 5; n++)
        { //商品種類
            ProductKind[n] = NowTown.GetComponent<TownPro>().Product[n];
            //商品画像
            Product[n].GetComponent<Image>().sprite = GM.GetComponent<ProductImage>().Product[ProductKind[n]];
            //在庫
            ProductAmt[n] = (int)NowTown.GetComponent<TownPro>().ProductAmt[n];
            if (ProductAmt[n] > 0)
            {
                ProductAmtText[n].text = ProductAmt[n] + "";
                Product[n].GetComponent<Button>().interactable = true;
                //商品値段
                 ProductPrice[n]=(int)GM.GetComponent<ProductImage>().ProductPrice[ProductKind[n]];
                 ProductSellPrice[n] = (int)GM.GetComponent<ProductImage>().ProductSellPrice[ProductKind[n]];

               // ProductPrice[n] = (int)(50 * (1 / (Mathf.Exp(5 * ((float)(ProductAmt[n]) / 500)) - 0.5f)) + GM.GetComponent<ProductImage>().ProductPrice[ProductKind[n]]);
                //値段表示
                ProductPriceText[n].text = ProductPrice[n] + "枚";

            }
            else
            {
                Product[n].GetComponent<Button>().interactable = false;
                ProductAmtText[n].text =  "売切";
            }
            //商品値段
          /*  ProductPrice[n] = (int)(-100 * (1 / (Mathf.Exp(5*(ProductAmt[n]/500)) - 0.5f)) + GM.GetComponent<ProductImage>().ProductPrice[ProductKind[n]]);
            //値段表示
            ProductPriceText[n].text = ProductPrice[n] + "枚";
            */
        }
    }
}
