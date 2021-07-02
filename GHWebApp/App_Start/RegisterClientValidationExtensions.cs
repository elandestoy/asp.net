using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(GHWebApp.App_Start.RegisterClientValidationExtensions), "Start")]
 
namespace GHWebApp.App_Start {
    public static class RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            
        }
    }
}