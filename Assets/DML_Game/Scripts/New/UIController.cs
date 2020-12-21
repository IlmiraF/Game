using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text scoresDisplay;

    void Start()
    {
        GameManager.instance.scoreEvent += ScoreChange;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ScoreChange(int scores)
    {
        if(scoresDisplay != null)
        {
            scoresDisplay.text = scores.ToString();
        }
    }

    void OnDestroy()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
