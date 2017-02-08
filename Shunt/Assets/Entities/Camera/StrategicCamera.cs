/*
||	Junior Starter Kit by Alexander Webb, 2017
||	~=~ StrategicCamera ~=~
||	Attach to Camera to give a basic top-down view
*/

using UnityEngine;
using System.Collections;

public class StrategicCamera : MonoBehaviour {
		public Vector3 locusOffset;
		public float rotationSpeed = 45f;
		public float panningAcceleration = 10f;
		public float panningSpeed = 5f;
		public float panningDecay = 5f;
		public float zoomDecay = 5f;
		public float zoomSpeed = 100f;
		public float defaultDistance = 10f;
		public float minDistance = 2f;
		public float maxDistance = 50f;
		public float defaultOrientation = 45f;
		public float defaultInclination = -20f;
		public bool canRotate = true;
		public bool canZoom = true;
		public bool rightMouseOrbits = true;
		public bool invertY;
		public float minInclination = -85f;
		public float maxInclination = 85f;

		private Vector3 _locusPosition;
		private float _locusOrientation;
		private float _locusInclination;
		private float _forwardMomentum;
		private float _leftMomentum;
		private float _distance;
		private float _zoomMomentum;
		// As a convention, we name our private variables starting with an underscore, to help remind us they are private

		// Awake is called ONCE, when all scripts are initialised (even if the script is not enabled)
		void Awake () {
				_distance = defaultDistance;
				_locusInclination = defaultOrientation;
				_locusOrientation = defaultOrientation;
		}

		// Unity calls LateUpdate methods every frame, after all Update methods
		void LateUpdate () {
				if (canRotate){
						if (Input.GetMouseButton(1)){
								// holding RMB, so gather inputs for rotation
								_locusOrientation += Input.GetAxis ("Mouse X") * Time.deltaTime * rotationSpeed;
								if (invertY){
										_locusInclination += Input.GetAxis ("Mouse Y") * Time.deltaTime * rotationSpeed;
								} else {
										_locusInclination -= Input.GetAxis ("Mouse Y") * Time.deltaTime * rotationSpeed;	
								}

								// clamp inclination
								_locusInclination = Mathf.Clamp(_locusInclination, minInclination, maxInclination);
						}
				}

				_forwardMomentum += Input.GetAxis ("Vertical") * Time.deltaTime * panningAcceleration;
				_forwardMomentum = Mathf.Clamp (_forwardMomentum, -panningSpeed, panningSpeed);
				_leftMomentum += Input.GetAxis ("Horizontal") * Time.deltaTime * panningAcceleration;
				_leftMomentum = Mathf.Clamp (_leftMomentum, -panningSpeed, panningSpeed);

				if (canZoom) {
						_zoomMomentum -= Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * zoomSpeed;
				}

				// calc distance & clamp
				_distance = Mathf.Clamp(_distance += _zoomMomentum, minDistance, maxDistance);

				//----------------------------------------------------------------------------------
				// So by this point we should have all our inputs. Now we just have to apply them...
				//----------------------------------------------------------------------------------

				// First, reset camera "locus"
				transform.rotation = Quaternion.identity;
				transform.position = _locusPosition + transform.TransformVector(locusOffset);

				// then rotate on Y axis to the Orientation
				transform.Rotate(0, _locusOrientation, 0);

				// translate our position relative to our *orientation*, plus the offset
				_locusPosition += transform.TransformVector(_leftMomentum, 0, _forwardMomentum) * Time.deltaTime;
				transform.position = _locusPosition + transform.TransformVector(locusOffset);

				// now inclinate the camera
				transform.Rotate(_locusInclination, 0, 0);

				// finally, pull back to _distance from the locus
				transform.Translate (new Vector3 (0, 0, -_distance));

				// decay momentum
				_leftMomentum *= 1 - (panningDecay * Time.deltaTime);
				_forwardMomentum *= 1 - (panningDecay * Time.deltaTime);
				_zoomMomentum *= 1 - (zoomDecay * Time.deltaTime);
		}
}
