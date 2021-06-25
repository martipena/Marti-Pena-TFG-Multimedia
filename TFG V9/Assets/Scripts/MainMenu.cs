using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TFG
{
    public class MainMenu : MonoBehaviour
    {
        public static bool carga = false;
        public GameObject menuEnglish;
        public GameObject menuEnglishOptions;
        public GameObject menuEsp;
        public GameObject menuEspOptions;
        public GameObject menuCat;
        public GameObject menuCatOptions;
        public GameObject english;
        public GameObject spanish;
        public GameObject catalan;
        public static bool englishSel=true;
        public static bool spanishSel;
        public static bool catalanSel;
        public static bool inici=false;
        public void Start()
        {
            Cursor.visible = true;
            if (inici)
            {
                englishSel = GameControl.english;
                spanishSel = GameControl.spanish;
                catalanSel = GameControl.catalan;

                if (englishSel)
                {
                    spanish.SetActive(false);
                    catalan.SetActive(false);
                    english.SetActive(true);
                    BackToMenuEnglish();
                }
                if (spanishSel)
                {
                    english.SetActive(false);
                    catalan.SetActive(false);
                    spanish.SetActive(true);
                    BackToMenuEsp();
                }
                if (catalanSel)
                {
                    
                    spanish.SetActive(false);
                    english.SetActive(false);
                    catalan.SetActive(true);
                    BackToMenuCat();
                }

                /*if (englishSel)
                {
                    BackToMenuEnglish();
                }else if (spanishSel)
                {
                    BackToMenuEsp();
                }else if (catalanSel)
                {
                    BackToMenuCat();
                }*/
            }
            
        }
        public void StartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Game");
        }

        public void LoadGame()
        {
            Time.timeScale = 1;
            carga = true;
            SceneManager.LoadScene("Game");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
        public void Update()
        {
            if (englishSel)
            {
                spanish.SetActive(false);
                catalan.SetActive(false);
                english.SetActive(true);
                
            }
            if (spanishSel)
            {
                english.SetActive(false);
                catalan.SetActive(false);
                spanish.SetActive(true);
                
            }
            if (catalanSel)
            {
                spanish.SetActive(false);
                english.SetActive(false);
                catalan.SetActive(true);
                
            }
        }
        public void LanguageEng()
        {
            englishSel = true;
            spanishSel = false;
            catalanSel = false;
            menuEnglishOptions.SetActive(true);
        }

        public void LanguageEsp()
        {
            englishSel = false;
            spanishSel = true;
            catalanSel = false;
            menuEspOptions.SetActive(true);
        }

        public void LanguageCat()
        {
            englishSel = false;
            spanishSel = false;
            catalanSel = true;
            menuCatOptions.SetActive(true);
        }

        public void BackToMenuEnglish()
        {
            menuEnglishOptions.SetActive(false);
            menuEnglish.SetActive(true);
        }

        public void BackToMenuEsp()
        {
            menuEspOptions.SetActive(false);
            menuEsp.SetActive(true);
        }

        public void BackToMenuCat()
        {
            Debug.Log("s");
            menuCatOptions.SetActive(false);
            menuCat.SetActive(true);
        }

        public void OpenOptionsEnglish()
        {
            menuEnglishOptions.SetActive(true);
            menuEnglish.SetActive(false);
        }

        public void OpenOptionsEsp()
        {
            menuEspOptions.SetActive(true);
            menuEsp.SetActive(false);
        }
        public void OpenOptionsCat()
        {
            menuCatOptions.SetActive(true);
            menuCat.SetActive(false);
        }
    }
}

