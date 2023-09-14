using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
    // This is a class (template) that is used with the player/enemies in the game to get and set health values

    //Fields
    int _currentHealth;
    int _currentMaxHealth;

    public int Health
    { get { return _currentHealth; } set { _currentHealth = value; } }

    public int MaxHealth
    { get { return _currentMaxHealth; } set { _currentMaxHealth = value; } }


}
