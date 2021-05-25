using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    public float scrollSpeed;
    Vector2 startPos;
    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        if(transform.position.x < -30f){
            transform.position = new Vector3(-2, transform.position.y, transform.position.z);
        }
        transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed);
    }
}
