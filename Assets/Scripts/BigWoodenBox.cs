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
}