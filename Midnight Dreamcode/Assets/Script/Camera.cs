using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform bg0;
    [SerializeField] private float factor0 = 0.8f;

    [SerializeField] private Transform bg1;
    [SerializeField] private float factor1 = 0.5f;

    [SerializeField] private Transform bg2;
    [SerializeField] private float factor2 = 0.25f;

    [SerializeField] private Transform player;

    private float defaultCamera;
    private float nextCamera;
    
    // Update is called once per frame
    void Update()
    {
        defaultCamera = transform.position.x;
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

   // private void LateUpdate()
   // {
      //  nextCamera = transform.position.x;
       // bg0.position = new Vector3(bg0.position.x + (nextCamera - defaultCamera) *
        //factor0, bg0.position.y, bg0.position.z);
       // bg1.position = new Vector3(bg1.position.x + (nextCamera - defaultCamera) *
       // factor1, bg1.position.y, bg1.position.z);
       // bg2.position = new Vector3(bg2.position.x + (nextCamera - defaultCamera) *
        //factor2, bg2.position.y, bg2.position.z);
   // }
}
