using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Renderer playerRender;
    public int playerHealth;
    public int numBlinks;
    public float seconds;
    
    void Start()
    {
        playerRender = GetComponent<Renderer>();
        PlayerHealthBar.healthMax = playerHealth;
        PlayerHealthBar.healthCurrent = playerHealth;
    }

    public void DamagePlayer(int damage)
    {
        playerHealth -= damage;
        if(playerHealth < 0){
            playerHealth = 0;
        }
        PlayerHealthBar.healthCurrent = playerHealth;
        if(playerHealth <= 0){
            Destroy(gameObject);
        }
        BlinkPlayer(numBlinks, seconds);
    }

    private void BlinkPlayer(int num, float time)
    {
        StartCoroutine(DoBlink(num, time));
    }

    IEnumerator DoBlink(int num, float time)
    {
        for(int i=0; i<num*2; i++){
            playerRender.enabled = !playerRender.enabled;
            yield return new WaitForSeconds(time);            
        }
        playerRender.enabled = true;
    }
}
