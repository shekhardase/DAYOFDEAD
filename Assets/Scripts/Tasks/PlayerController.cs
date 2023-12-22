using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.UnitedGameDevelopers.PlayerController
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float moveSpeed;
        #endregion

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

            if (transform.position.x > -2f && Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            }
            if (transform.position.x < 2f && Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            }
        }
    }
}
