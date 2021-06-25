using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    public class respawnPlayer : MonoBehaviour
    {
        public Transform respawn;
        public static bool oob=false;
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
            if(other.tag == "Player" && this.tag == "outOfBound")
            {
                oob = true;
            }
            else if (other.tag == "Player")
            {
                ThirdPersonMovement.posRes = respawn.transform.position;
            }
        }
    }

}
