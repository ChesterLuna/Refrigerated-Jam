using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public Transform objective;

    public float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(objective);
        //this.transform.rotation.Set(0,0, this.transform.rotation.z, transform.rotation.w); 

        //this.transform.position += new Vector3 (Mathf.Sin(transform.forward.x)  * moveSpeed * Time.deltaTime, Mathf.Cos(transform.forward.y) * moveSpeed * Time.deltaTime, 0);

    }
}
