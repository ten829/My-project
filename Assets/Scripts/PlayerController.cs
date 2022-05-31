using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody rb;
    [SerializeField]
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out anim);
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
            anim.SetFloat("Speed", 1);
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
        else{
            anim.SetFloat("Speed", 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("触った");
        if(other.gameObject.TryGetComponent(out enterdungeon enterdungeon)) {
            SceneManager.LoadScene(enterdungeon.dungeonname.ToString());


        }

    }
}