using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronBoxController : Box
{
    protected override int GetStartingHealth()
    {
        return 3;
    }

    protected override bool isBreackable()
    {
        return true;
    }

    protected override int GetScore()
    {
        return 3;
    }

    public void Start()
    {
        base.Start();
    }

    public void Update()
    {
        base.Update();
    }
}