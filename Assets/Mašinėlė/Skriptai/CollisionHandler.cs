using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace AssemblyCSharp
{
	public class CollisionHandler : MonoBehaviour
	{
		public GameObject effect;

		void OnCollisionEnter (Collision col)
 		{
            //If object touched wall
			if (col.gameObject.tag == "wall")
            {
                //Display explosion animation
				GameObject expl = Instantiate(effect, transform.position, Quaternion.identity) as GameObject;

                //Destroy object
				Destroy(this.gameObject);

                //Destroy explosion animation
				Destroy(expl, 3); 

				Debug.Log ("wall hit");
			}
            //If object collided with Player
			if (col.gameObject.tag == "Player")
            {
				foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    //Destroy all enemies
					Destroy(enemy);
				}
			if (col.gameObject.tag == "Enemy")
                {
					Debug.Log ("enemy collision");
				}
            
                //Destroy colision information
        		Destroy(col.gameObject);
			}
 		}

	}
}

