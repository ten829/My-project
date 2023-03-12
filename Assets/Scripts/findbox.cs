using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findbox : MonoBehaviour
{
    [SerializeField] GameObject rayposition;
    [SerializeField] private float raydistance = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            generateray();
        }
       
        
    }
    private void generateray()
    {
        Ray ray = new Ray(rayposition.transform.position, rayposition.transform.forward);
        //Debug.DrawRay(ray.origin, ray.direction * raydistance, Color.blue, 1.0f);
        if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, raydistance))
        {
            if(hit.collider.TryGetComponent(out boxclass boxclass))
            {
                boxclass.boxaccess();
            }

        }
    }
}
