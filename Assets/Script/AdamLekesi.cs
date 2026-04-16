using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AdamLekesi : MonoBehaviour
{
   
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    

}
