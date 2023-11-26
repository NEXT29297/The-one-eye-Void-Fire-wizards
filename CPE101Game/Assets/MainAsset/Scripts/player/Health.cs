using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField] float maxHP;
    public float currentHP;
    public Slider healthSlider;
    public Slider easeHealthSlider;
    private float lerpSpeed = 0.05f;

    ThirdPersonMovement playerMovement;
    PlayerDash playerDash;
    public GameObject DieEffect;
    public GameObject GameOver;
    public GameObject currwaveText;
    public GameObject currwave;

    //[SerializeField] PlayerHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        playerMovement = GetComponent<ThirdPersonMovement>();
        playerDash = GetComponent<PlayerDash>();


    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP >= maxHP) currentHP = maxHP;
        healthSlider.value = currentHP;
        easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, currentHP, lerpSpeed);
    }

    public void TakeDamage(float damageAmount)
    {
        currentHP -= damageAmount;

        if (currentHP <= 0)
        {
            DieEffect.SetActive(true);
            GameOver.SetActive(true);
            currwaveText.SetActive(false);
            currwave.SetActive(false);
            healthSlider.value = 0;
            easeHealthSlider.value = 0;
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
        Destroy(gameObject);// Instantiate(ragdoll, transform.position, transform.rotation);

        /*
        playerMovement.enabled = false;
        playerDash.enabled = false;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        */

        //Debug.Log("ragdoll");
        Debug.Log("Die");
    }

}
