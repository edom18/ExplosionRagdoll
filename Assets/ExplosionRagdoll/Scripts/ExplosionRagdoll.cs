using UnityEngine;
using System.Collections;

public class ExplosionRagdoll : MonoBehaviour {

	#region publicVariables
	public float m_force = 500f;
	public float m_radius = 100f;
	public Vector3 m_position = Vector3.zero;

	// For replacing game object in explosion.
	public GameObject m_ragdoll;

	public GameObject m_explosion;
	#endregion

	private bool isEnd = false;

	void Start () {

	}
	
	void Update () {
		if (isEnd) {
			return;
		}

		if (Input.GetMouseButton(0)) {
			isEnd = true;

			GameObject ragdoll   = Instantiate(m_ragdoll, transform.position, transform.rotation) as GameObject;
			GameObject explosion = Instantiate(m_explosion, transform.position, transform.rotation) as GameObject;

			GameObject.Destroy(gameObject);

			Component[] rigidbodies = ragdoll.GetComponentsInChildren<Rigidbody>();
			foreach (Rigidbody rigidbody in rigidbodies) {
				rigidbody.AddExplosionForce(m_force, m_position, m_radius);
			}
		}
	}
}
