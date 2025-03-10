using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BobrController : MonoBehaviour
{
    public bool IsTimid = false;

    [SerializeField] private float bobrSpeed;
    [SerializeField] private float bobrRunningSpeed;


    private NavMeshAgent agent;
    private ApplePool ApplePool;
    private BobrPool BobrPool;

    private Transform targetApple;
    private Vector3 bobrSpawnPos;

    private Collider bobrCollider;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ApplePool = FindFirstObjectByType<ApplePool>();
        BobrPool = FindFirstObjectByType<BobrPool>();
        bobrCollider = GetComponent<Collider>();       
    }

    private void OnEnable()
    {
        SetBobrBasePosition(transform.position);
    }
    public void SetBobrBasePosition(Vector3 position)
    {
        bobrSpawnPos = position;
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
            if (IsTimid)
                GoToBase();
            else
                Wait();
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
        agent.speed = bobrRunningSpeed;
        GoToBase();
    }
    public void GoToBase()
    {
        agent.SetDestination(bobrSpawnPos);
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
            OnCollider();
            yield return new WaitForSeconds(3);
            BobrPool.ReturnBobr(gameObject);
        }   
    }
}
