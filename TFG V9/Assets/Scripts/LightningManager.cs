using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    [ExecuteAlways]
    public class LightningManager : MonoBehaviour
    {
        [SerializeField] private Light DirectionalLight;
        [SerializeField] private LightningPreset Preset;
        [SerializeField] private LightningPreset Preset2;

        [SerializeField, Range(0, 24)] private float TimeOfDay;
        public static bool Night;
        public static float nightDuration = 30;//60 = el dia dura 6 min i la nit dura 6
        public static float dayDuration = 30;
        public static bool canChangeTime=false;
        public static bool skipNight;
        public float nextNight;
        public float nextDay;
        private void Update()
        {
            if (Preset == null || Preset2 == null)
            {
                return;
            }
            if (skipNight)
            {
                TimeOfDay = 8;
                skipNight = false;
                nightDuration = 120;
                dayDuration = 30;
            }
            if(GameControl.deaths==5 || GameControl.deaths >= 10)
            {
                dayDuration = 120;
                nightDuration = 30;
            }
            if (Application.isPlaying)
            {
                if (canChangeTime)
                {
                    if (Night)
                    {
                        TimeOfDay += Time.deltaTime / nightDuration;
                    }
                    else if (Night == false)
                    {
                        TimeOfDay += Time.deltaTime / dayDuration;
                    }

                    TimeOfDay %= 24;
                    UpdateLighting(TimeOfDay / 24f);
                }
                
            }
            else
            {
                UpdateLighting(TimeOfDay / 24f);
            }
            if (TimeOfDay < 8 || TimeOfDay >= 20)
            {
                Night = true;
            }
            if(TimeOfDay>7 && TimeOfDay < 8 && nightDuration!=120)
            {
                nightDuration = 45;
                dayDuration = 75;
            }
            else
            {
                //Night = false;
            }

        }

        private void UpdateLighting(float timePercent)
        {
            if (GameControl.neu)
            {
                RenderSettings.ambientLight = Preset2.Ambientcolor.Evaluate(timePercent);
                RenderSettings.fogColor = Preset2.FogColor.Evaluate(timePercent);
                if (DirectionalLight != null)
                {
                    DirectionalLight.color = Preset2.DirectionalColor.Evaluate(timePercent);
                    DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
                }
            }
            else
            {
                RenderSettings.ambientLight = Preset.Ambientcolor.Evaluate(timePercent);
                RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);
                if (DirectionalLight != null)
                {
                    DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
                    DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
                }
            }
            
        }

        private void OnValidate()
        {
            if (DirectionalLight != null)
            {
                return;
            }
            if (RenderSettings.sun != null)
            {
                DirectionalLight = RenderSettings.sun;
            }
            else
            {
                Light[] lights = GameObject.FindObjectsOfType<Light>();
                foreach (Light light in lights)
                {
                    if (light.type == LightType.Directional)
                    {
                        DirectionalLight = light;
                        return;
                    }
                }
            }
        }
    }

}
