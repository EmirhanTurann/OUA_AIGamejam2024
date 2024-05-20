using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbility : MonoBehaviour
{
    public float TimerMana = 100;
    public float attackDelay = 0;
    public float ChangeAgeDelay = 0;
    private Animator Animator;
    public bool isChild;
    public Vector3 AdaultScale;
    public Vector3 ChildScale;
    bool isAblity=false;
    CharacterMovement CharacterMovement;
    CharacterLifeSystem CharacterLifeSystem;
    public GameObject AttackParticle;
    public GameObject ChangeAgeParticles;
    public LayerMask layerMask;
    public GameObject RayExitPoint;
    public bool isObstacle = false;


    private void Start()
    {
        Animator = GetComponent<Animator>();
        CharacterMovement = GetComponent<CharacterMovement>();
        CharacterLifeSystem = GetComponent<CharacterLifeSystem>();
       
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && isAblity==false && TimerMana >= 20)
        {
            isAblity = true;
            TimerMana -= 20;
            StartCoroutine(ChangeAgeCoroutine());
           
        }

        //if (Input.GetKeyDown(KeyCode.Mouse0) && isAblity == false && TimerMana >= 30)
        //{
        //    //isAblity = true;
        //    //TimerMana -= 30;
        //    //StartCoroutine(AttackCoroutine());

        //}

        if (isAblity == true)
        {
            CharacterMovement.isMoved = false;
        }
        if(isAblity==false && CharacterLifeSystem.isDead==false && isObstacle==false)
        {
            CharacterMovement.isMoved = true;
        }
    }

    private void FixedUpdate()
    {
        

            RaycastHit hit;

            if (Physics.Raycast(RayExitPoint.transform.position, RayExitPoint.transform.TransformDirection(RayExitPoint.transform.forward), out hit, 10f, layerMask))
            {
                Debug.DrawRay(RayExitPoint.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");

                if (Input.GetKey(KeyCode.Mouse0) && TimerMana >= 20)
                {
                  isAblity = true;
                  TimerMana -= 20;
                  StartCoroutine(AttackCoroutine());

                if (hit.transform.gameObject.CompareTag("Enemy"))
                    {
                     StartCoroutine(hit.transform.gameObject.GetComponent<Enemy>().EnemyChangeAge());
                    }
                
                    if (hit.transform.gameObject.CompareTag("SawBlade"))
                    {
                    Debug.Log("saw");

                    StartCoroutine(hit.transform.GetChild(0).gameObject.GetComponent<SawBlade>().FreezeBlade());
                  
                    //hit.transform.gameObject.transform.GetChild(0).GetComponent<SphereCollider>().enabled = false;
                    }
                
                
                }

                if (hit.transform.gameObject.CompareTag("Obstacle"))
                {
                
                    if (Vector3.Distance(transform.position,hit.transform.position)<8f)
                    {
                        GetComponent<CharacterMovement>().isMoved = false;
                        isObstacle = true;


                    }
                    
                }
            if (hit.transform.gameObject.CompareTag("ObstacleColumn") && !GetComponent<CharacterMovement>().isJump)
            {
                if (Vector3.Distance(transform.position, hit.transform.position) < 3f)
                {
                    GetComponent<CharacterMovement>().isMoved = false;
                    isObstacle = true;

                }

            }


            }
            else
            {
                Debug.DrawRay(RayExitPoint.transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.white);
                Debug.Log("Did not Hit");
                isObstacle = false;
            }


        
    }
    IEnumerator AttackCoroutine()
    {
        Animator.SetTrigger("isChangeEnemyAge");
        yield return new WaitForSeconds(0.9f);
        AttackParticle.SetActive(true);
        yield return new WaitForSeconds(attackDelay);
        isAblity = false;
        AttackParticle.SetActive(false);

    }
    IEnumerator ChangeAgeCoroutine()
    {
        
        Animator.SetTrigger("isChangeSelfAge");
        ChangeAgeParticles.SetActive(true);
        yield return new WaitForSeconds(ChangeAgeDelay);
        if (isChild)
        {
            transform.localScale = AdaultScale;
            CharacterMovement.jumpForce = 300;
            AttackParticle.transform.position = new Vector3(AttackParticle.transform.position.x, transform.position.y+1.50f,transform.position.z + 2.2f);
            RayExitPoint.transform.position = new Vector3(RayExitPoint.transform.position.x, transform.position.y + 3f, RayExitPoint.transform.position.z);
            isChild = false;
        }
        else
        {
            transform.localScale = ChildScale;
            CharacterMovement.jumpForce = 50;
            AttackParticle.transform.position = new Vector3(AttackParticle.transform.position.x, transform.position.y + 1f, transform.position.z+2.2f);
            RayExitPoint.transform.position = new Vector3(RayExitPoint.transform.position.x, transform.position.y+0.20f, RayExitPoint.transform.position.z);
            isChild = true;
        }
        isAblity = false;
        ChangeAgeParticles.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hourglass"))
        {
            if (TimerMana<100)
            {
                TimerMana += 20;
                Destroy(other.gameObject);
            }
            
        }
    }
}
