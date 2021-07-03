using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FieldManager : Singleton<FieldManager>
{
    public Transform house;
    public Transform spawn;
    public List<Transform> plants;
    public List<Transform> enemy;
    public Transform houseBulletSpawn;

}