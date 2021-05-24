using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PolygonCollider2D hitBox;
    private Animator attackAnim;
    public int attactPower;
    private bool attackPress;
    public float startTime;
    public float endTime;
    void Start()
    {
        hitBox = GetComponent<PolygonCollider2D>();
        attackAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void Update()
    {
        attackPress = Input.GetButtonDown("Fire2");
        Attack();
    }

    void Attack()
    {
        if(attackPress){
            attackAnim.SetTrigger("PlayerAttack_2");
            StartCoroutine(EnableHitBox());
        }
    }

    IEnumerator EnableHitBox()
    {
        yield return new WaitForSeconds(startTime);
        hitBox.enabled = true;
        StartCoroutine(DisableHitBox());
    }

    IEnumerator DisableHitBox()
    {
        yield return new WaitForSeconds(endTime);
        hitBox.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            other.GetComponent<Enemy>().TakeDamage(attactPower);
        }
    }
}
