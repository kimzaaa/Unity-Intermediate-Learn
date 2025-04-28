using UnityEngine;
using UnityEngine.AI;

public class Battle : State
{
    public Battle(Enemy enemy, UnityEngine.AI.NavMeshAgent agent) : base(enemy, agent)
    {
        Name = STATE.BATTLE;
    }

    private float _attackCooldown = 0.5f;
    public override void Enter(){
        Debug.Log("In Battle State");
        Debug.Log("Attack Player");
        base.Enter();
    }
    public override void Update(){
        float distance = Vector3.Distance(EnemyClass.transform.position, PlayerController.Instance.transform.position);        
        Agent.SetDestination(PlayerController.Instance.transform.position);
        _attackCooldown -= Time.deltaTime;
        if (distance < EnemyClass.AttackRange){
            if (_attackCooldown <= 0f){
            Debug.Log("Attack Player");
            _attackCooldown = 0.5f;
            }
        }
        else{
            NextState = new Chasing(EnemyClass, Agent);
            Debug.Log("Battle -> In Chase State");
            Stage = EVENT.EXIT;
        }

        
    }
    public override void Exit(){
        base.Exit();
    }
}

