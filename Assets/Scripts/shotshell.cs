using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotshell : MonoBehaviour
{
    public float shotSpeed;
    public float Destroytime;
    [SerializeField]
    private GameObject shellPrefab;
    [SerializeField]
    private AudioClip shotSound;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("gun");
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            shellRb.AddForce(transform.forward * shotSpeed);
            Destroy(shell, Destroytime);
            if (shotSound != null)
            {
                AudioSource.PlayClipAtPoint(shotSound, transform.position);
            }
            
        }

        
    }
}
