using System.Collections.Generic;
using UnityEngine;

public class AxePool : MonoBehaviour
{
    public GameObject axePrefab;
    public int poolSize = 15;

    private Queue<GameObject> axePool;

    void Awake()
    {
        axePool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject axe = Instantiate(axePrefab, transform.GetChild(3));
            axe.SetActive(false);
            axePool.Enqueue(axe);
        }
    }

    public GameObject GetAxe(Vector3 pos)
    {
        if (axePool.Count > 0)
        {
            GameObject axe = axePool.Dequeue();
            axe.SetActive(true);
            axe.transform.position = pos;
            return axe;
        }
        else
        {
            Debug.LogWarning("Axe pool is empty");
            return null;
        }
    }

    public void ReturnAxe(GameObject axe)
    {
        axe.SetActive(false);
        axePool.Enqueue(axe);
    }
}
