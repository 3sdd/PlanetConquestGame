using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField]
    InputAction action;
    Camera mainCamera;

    private void Awake()
    {
        action.performed += MouseDown;
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void MouseDown(InputAction.CallbackContext context)
    {
        var ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider != null && IsPlanet(hit.collider.gameObject))
            {
                StartCoroutine(DragAndDropUpdate());
            }
        }
    }

    bool IsPlanet(GameObject obj)
    {
        return obj.CompareTag("Planet");
    }

    IEnumerator DragAndDropUpdate()
    {
        print("start");
        while (action.ReadValue<float>() != 0)
        {

            // TODO: fixed updateである必要なさそう。すこし反応悪くなる？
            yield return new WaitForFixedUpdate();
        }

        print("finished");
    }
}
