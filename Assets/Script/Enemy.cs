using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyChangeParticles;
    Animator Animator;
    public Material Material;
    public LayerMask layerMask;
    public float Distance;
    public GameObject Character;
    bool isAttack;
    bool isChangeAge =false;
    private void Start()
    {
        Animator = GetComponent<Animator>();
        Character = GameObject.FindGameObjectWithTag("Character");
    }
    public IEnumerator EnemyChangeAge() 
    {
        isChangeAge = true;
        GetComponent<CapsuleCollider>().enabled = false;
         yield return new WaitForSeconds(1.5f);
        EnemyChangeParticles.SetActive(true);
        Animator.SetBool("Transition",true);
        yield return new WaitForSeconds(1f);
        transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().material = Material;
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
       

    }

    public IEnumerator CharacterDead()
    {
        yield return new WaitForSeconds(1f);
        Character.GetComponent<Animator>().SetTrigger("isDead");
    }

    private void FixedUpdate()
    {
        Distance = Vector3.Distance(this.transform.position, Character.transform.position);
     
        if (Distance < 3 && isAttack == false && isChangeAge==false)
        {
            Character.GetComponent<CharacterMovement>().isMoved = false;
            Character.GetComponent<CharacterLifeSystem>().isDead = true;
            Animator.SetTrigger("Attack");
            StartCoroutine(CharacterDead()); 
            isAttack = true;
        }
     

    }

}
