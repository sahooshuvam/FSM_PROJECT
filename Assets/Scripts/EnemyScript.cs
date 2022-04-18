using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public enum STATE { LOOKFOR,GOTO, ATTACK,DEAD};
    public STATE currentState = STATE.LOOKFOR;
    public float enemySpeed;
    public float gotoDistance;
    public float attackDistance;
    public Transform target;
    public string playerTag;
    public float attackTime;
    public float currentTime;
    PlayerScript player;


      // Start is called before the first frame update\

      IEnumerator Start()
    {
        currentTime = attackTime;
        if (target!= null)
        {
            player = target.GetComponent<PlayerScript>();
        }
        while (true)
        {
            switch (currentState)
            {
                case STATE.LOOKFOR: LookForMethod();
                    break;
                case STATE.GOTO: GotoMethod();
                    break;
                case STATE.ATTACK: AttackMethod();
                    break;
                case STATE.DEAD: DeadMethod();
                    break;
                default:
                    break;
            }
            yield return 0;
        }      
    }

    private void DeadMethod()
    {
        print("Game Over");
    }

    private void AttackMethod()
    {
        currentTime = currentTime - Time.deltaTime;
        if (currentTime <= 0f)
        {
            player.health--;
            currentTime = attackTime;
        }
        if (player.health <=0)
        {
            currentState = STATE.DEAD;
        }
        if (Vector3.Distance(target.transform.position,this.transform.position)>attackDistance)
        {
            currentState = STATE.GOTO;
        }
        print("Attack Method");
    }

    private void GotoMethod()
    {
        if (Vector3.Distance(target.transform.position, this.transform.position) > attackDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
        }
        else
        {
            currentState = STATE.ATTACK;
        }
        print("Goto Method");
    }

    private void LookForMethod()
    {
        if (Vector3.Distance(target.transform.position, this.transform.position) < gotoDistance)
        {
            currentState = STATE.GOTO;
        }
        print("LookFor Method");
    }
}
