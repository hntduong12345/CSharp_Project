using ITCenterBO.Models;
using System.Runtime.CompilerServices;

namespace ITCenterController.Constants
{
    public class ApiEndPointConstant
    {
        public const string RootEndPoint = "/api";
        public const string ApiVersion = "/v1";
        public const string ApiEndPoint = RootEndPoint + ApiVersion;

        public static class Account
        {
            public const string AccountsEndPoint = ApiEndPoint + "/accounts";
            public const string AccountEndPoint = AccountsEndPoint + "/{id}";
            public const string AccountStatusEndPoint = AccountEndPoint + "/status";
        }

        public static class Authentication
        {
            public const string AuthenticationEndpoint = ApiEndPoint + "/auth";
            public const string LoginEndPoint = AuthenticationEndpoint + "/login";
            public const string SignUpEndPoint = AuthenticationEndpoint + "/signup";
        }

        public static class Role
        {
            public const string RolesEndPoint = ApiEndPoint + "/roles";
            public const string RoleEndPoint = RolesEndPoint + "/{id}";
        }

        public static class Feedback
        {
            public const string FeedbacksEndPoint = ApiEndPoint + "/feedbacks";
            public const string FeedbackEndPoint = FeedbacksEndPoint + "/{id}";
            public const string FeedbackStatusEndPoint = FeedbackEndPoint + "/status";
        }

        public static class Course
        {
            public const string CoursesEndPoint = ApiEndPoint + "/courses";
            public const string CourseEndPoint = CoursesEndPoint + "/{id}";
            public const string CourseStatusEndPoint = CourseEndPoint + "/status";
            public const string BestSellerCourseEndPoint = ApiEndPoint + "/best-sellers";
        }

        public static class Category
        {
            public const string CategoriesEndPoint = ApiEndPoint + "/categories";
            public const string CategoryEndPoint = CategoriesEndPoint + "/{id}";
            public const string RandomCategoryEndPoint = CategoriesEndPoint + "/random";
            public const string CategoryNameEndPoint = CategoriesEndPoint + "/{name}";
            public const string CoursesOfCategoryEndPoint = CategoryNameEndPoint + "/courses";
        }

        public static class Lesson
        {
            public const string LessonsEndPoint = ApiEndPoint + "/lessons";
            public const string LessonEndPoint = LessonsEndPoint + "/{id}";
            public const string LessonDeleteEndPoint = LessonEndPoint + "/delete";
        }

        public static class OwnedCourse
        {
            public const string OwnedCoursesEndPoint = ApiEndPoint + "/owned-courses";
            public const string OwnedCourseEndPoint = OwnedCoursesEndPoint + "/{id}";
            public const string OwnedCourseStatusEndPoint = OwnedCourseEndPoint + "/status";
        }

        public static class Order
        {
            public const string OrdersEndPoint = ApiEndPoint + "/orders";
            public const string OrderEndPoint = OrdersEndPoint + "/{id}";
            public const string AccountOrderEndPoint = OrdersEndPoint + "/account/{accountId}";

            public const string OrderHasBeenPaidEndPoint = OrdersEndPoint + "/order-paided";
            public const string OrderAddEndPoint = OrdersEndPoint + "/create-to-carte";
            public const string OrderStatusEndPoint = OrdersEndPoint + "/status";
        }

        public static class OrderDetail
        {
            public const string OrderDetailsEndPoint = ApiEndPoint + "/order-details";
            public const string OrderDetailEndPoint = OrderDetailsEndPoint + "/{id}";
            public const string OrderDetailInOrderEndPoint = OrderDetailsEndPoint + "/{orderId}";

            public const string OrderDetailHasBeenPaidEndPoint = OrderDetailsEndPoint + "/order-detail-paided";
            public const string OrderDetailPriceEndPoint = OrderDetailsEndPoint + "/price";
            public const string OrderDetailPricePaidEndPoint = OrderDetailsEndPoint + "/price-paided";
            public const string OrderDetailAddEndPoint = OrderDetailsEndPoint + "/add-to-carte";
            public const string OrderDetailRemoveEndPoint = OrderDetailsEndPoint;
        }

        public static class Payment
        {
            public const string PaymentEndPoint = ApiEndPoint + "/payment";
            public const string PyamentReturnEndPoint = PaymentEndPoint + "/vnpay-return";
        }

        public static class OwnedLesson
        {
            public const string OwnedLessonsEndPoint = ApiEndPoint + "/owned-lessons";
            public const string OwnedLessonEndPoint = OwnedLessonsEndPoint + "/{id}";
            public const string OwnedLessonStatusEndPoint = OwnedLessonEndPoint + "/status";
            public const string OwnedLessonProgressEndPoint = OwnedLessonsEndPoint + "/course";
        }

        public static class Assignment
        {
            public const string AssignmentEndPoint = ApiEndPoint + "/assignment";
            public const string AssignmentInCourseEndPoint = AssignmentEndPoint + "/assignment-in-course/{courseId}";
            public const string AssignmentDetailEndPoint = AssignmentEndPoint + "/assignment-detail/{assignmentId}";
            public const string AssignmentCreOrUpdEndPoint = AssignmentEndPoint;
        }

        public static class LearnerAssignment
        {
            public const string LearnerAssignmentEndPoint = ApiEndPoint + "/learner-assignment";
            public const string LearnerAssignmentCreOrUpdEndPoint = LearnerAssignmentEndPoint;
            public const string LearnerAssignmentGetOneEndPoint = LearnerAssignmentEndPoint + "/{learnerAssignmentId}";
        }
    }
}
