using OnLocationEVMT.DependencyServices;
using OnLocationEVMT.iOS.CustomRenders;
using OnLocationEVMT.iOS.LoginServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(IosLogin))]
namespace OnLocationEVMT.iOS.CustomRenders
{
   public class IosLogin: ILoginServices
    {
        public async Task<int> VerfiyLogin(string UserName, string Password)
        {
            int result = 0;

            try
            {
                await Task.Run(() =>
                {
                    Authentication login = new Authentication();
                    // login.Url = "https://mstage.onlocationind.com/sites/services/_vti_bin/authentication.asmx";
                    LoginResult loginResult = login.Login(UserName, Password);
                    if (loginResult.ErrorCode == LoginErrorCode.NoError)
                    {
                        result = 1;
                    }
                    else if (loginResult.ErrorCode == LoginErrorCode.PasswordNotMatch)
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
