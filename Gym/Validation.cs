using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym
{
    class Validation
    {
      
        private ErrorProvider errorProvider;
        public Validation(ErrorProvider err)
        {
            errorProvider = err;
            errorProvider.Clear(); // Clear any existing errors
        }
        public void CheckRequired(TextBox txt)
        {        
            if (string.IsNullOrEmpty(txt.Text))
            {
                errorProvider.SetError(txt, "*Required.");
            }         
        }


    }
}
