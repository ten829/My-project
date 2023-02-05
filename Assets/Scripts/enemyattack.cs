using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyattack : MonoBehaviour
{
    public Animator anim;
    private attack attack;
    [SerializeField] CapsuleCollider CapsuleCollider;
    PlayerController playerController;
    public int enemydamage = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out attack);
        
        //anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.TryGetComponent(out playerController))
        {
            Debug.Log("プレイヤーの情報を取得");
            StartCoroutine(Attackanim());
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out playerController))
        {
            //playerController = null;
        }
    }
    public IEnumerator Attackanim()
    {
        float timer = 0f;
        Debug.Log("攻撃開始");
        while (playerController != null)
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                anim.SetTrigger("attack");
                timer = 0f;
            }
            yield return null;
        }
        Debug.Log("攻撃終了");    
    }
    public void collideron()
    {
        Debug.Log("collideron");
    }
    public void collideroff()
    {
        Debug.Log("collideroff");
    }
}
