using GAP.Transversal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.BussinesLogic.Contract
{
    public interface IUser
    {
        bool IsValidated(LoginViewModel loginViewModel);
    }
}
