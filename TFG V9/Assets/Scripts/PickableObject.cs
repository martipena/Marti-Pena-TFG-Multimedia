using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    public class PickableObject : MonoBehaviour
    {
        public GameObject sparkle;
        public static bool amaga=false;
        // Start is called before the first frame update
        void Start()
        {
            Instantiate(sparkle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z), Quaternion.identity,transform);
        }

        // Update is called once per frame
        void Update()
        {
            if (amaga)
            {

            }
        }

    }

}
