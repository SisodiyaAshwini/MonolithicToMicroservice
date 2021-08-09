using BookStore.ProductService.Helper;
using BookStore.ProductService.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("GetProduct")]
        public IActionResult Get()
        {
            var productvm = _productRepository.GetAll().ToViewModel();

            return new OkObjectResult(productvm);
        }

        [HttpGet]
        [Route("GetProductSync")]
        /*One way to turn a synchronous operation into an asynchronous one is to run it on a separate thread, and that's where Task.Run comes in. 
        * The Run method queues code to run on a different thread (usually from the "thread pool", which is a set of worker threads managed for 
        * your application by .NET). 
        * And, importantly, Task.Run returns a Task which means you can use the await keyword with it!
        https://www.pluralsight.com/guides/using-task-run-async-await */

        /* Most of the time you'll want it to continue on the original thread you were on when you called await, especially in the case of an application with a graphical user interface, 
         * where you'll need to update UI elements on the main application thread. Fortunately, await captures the current SynchronizationContext, 
         * which includes information about the current thread, and by default automatically returns to that thread when finished. */

        /*Should I Use Task.Run With ASP.NET Core?
        Thus far we've talked about UI-based applications, but does this information about Task.Run apply to a web application framework such 
        as ASP.NET Core?
        There are certainly a number of advantages to using async/await with ASP.NET Core, but the same cannot be said for Task.Run.
        As it turns out, using thread pool threads doesn't make much sense when you're serving a web page.Generally, with ASP.NET there is one 
        thread per request and you want to be able to handle as many requests concurrently as possible.Using Task.Run in that context actually 
        reduces scalability because you're reducing the number of threads available to handle new requests. Furthermore, using a separate 
        thread won't do anything for responsiveness, since the user is not able to interact with the page until it is loaded anyway. 
        And once the page is loaded, responsiveness is primarily determined by the user's client-side browser interactions (and the quality of 
        the JavaScript code), not by ASP.NET. So, for CPU-bound code in ASP.NET, it's best to stick to synchronous processing.
        In short, avoid using Task.Run in ASP.NET applications.If you are using async/await, focus on the naturally asynchronous I/O operations!*/

        public IActionResult GetIsStillSynchronous()// Because this is not returning the task.
        {
            var task = Task.Run(async () => await _productRepository.GetAllAsync());
            return new OkObjectResult(task.Result.ToViewModel());
        }

        [HttpGet]
        [Route("GetProductAsync")]

        public async Task<IActionResult> GetAsync() //This are returning the task
        {
            var task = Task.Run(() => _productRepository.GetAllAsync().Result.ToViewModel());
            return new OkObjectResult(await task);
        }

        [HttpGet]
        [Route("GetProductAsync")]
        //in this we have created a task with simple get and running it async
        public async Task<IActionResult> GetAsyncUsingSync()//This are returning the task
        {
            return new OkObjectResult(await Task.Run(() => _productRepository.GetAll().ToViewModel()));
        }

    }
}
