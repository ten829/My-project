using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxclass : MonoBehaviour
{
    public void boxaccess()
    {
        Debug.Log("アクセス済");
        gameObject.AddComponent<Rigidbody>();
        
    }
    public void selectbox()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
