using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Animator animator;
    public SceneManagerController sceneManagerController;
    IEnumerator FinishLevel() 
    {
        animator.SetBool("isFinish", true);
       
        yield return new WaitForSeconds(3);
        sceneManagerController.NextScene();


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            other.GetComponent<CameraTracking>().enabled = false;
            StartCoroutine(FinishLevel());

        }
    }
}
