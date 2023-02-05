using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    public int Gametime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    IEnumerator CountDown()
    {
        //yield return null;
        //yield return new WaitForSeconds(5f);
        //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        while (Gametime  > 0)
        {
            yield return new WaitForSeconds(1.0f);
            Gametime --;
            Debug.Log(Gametime);
        }
        Debug.Log("カウントダウン終了");

    }
}
