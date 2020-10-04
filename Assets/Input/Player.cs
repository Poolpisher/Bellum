// GENERATED AUTOMATICALLY FROM 'Assets/Input/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""Action"",
            ""id"": ""1c09bccb-49b4-461f-a341-b5f5eb9475b4"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a635dea8-05a1-4040-90a3-57b7cc2efa06"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Value"",
                    ""id"": ""c8502538-194b-4bd6-9f5e-a89625aa41e0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""dcddc70e-c244-4832-82c6-8a941ea42bcd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""7375ae87-9513-4580-8008-e68feef239dc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f2cf7a41-0944-4dff-96ba-7314f3116955"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a5a19c76-39ac-437b-ad6a-f9a9fdd18183"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b8cbde81-8af4-4711-be2e-e75442f2dabd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""742f3310-9e9f-412b-980c-af18264c75d7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8b136a30-c3bf-4b02-acf8-4081285673a3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6c132181-c657-445d-8efb-df00f6eb0fd4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f3539f5-8beb-44ae-ae44-3af6730c9d51"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e63a2df-30a9-4c0c-822b-224c847d53cb"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Action
        m_Action = asset.FindActionMap("Action", throwIfNotFound: true);
        m_Action_Move = m_Action.FindAction("Move", throwIfNotFound: true);
        m_Action_Shoot = m_Action.FindAction("Shoot", throwIfNotFound: true);
        m_Action_MouseClick = m_Action.FindAction("MouseClick", throwIfNotFound: true);
        m_Action_MousePosition = m_Action.FindAction("MousePosition", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Action
    private readonly InputActionMap m_Action;
    private IActionActions m_ActionActionsCallbackInterface;
    private readonly InputAction m_Action_Move;
    private readonly InputAction m_Action_Shoot;
    private readonly InputAction m_Action_MouseClick;
    private readonly InputAction m_Action_MousePosition;
    public struct ActionActions
    {
        private @Player m_Wrapper;
        public ActionActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Action_Move;
        public InputAction @Shoot => m_Wrapper.m_Action_Shoot;
        public InputAction @MouseClick => m_Wrapper.m_Action_MouseClick;
        public InputAction @MousePosition => m_Wrapper.m_Action_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_Action; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionActions set) { return set.Get(); }
        public void SetCallbacks(IActionActions instance)
        {
            if (m_Wrapper.m_ActionActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnMove;
                @Shoot.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnShoot;
                @MouseClick.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnMouseClick;
                @MousePosition.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_ActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public ActionActions @Action => new ActionActions(this);
    public interface IActionActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnMouseClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
