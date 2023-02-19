using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxgeneration : MonoBehaviour
{
    public float timer;
    [SerializeField] GameObject spowner;
    [SerializeField] GameObject boxprefab;
    changematerial changematerial;
    bool isboxgenerate = true;
    [SerializeField] private float waitTime = 1.0f;
    [SerializeField] private UImanager UImanager;
    int waittimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out changematerial);
    }

    // Update is called once per frame
    void Update()
    {
        if (isboxgenerate == false && waittimer != 0)
        {
            UImanager.shakebox();
            return;
        }
        if (Input.GetKeyDown(KeyCode.C) && isboxgenerate == true)
        {
            createbox();
 
        }
        if (Input.GetKey(KeyCode.C))
        {
            //this.GetComponent<PlayerController>().enabled = false;
            Addtimer();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            timer = 0f;
            //this.GetComponent<PlayerController>().enabled = true;
        }

        
    }

    public void Addtimer()
    {
        timer += Time.deltaTime;
        
    }

    public void createbox()
    {
        //isboxgenerate = false;
        GameObject box = Instantiate(boxprefab, spowner.transform.position, Quaternion.identity);
        StartCoroutine(Sizeup(box));
    }
    public IEnumerator Sizeup(GameObject box)
    {
        waittimer = (int)waitTime;
        bool isset = Input.GetKey(KeyCode.C);
        while (timer <= 5f && isset == true)
        {
            isset = Input.GetKey(KeyCode.C);
            Debug.Log("while");
            if (timer < 1f)
            {

            }
            else if (1f <= timer && timer <= 2f)
            {
                box.transform.localScale = Vector3.one * 1.5f;
            }
            else if (2f < timer)
            {

                box.transform.localScale = Vector3.one * 2f;
                //this.GetComponent<PlayerController>().enabled = true;
            }
            if (timer > 5.0f)
            {
                isset = false;
            }
            yield return null;
        
        }
        isboxgenerate = false;
        changematerial.changeblockcolor(box);
        //waittimer = (int)waitTime;
        UImanager.setup(waittimer);
        while (waittimer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            waittimer--;
            UImanager.displaywaittime(waittimer);
        }
        UImanager.inactivewaittime();
        //timer = 0f;
        //yield return new WaitForSeconds(waitTime);
        isboxgenerate = true;
        
    }
}
