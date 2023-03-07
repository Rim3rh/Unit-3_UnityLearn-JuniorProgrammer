using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    public float mat1, mat2, mat3, mat4, speedRotation, cubeSize;

    private float timer1, timer2;
    private bool timerb1, timerb2;
    
    void Start()
    {
        mat1 = 0f;
        mat2 = 10f;
        mat3 = 0f;
        mat4 = 1f;
        speedRotation = 10f;
        cubeSize = 4f;


        transform.position = new Vector3(3, 4, 1);


        timerb1 = false;
        timer1 = 2f;

    }
    
    void Update()
    {
        Debug.Log(timer1);
        timer1 += timerb1? Time.deltaTime : -Time.deltaTime;
        if (timer1 >= 2) timerb1 = false; 
        if (timer1 <= -2) timerb1 = true; 


        Material material = Renderer.material;
        material.color = new Color(mat1,timer1, mat3, mat4);

        transform.localScale = Vector3.one * cubeSize; 

        transform.Rotate(speedRotation * Time.deltaTime, 0.0f, 0.0f);
    }
}
