using System.Collections;
using UnityEngine;

public class TreeAppleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject BoomEffect;

    [SerializeField] private float timeToSpawn;
    [SerializeField] private float maxAppleSpawnCount;

    private ApplePool applePool;
    private Collider Collider;
    private Vector3 minBounds;
    private Vector3 maxBounds;
    private Animator animator;

    private void Start()
    {
        Collider = GetComponent<Collider>();
        animator = transform.parent.GetComponent<Animator>();
        applePool = GetComponent<ApplePool>();
        minBounds = Collider.bounds.min;
        maxBounds = Collider.bounds.max;

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToSpawn);
            animator.SetTrigger("Spawning");
            yield return new WaitForSeconds(1);
            BoomEffect.SetActive(true);
            for (int i = 0; i < maxAppleSpawnCount; i++)
            {
                float randomX = Random.Range(minBounds.x, maxBounds.x);
                float randomY = Random.Range(minBounds.y, maxBounds.y);
                float randomZ = Random.Range(minBounds.z, maxBounds.z);
                Vector3 randomPointInsideCollider = new(randomX, randomY, randomZ);
                applePool.GetApple(randomPointInsideCollider, Quaternion.identity);
            }
        }     
    }
}
