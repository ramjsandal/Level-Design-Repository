using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public GameObject enemyDestroyed;
    [SerializeField] private int _health = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            _health -= 1;
        }

        if (_health <= 0)
        {
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        Instantiate(enemyDestroyed, transform.position, transform.rotation);
        gameObject.SetActive(false);
        Destroy(gameObject, 0.5f);
    }
}
