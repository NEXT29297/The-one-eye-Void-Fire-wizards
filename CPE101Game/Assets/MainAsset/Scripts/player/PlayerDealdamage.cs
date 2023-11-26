using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDealdamage : MonoBehaviour
{

    [SerializeField] float damage;
    public ParticleSystem _particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2f);
    }

    List<ParticleCollisionEvent> colEvent = new List<ParticleCollisionEvent>();
    private void OnParticleCollision(GameObject collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
