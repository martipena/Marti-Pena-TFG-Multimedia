using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TFG
{
    public class GameControl : MonoBehaviour
    {
        public static bool foguera1;
        public static bool foguera2;
        public static bool foguera3;
        public static bool foguera4;
        public static bool foguera5;
        public static bool fogueraOberta = false;
        public static bool neu=false;
        public static int deaths = 0;
        public static bool english;
        public static bool spanish;
        public static bool catalan;

        public GameObject[] pocionsHP = new GameObject[20];
        public GameObject[] pocionsSta = new GameObject[7];
        public GameObject[] fogueres = new GameObject[5];

        public bool[] numPocionsHp = new bool[20];
        public bool[] numPocionsSta = new bool[7];
        public bool[] numFogueres = new bool[5];
        public GameObject Player;

        public void Start()
        {
            english = MainMenu.englishSel;
            spanish = MainMenu.spanishSel;
            catalan = MainMenu.catalanSel;
            for(int i = 0; i < pocionsHP.Length; i++)
            {
                if (pocionsHP[i].activeSelf)
                {
                    numPocionsHp[i] = true;
                }
            }

            for (int i = 0; i < pocionsSta.Length; i++)
            {
                if (pocionsSta[i].activeSelf)
                {
                    numPocionsSta[i] = true;
                }
            }

            for (int i = 0; i < fogueres.Length; i++)
            {
                if (fogueres[i].activeSelf==false)
                {
                    numFogueres[i] = false;
                }
                else
                {
                    numFogueres[i] = true;
                }
            }
        }

        private void Update()
        {
            if (fogueraOberta)
            {
                EstatFogueres();
                fogueraOberta = false;
            }
        }

        public void ComprovaInici(bool[]pocionsHp,bool[] pocionsSta, bool[] fogueres)
        {
            
            numPocionsSta = pocionsSta;
            numPocionsHp = pocionsHp;
            numFogueres = fogueres;
            MostraInici();
        }

        public void MostraInici()
        {
            for (int i = 0; i < fogueres.Length; i++)
            {
                if (numFogueres[i] == true)
                {
                    fogueres[i].SetActive(true);
                }
            }

            for (int i = 0; i < pocionsHP.Length; i++)
            {
                if (numPocionsHp[i] == false)
                {
                    pocionsHP[i].SetActive(false);
                }
            }

            for (int i = 0; i < pocionsSta.Length; i++)
            {
                if (numPocionsSta[i] == false)
                {
                    pocionsSta[i].SetActive(false);
                }
            }
        }

        public void EstatPocionsHp()
        {
            for (int i = 0; i < pocionsHP.Length; i++)
            {
                if (pocionsHP[i].activeSelf==false)
                {
                    numPocionsHp[i] = false;
                }
            }
        }

        public void EstatPocionsSta()
        {
            for (int i = 0; i < pocionsSta.Length; i++)
            {
                if (pocionsSta[i].activeSelf==false)
                {
                    numPocionsSta[i] = false;
                }
            }
        }

        public void EstatFogueres()
        {
            for (int i = 0; i < fogueres.Length; i++)
            {
                if (fogueres[i].activeSelf)
                {
                    numFogueres[i] = true;
                }
            }
        }

        public void Zona1()
        {
            Player.GetComponent<ThirdPersonMovement>().fastTravel1();
        }

        public void Zona2()
        {
            if (fogueres[1].activeSelf)
            {
                Player.GetComponent<ThirdPersonMovement>().fastTravel2();
            }
            
        }

        public void Zona3()
        {
            if (fogueres[2].activeSelf)
            {
                Player.GetComponent<ThirdPersonMovement>().fastTravel3();
            }

        }

        public void Zona4()
        {
            if (fogueres[3].activeSelf)
            {
                Player.GetComponent<ThirdPersonMovement>().fastTravel4();
            }

        }

        public void Zona5()
        {
            if (fogueres[4].activeSelf)
            {
                Player.GetComponent<ThirdPersonMovement>().fastTravel5();
            }

        }

        public Vector3 FTzona1()
        {
            if (fogueres[0].activeSelf)
            {
                return fogueres[0].transform.position;
            }

            return new Vector3(0,0,0);
        }

        public Vector3 FTzona2()
        {
            if (fogueres[1].activeSelf)
            {
                return fogueres[1].transform.position;
            }

            return new Vector3(0, 0, 0);
        }
        public Vector3 FTzona3()
        {
            if (fogueres[2].activeSelf)
            {
                return fogueres[2].transform.position;
            }

            return new Vector3(0, 0, 0);
        }
        public Vector3 FTzona4()
        {
            if (fogueres[3].activeSelf)
            {
                return fogueres[3].transform.position;
            }

            return new Vector3(0, 0, 0);
        }
        public Vector3 FTzona5()
        {
            if (fogueres[4].activeSelf)
            {
                return fogueres[4].transform.position;
            }

            return new Vector3(0, 0, 0);
        }
    }

}
