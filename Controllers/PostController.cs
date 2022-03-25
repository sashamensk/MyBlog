using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly PostDbContext _db;

        public PostController(PostDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if(_db != null)
            {
                IEnumerable<Post> objPostList = _db.Post.ToList();
                return View(objPostList);
            }
            return View();
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post obj)
        {

            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    obj.Author = User.Identity.Name;
                }
                _db.Post.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Post created succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Post.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Post obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            //}
            if (ModelState.IsValid)
            {
                _db.Post.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Post.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Post.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Post.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted succesfully";
            return RedirectToAction("Index");
        }

        // TODO: Add View here! 

        //public IActionResult PostByCategory()
        //{
        //    return View();
        //}

        //public IActionResult PostByCategory()
        //{
        //    if (category.CategoryName == _db.Post.Find()
        //    {
        //        return NotFound();
        //    }
        //    var categoryFromDb = _db.Post.Find(PostCategory);

        //    if (categoryFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(categoryFromDb);
        //}
    }
}
