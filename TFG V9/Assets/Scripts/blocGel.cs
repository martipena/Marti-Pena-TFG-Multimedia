using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    public class blocGel : MonoBehaviour
    {
        public static float hpBloc;
        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            ThirdPersonMovement.hpCube = hpBloc;
            //Debug.Log("HP: " + hpBloc);
            if (ThirdPersonMovement.teCalor)
            {
                hpBloc -= Time.deltaTime*2;
            }else if (ThirdPersonMovement.teCalorExtrema)
            {
                hpBloc -= Time.deltaTime*4;
            }
            else if (!ThirdPersonMovement.teFred && !ThirdPersonMovement.teCalor && !ThirdPersonMovement.teCalorExtrema)
            {
                hpBloc -= Time.deltaTime /3;
            }
            if (hpBloc <= 0)
            {
                ThirdPersonMovement.blocFos = true;
            }
        }
    }

}
