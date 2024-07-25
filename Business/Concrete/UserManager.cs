using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
           return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(User user)
        {
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.EntityListed);
        }

        public IDataResult<User>GetUserByCustomerId(int id)
        {
            
            return new SuccessDataResult<User>(_userDal.Get(x => x.Id == id),Messages.EntityListed);
        }

        public IResult Update(User user)
        {
            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}
