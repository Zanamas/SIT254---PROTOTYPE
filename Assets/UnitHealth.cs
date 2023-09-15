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


    //Constructor
    public UnitHealth(int health, int maxHealth)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    } 


    //Methods

    // Run to damage the unit
    public void DmgUnit(int dmgAmount)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= dmgAmount;
        }
    }


    //run to heal the unit
    public void healUnit(int healAmount)
    {
        //checks if unit can be healed
        if (_currentHealth < _currentMaxHealth)
        {

            //prevents overheal if applicable
            if (_currentHealth + healAmount > _currentHealth)
            {
                _currentHealth = _currentMaxHealth;
            }

            //if cannot overheal
            else
            {
                _currentHealth += healAmount;
            }
            
        }
    }
}
