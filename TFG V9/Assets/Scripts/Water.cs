using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TFG
{
    public class Water : MonoBehaviour
    {
        private bool dirRight = true;
        public float speed = 2.0f;
        public float min;//Minim i maxim de alçada que puja l'aigua
        public float max;
        public float flotacio;
        public GameObject foc;
        public bool gastaSta;
        public static bool potNadar = false;
        public static bool restauraSta = false;
        // Update is called once per frame
        void Update()
        {
           
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "focTorch" && ThirdPersonMovement.teFoc == true )
            {
                ThirdPersonMovement.teFoc = false;
                foc.SetActive(false);
                
            }
            if(other.tag == "Player")
            {
                ThirdPersonMovement.saltaAigua = false;
                ThirdPersonMovement.gastaSta = gastaSta;
            }
            if (other.tag == "swim")
            {
                Debug.Log("a");
                //ThirdPersonMovement.gravity = 0;
                potNadar = true;
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.tag == "swim")
            {
                //ThirdPersonMovement.gravity = grav;
                potNadar = false;
                restauraSta = true;
                Debug.Log("Deixa");
            }
            if (other.tag == "Player")
            {
                ThirdPersonMovement.saltaAigua = true;
            }
        }
    }

}
