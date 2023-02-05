using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changematerial : MonoBehaviour
{
    [SerializeField] Material white;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeblockcolor(GameObject target)
    {
        target.GetComponent<MeshRenderer>().material = white;
    }
}
