using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody rb;
    [SerializeField]
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
 
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        
    }
    private void FixedUpdate()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y ,0);

        if (moveForward!= Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

}
