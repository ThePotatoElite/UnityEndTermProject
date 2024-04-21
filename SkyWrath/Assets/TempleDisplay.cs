using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleDisplay : MonoBehaviour
{
    [SerializeField] TempleInfo TempleInfo;
    [SerializeField] float _hP;
    void Start()
    {
        _hP = TempleInfo.HP;
    }
}
