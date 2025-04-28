using UnityEngine;
using UnityEngine.AI;

public class Roaming : State
{
    public Roaming(Enemy enemy, NavMeshAgent agent) : base(enemy, agent)
    {
        Name = STATE.ROAMING;
    }

    public override void Enter()
    {
        Debug.Log("In Roaming State");
        // How many location to patrol
        int locationQuantity = EnemyClass.ObserveLocation.Length;

        // We gonna go there
        Agent.SetDestination(SearchWaypoint(locationQuantity));
        
        base.Enter();
    }

    public override void Update()
    {
        if (Agent.remainingDistance < .5f)
        {
            //If remaining distance is less than 0.5m
            //Set NextState to Idle
            //And Change State to Exit
            NextState = new Idle(EnemyClass, Agent);
            Stage = EVENT.EXIT;

            // How many location to patrol
            int locationQuantity = EnemyClass.ObserveLocation.Length;

            // We gonna go there
            // Agent.SetDestination(SearchWaypoint(locationQuantity));
        }
        
        // base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }

    private Vector3 SearchWaypoint(int locationQuantity)
    {
        //Random POIs(Point of interests)
        int index = Random.Range(0, locationQuantity);
        
        //Set estimate destination
        Vector3 destination = EnemyClass.ObserveLocation[index].position;

        /*Find if Navmesh exist on that position or not
         If not find the closest one,
         If there's no closest one random another point*/
        NavMeshHit hit;
        if (NavMesh.SamplePosition(destination, out hit, 1.0f, NavMesh.AllAreas))
        {
            destination = hit.position;
        }
        else destination = SearchWaypoint(locationQuantity);
        
        return destination;
    }
}