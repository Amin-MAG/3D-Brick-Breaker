using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBoxController : Box
{

    public void Start()
    {
        base.Start();


        Debug.Log("Wood");
    }

    void Update()
    {
        base.Update();
        
        
    }
    
    protected override int GetStartingHealth()
    {
        return 1;
    }

    protected override bool isBreackable()
    {
        return true;
    }
    
    protected override int GetScore()
    {
        return 1;
    }
}