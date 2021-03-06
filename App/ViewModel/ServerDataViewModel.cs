using System;
using App.Models;
using System.Xml;

namespace App.ViewModel
{
    class ServerDataViewModel
    {
        public ServerData Server { get; private set; }
        public CamerasListViewModel c_vm { get; private set; }

        public ServerDataViewModel()
        {
            Server = ServerData.GetInstance();
            c_vm = new CamerasListViewModel();
        }

        public void GetData()
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(Server.URLString))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "ChannelInfo" && reader.HasAttributes)
                        {
                            FillCamerasList(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillCamerasList(XmlTextReader reader)
        {
            string nameCamera = "", nameServer = "";
            bool isSoundOn = false;
            while (reader.MoveToNextAttribute())
            {
                switch (reader.Name)
                {
                    case "Name":
                        nameCamera = reader.Value;
                        break;
                    case "AttachedToServer":
                        nameServer = reader.Value;
                        break;
                    case "IsSoundOn":
                        isSoundOn = Convert.ToBoolean(reader.Value);
                        break;
                }
            }

            c_vm.Cameras.Add(new CameraViewModel(nameCamera, nameServer, isSoundOn));
        }
    }
}
