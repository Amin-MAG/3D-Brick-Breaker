using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWoodenBox : Box
{
    // Start is called before the first frame update
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
        return 5;
    }

    protected override bool isBreackable()
    {
        return true;
    }
    
    protected override int GetScore()
    {
        return 5;
    }
}