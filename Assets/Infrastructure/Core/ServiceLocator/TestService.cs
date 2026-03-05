using Core.Service_Locator;
using UnityEngine;

namespace Infrastructure.Core.ServiceLocator
{
    public class TestService : IService  
    {
        public void Register()
        {
            ServiceLocator.Instance.RegisterService(this);
        }
    
        public void DoSomething() 
        {
            Debug.Log("Doing something in TestService");
        }
    }
}
