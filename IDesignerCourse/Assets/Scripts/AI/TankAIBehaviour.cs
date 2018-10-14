using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankAIBehaviour : MonoBehaviour {
    //Target of the tank
    private GameObject target;

    //Shooting script of the tank
    private TankShooting shootScript;

    private NavMeshAgent agentComponent;

    //Shoot cooldown
    private float CurrentTimerShoot;
    public float TimerShoot = 2f;

    //Distance to player
    private float DistanceToPlayer = 100f;

    //Initial timeout of the AI
    public float InitialTimeout = 3f;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");

        agentComponent = gameObject.GetComponent<NavMeshAgent>();
        shootScript = gameObject.GetComponent<TankShooting>();

        CurrentTimerShoot = TimerShoot;
    }
	
	// Update is called once per frame
	void Update () {
        CurrentTimerShoot -= Time.deltaTime;
        InitialTimeout -= Time.deltaTime;
		if(target != null)
        {
            if(InitialTimeout < 0)
            {
                CalculateDistance();
                MoveToPlayer();

                if (CheckIsFacing() && CurrentTimerShoot < 0)
                {
                    Fire();
                    CurrentTimerShoot = TimerShoot;
                }
            }
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
	}

    private void CalculateDistance()
    {
        if(target != null)
        {
            DistanceToPlayer = Vector3.Distance(gameObject.transform.position, target.transform.position);
        }
    }

    private void MoveToPlayer()
    {
       if(DistanceToPlayer > 10f || !CheckIsFacing())
        {
            Vector3 targetPosition = new Vector3(target.transform.position.x, 0f, target.transform.position.z);
            agentComponent.SetDestination(targetPosition);
        }
       else
        {
            agentComponent.SetDestination(gameObject.transform.position);
        }
    }

    private bool CheckIsFacing()
    {
        if(Vector3.Angle(gameObject.transform.forward, target.transform.position - gameObject.transform.position) < 5f)
        {
            return true;
        }
        return false;
    }

    private void Fire()
    {
        Debug.Log("DistanceToPlayer: " + DistanceToPlayer);
        if(DistanceToPlayer < 20f)
        {
            shootScript.Fire(15f);
        }
        else if(DistanceToPlayer < 30f)
        {
            shootScript.Fire(20f);
        }
        else if(DistanceToPlayer < 40f)
        {
            shootScript.Fire(25f);
        }
        else
        {
            shootScript.Fire(30f);
        }
    }
}
