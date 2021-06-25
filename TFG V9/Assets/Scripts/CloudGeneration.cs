using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGeneration : MonoBehaviour
{
    public GameObject cloud;
    public float interval;
    float randPos;
    public bool next = true;
    // Start is called before the first frame update
    void Start()
    {
        randPos = Random.Range(-50, 50);
        Instantiate(cloud, new Vector3(transform.position.x + randPos, transform.position.y, transform.position.z), transform.rotation * Quaternion.Euler(0f, Random.Range(0,360), 0f), transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (next)
        {
            StartCoroutine(timeForNext());
        }
        
    }

    public IEnumerator timeForNext()
    {
        next = false;
        yield return new WaitForSeconds(interval);
        randPos = Random.Range(-50, 50);
        Instantiate(cloud, new Vector3(transform.position.x + randPos, transform.position.y, transform.position.z), transform.rotation * Quaternion.Euler(0f, Random.Range(0, 360), 0f), transform);
        next = true;
    }
}
