using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEforMete : MonoBehaviour
{

    public GameObject AOEDamage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AOEDMG());
    }

    IEnumerator AOEDMG()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(AOEDamage, transform.position, transform.rotation);
    }
}
