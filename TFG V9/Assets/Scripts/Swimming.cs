using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    public class Swimming : MonoBehaviour
    {
        public static bool potNadar = false;
        public static bool restauraSta = false;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "swim")
            {
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
        }
    }
}

