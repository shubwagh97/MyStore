using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Models;


namespace MyStore.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StoreReportController : Controller
    {
        private readonly StoreReportAPIDbContext dbContext;
        public StoreReportController(StoreReportAPIDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        [HttpGet]
        public IActionResult GetStoreReports()
        {

            return Ok(dbContext.StoreReports.ToList());

        }

        [HttpGet]
        [Route("id")]
        public IActionResult GetStoreReports([FromRoute] int id)
        {
            var storeReport = dbContext.StoreReports.Find(id);
            if (storeReport == null)
            {
                return NotFound();
               
            }
            return Ok(storeReport);

        }

        [HttpPost]
        public IActionResult AddStoreReports(AddStoreReportRequest addStoreReportRequest)
        {
            var storeReport = new StoreReport()
            {
                Id=addStoreReportRequest.Id,
                CustomerName=addStoreReportRequest.CustomerName,
                MobName=addStoreReportRequest.MobName,
                Price=addStoreReportRequest.Price,
                DateTime = addStoreReportRequest.DateTime
            };
            dbContext.StoreReports.Add(storeReport);
          
            return Ok(storeReport);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateStoreReport([FromRoute] int id, UpdateStoreReportRequest updateStoreReportRequest)
        {
            var storeReport = dbContext.StoreReports.Find(id);
            if (storeReport != null)
            {
                storeReport.CustomerName = updateStoreReportRequest.CustomerName;
                storeReport.MobName = updateStoreReportRequest.MobName;
                storeReport.Price = updateStoreReportRequest.Price;
                storeReport.DiscountPrice = updateStoreReportRequest.DiscountPrice;
                storeReport.DateTime = updateStoreReportRequest.DateTime;
                dbContext.SaveChanges();
                return Ok(storeReport);
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteStoreReport([FromRoute] int id, DeleteStoreReportRequest deleteStoreReportRequest)
        {
            var storeReport = dbContext.StoreReports.Find(id);
            if (storeReport != null)
            {
                dbContext.Remove(storeReport);
                dbContext.SaveChanges();
                return Ok(storeReport);
            }
            return NotFound();
        }

    }
}
