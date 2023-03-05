using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackcollision : MonoBehaviour
{
    private float forcepower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setup(float forcepower)
    {
        this.forcepower = forcepower;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Rigidbody rb))
        {
            Vector3 Direction = other.transform.position - this.transform.position;
            rb.AddForce(Direction * forcepower);
        }
    }
}
