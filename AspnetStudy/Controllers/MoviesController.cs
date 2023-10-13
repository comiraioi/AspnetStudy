using AspnetStudy.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspnetStudy.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;  //DB에 접근

        //생성자
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index()
        {
            //var movies = GetMovies();
            var movies = _context.Movies.Include(m => m.Genre).ToList();    //using System.Data.Entity;

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            //var movie = GetMovies().SingleOrDefault(m => m.Id == id);
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        /*private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Title = "Elimental"},
                new Movie { Id = 2, Title = "Wall-E"}
            };
        }*/


        /* Action Results 헬퍼 메서드
           return View(객체);     //기본 뷰
           return Content("Hello, World!");    //간단한 텍스트
           return HttpNotFound();    //not found 404 에러
           return Content("Hello, World!");    //간단한 텍스트
           return Content("Hello, World!");    //간단한 텍스트
           return new EmptyResult();    //아무것도 반환하지 않음

           return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});
           // RedirectToAction("액션(메서드명)", "컨트롤러명", new { 파라미터 = 값});
        */

        /*
        // GET: Movies/Random
        public ActionResult Random()
        {
            /* 뷰에 데이터 넘기기

            [방법1] 모델 속성
            var movie = new Movie() { Title = "Elimental" };
            return View(movie);     //기본 뷰

            [방법2] View Data
            ViewData["Movie"] = movie;

            [방법3] View Bag
            ViewBag.Movie = movie;

            return View();  

            //[방법 4] View Models
            var movies = new List<Movie> 
            { 
                new Movie {Title = "Elimental" },
                new Movie {Title = "Wall-E"}
            };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movies = movies,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id) 
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, String sortBy)    //int에 ? 붙이면 Nullable
        {
            if (!pageIndex.HasValue)    //pageIndex에 값이 없으면
                pageIndex = 1;          //기본값 1

            if (String.IsNullOrEmpty(sortBy))   //sortBy가 Null이거나 Empty면
                sortBy = "Title";               //기본값 Title

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

            //url 요청
            // 매개변수에 값을 지정하지 않았을 때의 기본값을 설정해야 오류 발생 X
            https://localhost:44368/컨트롤러명
            
            // 기본값을 설정하면 매개변수 1개만 값을 넘겨도 오류 발생 X
            https://localhost:44368/컨트롤러명?매개변수1=값1&매개변수2=값2
             
            
        }
        */

        /* 속성 라우팅 적용
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")] 
        public ActionResult ByReleaseDate(int year, int month) 
        {
            return Content(year + "/" + month);
        }

        [Route("Movies")]
        public ActionResult Movies()
        {
            var movies = new List<Movie>
            {
                new Movie { Title = "Elimental"},
                new Movie { Title = "Wall-E"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movies = movies
            };

            return View(viewModel);
        }
        */
    }
}