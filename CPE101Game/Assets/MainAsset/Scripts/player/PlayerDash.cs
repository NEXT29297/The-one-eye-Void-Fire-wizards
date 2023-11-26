using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    ThirdPersonMovement playerMovement;
    PlayerAttack playerAttack;

    public float dashSpeed;
    public float dashTime;

    public float cooldownTime = 2f; // Cooldown time in seconds
    private bool isCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<ThirdPersonMovement>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !isCooldown)
        {
            StartCoroutine(Dash());

            StartCoroutine(Cooldown());
        }

        /*if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Dash());
        }*/
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        playerAttack.enabled = false;

        while (Time.time < startTime + dashTime)
        {
            playerMovement.controller.Move(playerMovement.moveDir * dashSpeed * Time.deltaTime);

            yield return null;
        }

        playerAttack.enabled = true;

    }

    IEnumerator Cooldown()
    {
        // Set cooldown state to true
        isCooldown = true;

        // Wait for the cooldown time
        yield return new WaitForSeconds(cooldownTime);

        // Reset cooldown state to false
        isCooldown = false;
    }

}
