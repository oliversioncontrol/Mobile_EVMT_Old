using OnLocationEVMT.DependencyServices;
using OnLocationEVMT.Droid.CustomRenders;
using OnLocationEVMT.Droid.LoginServices;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidLogin))]
namespace OnLocationEVMT.Droid.CustomRenders
{
    public class DroidLogin : ILoginServices
    {
        public async Task<int> VerfiyLogin(string UserName, string Password)
        {
            int result = 0;

            try
            {
                await Task.Run(() =>
                {
                    Authentication login = new Authentication();                   
                    LoginResult loginResult = login.Login(UserName, Password);
                    if (loginResult.ErrorCode == LoginErrorCode.NoError)
                    {
                        result = 1;
                    }
                    else if(loginResult.ErrorCode== LoginErrorCode.PasswordNotMatch)
                    {
                        result = 2;
                    }                 
                   
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return result;
        }

       

    }
}