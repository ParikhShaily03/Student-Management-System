namespace Student_Management_System.Models.DTOs
{
    public class ApiMassage
    {
        // Success Messages
        public static readonly string Success = "Operation completed successfully.";
        public static readonly string Updated = "Record updated successfully.";
        public static readonly string Deleted = "User soft deleted successfully.";

        // Error Messages
        public static readonly string NotFound = "Requested resource not found.";
        public static readonly string Notcreated = "User Not Created";
        public static readonly string NotUpdated = "User Not Updated";
        public static readonly string BadRequest = "Invalid request parameters.";
        public static readonly string Unauthorized = "You are not authorized to perform this action.";
        public static readonly string InternalServerError = "An unexpected error occurred.";

        // Custom Messages
        public static readonly string LoginSuccess = "User logged in successfully.";
        public static readonly string LoginFailed = "Invalid username or password.";
        public static readonly string RegistrationSuccess = "User registered successfully.";
        public static readonly string RegistrationFailed = "User registration failed.";
        public static readonly string ExpiryMinutes = "Timeout";
        public static readonly string LogoutSuccess = "User Log Out successfully";


    }
}
