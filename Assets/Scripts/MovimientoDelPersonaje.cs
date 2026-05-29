using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;



public class MovimientoDelPersonaje : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      inputHorizontal =  Input.GetAxisRaw("Horizontal");
      inputVertical =  Input.GetAxisRaw("Vertical");

    Vector3 inputDirection = new Vector3(inputHorizontal,0,inputVertical);
    inputDirection.Normalize();
    transform.position = transform.position + inputDirection*speed*Time.deltaTime; 
    
    if (inputHorizontal > 0){

        transform.rotation = Quaternion.Euler(0,90,0);
    }
    if (inputHorizontal < 0){

        transform.rotation = Quaternion.Euler(0,270,0);
    }
    if (inputVertical > 0){

        transform.rotation = Quaternion.Euler(0,0,0);
    }
    if (inputVertical < 0){

        transform.rotation = Quaternion.Euler(0,180,0);
    }
    if (inputHorizontal > 0 && inputVertical > 0){

        transform.rotation = Quaternion.Euler(0,45,0);
    }
    if (inputHorizontal > 0 && inputVertical < 0){

        transform.rotation = Quaternion.Euler(0,135,0);
    }
    if (inputHorizontal < 0 && inputVertical > 0){

        transform.rotation = Quaternion.Euler(0,315,0);
    }
     if (inputHorizontal < 0 && inputVertical < 0){

        transform.rotation = Quaternion.Euler(0,225,0);
    }
    } 
}
