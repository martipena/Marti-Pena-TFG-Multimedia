using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedernal : MonoBehaviour
{
    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "espasa" && Input.GetMouseButton(0))
        {
            fire.SetActive(true);
            StartCoroutine(stopFire());
        }
    }

    public IEnumerator stopFire()
    {
        yield return new WaitForSeconds(5.0f);
        fire.SetActive(false);
    }
}
