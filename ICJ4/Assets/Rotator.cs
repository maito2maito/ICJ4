using UnityEngine;

public class Rotator : MonoBehaviour

{

    public Vector3 rotatspeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime * rotatspeed);  
    }
}
