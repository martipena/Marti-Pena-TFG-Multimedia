using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace TFG
{
    public class ThirdPersonMovement : MonoBehaviour
    {
        public CharacterController controller;
        public Transform cam;
        FreeClimb freeClimb;
        public float speed = 6f;
        public float originalSpeed;
        float baseSpeed;
        public GameObject movimentcoses;//rigidbody per moure coses
        public Vector3 posMoure;

        public float turnSmoothTime = 0.1f;
        float turnSmoothVelocity;
        public float gravity = -9.81f;
        public float jumpHeight = 3f;
        float baseJump;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;
        public float stamina = 2.5f;
        public float maxStamina = 2.5f;
        public float maxHP;
        public float currentHP;
        public static float hpCube;
        public Text valorSta;
        Animator anim;

        Vector3 velocity;
        public bool isGrounded;
        bool canSprint = true;
        bool canRestore = false;
        bool canTorch = true;
        bool canSword = true;
        bool canCube = true;
        public static bool swim = false;
        public bool isClimbing;

        public Slider staminaBar;
        public Image background;
        public Image fillStamina;

        public Slider healthBar;
        public Slider vidaTorch;
        public Slider vidaCube;

        public Slider staminaBarEsp;
        public Image backgroundEsp;
        public Image fillStaminaEsp;

        public Slider healthBarEsp;
        public Slider vidaTorchEsp;
        public Slider vidaCubeEsp;

        public Slider staminaBarEng;
        public Image backgroundEng;
        public Image fillStaminaEng;

        public Slider healthBarEng;
        public Slider vidaTorchEng;
        public Slider vidaCubeEng;

        public GameObject wayPoint;
        public GameObject torch;
        public GameObject torchFire;
        public GameObject espasa;
        public GameObject posRespawn;
        public GameObject cubGel;
        public GameObject posMirar;
        public GameObject panelPrompt;
        public GameObject panelBonfire;
        public GameObject menuBonfire;

        public GameObject panelPromptEsp;
        public GameObject panelBonfireEsp;
        public GameObject menuBonfireEsp;

        public GameObject panelPromptEng;
        public GameObject panelBonfireEng;
        public GameObject menuBonfireEng;

        //public Rigidbody rigid;
        public static Vector3 posRes;
        public GameObject defaultRes;
        float delta;
        [SerializeField]
        public static bool stopClimb = true;
        public static bool resetPos = false;
        public static bool teFoc = false;
        public static bool teGel = false;
        public static bool palTrencat = false;
        public static bool blocFos = false;
        public bool tePal = false;
        public bool teEspasa = false;
        public bool agafaLloc = false;
        public bool teBlocGel = false;
        public bool caigudaSalt = false;
        public bool noMoureCam = false;
        public static bool gastaSta = true;
        public static bool saltaAigua = true;
        public GameObject camara;
        public GameObject playerCharacter;
        float posy;
        public static bool enemicEtToca = false;
        public static bool enemicPotTocar = true;
        public static bool teFred = false;
        public static bool teCalor = false;
        public static bool teCalorExtrema = false;
        public static bool moureEsc = false;
        public static bool eliminaText = false;
        public Vector3 saveLocation;
        public string sceneName;
        public static float valorCorrent;//velocitat del corrent del aigua
        private float timer = 0.5f;
        float curH;
        Vector3 newPos;
        public GameObject tutorials;
        public GameObject[] mostraTutorial = new GameObject[0];
        public GameObject tutorialsEsp;
        public GameObject[] mostraTutorialEsp = new GameObject[0];
        public GameObject tutorialsEng;
        public GameObject[] mostraTutorialEng = new GameObject[0];
        public GameObject sortidaCova;
        public GameObject sparkelFinal;
        public bool doubleJump = false;
        public bool moonJump = false;
        public GameObject doubleJumpPotion;
        public GameObject moonJumpPotion;
        public bool isJumping;
        public bool canDoubleJump;
        public bool helperJump = false;
        public static bool primerPal = false;
        public GameObject gameController;
        public bool[] pocionsHp = new bool[20];
        public bool[] pocionsSta = new bool[7];
        public bool[] fogueraOberta = new bool[5];
        public bool covaSortida=true;
        public int deaths;
        private void Start()
        {
            //vidaCube.value = blocGel.hpBloc;
            //vidaTorch.value = palHP.hp;
            teFred = false;
            teCalor = false;
            teCalorExtrema = false;
            hpCube = blocGel.hpBloc;
            posMoure = movimentcoses.transform.localPosition;
            posRes = defaultRes.transform.position;
            originalSpeed = speed;
            sceneName = SceneManager.GetActiveScene().name;
            camara.SetActive(false);
            camara.SetActive(true);
            baseJump = jumpHeight;
            baseSpeed = speed;
            stamina = maxStamina;
            currentHP = maxHP;
            staminaBar.maxValue = maxStamina;
            staminaBar.value = maxStamina;
            staminaBarEsp.maxValue = maxStamina;
            staminaBarEsp.value = maxStamina;
            staminaBarEng.maxValue = maxStamina;
            staminaBarEng.value = maxStamina;
            vidaCube.maxValue = 300;
            vidaTorch.maxValue = 100;
            vidaCubeEsp.maxValue = 300;
            vidaTorchEsp.maxValue = 100;
            vidaCubeEng.maxValue = 300;
            vidaTorchEng.maxValue = 100;
            healthBar.maxValue = maxHP;
            healthBar.value = maxHP;
            healthBarEsp.maxValue = maxHP;
            healthBarEsp.value = maxHP;
            healthBarEng.maxValue = maxHP;
            healthBarEng.value = maxHP;
            //background.color = Color.Lerp(Color.green, Color.green, 1);
            //fillStamina.color = Color.Lerp(Color.green, Color.green, 1);
            freeClimb = GetComponent<FreeClimb>();
            anim = GetComponentInChildren<Animator>();
            if (covaSortida)
            {
                LightningManager.canChangeTime = false;
            }
            if (MainMenu.carga)
            {
                MainMenu.carga = false;
                LoadPlayer();
            }
        }

        // Update is called once per frame
        void Update()
        {
            
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                //The position of the waypoint will update to the player's position
                UpdatePosition();
                timer = 0.5f;
            }

            if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)//pausa
            {
                Time.timeScale = 0;
                
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
            {
                tutorials.SetActive(false);
                tutorialsEsp.SetActive(false);
                tutorialsEng.SetActive(false);
                for (int i = 0; i < mostraTutorial.Length; i++)
                {
                    mostraTutorial[i].SetActive(false);
                    mostraTutorialEsp[i].SetActive(false);
                    mostraTutorialEng[i].SetActive(false);
                }
                Time.timeScale = 1;
                menuBonfire.SetActive(false);
                menuBonfireEsp.SetActive(false);
                menuBonfireEng.SetActive(false);
            }
            if (Time.timeScale == 1)//Amaga elements de la UI
            {
                Cursor.visible = false;
                if (staminaBar.value == staminaBar.maxValue || staminaBarEsp.value == staminaBarEsp.maxValue || staminaBarEng.value == staminaBarEng.maxValue)
                {
                    staminaBar.gameObject.SetActive(false);
                    staminaBarEsp.gameObject.SetActive(false);
                    staminaBarEng.gameObject.SetActive(false);
                }
                else
                {
                    
                    if (GameControl.catalan)
                    {
                        staminaBar.gameObject.SetActive(true);
                    }else if (GameControl.spanish)
                    {
                        staminaBarEsp.gameObject.SetActive(true);
                    }else if (GameControl.english)
                    {
                        staminaBarEng.gameObject.SetActive(true);
                    }
                }
                if (healthBar.value == healthBar.maxValue)
                {
                    //healthBar.gameObject.SetActive(false);
                }
                else
                {
                    if (GameControl.catalan)
                    {
                        healthBar.gameObject.SetActive(true);
                    }else if (GameControl.spanish)
                    {
                        healthBarEsp.gameObject.SetActive(true);
                    }else if (GameControl.english)
                    {
                        healthBarEng.gameObject.SetActive(true);
                    }
                    
                }
                movimentcoses.transform.localPosition = posMoure;
                if (correntAigua.tocat)
                {
                    controller.Move(correntAigua.direccioFinal * Time.deltaTime * valorCorrent);
                }
                else
                {

                }

                if (respawnPlayer.oob)
                {
                    respawnPlayer.oob = false;
                    outOfBounds();
                }
                vidaTorch.value = palHP.hp;
                vidaCube.value = hpCube;
                vidaTorchEsp.value = palHP.hp;
                vidaCubeEsp.value = hpCube;
                vidaTorchEng.value = palHP.hp;
                vidaCubeEng.value = hpCube;
                healthBar.value = currentHP;
                healthBarEsp.value = currentHP;
                healthBarEng.value = currentHP;
                if (currentHP <= 0)
                {
                    GameControl.deaths++;
                    SceneManager.LoadScene("MainMenu");
                    LoadPlayer();
                }
                if (enemicEtToca == true)//mal que et fa un enemic al tocarte i temps que tarda en poderte donar un altre cop
                {
                    enemicEtToca = false;
                    currentHP -= 20;
                    StartCoroutine(nextHit());

                }
                if (teFred && teFoc)
                {

                }
                if (teFred && !teFoc)
                {
                    currentHP -= Time.deltaTime;
                }
                else if (teCalor && canCube == false)
                {
                    currentHP -= Time.deltaTime/2;
                }
                else if (teCalor && canCube == true)
                {
                    currentHP -= Time.deltaTime;
                }
                else if (teCalorExtrema && canCube == false)
                {
                    currentHP -= Time.deltaTime/5;
                }
                else if (teCalorExtrema && canCube == true)
                {

                    currentHP -= Time.deltaTime * 5;
                }

                if (Water.potNadar)
                {
                    if (agafaLloc == false)
                    {
                        posy = this.transform.position.y;
                        agafaLloc = true;
                    }
                    speed = originalSpeed / 2;
                    gravity = 0;
                    velocity.y = 0;
                    this.transform.position = new Vector3(this.transform.position.x, posy, this.transform.position.z);
                    //anim.enabled = false;
                    
                    anim.SetFloat("move", 1.5f);//Animació nedar
                    anim.SetFloat("swim", 0);
                    //anim.enabled = true;
                    if (gastaSta == true)
                    {
                        staminaSwimming();
                    }
                    else
                    {

                    }

                }
                else
                {
                    gravity = -9.81f;
                    agafaLloc = false;
                }
                if (palTrencat)
                {
                    palTrencat = false;
                    tePal = false;
                    torch.SetActive(false);
                    torchFire.SetActive(false);
                    teFoc = false;
                    vidaTorch.gameObject.SetActive(false);
                    vidaTorchEsp.gameObject.SetActive(false);
                    vidaTorchEng.gameObject.SetActive(false);
                }
                if (blocFos)
                {
                    canCube = true;
                    blocFos = false;
                    teBlocGel = false;
                    cubGel.SetActive(false);
                    vidaCube.gameObject.SetActive(false);
                    vidaCubeEsp.gameObject.SetActive(false);
                    vidaCubeEng.gameObject.SetActive(false);
                }
                isGrounded = OnGround();
                if (!isGrounded && velocity.y < -6 || !isGrounded && velocity.y > 0)
                {
                    anim.SetFloat("move", 1);
                    anim.SetFloat("jump", 1);
                }
                if (velocity.y < -15 && velocity.y > -30 && isGrounded && moonJump == false)//Dany per caiguda
                {
                    currentHP -= 20;
                }
                else if (velocity.y < -30 && velocity.y> -40 && isGrounded && moonJump == false)
                {
                    currentHP -= 50;
                }
                else if (velocity.y < -40 && isGrounded && moonJump == false)
                {
                    currentHP -= 100;
                }

                if (velocity.y < -5 && OnSlope())//Evita quedar-se enganxat en pendents
                {
                    controller.Move(Vector3.back * Time.deltaTime * 10);
                }
                if (!isGrounded && !Input.GetButton("Run"))
                {
                    speed -= Time.deltaTime * 3;
                }
                if (caigudaSalt == true)
                {
                    velocity.y += gravity * Time.deltaTime;
                }
                if (isGrounded)
                {
                    FreeClimb.isInverted = false;
                    caigudaSalt = false;
                    if (canSprint == true)
                    {
                        speed = originalSpeed;
                    }
                    

                }
                delta = Time.deltaTime;
                if (!isGrounded && stopClimb)//guarda pal i espasa al escalar
                {

                    isClimbing = freeClimb.CheckForClimb();

                    if (isClimbing)
                    {
                        velocity.y = -2;
                        resetPos = false;
                        torch.SetActive(false);
                        torchFire.SetActive(false);
                        canTorch = true;
                        espasa.SetActive(false);
                        canSword = true;
                        teFoc = false;
                        disableControl();
                    }

                }
                if (moureEsc)
                {
                    //StartCoroutine(waitToGetUp());
                    //finalEscaladaEsq();
                }

                if (isClimbing && Input.GetButtonDown("Jump"))//Aixecarse al saltar
                {
                    enableControl();
                }
                
                if (isClimbing && this.transform.localRotation.eulerAngles.z > 60)//Aixecarse automaticament al arribar a dalt
                {
                    Debug.Log("Invert");
                    FreeClimb.isInverted = true;
                    // enableControl();
                }
                if (isClimbing && this.transform.localRotation.eulerAngles.x > 86 && FreeClimb.isInverted==true)//Aixecarse automaticament al arribar a dalt
                {
                    Debug.Log("Aixeca");
                    FreeClimb.isInverted = false;
                    enableControl();
                }
                if (isClimbing && this.transform.localRotation.eulerAngles.x > 60 && FreeClimb.isInverted==false)//Aixecarse automaticament al arribar a dalt
                {
                    Debug.Log("NoInvert");
                    //FreeClimb.isInverted = false;
                    enableControl();
                }
                if (isClimbing)
                {
                    staminaClimbing();
                    velocity.y = 0;
                    freeClimb.Tick(delta);
                    return;
                }
                /*if (isClimbing)
                {
                    freeClimb.Tick(delta);
                    return;
                }*/
                else
                {
                    staminaBar.value = stamina;
                    staminaBarEsp.value = stamina;
                    staminaBarEng.value = stamina;

                    //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);//Mira si toca el terra
                    //Debug.Log("Terra: " + Physics.CheckSphere(groundCheck.position, groundDistance, groundMask));

                    if (isGrounded && velocity.y < 0)
                    {
                        velocity.y = -2f;
                    }

                    if (Input.GetKeyDown(KeyCode.E) && tePal == true)
                    {
                        if (canTorch == true)
                        {
                            if (GameControl.catalan)
                            {
                                vidaTorch.gameObject.SetActive(true);
                            }else if (GameControl.spanish)
                            {
                                vidaTorchEsp.gameObject.SetActive(true);
                            }else if (GameControl.english)
                            {
                                vidaTorchEng.gameObject.SetActive(true);
                            }

                            torch.SetActive(true);
                            canTorch = false;

                        }
                        else if (canTorch == false)
                        {
                            vidaTorch.gameObject.SetActive(false);
                            vidaTorchEsp.gameObject.SetActive(false);
                            vidaTorchEng.gameObject.SetActive(false);
                            torch.SetActive(false);
                            torchFire.SetActive(false);
                            canTorch = true;
                            teFoc = false;
                        }

                    }
                    if (Input.GetKeyDown(KeyCode.E) && teBlocGel == true)
                    {

                        if (canCube == true)
                        {
                            vidaCube.gameObject.SetActive(true);
                            cubGel.SetActive(true);
                            canCube = false;
                        }
                        else if (canCube == false)
                        {
                            vidaCube.gameObject.SetActive(false);
                            cubGel.SetActive(false);
                            canCube = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && teEspasa == true)//Treure espasa
                    {
                        if (canSword == true)
                        {
                            espasa.SetActive(true);
                            canSword = false;
                        }
                        else if (canSword == false)
                        {
                            espasa.SetActive(false);
                            canSword = true;
                        }
                    }
                    
                    if (torch.activeSelf && teFoc == true)
                    {
                        torchFire.SetActive(true);
                    }

                    float horizontal = Input.GetAxisRaw("Horizontal");
                    float vertical = Input.GetAxisRaw("Vertical");
                    Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


                    if (stamina < maxStamina && canSprint == false && isGrounded || canRestore == true && isGrounded)//Resistencia
                    {
                        restoreStamina();
                    }
                    if (canSprint)
                    {
                        if (direction != new Vector3(0, 0, 0))
                        {
                            if (Input.GetButton("Run") && isGrounded && saltaAigua==true)//Sprint
                            {
                                canRestore = false;
                                sprint();
                            }
                            else if (Input.GetButton("Run") && !isGrounded)
                            {
                                speed -= Time.deltaTime * 15;
                            }
                        }
                        if (Input.GetButtonUp("Run"))
                        {
                            canRestore = true;
                            restoreStamina();
                        }


                    }
                    if (Water.restauraSta)
                    {
                        canRestore = true;
                        restoreStamina();
                        Water.restauraSta = false;
                    }

                    valorSta.text = stamina.ToString();

                    if (Water.potNadar && direction.magnitude < 0.1f)
                    {
                        anim.SetFloat("move", 1.5f);//Animació nedar
                        anim.SetFloat("swim", 1);
                    }
                    if (direction.magnitude >= 0.1f)//Moviment
                    {
                        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                        transform.rotation = Quaternion.Euler(0f, angle, 0f);

                        if (Input.GetButton("Run") == false && isGrounded)//Mante la animacio de salt si deixa de sprint
                        {
                            anim.SetFloat("move", 0.5f);
                            anim.SetFloat("run", 0.5f);
                        }
                        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                        controller.Move(moveDir.normalized * speed * Time.deltaTime);

                    }
                    else if (Input.GetButtonDown("Jump") && isGrounded && direction.magnitude < 0.1f && saltaAigua==true)//Salt petit
                    {
                        helperJump = true;
                        isJumping = true;
                        anim.SetFloat("move", 1);
                        anim.SetFloat("jump", 0);
                        speed += 5;
                        velocity.y = Mathf.Sqrt((jumpHeight / 2) * -2f * gravity);
                       
                    }
                    else if (canSword == false && Input.GetMouseButton(0) && direction.magnitude < 0.1f && isGrounded)//Atacar
                    {
                        anim.Play("swordAttack", 0, 0);
                        //anim.SetFloat("move", 2);//Animació atac espasa
                        //anim.SetFloat("sword", 0);
                        
                    }
                    else if (direction.magnitude < 0.1f && isGrounded)//idle
                    {

                        anim.SetFloat("move", 0);
                    }
                    
                    if (Input.GetButton("Jump") && isGrounded && direction.magnitude >= 0.1f && saltaAigua == true)//Salt
                    {
                        anim.SetFloat("move", 0.5f);
                        anim.SetFloat("run", 0);
                        isJumping = true;
                        helperJump = true;
                        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                        StartCoroutine(jumpFall());
                        
                    }

                    if (Input.GetButtonUp("Jump") && doubleJump)
                    {
                        if (helperJump)
                        {
                            canDoubleJump = true;
                        }
                        
                    }

                    if(canDoubleJump && Input.GetButton("Jump"))//Doble salt
                    {
                        canDoubleJump = false;
                        if (moonJump)//Salt infinit
                        {
                            helperJump = true;
                        }
                        else
                        {
                            helperJump = false;
                        }
                        
                        velocity.y = Mathf.Sqrt(jumpHeight * 2 * -2f * gravity);
                        StartCoroutine(jumpFall());
                    }

                    if (isGrounded)
                    {
                        isJumping = false;
                        canDoubleJump = false;
                    }
                    

                    if (canSprint == false)
                    {
                        anim.SetFloat("move", 0.5f);
                        anim.SetFloat("run",0);
                    }
                    velocity.y += gravity * Time.deltaTime;
                    controller.Move(velocity * Time.deltaTime);
                    return;

                }
            }




        }


        void sprint()
        {
            if (stamina > 0)
            {
                if (isGrounded)
                {
                    anim.SetFloat("move", 0.5f);
                    anim.SetFloat("run",1);
                    speed = 15f;
                    stamina -= Time.deltaTime;
                }

            }
            else if (stamina < 0)
            {
                anim.SetFloat("move", 0.5f);
                anim.SetFloat("run", 0);
                canSprint = false;
                jumpHeight = jumpHeight / 2;
                speed = baseSpeed / 2f;
            }
        }

        void outOfBounds()
        {
            correntAigua.tocat = false;
            speed = originalSpeed;
            playerCharacter.SetActive(false);
            //playerCharacter.GetComponent<Rigidbody>().MovePosition(posRes);
            playerCharacter.transform.position = posRes;
            playerCharacter.SetActive(true);
            stamina = maxStamina;
            Water.potNadar = false;
        }

        public void fastTravel1()
        {
            Time.timeScale = 1;
            playerCharacter.SetActive(false);
            playerCharacter.transform.position = gameController.GetComponent<GameControl>().FTzona1();
            playerCharacter.SetActive(true);
        }

        public void fastTravel2()
        {
            Time.timeScale = 1;
            playerCharacter.SetActive(false);
            playerCharacter.transform.position = gameController.GetComponent<GameControl>().FTzona2();
            playerCharacter.SetActive(true);
        }

        public void fastTravel3()
        {
            Time.timeScale = 1;
            playerCharacter.SetActive(false);
            playerCharacter.transform.position = gameController.GetComponent<GameControl>().FTzona3();
            playerCharacter.SetActive(true);
        }

        public void fastTravel4()
        {
            Time.timeScale = 1;
            playerCharacter.SetActive(false);
            playerCharacter.transform.position = gameController.GetComponent<GameControl>().FTzona4();
            playerCharacter.SetActive(true);
        }

        public void fastTravel5()
        {
            Time.timeScale = 1;
            playerCharacter.SetActive(false);
            playerCharacter.transform.position = gameController.GetComponent<GameControl>().FTzona5();
            playerCharacter.SetActive(true);
        }

        void restoreStamina()
        {
            if (stamina < maxStamina)
            {

                if (canRestore == true)
                {
                    //speed = baseSpeed/2f;
                    stamina += Time.deltaTime * 2f;
                }
                else
                {
                    background.color = Color.Lerp(Color.red, Color.red, 1);
                    backgroundEsp.color = Color.Lerp(Color.red, Color.red, 1);
                    backgroundEng.color = Color.Lerp(Color.red, Color.red, 1);
                    fillStamina.color = Color.Lerp(Color.red, Color.black, Mathf.PingPong(Time.time, 1f));
                    fillStaminaEsp.color = Color.Lerp(Color.red, Color.black, Mathf.PingPong(Time.time, 1f));
                    fillStaminaEng.color = Color.Lerp(Color.red, Color.black, Mathf.PingPong(Time.time, 1f));
                    stamina += Time.deltaTime * 1.5f;
                }


                if (stamina >= maxStamina)
                {
                    jumpHeight = baseJump;
                    speed = baseSpeed;
                    background.color = Color.Lerp(Color.yellow, Color.yellow, 1);
                    backgroundEsp.color = Color.Lerp(Color.yellow, Color.yellow, 1);
                    backgroundEng.color = Color.Lerp(Color.yellow, Color.yellow, 1);
                    fillStamina.color = Color.Lerp(Color.yellow, Color.yellow, 1);
                    fillStaminaEsp.color = Color.Lerp(Color.yellow, Color.yellow, 1);
                    fillStaminaEng.color = Color.Lerp(Color.yellow, Color.yellow, 1);
                    stamina = maxStamina;
                    canSprint = true;
                    canRestore = false;
                }

            }

        }
        void staminaClimbing()
        {
            staminaBar.value = stamina;
            staminaBarEsp.value = stamina;
            staminaBarEng.value = stamina;
            if (stamina > 0)
            {
                stamina -= Time.deltaTime / 6;
            }
            else if (stamina < 0)
            {
                enableControl();
            }
        }

        void staminaSwimming()
        {
            staminaBar.value = stamina;
            staminaBarEsp.value = stamina;
            staminaBarEng.value = stamina;
            if (stamina > 0)
            {
                stamina -= Time.deltaTime / 2;
            }
            else if (stamina < 0)
            {
                correntAigua.tocat = false;
                speed = originalSpeed;
                playerCharacter.SetActive(false);
                //playerCharacter.GetComponent<Rigidbody>().MovePosition(posRes);
                playerCharacter.transform.position = posRes;
                playerCharacter.SetActive(true);
                stamina = maxStamina;
                Water.potNadar = false;
                saltaAigua = true;
            }
        }

        bool OnGround()
        {
            Vector3 origin = transform.position;
            origin.y += 0.4f;
            Vector3 direction = -transform.up;
            RaycastHit hit;

            if (Physics.Raycast(origin, direction, out hit, 0.6f) && hit.transform.tag!="water")
            {
                return true;
            }


            return false;
        }

        bool OnSlope()
        {
            Vector3 origin = transform.position;
            origin.y += 0.4f;
            Vector3 direction = transform.forward;
            Vector3 directionB = -transform.forward;
            RaycastHit hit;

            if (Physics.Raycast(origin, direction, out hit, 0.6f) && hit.transform.tag != "climbable")
            {
                return true;
            }

            if (Physics.Raycast(origin, directionB, out hit, 0.6f) && hit.transform.tag != "climbable")
            {
                return true;
            }


            return false;
        }

        public void OmpleLlistes()
        {
            pocionsHp = gameController.GetComponent<GameControl>().numPocionsHp;
            pocionsSta = gameController.GetComponent<GameControl>().numPocionsSta;
            fogueraOberta = gameController.GetComponent<GameControl>().numFogueres;
        }

        public void disableControl()
        {
            controller.enabled = false;
        }

        public void enableControl()
        {
            canRestore = true;
            restoreStamina();
            anim.gameObject.SetActive(false);
            anim.gameObject.SetActive(true);
            controller.enabled = true;
            isClimbing = false;
            anim.SetFloat("move", 0);
            resetPos = true;
            StartCoroutine(nextClimb());
        }

        public void finalEscaladaEsq()//arregla un error al escalar per la esquerra al eix z
        {
           /* enableControl();
            playerCharacter.SetActive(false);
            Debug.Log("Z: " + playerCharacter.transform.position.z + " Y " + playerCharacter.transform.position.y);
            //playerCharacter.transform.position = new Vector3(playerCharacter.transform.position.x, playerCharacter.transform.position.y + 0.5f, playerCharacter.transform.position.z - 2);
            Debug.Log("Z: " + playerCharacter.transform.position.z + " Y " + playerCharacter.transform.position.y);
            playerCharacter.SetActive(true);
            enableControl();
            moureEsc = false;*/
            /*if (isGrounded)
            {
                moureEsc = false;
            }*/

        }

        public void SavePlayer()
        {
            deaths = GameControl.deaths;
            OmpleLlistes();
            SaveSystem.SavePlayer(this);
            menuBonfire.SetActive(false);
            Time.timeScale = 1;
        }

        public void LoadPlayer()
        {
            Temperatura.potcambiar = false;
            PlayerData data = SaveSystem.LoadPlayer();
            if (data != null)
            {
                curH = data.currentHP;
                newPos.x = data.position[0];
                newPos.y = data.position[1];
                newPos.z = data.position[2];
                maxHP = data.maxHP;
                teEspasa = data.teEspasa;
                tePal = data.tePal;
                maxStamina = data.maxStamina;
                pocionsHp = data.numPocionsHp;
                pocionsSta = data.numPocionsSta;
                fogueraOberta = data.numFogueres;
                covaSortida = data.covaSortida;
                doubleJump = data.doubleJump;
                moonJump = data.moonJump;
                GameControl.deaths = data.deathCount;
                palHP.hp = 100;
                Temperatura.reset = true;
                if (doubleJump)
                {
                    doubleJumpPotion.SetActive(false);
                }
                if (moonJump)
                {
                    moonJumpPotion.SetActive(false);
                }
                if (covaSortida)
                {
                    sortidaCova.SetActive(false);
                }
                gameController.GetComponent<GameControl>().ComprovaInici(pocionsHp, pocionsSta, fogueraOberta);

                correntAigua.tocat = false;
                speed = originalSpeed;
                playerCharacter.SetActive(false);
                playerCharacter.transform.position = newPos;
                playerCharacter.SetActive(true);
                stamina = maxStamina;
                Water.potNadar = false;
                saltaAigua = true;
                enableControl();
                LightningManager.canChangeTime = true;
            }
            else
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Game");
            }
            
        }

        IEnumerator waitToGetUp()//Temps que tarda fins que es pugui tornar a enganxar a la paret
        {

            // suspend execution for 5 seconds
            yield return new WaitForSeconds(0.5f);
            enableControl();
            moureEsc = false;
            Debug.Log("Aixeca");
        }

        IEnumerator nextClimb()//Temps que tarda fins que es pugui tornar a enganxar a la paret
        {

            // suspend execution for 5 seconds
            yield return new WaitForSeconds(0.5f);
            stopClimb = true;
            StopCoroutine(nextClimb());
        }

        IEnumerator jumpFall()
        {
            yield return new WaitForSeconds(0.5f);
            caigudaSalt = true;
        }

        IEnumerator nextHit()
        {
            enemicPotTocar = false;
            yield return new WaitForSeconds(1.0f);
            enemicPotTocar = true;
        }

        void manageTutorials(int num)
        {
            if (GameControl.catalan)
            {
                tutorials.SetActive(true);
                mostraTutorial[num].SetActive(true);
            }else if (GameControl.spanish)
            {
                tutorialsEsp.SetActive(true);
                mostraTutorialEsp[num].SetActive(true);
            }else if (GameControl.english)
            {
                tutorialsEng.SetActive(true);
                mostraTutorialEng[num].SetActive(true);
            }
            
            Time.timeScale = 0;
            
        }

        void OnTriggerStay(Collider other)
        {
            if (other.tag == "pal" && tePal == false)
            {
                
                if (GameControl.catalan)
                {
                    panelPrompt.SetActive(true);
                    if (Input.GetKey(KeyCode.F))
                    {
                        Destroy(other.gameObject);
                        palHP.hp = 100;
                        tePal = true;
                        panelPrompt.SetActive(false);
                        if (primerPal == false)
                        {
                            manageTutorials(1);
                        }
                        primerPal = true;
                    }
                }else if (GameControl.spanish)
                {
                    panelPromptEsp.SetActive(true);
                    if (Input.GetKey(KeyCode.F))
                    {
                        Destroy(other.gameObject);
                        palHP.hp = 100;
                        tePal = true;
                        panelPromptEsp.SetActive(false);
                        if (primerPal == false)
                        {
                            manageTutorials(1);
                        }
                        primerPal = true;
                    }
                }
                else if (GameControl.english)
                {
                    panelPromptEng.SetActive(true);
                    if (Input.GetKey(KeyCode.F))
                    {
                        Destroy(other.gameObject);
                        palHP.hp = 100;
                        tePal = true;
                        panelPromptEng.SetActive(false);
                        if (primerPal == false)
                        {
                            manageTutorials(1);
                        }
                        primerPal = true;
                    }
                }

            }
            else if (other.tag == "pal" && tePal == true)
            {
                Destroy(other.gameObject);
                palHP.hp =vidaTorch.maxValue;
                palHP.hp = vidaTorchEsp.maxValue;
                palHP.hp = vidaTorchEng.maxValue;
            }
            if (other.tag == "sword" && teEspasa == false)
            {
                if (GameControl.catalan)
                {
                    panelPrompt.SetActive(true);
                    if (Input.GetKey(KeyCode.F))
                    {
                        Destroy(other.gameObject);
                        teEspasa = true;
                        panelPrompt.SetActive(false);
                        manageTutorials(0);
                    }
                }else if (GameControl.spanish)
                {
                    panelPromptEsp.SetActive(true);
                    if (Input.GetKey(KeyCode.F))
                    {
                        Destroy(other.gameObject);
                        teEspasa = true;
                        panelPromptEsp.SetActive(false);
                        manageTutorials(0);
                    }
                }
                else if (GameControl.english)
                {
                    panelPromptEng.SetActive(true);
                    if (Input.GetKey(KeyCode.F))
                    {
                        Destroy(other.gameObject);
                        teEspasa = true;
                        panelPromptEng.SetActive(false);
                        manageTutorials(0);
                    }
                }


            }
            else if (other.tag == "sword" && teEspasa == true)
            {

            }
            if (other.tag == "foguera" && other.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                if (GameControl.catalan)
                {
                    panelBonfire.SetActive(true);
                    if (Input.GetKey(KeyCode.F))
                    {
                        Cursor.visible = true;
                        saveLocation = other.transform.GetChild(3).gameObject.transform.position;
                        panelBonfire.SetActive(false);
                        menuBonfire.SetActive(true);
                        Time.timeScale = 0;
                    }
                }else if (GameControl.spanish)
                {
                    panelBonfireEsp.SetActive(true);
                    if (Input.GetKey(KeyCode.F))
                    {
                        Cursor.visible = true;
                        saveLocation = other.transform.GetChild(3).gameObject.transform.position;
                        panelBonfireEsp.SetActive(false);
                        menuBonfireEsp.SetActive(true);
                        Time.timeScale = 0;
                    }
                }
                else if (GameControl.english)
                {
                    panelBonfireEng.SetActive(true);
                    if (Input.GetKey(KeyCode.F))
                    {
                        Cursor.visible = true;
                        saveLocation = other.transform.GetChild(3).gameObject.transform.position;
                        panelBonfireEng.SetActive(false);
                        menuBonfireEng.SetActive(true);
                        Time.timeScale = 0;
                    }
                }


            }
            if (other.tag == "iceCube" && teBlocGel == false)
            {
                if (GameControl.catalan)
                {
                    panelPrompt.SetActive(true);
                    if (Input.GetKey(KeyCode.F))
                    {
                        Destroy(other.gameObject);
                        blocGel.hpBloc = 300;
                        teBlocGel = true;
                        panelPrompt.SetActive(false);
                    }
                }else if (GameControl.spanish)
                {
                    panelPromptEsp.SetActive(true);
                    if (Input.GetKey(KeyCode.F))
                    {
                        Destroy(other.gameObject);
                        blocGel.hpBloc = 300;
                        teBlocGel = true;
                        panelPromptEsp.SetActive(false);
                    }
                }else if (GameControl.english)
                {
                    panelPromptEng.SetActive(true);
                    if (Input.GetKey(KeyCode.F))
                    {
                        Destroy(other.gameObject);
                        blocGel.hpBloc = 300;
                        teBlocGel = true;
                        panelPromptEng.SetActive(false);
                    }
                }



            }
            if (other.tag == "tutEscalada")
            {
                manageTutorials(3);
                other.gameObject.SetActive(false);
            }

            if (other.tag == "surtCova")
            {
                covaSortida = true;
                sortidaCova.SetActive(false);
                LightningManager.canChangeTime = true;
            }

            if (other.tag == "sparkelFinal")
            {
                sparkelFinal.SetActive(false);
            }

            if (other.tag == "hpUp")
            {
                other.gameObject.SetActive(false);
                maxHP += 10;
                healthBar.maxValue = maxHP;
                healthBarEsp.maxValue = maxHP;
                healthBarEng.maxValue = maxHP;
                currentHP = maxHP;
                manageTutorials(4);
                gameController.GetComponent<GameControl>().EstatPocionsHp();
            }

            if (other.tag == "staUp")
            {
                other.gameObject.SetActive(false);
                maxStamina += 1;
                staminaBar.maxValue = maxStamina;
                staminaBarEsp.maxValue = maxStamina;
                staminaBarEng.maxValue = maxStamina;
                stamina = maxStamina;
                manageTutorials(5);
                gameController.GetComponent<GameControl>().EstatPocionsSta();
            }

            if(other.tag == "doubleJump")
            {
                doubleJump = true;
                other.gameObject.SetActive(false);
                manageTutorials(6);
            }

            if (other.tag == "moonJump")
            {
                moonJump = true;
                other.gameObject.SetActive(false);
                manageTutorials(7);
            }
        }

        void UpdatePosition()
        {
            wayPoint.transform.position = transform.position;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "save")
            {
                SavePlayer();
                //Debug.Log("aaaa");
            }
            if (other.tag == "load")
            {
                //Debug.Log("bbbb");
                LoadPlayer();
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.tag == "sparkelFinal")
            {
                sparkelFinal.SetActive(true);
            }

            if (other.tag == "sword" || other.tag == "pal" || other.tag == "iceCube" || other.tag =="foguera")
            {
                panelPrompt.SetActive(false);
                panelBonfire.SetActive(false);
                panelPromptEsp.SetActive(false);
                panelBonfireEsp.SetActive(false);
                panelPromptEng.SetActive(false);
                panelBonfireEng.SetActive(false);
            }
        }
    }
}