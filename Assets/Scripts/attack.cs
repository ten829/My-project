using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField] BoxCollider BoxCollider;
    private Animator anim;
    public bool Isattackbottun;
    [SerializeField] attackcollision attackcollisionprefab;
    [SerializeField] Transform attackcollisiontra;
    [SerializeField] float forcepower;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if(Isattackbottun == false)
        {
            return ;
        }
        if (Input.GetButtonDown("Fire1") && !anim.IsInTransition(0))
        {
            Attackanim();
        }
    }
    public void Attackanim()
    {
        anim.SetTrigger("attack");
    }
    public void collideron()
    {
        Debug.Log("collideron");
        BoxCollider.enabled = true;
        //ここでattackcollision生成
        attackcollision attackcollision = Instantiate(attackcollisionprefab, attackcollisiontra.position, Quaternion.identity);
        attackcollision.setup(forcepower);
        Destroy(attackcollision.gameObject,0.5f);

    }
    public void collideroff()
    {
        Debug.Log("collideroff");
        BoxCollider.enabled = false;

    }
}
