using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnBreakableBox : Box
{
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    protected override int GetStartingHealth()
    {
        return 999999999;
    }

    protected override bool isBreackable()
    {
        return false;
    }
    
    protected override int GetScore()
    {
        return 0;
    }
}