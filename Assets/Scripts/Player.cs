using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] ProjectileLauncher projectileLauncher;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ProjectileLauncher GetProjectileLauncher()
    {
        return projectileLauncher;
    }
}
