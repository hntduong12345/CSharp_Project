namespace ITCenterController.Constants
{
    public class MessageConstant
    {
        public static class LoginMessage
        {
            public const string InvalidEmailOrPassword = "Incorrect email or password!";
            public const string AccountIsUnavailable = "Your account has been disabled!";
        }

        public static class SignUpMessage
        {
            public const string EmailHasAlreadyUsed = "The email has already used";
        }

        public static class Status
        {
            public const int StsTrue = 1;
            public const int StsFalse = 0;
        }
    }
}
