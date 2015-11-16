using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TownPro : MonoBehaviour {
    public string TownName;
    public GameObject GameManger, TargerCheckButton,Player;
    public int /*人口*/population,
        /*需要*/Demand,DemandAmt,
                /*レベル*/Level,
                /*戦闘欲*/CombatDesire,
                /*発展速度*/DevelopmentSpeed,
                /*村の特長*/Specialty,
                //村資金
                 TownMoney;
    /*生産物*/
    public int[] Product = new int[5];
    public float  /*レベル*/LevelCount;
    public float[]/*生産物在庫*/
                    ProductAmt = new float[5];
                    
    

     
    public Text ShowTownName, TownLevel, ShowCombatDesire, ShowDevelopmentSpeed, ShowSpecialty;
    public Image[] ShowProduct = new Image[5];
    public Image ShowDemand;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OneWeek()
    {
        if (TownMoney > Level * 10 && Level > 1)
        TownMoney -= Level * 10;
        if (DemandAmt > Level * 1)
        DemandAmt -= Level *1;
        //発展
        //村資金が足りない場合
        if (TownMoney < Level * 30 && DevelopmentSpeed>0)
        {
            DevelopmentSpeed--;
            LevelCount -= 0.1f;

        }else
            //余っている場合
            if(TownMoney>Level*60){
                DevelopmentSpeed++;
                LevelCount += 0.1f;
            }
        //戦闘欲
        if (DemandAmt > Level * 5 &&  TownMoney > Level * 10)
        {
            CombatDesire++;
            LevelCount += 0.2f;
        }
        else
            if (DemandAmt == 0 && TownMoney < Level * 10 && CombatDesire>0)
        {
            CombatDesire--;
        }
        //村レベル
        if (LevelCount >= 1)
        {
            Level++;
            LevelCount--;
        }
         if (LevelCount <= -1)
        {
            if (Level > 1)
            {
                Level--;
            }
                LevelCount++;
            

        }
        //生産物の成長
        if (ProductAmt[0] + ProductAmt[1] < Level * 50)
        {
            ProductAmt[0] += DevelopmentSpeed * 0.4f*Random.Range(0.1f,2);
            if(DemandAmt>0)
            ProductAmt[1] += DevelopmentSpeed * 0.2f * Random.Range(0.1f, 2);
        }
        else
        {
            for (float n = ProductAmt[0] + ProductAmt[1]; n > Level * 50; n-=2)
            {    ProductAmt[0]--; ProductAmt[1]--;
            }
        }
        
        

        if (Player.GetComponent<PathFollower>().pathingTarget.gameObject == this.gameObject)
        {
            ShowPro();
        }

        for (int i = 0; i < 5; i++)
			{
            if(Product[i]!=0&&ProductAmt[i]>10)
                GameManger.GetComponent<ProductImage>().ChangePrice(Product[i], ProductAmt[i]);
			}
        
    }
    void ShowPro()
    {
        //名前を表示
        ShowTownName.text = TownName;
        //レベル表示
        TownLevel.text = "LV." + Level;
        //生産物表示
        for (int n = 0; n < 5; n++)
        {
            ShowProduct[n].sprite = GameManger.GetComponent<ProductImage>().Product[Product[n]];
        }
        
        //需要表示
        ShowDemand.sprite = GameManger.GetComponent<ProductImage>().Product[Demand];

        //戦闘欲表示
        ShowCombatDesire.text = "戦闘欲：" + CombatDesire;

        //発展速度
        ShowDevelopmentSpeed.text = "発展速度：" + DevelopmentSpeed;

        //村の特長
        switch (Specialty)
        {
            case 1:
                ShowSpecialty.text = "村の特長：農産物";
                break;
            case 2:
                ShowSpecialty.text = "村の特長：鉱物";
                break;
            case 3:
                ShowSpecialty.text = "村の特長：動物";
                break;
            case 4:
                ShowSpecialty.text = "村の特長：装備";
                break;
        }
        //Yesボタンのターゲット
        TargerCheckButton.GetComponent<GoToTarget>().TargetPoint = this.gameObject;
        

    }
}
