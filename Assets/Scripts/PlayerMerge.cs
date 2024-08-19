using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMerge : CharacterBase
{
    public int Id;

    public override void SetPoint(int _point)
    {
        base.SetPoint(_point);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        SetPoint(10);
    }
}
