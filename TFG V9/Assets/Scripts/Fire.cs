using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TFG
{
    public class Fire : MonoBehaviour
    {
        public GameObject foc;
        public bool foguera1;
        public bool foguera2;
        public bool foguera3;
        public bool foguera4;
        public bool foguera5;
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "torch" && ThirdPersonMovement.teFoc == false && this.tag != "foguera")
            {
                ThirdPersonMovement.teFoc = true;
            }
            if (this.tag == "foguera" && other.tag== "focTorch")
            {
                foc.SetActive(true);
                GameControl.fogueraOberta = true;
                if (foguera1)
                {
                    GameControl.foguera1 = true;
                }else if (foguera2)
                {
                    GameControl.foguera2 = true;
                }
                else if(foguera3)
                {
                    GameControl.foguera3 = true;
                }else if (foguera4)
                {
                    GameControl.foguera4 = true;
                }
                else if (foguera5)
                {
                    GameControl.foguera5 = true;
                }
            }
        }
    }

}
