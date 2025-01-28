using System.Collections;
using UnityEngine;

public class TreeAppleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject BoomEffect;

    [SerializeField] private TreeType treeType;

    private ApplePool applePool;
    private Collider Collider;
    private Vector3 minBounds;
    private Vector3 maxBounds;
    private Animator animator;

    private enum TreeType 
    {
        Default,
        Unique,
        Golden
    }

    private void Start()
    {
        Collider = GetComponent<Collider>();
        animator = transform.parent.GetComponent<Animator>();
        applePool = GetComponent<ApplePool>();
        minBounds = Collider.bounds.min;
        maxBounds = Collider.bounds.max;

        switch (treeType)
        {
            case TreeType.Default:
                {
                    StartCoroutine(DefaultSpawner());
                }
                break;
            case TreeType.Unique:
                {
                    StartCoroutine(UniqueSpawner());
                }
                break;
            case TreeType.Golden:
                {
                    StartCoroutine(GoldenSpawner());
                }
                break;

            default: break;
        }
    }

    IEnumerator DefaultSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(19);
            animator.SetTrigger("Spawning");
            yield return new WaitForSeconds(1);
            BoomEffect.SetActive(true);
            for (int i = 0; i < 10; i++)
            {
                float randomX = Random.Range(minBounds.x, maxBounds.x);
                float randomY = Random.Range(minBounds.y, maxBounds.y);
                float randomZ = Random.Range(minBounds.z, maxBounds.z);
                Vector3 randomPointInsideCollider = new Vector3(randomX, randomY, randomZ);
                Instantiate(applePool.GetApple(randomPointInsideCollider, Quaternion.identity));
            }
        }     
    }

    IEnumerator UniqueSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(14);
            animator.SetTrigger("Spawning");
            yield return new WaitForSeconds(1);
            BoomEffect.SetActive(true);
            for (int i = 0; i < 10; i++)
            {
                float randomX = Random.Range(minBounds.x, maxBounds.x);
                float randomY = Random.Range(minBounds.y, maxBounds.y);
                float randomZ = Random.Range(minBounds.z, maxBounds.z);
                Vector3 randomPointInsideCollider = new Vector3(randomX, randomY, randomZ);
                Instantiate(applePool.GetApple(randomPointInsideCollider, Quaternion.identity));
            }
        }
    }

    IEnumerator GoldenSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(60);
            animator.SetTrigger("Spawning");
            yield return new WaitForSeconds(1);
            BoomEffect.SetActive(true);
            for (int i = 0; i < 1; i++)
            {
                float randomX = Random.Range(minBounds.x, maxBounds.x);
                float randomY = Random.Range(minBounds.y, maxBounds.y);
                float randomZ = Random.Range(minBounds.z, maxBounds.z);
                Vector3 randomPointInsideCollider = new Vector3(randomX, randomY, randomZ);
                Instantiate(applePool.GetApple(randomPointInsideCollider, Quaternion.identity));
            }
        }
    }
}
