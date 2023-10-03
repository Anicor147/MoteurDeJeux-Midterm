using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseCharacter
{
   void TakeDamage(float damage);
   void OnDeath();
}
