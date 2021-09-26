namespace App.Models
{
    class ServerData
    {
        private static ServerData instance;
        public readonly string URLString = "http://demo.macroscop.com/configex?login=root";

        public static ServerData GetInstance()
        {
            if (instance == null)
                instance = new ServerData();
            return instance;
        }
    }
}
