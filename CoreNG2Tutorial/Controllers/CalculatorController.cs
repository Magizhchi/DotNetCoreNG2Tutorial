using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreNG2Tutorial.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreNG2Tutorial.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        [HttpPost("add")]
        public int AddValues([FromBody]History item)
        {
            using (var context = new NG2TutorialContext())
            {
                if (item == null)
                {
                    return -9999;
                }
                item.Result = item.Argument1 + item.Argument2;
                item.OperationId = 1;

                context.History.Add(item);
                context.SaveChanges();
                return item.Result.Value;
            }
    }

        [HttpPost("subtract")]
        public int SubtractValues([FromBody]History item)
        {
            using (var context = new NG2TutorialContext())
            {
                if (item == null)
                {
                    return -9999;
                }
                item.Result = item.Argument1 - item.Argument2;
                item.OperationId = 1;

                context.History.Add(item);
                context.SaveChanges();
                return item.Result.Value;
            }
        }

        [HttpPost("Multiply")]
        public int MutltiplyValues([FromBody]History item)
        {
            using (var context = new NG2TutorialContext())
            {
                if (item == null)
                {
                    return -9999;
                }
                item.Result = item.Argument1 * item.Argument2;
                item.OperationId = 1;

                context.History.Add(item);
                context.SaveChanges();
                return item.Result.Value;
            }
        }

        [HttpPost("divide")]
        public int DivideValues([FromBody]History item)
        {
            using (var context = new NG2TutorialContext())
            {
                if (item == null)
                {
                    return -9999;
                }
                item.Result = item.Argument1 / item.Argument2;
                item.OperationId = 1;

                context.History.Add(item);
                context.SaveChanges();
                return item.Result.Value;
            }
        }
    }

    public class Arguments
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
    }
}
