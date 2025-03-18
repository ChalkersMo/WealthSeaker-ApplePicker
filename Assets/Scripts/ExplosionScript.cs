using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    public void Explode()
    {
        explosion.Play();
    }
}
