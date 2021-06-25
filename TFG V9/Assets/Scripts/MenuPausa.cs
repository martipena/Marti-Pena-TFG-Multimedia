using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TFG
{
    public class MenuPausa : MonoBehaviour
    {
        public CinemachineFreeLook vcam;
        public float maxSpeedXDef;
        public float maxSpeedYDef;
        public bool invertXDef;
        public bool invertYDef;
        public bool invertidaX = false;
        public bool invertidaY = false;
        public GameObject inGameUI;
        public GameObject menuPausa;
        public GameObject menuBonfire;
        public GameObject menuMap;
        public GameObject menuTutorial;

        public GameObject inGameUIEsp;
        public GameObject menuPausaEsp;
        public GameObject menuBonfireEsp;
        public GameObject menuMapEsp;
        public GameObject menuTutorialEsp;

        public GameObject inGameUIEng;
        public GameObject menuPausaEng;
        public GameObject menuBonfireEng;
        public GameObject menuMapEng;
        public GameObject menuTutorialEng;

        public GameObject CanvasCat;
        public GameObject CanvasEsp;
        public GameObject CanvasEng;

        public Slider XSpeed;
        public Slider YSpeed;
        public Slider XSpeedEsp;
        public Slider YSpeedEsp;
        public Slider XSpeedEng;
        public Slider YSpeedEng;

        public GameObject Mapa;
        public GameObject mainCam;
        public GameObject mapCam;
        // Start is called before the first frame update
        void Start()
        {
            XSpeed.maxValue = 1000;
            XSpeed.minValue = 150;
            XSpeed.value = maxSpeedXDef;
            YSpeed.maxValue = 8;
            YSpeed.minValue = 1;
            YSpeed.value = maxSpeedYDef;

            XSpeedEsp.maxValue = 1000;
            XSpeedEsp.minValue = 150;
            XSpeedEsp.value = maxSpeedXDef;
            YSpeedEsp.maxValue = 8;
            YSpeedEsp.minValue = 1;
            YSpeedEsp.value = maxSpeedYDef;

            XSpeedEng.maxValue = 1000;
            XSpeedEng.minValue = 150;
            XSpeedEng.value = maxSpeedXDef;
            YSpeedEng.maxValue = 8;
            YSpeedEng.minValue = 1;
            YSpeedEng.value = maxSpeedYDef;

            invertXDef = vcam.m_XAxis.m_InvertInput;
            invertYDef = vcam.m_YAxis.m_InvertInput;
            invertidaX = vcam.m_XAxis.m_InvertInput;
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.timeScale == 0 && !menuBonfire.activeSelf && !menuMap.activeSelf && !menuTutorial.activeSelf && !menuBonfireEsp.activeSelf && !menuMapEsp.activeSelf && !menuTutorialEsp.activeSelf && !menuBonfireEng.activeSelf && !menuMapEng.activeSelf && !menuTutorialEng.activeSelf)
            {
                Cursor.visible = true;
                if (GameControl.catalan)
                {
                    CanvasCat.SetActive(true);
                    CanvasEsp.SetActive(false);
                    CanvasEng.SetActive(false);
                    menuPausa.SetActive(true);
                    inGameUI.SetActive(false);
                    //Debug.Log("pausa");
                    vcam.m_XAxis.m_MaxSpeed = XSpeed.value;//sensibilitat x
                    vcam.m_XAxis.m_InvertInput = false;//invertir camara x
                    vcam.m_YAxis.m_MaxSpeed = YSpeed.value;//sensibilitat y
                    vcam.m_YAxis.m_InvertInput = false;//invertir camara y
                }
                else if (GameControl.spanish)
                {
                    CanvasCat.SetActive(false);
                    CanvasEsp.SetActive(true);
                    CanvasEng.SetActive(false);
                    menuPausaEsp.SetActive(true);
                    inGameUIEsp.SetActive(false);
                    //Debug.Log("pausa");
                    vcam.m_XAxis.m_MaxSpeed = XSpeedEsp.value;//sensibilitat x
                    vcam.m_XAxis.m_InvertInput = false;//invertir camara x
                    vcam.m_YAxis.m_MaxSpeed = YSpeedEsp.value;//sensibilitat y
                    vcam.m_YAxis.m_InvertInput = false;//invertir camara y
                }
                else if (GameControl.english)
                {
                    CanvasCat.SetActive(false);
                    CanvasEsp.SetActive(false);
                    CanvasEng.SetActive(true);
                    menuPausaEng.SetActive(true);
                    inGameUIEng.SetActive(false);
                    //Debug.Log("pausa");
                    vcam.m_XAxis.m_MaxSpeed = XSpeedEng.value;//sensibilitat x
                    vcam.m_XAxis.m_InvertInput = false;//invertir camara x
                    vcam.m_YAxis.m_MaxSpeed = YSpeedEng.value;//sensibilitat y
                    vcam.m_YAxis.m_InvertInput = false;//invertir camara y
                }
            }
            if (Time.timeScale == 1)
            {
                
                if (GameControl.catalan)
                {
                    CanvasCat.SetActive(true);
                    CanvasEsp.SetActive(false);
                    CanvasEng.SetActive(false);
                    menuPausa.SetActive(false);
                    menuBonfire.SetActive(false);
                    mainCam.SetActive(true);
                    mapCam.SetActive(false);
                    menuMap.SetActive(false);
                    inGameUI.SetActive(true);
                }
                else if (GameControl.spanish)
                {
                    CanvasCat.SetActive(false);
                    CanvasEsp.SetActive(true);
                    CanvasEng.SetActive(false);
                    menuPausaEsp.SetActive(false);
                    menuBonfireEsp.SetActive(false);
                    mainCam.SetActive(true);
                    mapCam.SetActive(false);
                    menuMapEsp.SetActive(false);
                    inGameUIEsp.SetActive(true);
                }else if (GameControl.english)
                {
                    CanvasCat.SetActive(false);
                    CanvasEsp.SetActive(false);
                    CanvasEng.SetActive(true);
                    menuPausaEng.SetActive(false);
                    menuBonfireEng.SetActive(false);
                    mainCam.SetActive(true);
                    mapCam.SetActive(false);
                    menuMapEng.SetActive(false);
                    inGameUIEng.SetActive(true);
                }
            }
        }

        public void valorsDefecte()
        {
            XSpeed.value = maxSpeedXDef;
            YSpeed.value = maxSpeedYDef;
            XSpeedEsp.value = maxSpeedXDef;
            YSpeedEsp.value = maxSpeedYDef;
            XSpeedEng.value = maxSpeedXDef;
            YSpeedEng.value = maxSpeedYDef;
        }

        public void tornarJoc()
        {
            
            if (GameControl.catalan)
            {
                Time.timeScale = 1;
                menuPausa.SetActive(false);
                menuBonfire.SetActive(false);
                menuTutorial.SetActive(false);
                inGameUI.SetActive(true);
            }
            else if (GameControl.spanish)
            {
                Time.timeScale = 1;
                menuPausaEsp.SetActive(false);
                menuBonfireEsp.SetActive(false);
                menuTutorialEsp.SetActive(false);
                inGameUIEsp.SetActive(true);
            }
            else if (GameControl.english)
            {
                Time.timeScale = 1;
                menuPausaEng.SetActive(false);
                menuBonfireEng.SetActive(false);
                menuTutorialEng.SetActive(false);
                inGameUIEng.SetActive(true);
            }
        }

        public void tornarMenu()
        {
            MainMenu.inici = true;
            SceneManager.LoadScene("MainMenu");
        }

        public void esperarDia()
        {
            LightningManager.skipNight = true;
        }

        public void obrirMapa()
        {
            
            if (GameControl.catalan)
            {
                mainCam.SetActive(false);
                mapCam.SetActive(true);
                menuBonfire.SetActive(false);
                menuMap.SetActive(true);
                menuPausa.SetActive(false);
                menuTutorial.SetActive(false);
                Mapa.GetComponent<Map>().UpdateMap();
            }
            else if (GameControl.spanish)
            {
                mainCam.SetActive(false);
                mapCam.SetActive(true);
                menuBonfireEsp.SetActive(false);
                menuMapEsp.SetActive(true);
                menuPausaEsp.SetActive(false);
                menuTutorialEsp.SetActive(false);
                Mapa.GetComponent<Map>().UpdateMap();
            }
            else if (GameControl.english)
            {
                mainCam.SetActive(false);
                mapCam.SetActive(true);
                menuBonfireEng.SetActive(false);
                menuMapEng.SetActive(true);
                menuPausaEng.SetActive(false);
                menuTutorialEng.SetActive(false);
                Mapa.GetComponent<Map>().UpdateMap();
            }
        }

        public void closeMap()
        {
            
            if (GameControl.catalan)
            {
                mainCam.SetActive(true);
                mapCam.SetActive(false);
                menuBonfire.SetActive(true);
                menuMap.SetActive(false);
            }
            else if (GameControl.spanish)
            {
                mainCam.SetActive(true);
                mapCam.SetActive(false);
                menuBonfireEsp.SetActive(true);
                menuMapEsp.SetActive(false);
            }
            else if (GameControl.english)
            {
                mainCam.SetActive(true);
                mapCam.SetActive(false);
                menuBonfireEng.SetActive(true);
                menuMapEng.SetActive(false);
            }
        }

        public void InvertircamaraX()
        {
            invertidaX = !invertidaX;
            Time.timeScale = 1;
            vcam.m_XAxis.m_InvertInput = invertidaX;
        }

        public void InvertircamaraY()
        {
            invertidaY = !invertidaY;
            Time.timeScale = 1;
            vcam.m_YAxis.m_InvertInput = invertidaY;
        }

        public void sortirJoc()
        {
            Application.Quit();
        }

    }

}