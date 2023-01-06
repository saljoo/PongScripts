using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty
{
    easy,   //0
    normal, //1
    hard    //2
}

public class Settings : MonoBehaviour
{
    static public Difficulty difficulty = Difficulty.normal;
    static public int rounds = 10;
} 
