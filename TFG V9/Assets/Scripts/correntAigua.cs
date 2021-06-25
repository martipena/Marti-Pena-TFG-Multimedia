using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    public class correntAigua : MonoBehaviour
    {

        public GameObject player;
        public Vector3 direccio;
        public static Vector3 direccioFinal;
        public static bool tocat;
        public static bool tocaTronc;
        public float valorCorrent;
        public bool f = false;
        public bool b = false;
        public bool r = false;
        public bool l = false;
        private void Start()
        {
            //direccioFinal = direccio;
        }
        void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player")
            {
                direccioFinal = direccio;
                //Debug.Log("Dire: " + direccioFinal);
                tocat = true;
                ThirdPersonMovement.valorCorrent = valorCorrent;
            }
            if (other.tag == "log")
            {
                tocaTronc = true;
                other.GetComponent<palHP>().davant = f;
                other.GetComponent<palHP>().darrera = b;
                other.GetComponent<palHP>().esq = l;
                other.GetComponent<palHP>().dreta = r;
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                tocat = false;
            }
            if (other.tag == "log")
            {
                tocaTronc = false;
                other.GetComponent<palHP>().davant = false;
                other.GetComponent<palHP>().darrera = false;
                other.GetComponent<palHP>().esq = false;
                other.GetComponent<palHP>().dreta = false;
            }
        }
    }

}
