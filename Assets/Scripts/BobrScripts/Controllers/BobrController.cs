using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BobrController : MonoBehaviour
{
    public bool IsTimid = false;
    public bool isChasingByPlayer = false;

    [SerializeField] private float bobrSpeed;
    [SerializeField] private float bobrRunningSpeed;

    private NavMeshAgent agent;
    private ApplePool ApplePool;
    private BobrPool BobrPool;
    private BobrStateMachine StateMachine;

    private Transform targetApple;
    private Vector3 bobrSpawnPos;

    private Vector3 lastTargetPosition;

    private Collider bobrCollider;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ApplePool = FindFirstObjectByType<ApplePool>();
        BobrPool = FindFirstObjectByType<BobrPool>();
        bobrCollider = GetComponent<Collider>();
        StateMachine = GetComponent<BobrStateMachine>();
    }

    private void OnEnable()
    {
        Invoke(nameof(SetBobrBasePosition),0.2f);
        agent.Warp(transform.position);
    }
    public void SetBobrBasePosition()
    {
        bobrSpawnPos = transform.position;
    }
    public void FindActiveApple()
    {
        try
        {
            targetApple = ApplePool.GetRandomActiveApple().transform;
            agent.speed = bobrRunningSpeed;
            if(!isChasingByPlayer)
                StateMachine.SwitchState(StateMachine.BobrSeekingState);
        }
        catch
        {
            if (IsTimid)
            {
                agent.speed = bobrRunningSpeed;
                GoToBase();
            }

            else
                Wait();
        }
    }
    public void SeekApples()
    {
        if (targetApple != null)
        {
            if (lastTargetPosition != targetApple.position)
            {
                if (agent.isOnNavMesh && !agent.pathPending)
                {
                    agent.SetDestination(targetApple.position);
                    lastTargetPosition = targetApple.position;
                }
            }

            if (agent.remainingDistance <= 0.1f && !agent.pathPending)
            {
                FindActiveApple();
            }
        }
        else
        {
            FindActiveApple();
        }
    }


    public void Wait()
    {
        agent.isStopped = true;
        targetApple = null;
        if(StateMachine.currentState != StateMachine.BobrHumilityState)
            StateMachine.SwitchState(StateMachine.BobrHumilityState);
    }
    public void PickUpApple(GameObject apple)
    {
        bobrCollider.enabled = false;
        agent.isStopped = true;
        targetApple = null;
        ApplePool.ReturnBusyApple(apple);
    }
    public void OnAgent()
    {
        agent.isStopped = false;
        agent.speed = bobrRunningSpeed;
    }
    public void OnCollider()
    {
        bobrCollider.enabled = true;
    }
    public void RunAway()
    {
        agent.speed = bobrRunningSpeed;
        GoToBase();
        isChasingByPlayer = true;
    }
    public void GoToBase()
    {
        agent.SetDestination(bobrSpawnPos);
        CheckRunPos();
    }
    public void CheckRunPos()
    {
        if (Vector3.Distance(transform.position, bobrSpawnPos) <= 2)
        {
            Wait();
        }
    }
    public void Die()
    {
        StartCoroutine(die());
        IEnumerator die()
        {
            Wait();
            OnCollider();
            yield return new WaitForSeconds(3);
            BobrPool.ReturnBobr(gameObject);
        }   
    }
}
