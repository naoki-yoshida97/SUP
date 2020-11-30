using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardChange : MonoBehaviour
{
    
    Transform tf; //Main CameraのTransform
    Camera cam; //Main CameraのCamera
    Vector3 aiming; // aim Board position
    Vector3 city; // city Board position
    Vector3 CamStartPos;


    // Start is called before the first frame update
    void Start()
    {
        tf = this.gameObject.GetComponent<Transform>(); //Main CameraのTransform取得
        cam = this.gameObject.GetComponent<Camera>();  //MainCameraのCameraを取得する
        aiming = new Vector3(0.0f,0.0f,-10f);
        city = new Vector3(0.0f,0.0f,-4f);
        CamStartPos = new Vector3(0.0f, 0.0f,-10f);

        
    }

    // Update is called once per frame
    void Update()
    {
        //---Zoom/IN/OUT---
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(cam.orthographicSize >= 150f)
            {
                cam.orthographicSize = cam.orthographicSize - 30f;
            }
            else
            {
                cam.orthographicSize = cam.orthographicSize + 0f;
            }
        }
        else if(Input.GetKeyDown(KeyCode.O))
        {
            if(cam.orthographicSize <= 360f)
            {
                cam.orthographicSize = cam.orthographicSize + 30f;
            }
            else
            {
                cam.orthographicSize = cam.orthographicSize + 0f;
            }  
        }

        //------Cam Move-------

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(tf.position.y <= 240f)
            {
                tf.position = tf.position + new Vector3(0.0f,30f,0.0f);
            }
            else
            {
                tf.position = tf.position; 
            }    
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(tf.position.y >= -240f)
            {
                tf.position = tf.position + new Vector3(0.0f,-30f,0.0f);
            }
            else
            {
                tf.position = tf.position;
            }    
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(tf.position.x <= 450f)
            {
                tf.position = tf.position + new Vector3(30f,0.0f,0.0f);
            }
            else
            {
                tf.position = tf.position;
            }
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(tf.position.x >= -450f)
            tf.position = tf.position + new Vector3(-30f,0.0f,0.0f);
        }

        //----BoardChange----

        if(Input.GetKeyDown(KeyCode.LeftControl )|| Input.GetKeyDown( KeyCode.RightControl))
        {
            tf.position = new Vector3(0.0f, 0.0f, tf.position.z);
            cam.orthographicSize = 390f;
            if( tf.position == aiming )
            {
                tf.position = city;   
            }
            else if(tf.position == city)
            {
                tf.position = aiming;
            }
        }
        
    }
}
