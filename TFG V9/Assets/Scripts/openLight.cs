using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    public class openLight : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (LightningManager.Night)
            {
                this.GetComponent<Light>().enabled = false;
            }

            if (LightningManager.Night==false)
            {
                this.GetComponent<Light>().enabled = true;
            }
        }
    }

}
