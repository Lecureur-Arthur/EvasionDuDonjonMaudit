using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnim : MonoBehaviour
{
    Animator chestLid;
    // Start is called before the first frame update
    void Start()
    {
        chestLid = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            chestLid.Play("ChestOpen");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            chestLid.Play("ChestClose");
        }
    }
}
