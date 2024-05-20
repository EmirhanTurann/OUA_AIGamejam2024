using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSphereMovement : MonoBehaviour
{
    public float RollSpeed;
    public float RollRotateSpeed;
    public CharacterLifeSystem CharacterLifeSystem;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z + RollSpeed * Time.deltaTime);
        transform.Rotate(0f, 0f, RollRotateSpeed, Space.Self);
        if (CharacterLifeSystem.isDead==true)
        {
            RollSpeed = 0;
            RollRotateSpeed = 0;
        }
    }

    IEnumerator StopStoneSphere()
    {
        yield return new WaitForSeconds(0.5f);
        RollSpeed=0;
        RollRotateSpeed=0;

}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            StartCoroutine(StopStoneSphere());

        }
    }
}
