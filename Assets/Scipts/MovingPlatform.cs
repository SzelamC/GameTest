using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float movingSpeed;
    public float waitTime;
    public Transform[] movePos;
    private Transform playerDefaultTransform;

    private int i;

    void Start()
    {
        i = 1;
        playerDefaultTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, movingSpeed * Time.deltaTime);
        if(Vector2.Distance(transform.position, movePos[i].position) < 0.1f){
            if(waitTime < 0){
                if(i==0){
                    i = 1;
                }
                else{
                    i = 0;
                }
                waitTime = 0.5f;
            }
            else{
                waitTime -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2d(Collider2D other) 
    {
        if(other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D"){
            other.gameObject.transform.parent = gameObject.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D"){
            other.gameObject.transform.parent = playerDefaultTransform;
        }
    }
}
