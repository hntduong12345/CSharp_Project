using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.DataSrc;
using WcfService.Models;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        #region Accounts
        public bool CreateAccount(Account account)
        {
            try
            {
                Account acc = AccData.Accounts.FirstOrDefault(x => x.Id == account.Id);
                if (acc == null)
                {
                    AccData.Accounts.Add(account);
                }
                else
                {
                    throw new Exception();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteAccount(int id)
        {
            try
            {
                Account acc = AccData.Accounts.FirstOrDefault(x => x.Id == id);
                if (acc != null)
                {
                    AccData.Accounts.Remove(acc);
                }
                else
                {
                    throw new Exception();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Account GetAccount(int id)
        {
            return AccData.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public List<Account> GetAccounts()
        {
            return AccData.Accounts.ToList();
        }

        public bool UpdateAccount(Account account)
        {
            try
            {
                Account acc = AccData.Accounts.FirstOrDefault(x => x.Id == account.Id);
                if (acc != null)
                {
                    acc.FullName = account.FullName;
                    acc.Email = account.Email;
                    acc.Password = account.Password;
                    acc.Phone = account.Phone;
                    acc.Address = account.Address;
                    acc.Role = account.Role;
                    acc.IsActive = account.IsActive;
                    acc.Point = account.Point;
                }
                else
                {
                    throw new Exception();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region BlogCategory
        public bool CreateBlogCategory(BlogCategory category)
        {
            try
            {
                BlogCategory cate = BlogCategoryData.BlogCategories.FirstOrDefault(x => x.Id == category.Id);
                if (cate == null)
                {
                    BlogCategoryData.BlogCategories.Add(category);
                }
                else
                {
                    throw new Exception();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteBlogCategory(int id)
        {
            try
            {
                BlogCategory cate = BlogCategoryData.BlogCategories.FirstOrDefault(x => x.Id == id);
                if (cate != null)
                {
                    BlogCategoryData.BlogCategories.Remove(cate);
                }
                else
                {
                    throw new Exception();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<BlogCategory> GetBlogCategories()
        {
            return BlogCategoryData.BlogCategories.ToList();
        }

        public BlogCategory GetBlogCategory(int id)
        {
            return BlogCategoryData.BlogCategories.FirstOrDefault((x) => x.Id == id);
        }

        public bool UpdateBlogCategory(BlogCategory category)
        {
            try
            {
                BlogCategory cate = BlogCategoryData.BlogCategories.FirstOrDefault(x => x.Id == category.Id);
                if (cate != null)
                {
                    cate.Name = category.Name;
                }
                else
                {
                    throw new Exception();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Blog
        public bool CreateBlog(Blog blog)
        {
            try
            {
                Blog cBlog = BlogData.Blogs.FirstOrDefault(x => x.Id == blog.Id);
                if (cBlog == null)
                {
                    BlogData.Blogs.Add(blog);
                }
                else
                {
                    throw new Exception();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteBlog(int id)
        {
            try
            {
                Blog cBlog = BlogData.Blogs.FirstOrDefault(x => x.Id == id);
                if (cBlog != null)
                {
                    BlogData.Blogs.Remove(cBlog);
                }
                else
                {
                    throw new Exception();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Blog GetBlog(int id)
        {
            return BlogData.Blogs.FirstOrDefault(x => x.Id == id);
        }

        public List<Blog> GetBlogs()
        {
            return BlogData.Blogs.ToList();
        }

        public bool UpdateBlog(Blog blog)
        {
            try
            {
                Blog cBlog = BlogData.Blogs.FirstOrDefault(x => x.Id == blog.Id);
                if (cBlog != null)
                {
                    cBlog.Title = blog.Title;
                    cBlog.AccountId = blog.AccountId;
                    cBlog.DocUrl = blog.DocUrl;
                    cBlog.BlogCategoryId = blog.BlogCategoryId;
                    cBlog.Title = blog.Title;
                    cBlog.ImageUrl = blog.ImageUrl;
                }
                else
                {
                    throw new Exception();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
