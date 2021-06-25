using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    public class tree : MonoBehaviour
    {
        public GameObject arbre;
        public GameObject log;
        public GameObject pal;
        public bool potDesapareixer=false;
        public int hp = 2;
        public float speed = 1.0f; //how fast it shakes
        public float amount = 1.0f; //how much it shakes
        public bool moure=true;
        public static bool surtLog = false;
        public bool pot=false;
        public bool senseHP=true;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
            //this.transform.position = new Vector3(this.transform.position.x + (Mathf.Sin(Time.time * speed) * amount), this.transform.position.y, this.transform.position.z);
            //this.transform.position.x = Mathf.Sin(Time.time * speed) * amount;
            if (moure == false)
            {
                this.transform.position = new Vector3(this.transform.position.x + (Mathf.Sin(Time.time * speed) * amount), this.transform.position.y, this.transform.position.z);
            }
            if (hp <= 0 && senseHP)
            {
                senseHP = false;
                StopCoroutine(mou());
                surtLog = true;
                pot = true;
                arbre.SetActive(false);
                log.SetActive(true);
            }
            if (potDesapareixer)
            {
                potDesapareixer = false;
                Instantiate(pal, new Vector3(this.transform.position.x, this.transform.position.y+3, this.transform.position.z), Quaternion.identity);
                StopCoroutine(potLog());
                this.gameObject.SetActive(false);
            }
            if (pot)
            {
                StartCoroutine(potLog());
            }
        }

        void OnTriggerStay(Collider other)
        {
            if (other.tag == "espasa" && Input.GetMouseButton(0) && moure==true && hp>0)
            {
                moure = false;
                hp--;
                if (hp >= 1)
                {
                    StartCoroutine(mou());
                }
                else
                {
                    moure = true;
                }
                
            }
        }
        IEnumerator mou()
        {
            
            yield return new WaitForSeconds(0.5f);
            moure = true;
        }
        IEnumerator potLog()
        {
            pot = false;
            yield return new WaitForSeconds(2f);
            surtLog = false;
        }
    }
}

