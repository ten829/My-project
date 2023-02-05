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
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out changematerial);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && isboxgenerate == true)
        {
            createbox();
 
        }
        if (Input.GetKey(KeyCode.C) && isboxgenerate == true)
        {
            //this.GetComponent<PlayerController>().enabled = false;
            Addtimer();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            //this.GetComponent<PlayerController>().enabled = true;
        }

        
    }

    public void Addtimer()
    {
        timer += Time.deltaTime;
        if (timer >= 5f )
        {
            //timer = 0f;
            createbox();
             
        }
    }

    public void createbox()
    {
        //isboxgenerate = false;
        GameObject box = Instantiate(boxprefab, spowner.transform.position, Quaternion.identity);
        StartCoroutine(Sizeup(box));
    }
    public IEnumerator Sizeup(GameObject box)
    {
        bool isset = Input.GetKey(KeyCode.C);
        while (timer <= 5f && isset == true)
        {
            isset = Input.GetKey(KeyCode.C);
            Debug.Log("while");
            if(timer < 1f)
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
            yield return null;
        
        }
        isboxgenerate = false;
        changematerial.changeblockcolor(box);
        timer = 0f;
        yield return new WaitForSeconds(5f);
        isboxgenerate = true;
        
    }
}
