using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{
    public Image TownImage;
    public GameObject TownPanel,CheckPanel;
   public  Collider2D aCollider2d;
   public GameObject WorldCamera;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (WorldCamera.active)
            {
                Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Physics2D.OverlapPoint(aTapPoint) != null)
                {
                    aCollider2d = Physics2D.OverlapPoint(aTapPoint);
                    if (aCollider2d.tag == "Town")
                    {
                        GameObject obj = aCollider2d.transform.gameObject;

                        OpenTownInformaition();
                    }
                }
            }
        }
    }
    void OpenTownInformaition()
    {
        //パネル表示
        TownPanel.SetActive(true);
        CheckPanel.SetActive(true);
        //画像を共有
        TownImage.sprite = aCollider2d.GetComponent<SpriteRenderer>().sprite;
        //パラメータ表示
        aCollider2d.GetComponent<TownPro>().SendMessage("ShowPro");
    }

}