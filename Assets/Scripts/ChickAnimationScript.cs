using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickAnimationScript : MonoBehaviour
{
    public GameObject chickPrefab;
    Vector3 chickPosition;
    void Update()
    {
        //if(Input.GetKey(KeyCode.Space))
        //    CreateChick();
    }
    public void CreateChick()
    {
        chickPosition = new Vector3(transform.position.x, -1.7f, transform.position.z);
        GameObject chick = (GameObject)Instantiate(chickPrefab, chickPosition, Quaternion.identity);
    } 
}