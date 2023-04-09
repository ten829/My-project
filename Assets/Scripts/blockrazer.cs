using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockrazer : MonoBehaviour
{
    [SerializeField] bool isblockrayon;
    [SerializeField] float raydistance;
    [SerializeField] Transform rayposition;
    [SerializeField] boxclass boxclass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(isblockrayon == false)
        {
            return;
        }
        Ray ray = new Ray(rayposition.position, rayposition.forward);
        //Debug.DrawRay(ray.origin,ray.direction * raydistance,Color.blue,0.5f);
        RaycastHit hit;
        if(Physics.Raycast(ray.origin,ray.direction * raydistance,out hit) == false)
        {
            return;
        }
        //Debug.Log(hit.collider.gameObject.name);
        if(hit.collider.TryGetComponent(out boxclass))
        {
            Debug.Log("box見つけた");
            switchray();
            boxclass.boxaccess();

        }
    }

    public void switchray()
    {
        isblockrayon = !isblockrayon;
        
    }





}
