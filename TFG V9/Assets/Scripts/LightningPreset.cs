using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset", order = 1)]
    public class LightningPreset : ScriptableObject
    {
        public Gradient Ambientcolor;
        public Gradient DirectionalColor;
        public Gradient FogColor;
    }

}
