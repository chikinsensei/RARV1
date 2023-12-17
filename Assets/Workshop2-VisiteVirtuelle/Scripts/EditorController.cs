using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;


public class EditorController : MonoBehaviour
{
	[SerializeField] private EditorManager EditorManager;
	public void OnAction(CallbackContext context)
	{
		if (!context.performed) return;
		RaycastHit hit;
		Transform cameraTransform = Camera.main.transform;
		if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 2, ~LayerMask.NameToLayer("POI")))
		{
			var poi = hit.collider.gameObject.GetComponent<PointOfInterest>();
			EditorManager.DisplayPOI(poi.PointOfInterestData);
		}
	}
	public void OnCreate(CallbackContext context)
	{
		if (!context.performed) return;
		Transform cameraTransform = Camera.main.transform;
		EditorManager.CreateNewPointOfInterest(cameraTransform.position, cameraTransform.forward);
	}
	public void OnSave(CallbackContext context)
	{
		if (!context.performed) return;
		EditorManager.SaveScene();
	}
}
