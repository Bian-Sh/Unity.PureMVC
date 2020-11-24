
/*=========================================
* Author: Administrator
* DateTime:2017/6/21 13:48:51
* Description:$safeprojectname$
==========================================*/


using System.Collections.Generic;
using PureMVC.Patterns;

namespace OrderSystem
{
    public class ClientProxy : Proxy
    {
        public new const string NAME = "ClientProxy";
        public List<ClientItem> Clients
        {
            get { return (List<ClientItem>)base.Data; }
        }

        public ClientProxy() : base(NAME, new List<ClientItem>())
        {
            AddClient(new ClientItem(1, 2, 0));
            AddClient(new ClientItem(2, 1, 1));
            AddClient(new ClientItem(3, 4, 1));
            AddClient(new ClientItem(4, 5, 2));
            AddClient(new ClientItem(5, 12, 0));
        }

        public void AddClient(ClientItem item)
        {
            if (!Clients.Exists(v => v.id == item.id))
            {
                Clients.Add(item);
            }
        }
        public void DeleteClient(ClientItem item)
        {
            Clients.Remove(item);
        }

    }
}