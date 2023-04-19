using UnityEngine;

public class ObjectLerper : MonoBehaviour
{
    public float lerpSpeed = 2f;
    public float range = 10f;
    public Transform positionA;
    public Transform positionB;

    private Transform player;
    private bool isMovingTowardsA = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= range)
        {
            isMovingTowardsA = true;
        }
        else
        {
            isMovingTowardsA = false;
        }

        if (isMovingTowardsA)
        {
            transform.position = Vector3.Lerp(transform.position, positionA.position, Time.deltaTime * lerpSpeed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, positionB.position, Time.deltaTime * lerpSpeed);
        }
    }
}
