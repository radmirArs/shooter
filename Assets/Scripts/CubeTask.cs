using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class CubeTask : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float value;
    public Material material;
    public Transform cube1;
    public Transform cube2;
    // Start is called before the first frame update
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(cube1.transform.position, cube2.transform.position, value);
        material.color = Color.Lerp(Color.red, Color.green, value);
        transform.localScale = Vector3.Lerp(cube1.transform.localScale, cube2.transform.localScale, value);

    }
}
