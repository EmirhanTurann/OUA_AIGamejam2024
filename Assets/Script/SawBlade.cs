using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : MonoBehaviour
{

    public IEnumerator FreezeBlade()
    {

        yield return new WaitForSeconds(1f);
       gameObject.GetComponent<Animator>().enabled = false;
    }

    }
