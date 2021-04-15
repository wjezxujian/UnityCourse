using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;



public struct ShareComponent6 : ISharedComponentData, IEqualityComparer<ShareComponent6>
{
    public int data;

    public bool Equals(ShareComponent6 x, ShareComponent6 y)
    {
        return x.data == y.data;
    }

    public int GetHashCode(ShareComponent6 obj)
    {
        return data.GetHashCode();
    }
}
