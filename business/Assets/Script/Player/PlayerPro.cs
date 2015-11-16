using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPro : MonoBehaviour {
    public int Money, Speed, LoadLimit, Connoisseur,Leve,NowLoad,Exp;
    public Text MoneyText, SpeedText, LoadText, ConnoisseurText, LeveText, ExpText;
	// Use this for initialization
	void Start () {
        Leve = 1;
        NowLoad = 0;
	}
	
	// Update is called once per frame
	void Update () {
        MoneyText.text = "コイン：" + Money + "枚";
        LeveText.text = "LV." + Leve;
        ExpText.text = "EXP：" + Exp;
        SpeedText.text = "素早さ ：" + Speed;
        ConnoisseurText.text = "目利き：" + Connoisseur;
        LoadText.text = NowLoad + "/" + LoadLimit;

	}
}
