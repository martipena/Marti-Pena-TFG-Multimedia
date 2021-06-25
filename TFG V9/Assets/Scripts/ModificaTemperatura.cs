using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TFG
{
   
    public class ModificaTemperatura : MonoBehaviour
    {
        public int temperatura;
        
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && this.tag == "fred")
            {
                Temperatura.maxTemp = temperatura;
                Temperatura.potcambiar = true;
            }
            else if (other.tag == "Player" && this.tag == "templat")
            {
                
                if (Temperatura.altura <=20)//Temperatura adaptativa a la alçada
                {
                    Temperatura.maxTemp = temperatura;
                }else if(Temperatura.altura>20 || Temperatura.altura <=40)
                {
                    Temperatura.maxTemp = temperatura-2;
                }
                else if (Temperatura.altura > 40 || Temperatura.altura < 60)
                {
                    Temperatura.maxTemp = temperatura - 4;
                }
                Temperatura.potcambiar = true;
            }
            else if (other.tag == "Player" && this.tag == "calor")
            {
                Temperatura.maxTemp = temperatura;
                Temperatura.potcambiar = true;
            }
            else if (other.tag == "Player" && this.tag == "extremaCalor")
            {
                Temperatura.maxTemp = temperatura;
                Temperatura.potcambiar = true;
            }
        }
    }

}
