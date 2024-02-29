using System;
using UnityEngine;

namespace Core.Player
{
    public class PlayerController 
    {

        private PlayerModel m_viewModel = null;
        private Vector2 m_positionJoystick = Vector2.zero;
        private string m_axeExtractAnimation = "Axe";
        private string m_runExtractAnimation = "Run";
        private  float m_horizontalInput = 0;
        private float m_verticalInput = 0;
        private float m_speed = 3.0f;
        private float m_speedRot = 360;
        private bool m_isRun = false;
        public PlayerController(PlayerModel viewModel)
        {
            m_viewModel = viewModel;
        }
        public void Initialize()
        {
          
            InitializeEvents();
        }

      

        private void InitializeEvents()
        {
                ApplicationContainer.Instance.EventHolder.OnSwitchToExtractEvent += TakeWeapon;
                ApplicationContainer.Instance.EventHolder.OnPositionJoystickEvent += SetRun;
                     ApplicationContainer.Instance.EventHolder.OnStopJoystickEvent += SetAnimRun;
        }
       
        private void DisposeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnSwitchToExtractEvent -= TakeWeapon;
            ApplicationContainer.Instance.EventHolder.OnPositionJoystickEvent -= SetRun;
            ApplicationContainer.Instance.EventHolder.OnStopJoystickEvent -= SetAnimRun;
        }

        private void TakeWeapon(ToolsName toolsName)
        {
            m_viewModel.CharacterAnimator.SetBool(m_axeExtractAnimation , true);
            if (toolsName == ToolsName.Axe)
            {
                m_viewModel.AxeMeshRenderer.enabled = true;
                m_viewModel.CrunchMeshRenderer.enabled = false;
            }
            else if(toolsName == ToolsName.Nails)
            {
                m_viewModel.AxeMeshRenderer.enabled = false;
                m_viewModel.CrunchMeshRenderer.enabled = true;
            }
            else
            {
                m_viewModel.CharacterAnimator.SetBool(m_axeExtractAnimation , false);
                m_viewModel.AxeMeshRenderer.enabled = false;
                m_viewModel.CrunchMeshRenderer.enabled = false;
            }
        }

        public void Move()
        {
            if (m_isRun)
            {
                m_horizontalInput = m_positionJoystick.x;;
                m_verticalInput = m_positionJoystick.y;
                float targetAngle = Mathf.Atan2(-m_horizontalInput, -m_verticalInput) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
                m_viewModel.CharacterObject.gameObject.transform.rotation = Quaternion.RotateTowards( m_viewModel.CharacterObject.gameObject.transform.rotation, targetRotation, m_speedRot * Time.deltaTime);
                Vector3 movementDirection = new Vector3(m_horizontalInput, 0f, m_verticalInput).normalized;
                m_viewModel.PresetObject.transform.Translate(movementDirection * m_speed * Time.deltaTime);
            }
            
        }

        public void AnimationAttack()
        {
            Debug.Log("Anium");
            //m_viewModel.CharacterAnimator.
        }
        private void SetRun(Vector2 posJoystick)
        {
            m_positionJoystick = posJoystick;
        }

        private void SetAnimRun(bool state)
        {
            m_viewModel.CharacterAnimator.SetBool(m_runExtractAnimation, !state);
            m_isRun = !state;
        }

        public void Dispose()
        {
            DisposeEvents();
        }
    }
}