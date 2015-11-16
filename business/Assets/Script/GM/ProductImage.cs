using UnityEngine;
using System.Collections;

public class ProductImage : MonoBehaviour {
    public Sprite[] Product = new Sprite[20];
    public float[] ProductPrice = new float[20], LastWeekAmt = new float[20],
    ProductSellPrice = new float[20];
    public GameObject TransactionSellPanel;
    public int[] ProductAmt = new int[20];
        // Use this for initialization
	void Start () {
        //人参
        ProductPrice[1] = 5;
        //とうもろこし
        ProductPrice[2] = 5;
        //鉄剣
        ProductPrice[7]=50;
        //LeatherArmor
        ProductPrice[10] = 25;
        //鉄
        ProductPrice[13] = 30;
        //Leather
        ProductPrice[18] = 15;
        for (int n = 1; n < 20; n++)
        {
            ProductSellPrice[n] = ProductPrice[n] * 1.3f;
        }
        

	}
	
	// Update is called once per frame
	void Update () {
	
	}
   public void ChangePrice(int Number,float amt)
    {
        float n = amt - LastWeekAmt[Number];
       if(n>0)
        ProductPrice[Number] += (int)((1 / (Mathf.Exp(5 * ((float)(amt-LastWeekAmt[Number]) / 50)) - 0.5f)));
       else
           ProductPrice[Number] -= (int)((1 / (Mathf.Exp(5 * ((float)(amt - LastWeekAmt[Number]) / 50)) - 0.5f)));
        LastWeekAmt[Number] = amt;
        return;
    }
}
