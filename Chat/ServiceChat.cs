using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Chat
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextId = 1;
        public int Connect(string username)
        {
            ServerUser user = new ServerUser()
            {
                ID = nextId,
                Name = username,
                operationContext = OperationContext.Current
            };

            nextId++;

            SendMessage(user.Name + " подключился к чату.");
            users.Add(user);

            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                users.Remove(user);
                SendMessage(user.Name + " покинул чат.");
            }
        }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
