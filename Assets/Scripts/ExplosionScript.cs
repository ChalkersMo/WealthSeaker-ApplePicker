using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    public void Explode()
    {
        explosion.SetActive(true);
    }
}
