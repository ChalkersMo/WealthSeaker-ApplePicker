using System.Collections;
using UnityEngine;

public class BobrSpawnBase : MonoBehaviour
{
    [Header("Spawner setup")]
    [SerializeField] private float TimeToSpawn;

    [Header("Raycast setup")]
    [SerializeField] private float distanceBetweenCheck;
    [SerializeField] private float heightOfCheck = 25f, rangeOfCheck = 30f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Vector2 positivePosition, negativePosition;

    private float treesCount;

    private BobrPool bobrPool;

    private void Start()
    {
        bobrPool = GetComponent<BobrPool>();
        treesCount = transform.GetChild(0).childCount;
        StartCoroutine(BobrSpawn());
    }

    IEnumerator BobrSpawn()
    {
        while (treesCount > 0)
        {
            yield return new WaitForSeconds(TimeToSpawn);
            try
            {
                for (float x = Random.Range(negativePosition.x, positivePosition.x); x < positivePosition.x; x += distanceBetweenCheck)
                {
                    for (float z = Random.Range(negativePosition.y, positivePosition.y); z < positivePosition.y; z += distanceBetweenCheck)
                    {
                        if (Physics.Raycast(new Vector3(x, heightOfCheck, z), Vector3.down, out RaycastHit hit, rangeOfCheck, layerMask))
                        {
                            bobrPool.GetBobr(hit.point, Quaternion.identity);
                            goto End;
                        }
                    }
                }
            }
            catch
            {
                Debug.LogWarning("All bobrs alive");
            }
            End:;
        }
    }
}
