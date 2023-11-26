using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float maxHP;
    public float currentHP;
    public GameObject VFX;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount)
    {
        currentHP -= damageAmount;
        Instantiate(VFX, transform.position + new Vector3(0f, 0.5f, 0f), transform.rotation);
        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();

        }
        //else
        //{
        //    animator.SetTrigger("damage");
        //}
    }

    void Die()
    {
        Destroy(gameObject);
    }

}