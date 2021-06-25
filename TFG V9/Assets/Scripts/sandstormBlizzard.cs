using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandstormBlizzard : MonoBehaviour
{
    Color newCol;
    
    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player" && this.tag=="sandStorm")
        {
            ColorUtility.TryParseHtmlString("#D4B373", out newCol);
            RenderSettings.fog = true;
            RenderSettings.fogColor = newCol;
        }
        else if (other.tag == "Player" && this.tag == "blizzard")
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = Color.white;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && this.tag =="sandStorm")
        {
            RenderSettings.fog = false;
        }
        else if (other.tag == "Player" && this.tag == "blizzard")
        {
            RenderSettings.fog = false;
        }
    }
}
