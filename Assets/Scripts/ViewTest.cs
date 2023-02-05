using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTest : MonoBehaviour
{
    public Text scoretext;
    public Text hptext;

    public void DisplayScore(int Score)
    {
        scoretext.text = Score.ToString();
    }

    public void DisplayHp(int HP)
    {
        hptext.text = HP.ToString();
    }
}

