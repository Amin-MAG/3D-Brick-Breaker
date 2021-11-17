using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronBoxController : Box
{
    protected override int GetStartingHealth()
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