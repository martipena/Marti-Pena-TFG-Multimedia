using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    public class enemyAttack : MonoBehaviour
    {
        public static bool potTocar;
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player") && potTocar==true)
            {
                ThirdPersonMovement.enemicEtToca = true;
                potTocar = false;
            }
        }
    }

}
