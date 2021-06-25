using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{
    public class EnemyBehaviour : MonoBehaviour
    {
        public Animator anim;
        public int idleAnim;
        public int walkAnim;
        public bool canNextMove=true;
        public float time;
        float idleTime;
        private GameObject wayPoint;
        private Vector3 wayPointPos;
        public bool playerFound = false;
        private float speed = 0f;
        private bool attack = false;
        private bool canAttack = false;
        public int hp;
        private bool canGetHit = true;
        // Start is called before the first frame update
        void Start()
        {
            idleAnim = Random.Range(0, 3);
            idle();
            walkAnim = Random.Range(0, 2);
            time = 2;
            idleTime = time;
        }

        // Update is called once per frame
        void Update()
        {
            
            noHP();
            if (canGetHit == true)
            {
                if (playerFound && attack == false)
                {
                    wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
                    transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
                    transform.LookAt(wayPoint.transform.position);
                    anim.Play("Zombie Running");
                    float dist = Vector3.Distance(wayPointPos, transform.position);
                    if (dist < 1)
                    {
                        attack = true;
                        canAttack = true;
                        enemyAttack.potTocar = true;
                    }

                }

                if (attack && canAttack)
                {
                    canAttack = false;
                    Debug.Log("Ataca");
                    anim.Play("Zombie Punching");
                    StartCoroutine(attackDuration());
                }
                if (canNextMove && playerFound == false)
                {
                    StopCoroutine(nextMove(time));
                    time = idleTime;
                    StartCoroutine(nextMove(time));
                }
            }
            else
            {
                anim.Play("Zombie Reaction Hit");
                transform.position += Vector3.forward * Time.deltaTime * 2;
            }
            
            
        }

        void move()
        {
            int choose = Random.Range(0, 5);
            if(choose == 0)
            {
                time/= 2;
                anim.SetBool("WalkingDone", true);
                this.transform.Rotate(0.0f, 0 * Time.deltaTime, 0.0f, Space.Self);
                idle();
            }else if (choose >= 1)
            {
                anim.SetBool("WalkingDone", false);
                time *= 5;
                walk();
            }
        }

        void idle()
        {
            if (idleAnim == 0)
            {
                anim.Play("Zombie Idle");
            }
            else if (idleAnim == 1)
            {
                anim.Play("Zombie Idle2");
            }
            else if (idleAnim == 2)
            {
                anim.Play("Zombie Idle3");
            }
        }

        void walk()
        {
            if (walkAnim == 0)
            {
                anim.Play("Walking");
            }else if (walkAnim == 1)
            {
                anim.Play("Walking2");
            }
        }

        void getHit()
        {
            hp -= 1;
            canGetHit = false;
            StartCoroutine(nextHit());
        }

        void noHP()
        {
            if (hp <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }

        IEnumerator nextHit()
        {
            yield return new WaitForSeconds(1.0f);
            canGetHit = true;
        }

        IEnumerator attackDuration()
        {
            yield return new WaitForSeconds(1.5f);
            attack = false;
            enemyAttack.potTocar = false;
            StopCoroutine(attackDuration());
            
        }

        IEnumerator nextMove(float time)
        {
            canNextMove = false;
            move();
            yield return new WaitForSeconds(time);
            canNextMove = true;
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                wayPoint = GameObject.Find("wayPoint");
                playerFound = true;
            }
            if (other.tag == "espasa" && Input.GetMouseButton(0) && canGetHit)
            {
                getHit();
            }

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                playerFound = false;
            }
        }
    }

}
