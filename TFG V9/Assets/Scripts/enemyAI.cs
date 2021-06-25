using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    public class enemyAI : MonoBehaviour
    {
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
            if (other.tag == "Player" && ThirdPersonMovement.enemicPotTocar==true)
            {
                ThirdPersonMovement.enemicEtToca = true;
            }
            if (other.tag == "espasa" && Input.GetMouseButton(0))
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}

