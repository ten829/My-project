using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class presenterTest : MonoBehaviour
{
    public ModelTest modeltest;
    public ViewTest viewtest;
    public hp hp;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        modeltest.Score.Subscribe(score => viewtest.DisplayScore(score));
        hp.OnTriggerEnterAsObservable()
            .Where(other => other.gameObject.TryGetComponent(out enemyattack enemyattack))
            .Subscribe(other => {
                if (other.gameObject.TryGetComponent(out enemyattack enemyattack))
                {
                    Debug.Log("当たり判定取得");
                    hp.Health.Value -= enemyattack.enemydamage;

                }
            });
        hp.Health.Subscribe(HP => viewtest.DisplayHp(HP));

        button.OnClickAsObservable()
            .ThrottleFirst(System.TimeSpan.FromSeconds(5))
            .Subscribe(_ => Debug.Log("Click"));

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            modeltest.Score.Value += 10;
        }
        
    }

}
