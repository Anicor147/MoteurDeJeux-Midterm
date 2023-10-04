using UnityEngine;

namespace Enemy
{
    public class Test : MonoBehaviour
    {

         private void OnCollisionEnter2D(Collision2D other)
         {
             other.gameObject.GetComponent<PlayerController>().TakeDamage(50);
        }
    }
}
