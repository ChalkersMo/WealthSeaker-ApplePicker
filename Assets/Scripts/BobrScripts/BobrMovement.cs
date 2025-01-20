using UnityEngine;
using UnityEngine.AI;

public class BobrMovement : MonoBehaviour
{
    [SerializeField] Transform _TargetApple;
    NavMeshAgent agent;
    [SerializeField] Transform SpawnBase;

    enum BobrType
    {
        Default,
        Unique,
        Golden
    }
    [SerializeField] BobrType bobrType;
    [SerializeField]bool HaveTarget;

    private void Awake()
    {
        agent = transform.parent.GetComponent<NavMeshAgent>();
        try
        {
            _TargetApple = FindingApple();
        }
        catch { }
    }
    private void FixedUpdate()
    {
        if (_TargetApple != null)
        {
            agent.SetDestination(_TargetApple.position);
            transform.parent.LookAt(_TargetApple.transform);
        }
        else
        {
            _TargetApple = FindingApple();
           
            if (SpawnBase != null)
                agent.SetDestination(SpawnBase.position);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Apple") || other.gameObject.CompareTag("UniqueApple") || other.gameObject.CompareTag("GoldenApple"))
        {
            Destroy(other.gameObject);
            _TargetApple = null;
        }
    }

    Transform FindingApple()
    {
        Transform TargetApple;
        switch (bobrType)
        {
            case BobrType.Default:
                {
                    try
                    {
                        TargetApple = GameObject.FindGameObjectWithTag("Apple").transform;
                    }
                    catch
                    {
                        TargetApple = null;
                    }
                }
                break;
            case BobrType.Unique:
                {
                    try
                    {
                        TargetApple = GameObject.FindGameObjectWithTag("UniqueApple").transform;
                    }
                    catch
                    {
                        TargetApple = null;
                    }
                }
                break;
            case BobrType.Golden:
                {
                    try
                    {
                        TargetApple = GameObject.FindGameObjectWithTag("GoldenApple").transform;
                    }
                    catch
                    {
                        TargetApple = null;
                    }                  
                }
                break;

            default:
                TargetApple = GameObject.FindGameObjectWithTag("Apple").transform;
                break;
        }
        return TargetApple;
    }
}
