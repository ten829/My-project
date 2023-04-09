using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxgeneration : MonoBehaviour
{
    public float timer;
    [SerializeField] GameObject spowner;
    [SerializeField] GameObject airspowner;
    [SerializeField] GameObject boxprefab;
    changematerial changematerial;
    bool isboxgenerate = true;
    [SerializeField] private float waitTime = 1.0f;
    [SerializeField] private UImanager UImanager;
    [SerializeField] private jump jump;
    [SerializeField] private int maxgeneratecount;
    [SerializeField] private List<GameObject> boxlist = new List<GameObject>();
    int waittimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out changematerial);
    }

    // Update is called once per frame
    void Update()
    {
        //if (boxlist.Count >= maxgeneratecount)
        //{
           // return;
        //}
        if (Input.GetButtonDown("Fire2") && waittimer != 0)
        {
            UImanager.shakebox();
            
        }
        if (Input.GetButtonDown("Fire2") && isboxgenerate == true)
        {
            createbox();
 
        }
        if (Input.GetButton("Fire2"))
        {
            //this.GetComponent<PlayerController>().enabled = false;
            Addtimer();
        }
        if (Input.GetButtonUp("Fire2"))
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
        GameObject box = null;
        if (jump.isGround == true)
        {
            //isboxgenerate = false;
            box = Instantiate(boxprefab, spowner.transform.position, Quaternion.identity);
            box.transform.SetParent(spowner.transform);
            
        }
        else
        {
            box = Instantiate(boxprefab, airspowner.transform.position, Quaternion.identity);
            box.transform.SetParent(airspowner.transform);
        }
        
        if(boxlist.Count >= maxgeneratecount)
        {
            Destroy(boxlist[0]);
            boxlist.Remove(boxlist[0]);

            boxlist.Add(box);

        }
        else
        {
            boxlist.Add(box);
        }

        StartCoroutine(Sizeup(box));


    }
    public IEnumerator Sizeup(GameObject box)
    {
        
        bool isset = Input.GetButton("Fire2");
        while (timer <= 5f && isset == true)
        {
            isset = Input.GetButton("Fire2");
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
        box.transform.SetParent(null);

        waittimer = (int)waitTime;
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