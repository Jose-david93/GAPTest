
using GAP.AccessData.Repository;
using GAP.BussinesLogic.Contract;
using GAP.Transversal.Models;
using System.Linq;

namespace GAP.BussinesLogic.User
{
    public class BLUser : IUser
    {
        public bool IsValidated(LoginViewModel loginViewModel)
        {
            LoginViewModel result =  new ADRepository<LoginViewModel>().IsExist(loginViewModel);
            if (result != null)
                return true;
            return false;
        }
    }
}
