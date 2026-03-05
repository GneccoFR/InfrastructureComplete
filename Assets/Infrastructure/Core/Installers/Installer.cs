using Core.Service_Locator;
using Infrastructure.Core.ServiceLocator;
using UnityEngine;

namespace Core.Installers
{
    public abstract class Installer : MonoBehaviour
    {
        public abstract void Install(ServiceLocator serviceLocator);
    }
}