using System.Collections.Generic;
using UnityEngine;

public class BobrPool : MonoBehaviour
{
    [SerializeField] private GameObject bobrPrefab;
    [SerializeField] private int poolSize = 3;

    private readonly Queue<GameObject> bobrPool = new();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bobr = Instantiate(bobrPrefab, transform.GetChild(2));
            bobr.SetActive(false);
            bobrPool.Enqueue(bobr);
        }
    }

    public GameObject GetBobr(Vector3 position, Quaternion rotation)
    {
        if (bobrPool.Count > 0)
        {
            Debug.Log(bobrPool.Count);
            GameObject bobr = bobrPool.Dequeue();
            bobr.SetActive(true);
            bobr.transform.SetPositionAndRotation(position, rotation);
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
