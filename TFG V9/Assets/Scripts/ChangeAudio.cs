using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    public class ChangeAudio : MonoBehaviour
    {
        public GameObject audio1;
        public GameObject audio2;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (LightningManager.Night)
            {
                audio1.SetActive(false);
                audio2.SetActive(true);
            }
            else
            {
                audio1.SetActive(true);
                audio2.SetActive(false);
            }
        }
    }
}

