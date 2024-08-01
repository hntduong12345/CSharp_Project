using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.Models;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Account> GetAccounts();

        [OperationContract]
        Account GetAccount(int id);

        [OperationContract]
        bool UpdateAccount(Account account);

        [OperationContract]
        bool DeleteAccount(int id);

        [OperationContract]
        bool CreateAccount(Account account);

        [OperationContract]
        List<BlogCategory> GetBlogCategories();

        [OperationContract]
        BlogCategory GetBlogCategory(int id);

        [OperationContract]
        bool UpdateBlogCategory(BlogCategory category);

        [OperationContract]
        bool DeleteBlogCategory(int id);

        [OperationContract]
        bool CreateBlogCategory(BlogCategory category);

        [OperationContract]
        List<Blog> GetBlogs();

        [OperationContract]
        Blog GetBlog(int id);

        [OperationContract]
        bool UpdateBlog(Blog blog);

        [OperationContract]
        bool DeleteBlog(int id);

        [OperationContract]
        bool CreateBlog(Blog blog);
    }
}
