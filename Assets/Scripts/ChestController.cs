using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    Animator chestLid;
    bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        chestLid = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightController")
        {
            if (isOpen == false)
            {
                chestLid.Play("ChestOpen");
                isOpen = true;
            } 
            else
            {
                chestLid.Play("ChestClose");
                isOpen = false;
            }
        }
    }
}
