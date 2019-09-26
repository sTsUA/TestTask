using System;
using UnityEngine;

namespace Ships.Ammo
{
    public class AmmoBase : ScriptableObject, ICloneable
    {
        public virtual object Clone()
        {
            return null;
        }
    }
}