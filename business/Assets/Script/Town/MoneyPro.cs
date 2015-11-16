using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyPro : MonoBehaviour {
    public Text TalkText,TownMoneyText,GiveMoneyText;
    public GameObject MoneyPanel,Player;
    public Image NPC;
    public Sprite NpcChange, NormalNPC;
    public Slider MoneySlider;
    public bool Show;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Image>().color.a >= 1&&Show)
        {
            TownMoneyText.text = "村資金：" + Player.GetComponent<PathFollower>().pathingTarget.GetComponent<TownPro>().TownMoney + "枚";
            TalkText.text = "お金をいくら\n投資します？～";
            NPC.sprite = NpcChange;
            MoneyPanel.SetActive(true);
            MoneySlider.GetComponent<Slider>().maxValue = Player.GetComponent<PlayerPro>().Money;
            GiveMoneyText.text = MoneySlider.GetComponent<Slider>().value+"枚";
        }
        if (GetComponent<Image>().color.a < 0)
        {
            NPC.sprite = NormalNPC;
       //     TalkText.text = "次は何をします？";
        }

	}
    void GiveMoney()
    {
        Show = false;
        MoneyPanel.SetActive(false);
        Player.GetComponent<PlayerPro>().Money -= (int)MoneySlider.GetComponent<Slider>().value;
        Player.GetComponent<PathFollower>().pathingTarget.GetComponent<TownPro>().TownMoney += (int)MoneySlider.GetComponent<Slider>().value;
        GetComponent<CleanImage>().CanClean = true;
        MoneySlider.GetComponent<Slider>().value = 0;
        
    }
    void CanShow()
    {
        Show = true;
    }
}
