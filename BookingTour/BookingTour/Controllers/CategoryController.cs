using AutoMapper;
using BookingTourAPI.Common;
using BookingTourAPI.Common.RequestModel;
using BookingTourAPI.Common.ResponseModel;
using BusinessLogic.Business;
using BusinessLogic.Dtos.RequestDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingTourAPI.Controllers
{
    [Route("Category")]
    [Controller]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryBusiness _categoryBusiness;
        private readonly IMapper _mapper;

        public CategoryController(CategoryBusiness categoryBusiness,IMapper mapper)
        {
            _categoryBusiness = categoryBusiness;
            _mapper = mapper;
        }
        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategory()
        {
            var cate = await _categoryBusiness.GetAllCategory();
            var ctList = _mapper.Map<List<GetCategoryResponse>>(cate);
            return Ok(ctList);
        }
        [HttpGet("id/{cateid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int cateid)
        {
            var cate = await _categoryBusiness.GetCategoryById(cateid);
            if (cate == null)
            {
                return NotFound();
            }
            var cg = _mapper.Map<GetCategoryResponse>(cate);
            return Ok(cg);
        }
        [HttpGet("name/{catename}")]
        public async Task<IActionResult> GetCategoryByName([FromRoute] string catename)
        {
            var cate = await _categoryBusiness.GetCategoryByName(catename);
            if (cate == null)
            {
                return NotFound();
            }
            var cg = _mapper.Map<GetCategoryResponse>(cate);
            return Ok(cg);
        }
        [HttpPost("create-category")]
        [Authorize]
        public async Task<IActionResult> CreateCategory([FromBody]CreateCategoryRequest request)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));
            var cate = _mapper.Map<CreateCategoryModel>(request);
            var cg  = await _categoryBusiness.CreateCategory(cate, currentUserId);
            if (!cg)
            {
                return BadRequest();
            }
            return Ok(ApiResponse<CreateCategoryModel>.Succeed(cate));
        }
        [HttpPut("change-status/{cateid}")]
        [Authorize]
        public async Task<IActionResult> ChangeStatusCategory([FromRoute]int cateid,[FromBody]string status)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));

            var cate = await _categoryBusiness.ChangeStatusCate(cateid, status, currentUserId);
            if (!cate)
            {
                return BadRequest("Change stauts fail");
            }
            return Ok("change status success");
        }
        [HttpPut("update-cate/{cateid}")]
        [Authorize]
        public async Task<IActionResult> UpdateCategory(int cateid,UpdateCategoryRequset updateCategory)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));

            var cate = _mapper.Map<UpdateCategoryModel>(updateCategory);
            var uCate =  await _categoryBusiness.UpdateCategory(cateid, cate, currentUserId);
            if (!uCate)
            {
                return BadRequest("Update fail");
            }
            return Ok("Update Success");
        }
    }
}
