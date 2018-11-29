using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace curso_asp_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
       

        // GET api/values/5
        [HttpGet("{n1}/{n2}")]
        public IActionResult Sum(string n1, string n2)
        {
            if (IsNumeric(n1) && IsNumeric(n2))
            {
                var sum = ConvertToDecimal(n1) + ConvertToDecimal(n2);
                return Ok(sum.ToString());
            };
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string n1)
        {
            decimal d;

            if (decimal.TryParse(n1, out d))
                return d;

            return 0;
        }

        private bool IsNumeric(string n1)
        {
            double d;

            bool isNumber = double.TryParse(n1, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out d);
            return isNumber;
        }
    }
}
