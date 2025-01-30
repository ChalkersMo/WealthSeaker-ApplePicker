using System.Collections.Generic;
using UnityEngine;

public class ApplePool : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private int poolSize = 10;

    private readonly Queue<GameObject> applePool = new();
    private readonly List<GameObject> activeApples = new ();
    private readonly List<GameObject> busyApples = new();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject apple = Instantiate(applePrefab);
            apple.SetActive(false); 
            applePool.Enqueue(apple); 
        }
    }

    public GameObject GetApple(Vector3 position, Quaternion rotation)
    {
        if (applePool.Count > 0)
        {
            GameObject apple = applePool.Dequeue();
            apple.SetActive(true);
            apple.transform.position = position;
            apple.transform.rotation = rotation;
            activeApples.Add(apple);
            return apple;
        }
        else
        {
            Debug.LogWarning("Apple Pool is empty!");
            return null;
        }
    }

    public void ReturnApple(GameObject apple)
    {
        if (activeApples.Contains(apple))
        {
            apple.SetActive(false);
            activeApples.Remove(apple);
            applePool.Enqueue(apple);
        }
        else if (busyApples.Contains(apple))
        {
            apple.SetActive(false);
            busyApples.Remove(apple);
            applePool.Enqueue(apple);
        }
    }

    public GameObject GetRandomActiveApple()
    {
        if (activeApples.Count > 0)
        {
            int randomIndex = Random.Range(0, activeApples.Count);
            GameObject randomApple = activeApples[randomIndex];

            activeApples.RemoveAt(randomIndex);
            busyApples.Add(randomApple);

            return randomApple;
        }
        else
        {
            Debug.LogWarning("No active apples available!");
            return null;
        }
    }

    public void ReturnBusyApple(GameObject apple)
    {
        if (busyApples.Contains(apple))
        {
            apple.SetActive(false);
            busyApples.Remove(apple);
            applePool.Enqueue(apple);
        }
        else
        {
            ReturnApple(apple);
        }
    }
}
