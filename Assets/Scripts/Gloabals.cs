﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInput
{
    public static string Horizontal = "Horizontal";
    public static string Vertical = "Vertical";
    public static string Jump = "Jump";
    public static string MouseX = "Mouse X";
    public static string MouseY = "Mouse Y";
    public static string MouseScroll = "Mouse ScrollWheel";
    public static string Fire1 = "Fire1";
    public static string Fire2 = "Fire2";
    public static string Fire3 = "Fire3";
    public static string Run = "Run";
    public static string Cancel = "Cancel";
    public static string Submit = "Submit";
}

public static class TagGame
{
    public static string EnemyTag = "Enemy";
    public static string BuildingGrundTag = "Building";
    public static string City = "City";
}

public  enum TypeMonster
{
    Normal,
    Tank,
    Speeder
}
public enum ownership
{
    Player,
    Enemy,
    Neutral
}
[System.Serializable]
public struct Material2
{
    public string name;
    public int countity;
}