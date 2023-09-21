using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OwnerExtensions
{
    public static Color GetColor(this Owner owner)
    {
        switch (owner)
        {
            case Owner.None:
                return Color.gray;
            case Owner.Player:
                return new Color32(96, 165, 250,255);
                
            case Owner.Enemy1:
                return Color.red;
            default:
                throw new System.Exception("èIóπ");
        }
    }
}
