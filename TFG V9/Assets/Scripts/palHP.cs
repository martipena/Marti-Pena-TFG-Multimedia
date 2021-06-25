using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    public class palHP : MonoBehaviour
    {
        public static float hp;
        public float veureHP;
        public GameObject fire;
        public float posicio;
        public bool playerToca=false;
        public bool potTocar=true;
        public bool tocaAigua=false;
        public bool davant = false;
        public bool darrera = false;
        public bool dreta = false;
        public bool esq = false;
        // Update is called once per frame
        void Update()
        {
            veureHP = hp;
            if(fire == null)
            {

            }
            else if (fire.activeSelf && this.tag !="log")
            {
                hp -= Time.deltaTime;
            }
            if (hp <= 0 && this.tag!="log")
            {
                ThirdPersonMovement.palTrencat = true;
            }
            if (correntAigua.tocaTronc && this.tag!="torch" && tocaAigua && esq==true)
            {
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                this.GetComponent<Rigidbody>().transform.position += Vector3.left * Time.deltaTime * 1f;
                this.GetComponent<Rigidbody>().transform.position += Vector3.forward * Time.deltaTime * 0.03f;
                if (playerToca)
                {
                    StartCoroutine(mou());
                }
            }else if (correntAigua.tocaTronc && this.tag != "torch" && tocaAigua && dreta == true)
            {
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                this.GetComponent<Rigidbody>().transform.position += Vector3.right * Time.deltaTime * 1f;
                this.GetComponent<Rigidbody>().transform.position += Vector3.forward * Time.deltaTime * 0.03f;
                if (playerToca)
                {
                    StartCoroutine(mou());
                }
            }
            else if (correntAigua.tocaTronc && this.tag != "torch" && tocaAigua && davant == true)
            {
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                this.GetComponent<Rigidbody>().transform.position += Vector3.forward * Time.deltaTime * 1f;
                if (playerToca)
                {
                    StartCoroutine(mou());
                }
            }
            else if (correntAigua.tocaTronc && this.tag != "torch" && tocaAigua && darrera == true)
            {
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                this.GetComponent<Rigidbody>().transform.position += Vector3.back * Time.deltaTime * 1f;
                if (playerToca)
                {
                    StartCoroutine(mou());
                }
            }
            else
            {

            }
        }
        IEnumerator mou()
        {
            this.GetComponent<Rigidbody>().transform.position += Vector3.down * Time.deltaTime * 2;
            yield return new WaitForSeconds(0.5f);
            playerToca = false;
        }

        void OnTriggerStay(Collider other)//Crea pal al tallar un tronc
        {
            if (other.tag == "espasa" && Input.GetMouseButton(0) && this.tag=="log" && tree.surtLog==false)
            {
                this.transform.parent.GetComponent<tree>().potDesapareixer = true;
                this.gameObject.SetActive(false);
            }
        }
        void OnTriggerEnter(Collider other)//Crea pal al tallar un tronc
        {
            if (other.tag == "Player" && potTocar==true && this.tag!="torch")
            {
                playerToca = true;
                potTocar = false;
            }
            if (other.tag == "water")
            {
                tocaAigua = true;
            }
        }
    }

}
