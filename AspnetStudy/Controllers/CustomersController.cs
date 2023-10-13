using AspnetStudy.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspnetStudy.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;  //DB에 접근

        //생성자
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            //var customers = GetCustomers();

            /* DB에 있는 Customers 데이터 확보: 뷰에서 customers 객체가 반복될 떄 쿼리가 실제로 실행됨 */
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            /* 쿼리 즉시 실행됨 */
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        /*
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith"},
                new Customer { Id = 2, Name = "Mary Williams"}
            };
        }
        */

        /*[Route("Customers")]
        // GET: Customers
        public ActionResult Customers()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith"},
                new Customer { Id = 2, Name = "Mary Williams"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("Customers/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            var customer = new Customer { Id = Id };

            return View(customer);
        }*/
    }
}