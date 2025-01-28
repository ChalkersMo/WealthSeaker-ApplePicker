using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeZoneTrigging : MonoBehaviour
{
    [SerializeField] private GameObject SignObj;
    private GameObject Tree;
    private void Start()
    {
        Tree = transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Tree.SetActive(true);
            SignObj.SetActive(false);
            GetComponent<Collider>().enabled = false;
        }
    }

}
