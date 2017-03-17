using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TexasHoldEmEngine;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {

        [OperationContract(IsOneWay = true)]
        void RegisterForGame(string playerName);

        // TODO: Add your service operations here
    }
}
