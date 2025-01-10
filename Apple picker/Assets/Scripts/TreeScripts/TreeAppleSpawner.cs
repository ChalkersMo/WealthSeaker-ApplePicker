using System.Collections;
using UnityEngine;

public class TreeAppleSpawner : MonoBehaviour
{
    [SerializeField] GameObject DefaultApple;
    [SerializeField] GameObject UniqueApple;
    [SerializeField] GameObject GoldenApple;
    [SerializeField] GameObject BoomEffect;
    Collider Collider;
    Vector3 minBounds;
    Vector3 maxBounds;
    Animator animator;

    enum TreeType 
    {
        Default,
        Unique,
        Golden
    }
    [SerializeField] TreeType treeType;

    private void Start()
    {
        Collider = GetComponent<Collider>();
        animator = transform.parent.GetComponent<Animator>();
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
                GameObject Apple = Instantiate(DefaultApple);
                Apple.transform.position = randomPointInsideCollider;
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
                GameObject Apple = Instantiate(UniqueApple);
                Apple.transform.position = randomPointInsideCollider;
            }
        }
    }

    IEnumerator GoldenSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
        }
    }
}
