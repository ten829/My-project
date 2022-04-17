using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class body : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            transform.DOScale(Vector3.one * 0.5f, 1.0f).SetEase(Ease.InBack);

        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            transform.DOScale(Vector3.one, 1.0f).SetEase(Ease.InBack);
        }

        
    }
}
