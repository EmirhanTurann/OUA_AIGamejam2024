using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLifeSystem : MonoBehaviour
{
    public bool isDead = false;
    public GameObject GameOverPanel;

    private void Update()
    {
        if (isDead==true)
        {
            StartCoroutine(openGameOverPanel());
            
        }
    }
    void dead() 
    {
        isDead = true;
        GetComponent<CharacterMovement>().isMoved = false;
        GetComponent<Animator>().SetTrigger("isDead");
        GetComponent<CameraTracking>().enabled = false;
    }
    IEnumerator openGameOverPanel() 
    {
        GetComponent<CharacterMovement>().isMoved = false;
        GetComponent<CameraTracking>().enabled = false;
        yield return new WaitForSeconds(2f);
        GameOverPanel.SetActive(true);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SawBlade")|| other.CompareTag("StoneSphere") || other.CompareTag("FallTrigger"))
        {
            dead();
            if (other.GetComponent<Animator>())
            {
                other.GetComponent<Animator>().enabled = false;
            }
           

        }
    }
}
