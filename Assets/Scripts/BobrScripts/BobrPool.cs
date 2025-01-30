using System.Collections.Generic;
using UnityEngine;

public class BobrPool : MonoBehaviour
{
    [SerializeField] private GameObject bobrPrefab;
    [SerializeField] private int poolSize = 3;

    private Queue<GameObject> bobrPool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bobr = Instantiate(bobrPrefab);
            bobr.SetActive(false);
            bobrPool.Enqueue(bobr);
        }
    }

    public GameObject GetBobr(Vector3 position, Quaternion rotation)
    {
        if (bobrPool.Count > 0)
        {
            GameObject bobr = bobrPool.Dequeue();
            bobr.SetActive(true);
            bobr.transform.position = position;
            bobr.transform.rotation = rotation;
            return bobr;
        }
        else
        {
            Debug.LogWarning("Bobr Pool is empty!");
            return null;
        }
    }

    public void ReturnBobr(GameObject bobr)
    {
        bobr.SetActive(false);
        bobrPool.Enqueue(bobr);
    }
}
