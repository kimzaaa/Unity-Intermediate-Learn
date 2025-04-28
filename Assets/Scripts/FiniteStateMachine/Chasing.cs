using UnityEngine;
using UnityEngine.AI;

public class Chasing : State
{
    public Chasing(Enemy enemy, NavMeshAgent agent) : base(enemy, agent)
    {
        Name = STATE.CHASING;
    }

    public override void Enter(){
        //Agent.SetDestination(PlayerController.Instance.transform.position);
        base.Enter();
    }
    public override void Update(){
        Agent.SetDestination(PlayerController.Instance.transform.position);

        float distance = Vector3.Distance(EnemyClass.transform.position, PlayerController.Instance.transform.position);
        if (distance < EnemyClass.AttackRange)
        {
            NextState = new Battle(EnemyClass, Agent);
            Debug.Log("Chasing -> In Battle State");
            Stage = EVENT.EXIT;
        }
        else if(distance > EnemyClass.DetectionRange)
        {
            NextState = new Roaming(EnemyClass, Agent);
            Debug.Log("Chasing -> In Roaming State");
            Stage = EVENT.EXIT;
        }
        
    }
    public override void Exit(){
        base.Exit();
    }
}

