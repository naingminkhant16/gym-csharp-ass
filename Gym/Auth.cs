using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym
{
    static class Auth
    {

        private static int id = 0;
        private static String username = "";

        public static int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id == 0) id = value;
            }
        }

        public static string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (username == "") username = value;
            }
        }

        public static void Logout()
        {
            id = 0;
            username = "";
        }

    }
}
