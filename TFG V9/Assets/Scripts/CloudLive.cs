using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLive : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.1f, 0.3f);
        //StartCoroutine(timeToDie());
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = (new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z-speed) );
    }

    public IEnumerator timeToDie()//Es destrueix automatic als 10 minuts
    {
        yield return new WaitForSeconds(600);
        //Destroy(this.gameObject);
    }
}
