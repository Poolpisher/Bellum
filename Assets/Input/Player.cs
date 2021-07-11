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
                    ""name"": ""PlayerRotation"",
                    ""type"": ""Value"",
                    ""id"": ""7375ae87-9513-4580-8008-e68feef239dc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""00dbddba-fb82-4566-b309-c8b179856bad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Antebellum"",
                    ""type"": ""Button"",
                    ""id"": ""83fc938f-672a-44eb-9113-d7cba54c4648"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""bfe98c11-e485-4706-b00c-3837ea94edac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HUDshortcutLeft"",
                    ""type"": ""Value"",
                    ""id"": ""9ed914d1-ad75-4037-b97d-45a486546655"",
                    ""expectedControlType"": ""Dpad"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HUDshortcutRight"",
                    ""type"": ""Value"",
                    ""id"": ""205d8f36-f369-4d74-b0dd-72ae1ebd2ed7"",
                    ""expectedControlType"": ""Dpad"",
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
                    ""id"": ""c1650174-019b-4cdc-bf8f-f1370abc04d5"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c132181-c657-445d-8efb-df00f6eb0fd4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
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
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04abd4a9-c45b-47a1-be27-98bb27586e8f"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
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
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""PlayerRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ff07de1-02de-402b-b504-861effb28a1b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e1f9b7d-049c-475f-a091-2c26c4256491"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8775091b-f0c5-4e6e-af06-069f34cc5228"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Antebellum"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c819270-5e1c-48b5-bfca-ab5c701e0345"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Antebellum"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""348280b4-9a5e-476d-9408-11f2705669bd"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db35a37e-1ba2-4cfb-8414-49fc6d1ba66b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d29c98f-af07-413e-b3e8-050404b18878"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3566820a-db89-48e5-8284-f2fb74adf9a6"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""HUDshortcutLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c03cc33-a126-45b0-9681-f431d1bfbb21"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""HUDshortcutLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""feb4a09e-e62d-48e6-b4c6-a7e9ff51c2be"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2,StickDeadzone(min=0.2)"",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""PlayerRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fec4f57-8a6e-4b21-ae14-23b43f52575c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""HUDshortcutRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Xbox Controller"",
            ""bindingGroup"": ""Xbox Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard + mouse"",
            ""bindingGroup"": ""Keyboard + mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Action
        m_Action = asset.FindActionMap("Action", throwIfNotFound: true);
        m_Action_Move = m_Action.FindAction("Move", throwIfNotFound: true);
        m_Action_Shoot = m_Action.FindAction("Shoot", throwIfNotFound: true);
        m_Action_MouseClick = m_Action.FindAction("MouseClick", throwIfNotFound: true);
        m_Action_PlayerRotation = m_Action.FindAction("PlayerRotation", throwIfNotFound: true);
        m_Action_Reload = m_Action.FindAction("Reload", throwIfNotFound: true);
        m_Action_Antebellum = m_Action.FindAction("Antebellum", throwIfNotFound: true);
        m_Action_Exit = m_Action.FindAction("Exit", throwIfNotFound: true);
        m_Action_HUDshortcutLeft = m_Action.FindAction("HUDshortcutLeft", throwIfNotFound: true);
        m_Action_HUDshortcutRight = m_Action.FindAction("HUDshortcutRight", throwIfNotFound: true);
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
    private readonly InputAction m_Action_PlayerRotation;
    private readonly InputAction m_Action_Reload;
    private readonly InputAction m_Action_Antebellum;
    private readonly InputAction m_Action_Exit;
    private readonly InputAction m_Action_HUDshortcutLeft;
    private readonly InputAction m_Action_HUDshortcutRight;
    public struct ActionActions
    {
        private @Player m_Wrapper;
        public ActionActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Action_Move;
        public InputAction @Shoot => m_Wrapper.m_Action_Shoot;
        public InputAction @MouseClick => m_Wrapper.m_Action_MouseClick;
        public InputAction @PlayerRotation => m_Wrapper.m_Action_PlayerRotation;
        public InputAction @Reload => m_Wrapper.m_Action_Reload;
        public InputAction @Antebellum => m_Wrapper.m_Action_Antebellum;
        public InputAction @Exit => m_Wrapper.m_Action_Exit;
        public InputAction @HUDshortcutLeft => m_Wrapper.m_Action_HUDshortcutLeft;
        public InputAction @HUDshortcutRight => m_Wrapper.m_Action_HUDshortcutRight;
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
                @PlayerRotation.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnPlayerRotation;
                @PlayerRotation.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnPlayerRotation;
                @PlayerRotation.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnPlayerRotation;
                @Reload.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnReload;
                @Antebellum.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnAntebellum;
                @Antebellum.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnAntebellum;
                @Antebellum.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnAntebellum;
                @Exit.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnExit;
                @HUDshortcutLeft.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnHUDshortcutLeft;
                @HUDshortcutLeft.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnHUDshortcutLeft;
                @HUDshortcutLeft.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnHUDshortcutLeft;
                @HUDshortcutRight.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnHUDshortcutRight;
                @HUDshortcutRight.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnHUDshortcutRight;
                @HUDshortcutRight.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnHUDshortcutRight;
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
                @PlayerRotation.started += instance.OnPlayerRotation;
                @PlayerRotation.performed += instance.OnPlayerRotation;
                @PlayerRotation.canceled += instance.OnPlayerRotation;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Antebellum.started += instance.OnAntebellum;
                @Antebellum.performed += instance.OnAntebellum;
                @Antebellum.canceled += instance.OnAntebellum;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
                @HUDshortcutLeft.started += instance.OnHUDshortcutLeft;
                @HUDshortcutLeft.performed += instance.OnHUDshortcutLeft;
                @HUDshortcutLeft.canceled += instance.OnHUDshortcutLeft;
                @HUDshortcutRight.started += instance.OnHUDshortcutRight;
                @HUDshortcutRight.performed += instance.OnHUDshortcutRight;
                @HUDshortcutRight.canceled += instance.OnHUDshortcutRight;
            }
        }
    }
    public ActionActions @Action => new ActionActions(this);
    private int m_XboxControllerSchemeIndex = -1;
    public InputControlScheme XboxControllerScheme
    {
        get
        {
            if (m_XboxControllerSchemeIndex == -1) m_XboxControllerSchemeIndex = asset.FindControlSchemeIndex("Xbox Controller");
            return asset.controlSchemes[m_XboxControllerSchemeIndex];
        }
    }
    private int m_KeyboardmouseSchemeIndex = -1;
    public InputControlScheme KeyboardmouseScheme
    {
        get
        {
            if (m_KeyboardmouseSchemeIndex == -1) m_KeyboardmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard + mouse");
            return asset.controlSchemes[m_KeyboardmouseSchemeIndex];
        }
    }
    public interface IActionActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnMouseClick(InputAction.CallbackContext context);
        void OnPlayerRotation(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnAntebellum(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
        void OnHUDshortcutLeft(InputAction.CallbackContext context);
        void OnHUDshortcutRight(InputAction.CallbackContext context);
    }
}
