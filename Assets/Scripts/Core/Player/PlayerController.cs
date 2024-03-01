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
            Load();
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
                Save(GlobalConst.PositionPlayerX, m_viewModel.PresetObject.transform.position.x);
                Save(GlobalConst.PositionPlayerY, m_viewModel.PresetObject.transform.position.y);
                Save(GlobalConst.PositionPlayerZ, m_viewModel.PresetObject.transform.position.z);
            }
            
        }
        private void SetRun(Vector2 posJoystick)
        {
            m_positionJoystick = posJoystick;
        }
        private void Save(string name,float save)
        {
            SaveManager.Save(name, save);
        }
        private void Load()
        {
            float posX = SaveManager.LoadFloat(GlobalConst.PositionPlayerX);
            float posY = SaveManager.LoadFloat(GlobalConst.PositionPlayerY);
            float posZ = SaveManager.LoadFloat(GlobalConst.PositionPlayerZ);
            m_viewModel.PresetObject.transform.position = new Vector3(posX, posY, posZ);    
            if (m_viewModel.PresetObject.transform.position == new Vector3(0, 0, 0))
            {
                m_viewModel.PresetObject.transform.position = new Vector3(posX, posY, 3.88f);
            }
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