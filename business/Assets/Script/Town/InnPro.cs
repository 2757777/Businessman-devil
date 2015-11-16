using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InnPro : MonoBehaviour {
    public Text TalkText;
    public Image NPC;
    public Sprite NpcChange, NormalNPC;
    public float timer,count;
    public GameObject GM;
	// Use this for initialization
	void Start () {
        timer = 0;
        NormalNPC = NPC.sprite;
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Image>().color.a > 1&&count<4)
        {
            TalkText.text = "ごゆっくり\n休んでください～";
            NPC.sprite = NpcChange;
            timer += Time.deltaTime;
            if (timer > 1)
            {
                GM.GetComponent<GameDate>().SendMessage("OneWeek");
                timer = 0;
                count++;
                if (count == 4)
                {
                 
                    GetComponent<CleanImage>().CanClean = true;
                    count = 0;
                }
            }
        }
        if (GetComponent<Image>().color.a < 0)
        {
            NPC.sprite = NormalNPC;
           // TalkText.text = "次は何をします？";
        }

        
	}    
}
