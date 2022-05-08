using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chase : MonoBehaviour
{
    [SerializeField]
    private GameObject lookTarget;
    [SerializeField]
    private float movespeed;

    private NavMeshAgent agent;

    public void SetUpEemy()
    {
        if (TryGetComponent(out agent))
        {
            agent.destination = lookTarget.transform.position;
            //agent.speed = movespeed;
            Debug.Log("設定完了");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUpEemy();
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (lookTarget)
        {
            Vector3 direction = lookTarget.transform.position - transform.position;
            direction.y = 0;

            Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);
        }
        if  (lookTarget != null && agent != null)
        {
            agent.destination = lookTarget.transform.position;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerController PlayerController))
        {
            agent.speed = movespeed;
            Debug.Log("見つけた");
        }
        //else
        //{
            //agent.speed = 0f;
        //}
    }
}
