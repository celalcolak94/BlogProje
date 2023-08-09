using BlogProje.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Bibliography;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogProje.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context db = new Context();

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            var blogs = db.Blogs.Include(x => x.Category).Include(x => x.Comments).ToList();

            return View(blogs);
        }

        public IActionResult BlogReadAll(int id)
        {
            var values = bm.GetBlogById(id);
            var blog = db.Blogs.Include(x => x.Comments).FirstOrDefault(x => x.BlogId == id);

            if (values.Count > 0)
            {
                ViewBag.Comments = blog.Comments.Count();
                ViewBag.Id = id;
                ViewBag.WriterId = values.First().WriterId;
            }

            var blogs = bm.GetList();
            ViewBag.LastPostTitle = blogs[blogs.Count() - 1].BlogTitle;
            ViewBag.LastPostImage = blogs[blogs.Count() - 1].BlogImage;
            ViewBag.LastPostId = blogs[blogs.Count() - 1].BlogId;

            return View(values);
        }

        [Authorize]
        public IActionResult BlogListByWriter()
        {

            int writerId = Convert.ToInt32(User.FindFirstValue("sub"));
            var values = bm.GetBlogListByWriterWithCategory(writerId);

            return View(values);

        }

        [HttpGet]
        [Authorize]
        public IActionResult BlogAdd()
        {
            ViewBag.Categories = db.Categories.ToList();

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult BlogAdd(BlogModel blogModel)
        {
            ViewBag.Categories = db.Categories.ToList();

            int writerId = Convert.ToInt32(User.FindFirstValue("sub"));

            var blog = new Blog();

            if (blogModel.BlogImage is not null)
            {
                var extension = Path.GetExtension(blogModel.BlogImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                blogModel.BlogImage.CopyTo(stream);

                blog.BlogImage = newimagename;
            }

            if (ModelState.IsValid)
            {
                blog.BlogTitle = blogModel.BlogTitle;
                blog.BlogContent = blogModel.BlogContent;
                blog.CategoryId = blogModel.CategoryId;
                blog.WriterId = writerId;
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                bm.TAdd(blog);

                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                return View(blogModel);
            }

        }

        [HttpGet]
        [Authorize]
        public IActionResult BlogDelete(int id)
        {
            var value = bm.GetById(id);

            return View(value);
        }
        [HttpPost]
        [Authorize]
        public IActionResult BlogDelete(Blog blog)
        {
            bm.TDelete(blog);

            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        [Authorize]
        public IActionResult BlogUpdate(int id)
        {
            ViewBag.Categories = db.Categories.ToList();

            var blog = bm.GetById(id);
            var blogmodel = new BlogModel
            {
                BlogId = blog.BlogId,
                BlogTitle = blog.BlogTitle,
                BlogContent = blog.BlogContent,
                CategoryId = blog.CategoryId
            };

            return View(blogmodel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult BlogUpdate(BlogModel blogModel)
        {
            ViewBag.Categories = db.Categories.ToList();

            int writerId = Convert.ToInt32(User.FindFirstValue("sub"));

            var blog = new Blog();

            if (blogModel.BlogImage is not null)
            {
                var extension = Path.GetExtension(blogModel.BlogImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                blogModel.BlogImage.CopyTo(stream);

                blog.BlogImage = newimagename;
            }

            if (ModelState.IsValid)
            {
                blog.BlogId = blogModel.BlogId;
                blog.BlogTitle = blogModel.BlogTitle;
                blog.BlogContent = blogModel.BlogContent;
                blog.CategoryId = blogModel.CategoryId;
                blog.WriterId = writerId;
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());

                bm.TUpdate(blog);

                return RedirectToAction("BlogListByWriter");
            }
            else
            {
                return View(blogModel);
            }
        }
    }
}
