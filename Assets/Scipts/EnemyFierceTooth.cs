using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFierceTooth : Enemy
{   
    public Transform movePos;
    public Transform leftLimit;
    public Transform rightLimit;
    public Transform self;
    public Vector2 haha;

    public float speed;
    public float waitTime;
    public float startWaitTime;


    public void Start()
    {
        base.Start();
        movePos.position = GetRandomPos();
        waitTime = startWaitTime;
    }

    public void Update()
    {
        base.Update();

        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed*Time.deltaTime);

        if(Vector2.Distance(transform.position, movePos.position) < 0.1f){
            if(waitTime <= 0){
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else{
                waitTime -= Time.deltaTime;
            }
        }
        SwitchAnimation();
    }

    Vector2 GetRandomPos()
    {
        Vector2 randomPos = new Vector2(Random.Range(leftLimit.position.x, rightLimit.position.x), self.position.y);
        return randomPos;
    }

    private void SwitchAnimation()
    {
        if(Vector2.Distance(transform.position, movePos.position) >= 0.1f){
            enemyAnim.SetBool("Run", true);
            if(movePos.position.x > transform.position.x){
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else{
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }   
        else{
            enemyAnim.SetBool("Run", false);
        }
    }
}
