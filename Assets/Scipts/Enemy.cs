using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bloodEffect;
    public Animator enemyAnim;
    private SpriteRenderer enemyRen;
    private PlayerHealth playerHealth;
    
    public int health;
    public int damage;
    public float flashTime;
    private Color originalColor;
    
    
    public void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyRen = GetComponent<SpriteRenderer>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        originalColor = enemyRen.color;

    }

    // Update is called once per frame
    public void Update()
    {
        if(health < 0){
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage){
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        FlashColor(flashTime);
        CinemachineShake.Instance.ShakeCamera(3f, .1f);
    }


    void FlashColor(float time){
        enemyRen.color = Color.red;
        Invoke("ResetColor", time);
    }

    void ResetColor(){
        enemyRen.color = originalColor;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D"){
            if(playerHealth != null){
                playerHealth.DamagePlayer(damage);
            }    
        }
    }
}
