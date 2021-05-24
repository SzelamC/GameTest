using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator enemyAnim;
    private SpriteRenderer enemyRen;
    public int health;
    public int damage;
    public float flashTime;
    private Color originalColor;
    
    
    public void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyRen = GetComponent<SpriteRenderer>();
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
        health -= damage;
        FlashColor(flashTime);
    }

    void FlashColor(float time){
        enemyRen.color = Color.red;
        Invoke("ResetColor", time);
    }

    void ResetColor(){
        enemyRen.color = originalColor;
    }
}
