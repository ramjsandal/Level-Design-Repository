using UnityEngine;

public class ObjectLerper : MonoBehaviour
{
    public float lerpSpeed = 2f;
    public float range = 10f;
    public Transform positionA;
    public Transform positionB;
    public GameObject targetTrigger; // player must be close to this object to trigger events

    public bool oneTimeThing = false;
    private bool activateOnce = false;

    private Transform player;
    private bool isMovingTowardsA = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(targetTrigger.transform.position, player.position);

        if (distanceToPlayer <= range) // player is in range
        {
            isMovingTowardsA = true;
            if (oneTimeThing) {
                activateOnce = true; // has now been activated once
            }
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
            if (!activateOnce) {
                transform.position = Vector3.Lerp(transform.position, positionB.position, Time.deltaTime * lerpSpeed);
            }
        }
    }
}
