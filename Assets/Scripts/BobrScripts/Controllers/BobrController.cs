using UnityEngine;
using UnityEngine.AI;

public class BobrController : MonoBehaviour
{

    public bool IsRunningAway = false;

    [SerializeField] private float bobrSpeed;
    [SerializeField] private float bobrRunningSpeed;


    private NavMeshAgent agent;
    private ApplePool ApplePool;
    private BobrPool BobrPool;

    private Transform targetApple;
    private Transform bobrBase;

    private Collider bobrCollider;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ApplePool = FindFirstObjectByType<ApplePool>();
        BobrPool = FindFirstObjectByType<BobrPool>();
        bobrCollider = GetComponent<Collider>();
        bobrBase = transform.parent;
    }

    public void SetBobrBase(Transform bobrBase)
    {
        this.bobrBase = bobrBase;
        this.bobrBase.position = transform.position;
    }
    public void FindActiveApple()
    {
        try
        {
            targetApple = ApplePool.GetRandomActiveApple().transform;
            agent.speed = bobrRunningSpeed;
        }
        catch
        {
            GoToBase();
        }
    }
    public void SeekApples()
    {
        if (targetApple != null)
        {
            agent.SetDestination(targetApple.position);
        }          
        else
            FindActiveApple();
    }

    public void Wait()
    {
        agent.SetDestination(transform.position);
        agent.speed = 0;
        targetApple = null;
    }
    public void PickUpApple(GameObject apple)
    {
        bobrCollider.enabled = false;
        agent.SetDestination(transform.position);
        agent.speed = 0;
        targetApple = null;
        ApplePool.ReturnBusyApple(apple);
    }

    public void OnCollider()
    {
        bobrCollider.enabled = true;
    }
    public void RunAway()
    {
        IsRunningAway = true;
        agent.speed = bobrRunningSpeed;
        GoToBase();
    }
    public void GoToBase()
    {
        agent.SetDestination(bobrBase.position);
        if (Vector3.Distance(transform.position, bobrBase.position) <= 2)
        {
            Wait();
        }
    }
    public void Die()
    {
        BobrPool.ReturnBobr(gameObject);
    }
}
