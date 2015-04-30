using UnityEngine;
using System.Collections;

public class CatapultSmash : MonoBehaviour {

	public GameObject projectilePrefab;
	public Transform FashFather;
	public GameObject CurrentAimAt;
	public GameObject ProjectileInFlight;
	public float ProjectileSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ProjectileInFlight == null) {
			var Fashs = FashFather.GetComponentsInChildren<FashNavigation> ();
			CurrentAimAt = null;
			float currentDistance = float.PositiveInfinity;
			foreach (var f in Fashs){
				if (CurrentAimAt == null || currentDistance > (transform.position - f.transform.position).magnitude){
					CurrentAimAt = f.gameObject;
					currentDistance = (transform.position - f.transform.position).magnitude;
				}
			}
			if (CurrentAimAt != null){
				transform.LookAt(CurrentAimAt.transform);
				ProjectileInFlight = (GameObject)Instantiate(projectilePrefab, transform.position + transform.forward * 2 + new Vector3(0,0.5f,0), transform.rotation);
				ProjectileInFlight.transform.LookAt(CurrentAimAt.transform);
				ProjectileInFlight.GetComponent<Rigidbody>().AddForce(ProjectileInFlight.transform.forward * ProjectileSpeed, ForceMode.Impulse);
			}
		}
	}
}
