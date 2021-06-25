using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaNIt : MonoBehaviour
{
    public GameObject light;
    [SerializeField]
    private int duracioNit;//Com mes baix mes dura
    [SerializeField]
    private int duracioDia;//Com mes baix mes dura

    public static bool esNit = false;//Serveix perque altres components accedeixin per saber la hora
    void Update()
    {
        //hora = (int)light.transform.rotation.eulerAngles.x/24;
        if (light.transform.rotation.eulerAngles.x >188)
        {
            light.transform.Rotate(duracioNit * Time.deltaTime, 0, 0);
            esNit = true;
        }
        else
        {
            light.transform.Rotate(duracioDia * Time.deltaTime, 0, 0);
            esNit = false;
        }
    }
}