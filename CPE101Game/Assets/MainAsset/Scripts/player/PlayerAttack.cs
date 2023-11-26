using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attacker1;
    public Rigidbody attacker2;
    public GameObject FireBall;
    public GameObject FireBallPosition;
    public GameObject MeteorPosition;

    public float skillGauge;
    public Slider guageSlider;
    private float lerpSpeed = 0.05f;


    public float fireRate;
    private float nextFire;
    private float nextFire2;

    public float rotationSpeed = 5f;
    public Transform playerTransform; // Your player's transform
    public LayerMask enemyLayer; // The layer containing your enemies

    ThirdPersonMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<ThirdPersonMovement>();
        skillGauge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (skillGauge > 5)
        {
            skillGauge = 5;
        }
        //guageSlider.value = skillGauge;
        guageSlider.value = Mathf.Lerp(guageSlider.value, skillGauge, lerpSpeed);

        Transform nearestEnemy = FindNearestEnemy();

        //if (nearestEnemy != null)
        //{
        //    RotateTowards(nearestEnemy);
        //}

        if (Input.GetMouseButtonDown(1) && skillGauge >= 5)
        {
            skillGauge = 0;
            Instantiate(attacker1, MeteorPosition.transform.position, transform.rotation);
        }
        else if (Input.GetMouseButtonDown(0) && nearestEnemy != null && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            playerMovement.enabled = false;
            RotateTowards(nearestEnemy);

            Instantiate(FireBall, FireBallPosition.transform.position, transform.rotation);
            playerMovement.enabled = true;
            //Rigidbody clone;
            //clone = Instantiate(attacker2, transform.position + new Vector3(0f, 0f, 0f), transform.rotation);
            //clone.velocity = transform.TransformDirection(Vector3.forward * 30);
        }
        else if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(FireBall, FireBallPosition.transform.position, transform.rotation);
        }
    }

    Transform FindNearestEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(playerTransform.position, 70f, enemyLayer);

        Transform nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (var collider in hitColliders)
        {
            float distance = Vector3.Distance(playerTransform.position, collider.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = collider.transform;
            }
        }

        return nearestEnemy;
    }

    void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - playerTransform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
    public void addGauge()
    {
        skillGauge += 1;
    }
}
