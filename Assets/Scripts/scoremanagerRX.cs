using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
public class scoremanagerRX : MonoBehaviour
{
    public ReactiveProperty<int> Score;
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        Score.Subscribe(_ => DisplayScore());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Score.Value += 10;
        }
    }
    private void DisplayScore()
    {
        scoretext.text = Score.ToString();
    }
}
