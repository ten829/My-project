using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoremanager : MonoBehaviour
{
    public int score;
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            score += 10;
            DisplayScore();
        }
        
    }
    private void DisplayScore()
    {
        scoretext.text = score.ToString();
    }

}
