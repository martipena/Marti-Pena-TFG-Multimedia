using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    public class Snowing : MonoBehaviour
    {
        public GameObject SnowFall;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (GameControl.neu == true)
            {
                SnowFall.SetActive(true);
                SnowFall.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+5, this.transform.position.z);
            }
            if (GameControl.neu == false)
            {
                SnowFall.SetActive(false);
            }
        }
    }

}
