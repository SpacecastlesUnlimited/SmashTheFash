using UnityEngine;
using System.Collections;

public class Place : MonoBehaviour {

	public GameObject PolicePrefab;
	public GameObject CameraPrefab;
	public GameObject PoliceVanPrefab;
	public GameObject CatapultPrefab;

	public Transform policeParent;
	public Transform cameraParent;
	public Transform policeVanParent;
	public Transform catapultParent;

	public UnityEngine.UI.Text status;

	public GameObject SelectedObject;
	
	public GameObject Crosshair;

	private RaycastHit hitInfo;
	private Vector2 currentPos;
	private Vector2 endPos;
	private Vector2 startPos;
	private bool placing;
	private bool touching;

	// Use this for initialization
	void Start () {
		placing = false;
		touching = false;
	}

	void DonePlacing() {
		var mouseMoved = startPos - endPos;
		if (mouseMoved.x > 0 && mouseMoved.y < 0)
			PlacePrefab (PolicePrefab, policeParent);
		if (mouseMoved.x > 0 && mouseMoved.y > 0)
			PlacePrefab (CameraPrefab, cameraParent);
		if (mouseMoved.x < 0 && mouseMoved.y > 0)
			PlacePrefab (CatapultPrefab, policeVanParent);
		if (mouseMoved.x < 0 && mouseMoved.y < 0)
			PlacePrefab (PoliceVanPrefab, catapultParent);
		placing = false;
	}

	void Placing() {
		var mouseMoved = startPos - currentPos;
		var Text = "Drag To Place";
		if (mouseMoved.x > 0 && mouseMoved.y < 0)
			Text = "Cop";
		if (mouseMoved.x > 0 && mouseMoved.y > 0)
			Text = "Media";
		if (mouseMoved.x < 0 && mouseMoved.y > 0)
			Text = "Catapult";
		if (mouseMoved.x < 0 && mouseMoved.y < 0)
			Text = "Police Van";
		status.text = Text;
	}

	void PlacePrefab(GameObject prefab, Transform parent) {
		var placed = (GameObject)Instantiate(prefab, new Vector3(hitInfo.point.x, prefab.transform.position.y, hitInfo.point.z), prefab.transform.rotation);
		placed.transform.parent = parent;
	}

	void PlaceStuff() {
		if (hitInfo.collider.gameObject.tag == "Ground") {
			placing = true;
		}
	}

	void GetPoint() {
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(startPos.x,startPos.y,0));
		var layerMask = 1 << LayerMask.NameToLayer ("Clickable");
		Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
		if (Physics.Raycast (ray, out hitInfo,100,layerMask)) {
			PlaceStuff();
			SelectedObject = hitInfo.collider.gameObject;
			//Debug.Log (hitInfo.point);
			//target.position = hitInfo.point; //new Vector3(hitInfo.point.x, 0.0f, hitInfo.point.z );
		}
	}
	
	// Update is called once per frame
	void Update () {

		Crosshair.SetActive (placing);
		Crosshair.transform.position = new Vector3 (hitInfo.point.x, 10, hitInfo.point.z);

		status.text = "";
		if (!placing && Input.GetButtonDown ("Fire1")) {
			startPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			GetPoint();
		}

		if (placing && Input.GetButton ("Fire1")) {
			currentPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			Placing();
		}

		if (placing && Input.GetButtonUp ("Fire1")) {
			endPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			DonePlacing();
		}
		
		if (!placing && Input.touchCount == 1) {
			startPos = new Vector2(Input.touches[0].position.x, Input.touches[0].position.y);
			GetPoint();
			touching = true;
		}
		
		if (touching && placing && Input.touchCount == 1) {
			currentPos = new Vector2(Input.touches[0].position.x, Input.touches[0].position.y);
			Placing();
		}
		
		if (touching && placing && Input.touchCount == 0) {
			endPos = currentPos;
			DonePlacing();
			touching = false;
		}
	}
}
