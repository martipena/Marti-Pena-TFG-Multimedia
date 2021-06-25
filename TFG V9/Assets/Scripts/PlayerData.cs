using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    [System.Serializable]
    public class PlayerData
    {
        public float currentHP;
        public float[] position;
        public bool[] numPocionsHp = new bool[20];
        public bool[] numPocionsSta = new bool[7];
        public bool[] numFogueres = new bool[5];
        public float maxStamina;
        public float maxHP;
        public bool teEspasa;
        public bool tePal;
        public bool covaSortida;
        public bool doubleJump;
        public bool moonJump;
        public int deathCount;
        public PlayerData (ThirdPersonMovement player)
        {
            currentHP = player.currentHP;
            position = new float[3];
            position[0] = player.saveLocation.x;
            position[1] = player.saveLocation.y;
            position[2] = player.saveLocation.z;
            maxStamina = player.maxStamina;
            maxHP = player.maxHP;
            teEspasa = player.teEspasa;
            tePal = player.tePal;
            numPocionsHp = player.pocionsHp;
            numPocionsSta = player.pocionsSta;
            numFogueres = player.fogueraOberta;
            covaSortida = player.covaSortida;
            doubleJump = player.doubleJump;
            moonJump = player.moonJump;
            deathCount = player.deaths;
        }
    }

}
/*
 position[0] = player.saveLocation.x;
            position[1] = player.saveLocation.y;
            position[2] = player.saveLocation.z;

position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;
            position[2] = player.transform.position.z;
 */