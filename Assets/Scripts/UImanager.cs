using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UImanager : MonoBehaviour
{
    [SerializeField] private Text waittimetext;
    private int beforetime;
    [SerializeField] private Ease ease;
    
    // Start is called before the first frame update
    void Start()
    {
        inactivewaittime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void displaywaittime(int waittime)
    {
        waittimetext.DOCounter(beforetime, waittime, 0.5f);
        beforetime = waittime;
    }
    public void setup(int inittime)
    {
        waittimetext.transform.parent.gameObject.SetActive(true);
        beforetime = inittime;
        displaywaittime(beforetime);
    }
    public void inactivewaittime()
    {
        waittimetext.transform.parent.gameObject.SetActive(false);
    }
    public void shakebox()
    {
        waittimetext.transform.parent.gameObject.transform.DOShakeScale(0.25f).SetEase(ease);
    }

}
