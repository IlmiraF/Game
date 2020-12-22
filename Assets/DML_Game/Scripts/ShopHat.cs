using UnityEngine;
using UnityEngine.UI;

public class ShopHat : MonoBehaviour
{
    public Text scoresDisplay;

    public int price = 0;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;

    private bool pricebool;

    void Start()
    {
        GameManager.instance.scoreEvent += ScoreChange;
    }

    void Update()
    {
        if(pricebool)
        {
            if(GameManager.instance._UserScores >= price)
            {
                if (Item1.activeSelf)
                {
                    pricebool = false;
                }
                else
                {
                    Item1.SetActive(true);
                    Item2.SetActive(false);
                    Item3.SetActive(false);
                    GameManager.instance._UserScores -= price;
                    ScoreChange(GameManager.instance._UserScores);
                }
            } 
            else
            {
                pricebool = false;
            }
        }
    }

    void ScoreChange(int scores)
    {
        if (scoresDisplay != null)
        {
            scoresDisplay.text = scores.ToString();
        }
    }

    public void Buy()
    {
        pricebool = true;
    }
}
