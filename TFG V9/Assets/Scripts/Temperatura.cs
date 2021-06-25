using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TFG
{
    public class Temperatura : MonoBehaviour
    {
        public float curTemperature;
        public static float maxTemp;
        public static float altura;
        public static bool potcambiar = false;
        public static bool reset;
        public Slider termometre;
        public Image background;
        public Image fillTermometer;

        public Slider termometreEsp;
        public Image backgroundEsp;
        public Image fillTermometerEsp;

        public Slider termometreEng;
        public Image backgroundEng;
        public Image fillTermometerEng;

        private void Start()
        {
            maxTemp = 50;
            curTemperature = maxTemp / 2;
            
            if (GameControl.catalan)
            {
                termometre.maxValue = maxTemp;
                termometre.value = maxTemp;
                background.color = Color.Lerp(Color.green, Color.green, 1);
                fillTermometer.color = Color.Lerp(Color.green, Color.green, 1);
            }else if (GameControl.spanish)
            {
                termometreEsp.maxValue = maxTemp;
                termometreEsp.value = maxTemp;
                backgroundEsp.color = Color.Lerp(Color.green, Color.green, 1);
                fillTermometerEsp.color = Color.Lerp(Color.green, Color.green, 1);
            }else if (GameControl.english)
            {
                termometreEng.maxValue = maxTemp;
                termometreEng.value = maxTemp;
                backgroundEng.color = Color.Lerp(Color.green, Color.green, 1);
                fillTermometerEng.color = Color.Lerp(Color.green, Color.green, 1);
            }
            
        }
        // Update is called once per frame
        void Update()
        {
            if (GameControl.catalan)
            {
                termometre.enabled = true;
                background.enabled = true;
                fillTermometer.enabled = true;
                termometreEsp.enabled = false;
                backgroundEsp.enabled = false;
                fillTermometerEsp.enabled = false;
                termometreEng.enabled = false;
                backgroundEng.enabled = false;
                fillTermometerEng.enabled = false;
            }
            else if (GameControl.spanish)
            {
                termometre.enabled = false;
                background.enabled = false;
                fillTermometer.enabled = false;
                termometreEsp.enabled = true;
                backgroundEsp.enabled = true;
                fillTermometerEsp.enabled = true;
                termometreEng.enabled = false;
                backgroundEng.enabled = false;
                fillTermometerEng.enabled = false;
            }
            else if (GameControl.english)
            {
                termometre.enabled = false;
                background.enabled = false;
                fillTermometer.enabled = false;
                termometreEsp.enabled = false;
                backgroundEsp.enabled = false;
                fillTermometerEsp.enabled = false;
                termometreEng.enabled = true;
                backgroundEng.enabled = true;
                fillTermometerEng.enabled = true;
            }

            altura = this.transform.position.y;
            if (potcambiar)
            {
                if (curTemperature < maxTemp)
                {
                    curTemperature += Time.deltaTime * 5;
                }
                else if (curTemperature > maxTemp)
                {
                    curTemperature -= Time.deltaTime * 5;
                }
                if (curTemperature == maxTemp)
                {
                    potcambiar = false;
                }
            }
            termometre.value = curTemperature;
            termometreEsp.value = curTemperature;
            termometreEng.value = curTemperature;
            if (ThirdPersonMovement.teFoc == true)
            {
                
            }
            if (curTemperature >= 0 && curTemperature < 9)//fred(perd energia poc a poc)
            {
                GameControl.neu = true;
                ThirdPersonMovement.teFred = true;
                ThirdPersonMovement.teCalor = false;
                ThirdPersonMovement.teCalorExtrema = false;
                background.color = Color.Lerp(Color.blue, Color.blue, 1);
                fillTermometer.color = Color.Lerp(Color.blue, Color.black, Mathf.PingPong(Time.time, 1f));
                backgroundEsp.color = Color.Lerp(Color.blue, Color.blue, 1);
                fillTermometerEsp.color = Color.Lerp(Color.blue, Color.black, Mathf.PingPong(Time.time, 1f));
                backgroundEng.color = Color.Lerp(Color.blue, Color.blue, 1);
                fillTermometerEng.color = Color.Lerp(Color.blue, Color.black, Mathf.PingPong(Time.time, 1f));

            }
            else if (curTemperature > 10 && curTemperature <= 25)//templat
            {
                GameControl.neu = false;
                ThirdPersonMovement.teFred = false;
                ThirdPersonMovement.teCalor = false;
                ThirdPersonMovement.teCalorExtrema = false;
                background.color = Color.Lerp(Color.yellow, Color.yellow, 1);
                fillTermometer.color = Color.Lerp(Color.yellow, Color.yellow, Mathf.PingPong(Time.time, 1f));
                backgroundEsp.color = Color.Lerp(Color.yellow, Color.yellow, 1);
                fillTermometerEsp.color = Color.Lerp(Color.yellow, Color.yellow, Mathf.PingPong(Time.time, 1f));
                backgroundEng.color = Color.Lerp(Color.yellow, Color.yellow, 1);
                fillTermometerEng.color = Color.Lerp(Color.yellow, Color.yellow, Mathf.PingPong(Time.time, 1f));
            }
            else if (curTemperature > 26 && curTemperature < 40)//calor(perd energia poc a poc)
            {
                ThirdPersonMovement.teFred = false;
                ThirdPersonMovement.teCalor = true;
                ThirdPersonMovement.teCalorExtrema = false;
                background.color = Color.Lerp(Color.red, Color.red, 1);
                fillTermometer.color = Color.Lerp(Color.red, Color.black, Mathf.PingPong(Time.time, 1f));
                backgroundEsp.color = Color.Lerp(Color.red, Color.red, 1);
                fillTermometerEsp.color = Color.Lerp(Color.red, Color.black, Mathf.PingPong(Time.time, 1f));
                backgroundEng.color = Color.Lerp(Color.red, Color.red, 1);
                fillTermometerEng.color = Color.Lerp(Color.red, Color.black, Mathf.PingPong(Time.time, 1f));
            }
            else if (curTemperature > 41)//calor extrem(perd molta energia poc a poc)
            {
                ThirdPersonMovement.teFred = false;
                ThirdPersonMovement.teCalor = false;
                ThirdPersonMovement.teCalorExtrema = true;
                background.color = Color.Lerp(Color.magenta, Color.magenta, 1);
                fillTermometer.color = Color.Lerp(Color.magenta, Color.black, Mathf.PingPong(Time.time, 1f));
                backgroundEsp.color = Color.Lerp(Color.magenta, Color.magenta, 1);
                fillTermometerEsp.color = Color.Lerp(Color.magenta, Color.black, Mathf.PingPong(Time.time, 1f));
                backgroundEng.color = Color.Lerp(Color.magenta, Color.magenta, 1);
                fillTermometerEng.color = Color.Lerp(Color.magenta, Color.black, Mathf.PingPong(Time.time, 1f));
            }
            if (reset)
            {
                potcambiar = false;
                resetTemperature();
            }
        }

        public void resetTemperature()
        {
            curTemperature = 11;
            reset = false;
        }
    }

}
