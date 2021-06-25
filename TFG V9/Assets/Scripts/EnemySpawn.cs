using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    public class EnemySpawn : MonoBehaviour
    {
        public GameObject enemy;
        public bool canSpawn = false;
        GameObject[] enemies = new GameObject[0];
        // Start is called before the first frame update
        void Start()
        {



        }

        // Update is called once per frame
        void Update()
        {
            int numSpawn = Random.Range(1, 4);
            if (LightningManager.Night == true && canSpawn == true)
            {
                
                for (int i = 0; i < numSpawn; i++)
                {

                    int randPosx = Random.Range(-15, 15);
                    int randPosZ = Random.Range(-15, 15);
                    float randomRot = Random.Range(-360, 360);
                    Instantiate(enemy, new Vector3(transform.position.x + randPosx, 0, transform.position.z + randPosZ), transform.rotation * Quaternion.Euler(0f, randomRot, 0f));
                }
                canSpawn = false;
            }
            else if (LightningManager.Night == false && canSpawn == false)
            {
                canSpawn = true;
                enemies = GameObject.FindGameObjectsWithTag("enemy");
                for (int i = 0; i < enemies.Length; i++)
                {
                    Destroy(enemies[i]);
                }
            }
        }
        
    }

}
