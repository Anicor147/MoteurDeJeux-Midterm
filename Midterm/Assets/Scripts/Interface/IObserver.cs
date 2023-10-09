using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void HealthChanged(float health);
    void ManaChanged(float mana);
}
