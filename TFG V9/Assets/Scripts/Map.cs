using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    public class Map : MonoBehaviour
    {
        public GameObject clouds1;
        public GameObject clouds2;
        public GameObject clouds3;
        public GameObject clouds4;
        public GameObject cameraMap;
        public GameObject menuPausa;

        public void UpdateMap()
        {
            if (GameControl.foguera2)
            {
                clouds1.SetActive(false);
            }
            if (GameControl.foguera3)
            {
                clouds2.SetActive(false);
            }
            if (GameControl.foguera4)
            {
                clouds3.SetActive(false);
            }
            if (GameControl.foguera5)
            {
                clouds4.SetActive(false);
            }

        }

        public void Update()
        {
            if(cameraMap.activeSelf && Input.GetKey(KeyCode.Escape))
            {
                menuPausa.GetComponent<MenuPausa>().closeMap();
            }
        }
    }

}
