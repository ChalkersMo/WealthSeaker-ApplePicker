using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobrSpawnBase : MonoBehaviour
{
    [SerializeField] float TimeToSpawn;
    [SerializeField] GameObject Bobr;
    [SerializeField] GameObject UniqueBobr;
    [SerializeField] GameObject GoldenBobr;
    enum BaseType
    {
        Default,
        Unique,
        Golden
    }
    [SerializeField] BaseType baseType;
    private void Awake()
    {
        StartCoroutine(BobrSpawn());
    }
    IEnumerator BobrSpawn()
    {
        yield return new WaitForSeconds(TimeToSpawn);
        switch (baseType)
        {
            case BaseType.Default:
                {
                    int SpawnQuantity;
                    SpawnQuantity = Random.Range(1, 3);
                    for(int i = 0; i < SpawnQuantity; i++)
                        Instantiate(Bobr);
                }
                break;
            case BaseType.Unique:
                {
                    int SpawnQuantity;
                    SpawnQuantity = Random.Range(1, 5);
                    for (int i = 0; i < SpawnQuantity; i++)
                        Instantiate(UniqueBobr);
                }
                break; 
            case BaseType.Golden:
                {
                    int SpawnQuantity;
                    SpawnQuantity = Random.Range(1, 2);
                    for (int i = 0; i < SpawnQuantity; i++)
                        Instantiate(GoldenBobr);
                }
                break;
        }
    }
}
