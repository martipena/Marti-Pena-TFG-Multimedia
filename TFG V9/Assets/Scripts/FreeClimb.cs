using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFG
{


    public class FreeClimb : MonoBehaviour
    {
        public Animator anim;

        bool inPosition;
        bool isLerping;
        float t;
        Vector3 startPos;
        Vector3 targetPos;
        Quaternion startRot;
        Quaternion targetRot;
        public float possitionOffset;
        public float rayTowardsMoveDir = 0.5f;
        public float offsetFromWall = 0.3f;
        public float speed_multiplier = 0.2f;
        public float climbSpeed = 3;
        public float rotateSpeed = 5;
        public float rayForwardTowardsWall = 1;

        public float horizontal;
        public float vertical;
        public bool isMid;
        public static Vector3 prova;
        public Transform helper2;

        public IKSnapshot baseIKsnapshot;

        public FreeClimbAnimHook a_hook;
        public Transform helper;
        public static bool isInverted = false;
        float delta;
        void Start()
        {
            //CheckForClimb();
            Init();
        }

        public void Init()
        {
            helper2 = new GameObject().transform;
            helper2.name = "climb 2 helper";
            helper = new GameObject().transform;
            helper.name = "climb helper";
            a_hook.Init(this, helper);
            //CheckForClimb();
        }

        public bool CheckForClimb()
        {

            Vector3 origin = transform.position;//Agafem la posició actual
            origin.y += 1.4f;//La agafem una mica mes amunt del terra
            Vector3 dir = transform.forward;
            RaycastHit hit;

            if (Physics.Raycast(origin, dir, out hit, 0.5f) && hit.transform.tag == "climbable")
            {
                ThirdPersonMovement.stopClimb = false;
                helper.position = PosWithOffset(origin, hit.point);
                InitForClimb(hit);
                return true;

            }
            else
            {
                return false;
            }
        }

        void InitForClimb(RaycastHit hit)
        {
            helper.transform.rotation = Quaternion.LookRotation(-hit.normal);
            startPos = transform.position;
            targetPos = hit.point + (hit.normal * offsetFromWall);
            t = 0;
            inPosition = false;
            anim.CrossFade("climb_idle", 2);
        }

        /*void Update()
        {
            delta = Time.deltaTime;
            Tick(delta);
        }*/

        public void Tick(float delta1)
        {
            //helper2.transform.position = helper.transform.position;
            delta = delta1;
            if (!inPosition)
            {
                GetInPosition();
                return;
            }

            if (!isLerping)
            {
                if (isInverted)
                {
                    horizontal = -Input.GetAxis("Horizontal");
                    vertical = -Input.GetAxis("Vertical");
                }
                else
                {
                    horizontal = Input.GetAxis("Horizontal");
                    vertical = Input.GetAxis("Vertical");
                }
                
                float m = Mathf.Abs(horizontal) + Mathf.Abs(vertical);

                Vector3 h = helper.right * horizontal;
                Vector3 v = helper.up * vertical;
                Vector3 moveDir = (h + v).normalized;

                if (isMid)
                {
                    if (moveDir == Vector3.zero)
                        return;
                }
                else
                {
                    bool canMove = CanMove(moveDir);
                    if (!canMove || moveDir == Vector3.zero)
                        return;
                }

                isMid = !isMid;
                t = 0;
                isLerping = true;
                startPos = transform.position;
                Vector3 tp = helper.position - transform.position;
                float d = Vector3.Distance(helper.position, startPos) / 2;
                tp *= possitionOffset;
                tp += transform.position;
                targetPos = (isMid) ? tp : helper.position;


                //targetPos = helper.position;
                a_hook.CreatePositions(targetPos, moveDir, isMid);
            }
            else
            {
                t += delta * climbSpeed;
                if (t > 0.5f)
                {
                    t = 0.5f;
                    isLerping = false;
                }
                Vector3 cp = Vector3.Lerp(startPos, targetPos, t);
                transform.position = cp;
                transform.rotation = Quaternion.Slerp(transform.rotation, helper.rotation, delta * rotateSpeed);
            }
        }

        bool CanMove(Vector3 moveDir)
        {
            Vector3 origin = transform.position;
            float dis = rayTowardsMoveDir;
            Vector3 dir = moveDir;
            //DebugLine.singleton.SetLine(origin, origin + (dir * dis), 0);
            //Debug.DrawRay(origin, dir * dis);

            //Direcio a la que et vols moure
            RaycastHit hit;

            if (Physics.Raycast(origin, dir, out hit, dis))
            {
                return false;
            }

            origin += moveDir * dis;
            dir = helper.forward;
            float dis2 = rayForwardTowardsWall;

            //Busca una paret davant
            //DebugLine.singleton.SetLine(origin, origin + (dir * dis2), 1);
            Debug.DrawRay(origin, dir * dis2);
            if (Physics.Raycast(origin, dir, out hit, dis2))
            {
                helper.position = PosWithOffset(origin, hit.point);
                helper.rotation = Quaternion.LookRotation(-hit.normal);
                return true;
            }

            origin = origin + (dir * dis2);
            dir = -moveDir;
            //DebugLine.singleton.SetLine(origin, origin + dir, 1);
            //Debug.DrawRay(origin, dir * dis2);
            if (Physics.Raycast(origin, dir, out hit, rayForwardTowardsWall))
            {
                helper2.transform.position = helper.transform.position;
                helper.position = PosWithOffset(origin, hit.point);
                helper.rotation = Quaternion.LookRotation(-hit.normal);
                if (helper2.transform.position.z > helper.transform.position.z && ThirdPersonMovement.moureEsc == false)
                {
                    //Debug.Log("deixa");
                    ThirdPersonMovement.moureEsc = true;
                }

                return true;
            }

            //return false;

            origin += dir * dis2;
            dir = -Vector3.up;
            //DebugLine.singleton.SetLine(origin, origin + dir, 2);
            //Debug.DrawRay(origin,dir);

            if (Physics.Raycast(origin, dir, out hit, dis2))
            {
                float angle = Vector3.Angle(-helper.forward, hit.normal);
                if (angle < 40)
                {
                    helper.position = PosWithOffset(origin, hit.point);
                    helper.rotation = Quaternion.LookRotation(-hit.normal);
                    return true;
                }
            }

            return false;
        }

        void GetInPosition()
        {
            t += delta;
            if (t > 0.5f)
            {
                t = 0.5f;
                inPosition = true;

                a_hook.CreatePositions(targetPos, Vector3.zero, false);
            }

            Vector3 tp = Vector3.Lerp(startPos, targetPos, t);
            transform.position = tp;
            transform.rotation = Quaternion.Slerp(transform.rotation, helper.rotation, delta * rotateSpeed);
        }

        Vector3 PosWithOffset(Vector3 origin, Vector3 target)
        {
            Vector3 direction = origin - target;
            direction.Normalize();
            Vector3 offset = direction * offsetFromWall;
            return target + offset;
        }
        public void restartPos()
        {

        }
    }

    [System.Serializable]
    public class IKSnapshot
    {
        public Vector3 rh, lh, lf, rf;
    }
}