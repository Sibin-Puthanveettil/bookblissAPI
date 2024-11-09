using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components;
using SKbooks.Models;
using SKbooks.Sanath.BLL;

using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using SKbooksAPI.Models.Request;
using SKbooksAPI.Models.Response;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using SKbooksAPI.Models;


namespace SKbooks.Sanath.Controllers
{
   
    [Route("API")]

    public class Customercontroller : Controller
    {

        [HttpPost("CreateCustomer")]

        public ActionResult<BaseReponse> RegisterReqest([FromBody] RegisterReqest cust)
        {


            if (ModelState.IsValid)
            {
                Customerbll customerbll = new Customerbll();
                return Ok(customerbll.addCustomer(cust));

            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet("custlogin")]

        public ActionResult<BaseReponse> custlogin([FromQuery] LoginReqToken cust)
        {


            if (ModelState.IsValid)
            {
                Customerbll customerbll = new Customerbll();
                return Ok(customerbll.custlogin(cust));

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("Addcategory")]
        public ActionResult<BaseReponse> addcategory([FromQuery] category category)
        {
            if (ModelState.IsValid)
            {
                Customerbll customerbll = new Customerbll();
                return Ok(customerbll.addcategory(category));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost("AddLanguage")]
        public ActionResult<BaseReponse> AddLanguage([FromQuery] Language langu)
        {
            if (ModelState.IsValid)
            {
                Customerbll customerbll = new Customerbll();
                return Ok(customerbll.AddLanguage(langu));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("updatecategoey")]
        public ActionResult<BaseReponse> updatecategory([FromQuery] category category)
        {
            if (ModelState.IsValid)
            {
                Customerbll customerbll = new Customerbll();
                return Ok(customerbll.updateCategory(category));

            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("Deletecategory")]
        public ActionResult<BaseReponse> deletedcategory([FromQuery] category category)
        {
            if (ModelState.IsValid)
            {
                Customerbll customerbll = new Customerbll();
                return Ok(customerbll.deletedcategory(category));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteLanguage")]
        public ActionResult<BaseReponse> DeleteLanguage([FromQuery] Language langu)
        {
            if (ModelState.IsValid)
            {
                Customerbll customerbll = new Customerbll();
                return Ok(customerbll.DeleteLanguage(langu));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("Getcategorydata")]
        public ActionResult<category> getcategorydata()
        {
            if (ModelState.IsValid)
            {
                Customerbll customerbll = new Customerbll();
                List<category> category_ = new List<category>();
                category_ = customerbll.getcategorydata();
                return Ok(category_);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet("GetLanguage")]
        public ActionResult<Language> GetLanguage()
        {
            if (ModelState.IsValid)
            {
                Customerbll customerbll = new Customerbll();
                List<Language> Language_ = new List<Language>();
                Language_ = customerbll.GetLanguage();
                return Ok(Language_);
            }
            else
            {
                return BadRequest();
            }
        }



        [HttpPost("Addproducts")]

        public ActionResult<BaseReponse> addproducts([FromBody] SiteProduct product_)
        {
            if (ModelState.IsValid)
            {
                Customerbll customerbll = new Customerbll();

                return Ok(customerbll.addproducts(product_));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("Getproductdata")]
        public ActionResult<ProductResponse> Getproductdata()
        {
            if (ModelState.IsValid)
            {
                Customerbll customerbll = new Customerbll();
                List<ProductResponse> Product_ = new List<ProductResponse>();
                Product_ = customerbll.Getproductdata();
                return Ok(Product_);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
