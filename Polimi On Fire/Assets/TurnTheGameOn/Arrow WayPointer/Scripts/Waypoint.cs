namespace TurnTheGameOn.ArrowWaypointer
{
	using UnityEngine;		
	using UnityEngine.UI;	
	public class Waypoint : MonoBehaviour
	{

		public float radius;
		public GameObject toggle;
		public bool flagPass;
		[HideInInspector] public WaypointController waypointController;
		[HideInInspector] public int waypointNumber;

		void Update(){
			if (waypointController.player) {
				if((Vector3.Distance(transform.position, waypointController.player.position) < radius) && (toggle.GetComponent<Toggle>().isOn || (flagPass))){
					waypointController.ChangeTarget ();
				}
			}
		}

		void OnTriggerEnter (Collider col) {
			if(col.gameObject.tag == "Player"){
				waypointController.WaypointEvent (waypointNumber);
				waypointController.ChangeTarget ();
			}
		}

		#if UNITY_EDITOR
		void OnDrawGizmosSelected(){
			if (waypointController != null) waypointController.OnDrawGizmosSelected (radius);
		}
		#endif
	}
}