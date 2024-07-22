//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/ProjectAssets/Input/GameActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GameActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameActions"",
    ""maps"": [
        {
            ""name"": ""Arcada"",
            ""id"": ""78bd46a8-bd83-48a4-a6ca-ff0b94b32313"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""db56b2d3-5db8-4608-b9cb-cda7eb98a061"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shot"",
                    ""type"": ""Button"",
                    ""id"": ""a028eb60-b2c8-499b-8929-d5be0291eca7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Lazer"",
                    ""type"": ""Button"",
                    ""id"": ""68cb87af-ad0c-4e37-a7e6-7b2177011bc4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""e2353440-9dbd-4651-8d77-fb42f6770983"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""d20ebed4-5e78-45fa-9501-d8743494da64"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a2363355-b515-4cd3-80f2-3a55d6f31cce"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""15c0bbd9-47ea-42c5-8c21-dc90b0e95836"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2cae22a7-f38a-4d75-86b8-bc0e8ef4ec9e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a6c9fe9d-29c6-468c-a571-d38d274eb3c9"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6bf9d510-27de-40d3-b9e2-377e825cb1d8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60ffa306-9a0d-4461-8914-3c127fe718f6"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lazer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d34b5481-05bf-4d0a-9757-a830177a9b33"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Arcada
        m_Arcada = asset.FindActionMap("Arcada", throwIfNotFound: true);
        m_Arcada_Movement = m_Arcada.FindAction("Movement", throwIfNotFound: true);
        m_Arcada_Shot = m_Arcada.FindAction("Shot", throwIfNotFound: true);
        m_Arcada_Lazer = m_Arcada.FindAction("Lazer", throwIfNotFound: true);
        m_Arcada_Escape = m_Arcada.FindAction("Escape", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Arcada
    private readonly InputActionMap m_Arcada;
    private IArcadaActions m_ArcadaActionsCallbackInterface;
    private readonly InputAction m_Arcada_Movement;
    private readonly InputAction m_Arcada_Shot;
    private readonly InputAction m_Arcada_Lazer;
    private readonly InputAction m_Arcada_Escape;
    public struct ArcadaActions
    {
        private @GameActions m_Wrapper;
        public ArcadaActions(@GameActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Arcada_Movement;
        public InputAction @Shot => m_Wrapper.m_Arcada_Shot;
        public InputAction @Lazer => m_Wrapper.m_Arcada_Lazer;
        public InputAction @Escape => m_Wrapper.m_Arcada_Escape;
        public InputActionMap Get() { return m_Wrapper.m_Arcada; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ArcadaActions set) { return set.Get(); }
        public void SetCallbacks(IArcadaActions instance)
        {
            if (m_Wrapper.m_ArcadaActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_ArcadaActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_ArcadaActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_ArcadaActionsCallbackInterface.OnMovement;
                @Shot.started -= m_Wrapper.m_ArcadaActionsCallbackInterface.OnShot;
                @Shot.performed -= m_Wrapper.m_ArcadaActionsCallbackInterface.OnShot;
                @Shot.canceled -= m_Wrapper.m_ArcadaActionsCallbackInterface.OnShot;
                @Lazer.started -= m_Wrapper.m_ArcadaActionsCallbackInterface.OnLazer;
                @Lazer.performed -= m_Wrapper.m_ArcadaActionsCallbackInterface.OnLazer;
                @Lazer.canceled -= m_Wrapper.m_ArcadaActionsCallbackInterface.OnLazer;
                @Escape.started -= m_Wrapper.m_ArcadaActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_ArcadaActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_ArcadaActionsCallbackInterface.OnEscape;
            }
            m_Wrapper.m_ArcadaActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Shot.started += instance.OnShot;
                @Shot.performed += instance.OnShot;
                @Shot.canceled += instance.OnShot;
                @Lazer.started += instance.OnLazer;
                @Lazer.performed += instance.OnLazer;
                @Lazer.canceled += instance.OnLazer;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
            }
        }
    }
    public ArcadaActions @Arcada => new ArcadaActions(this);
    public interface IArcadaActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShot(InputAction.CallbackContext context);
        void OnLazer(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
    }
}
