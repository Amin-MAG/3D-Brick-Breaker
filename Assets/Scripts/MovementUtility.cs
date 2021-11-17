
using UnityEngine;

public class MovementUtility
{
    public static Vector3 GetVelocityDirectionVector(Vector3 v)
    {
        var x = v.x > 0 ? +1 : -1;
        var z = v.z > 0 ? +1 : -1;

        return new Vector3(x, 0, z);
    }
}