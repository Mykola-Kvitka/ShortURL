using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ShortURL.BLL.Interfaces;
using ShortURL.BLL.Services;
using ShortURL.Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using ShortURL.BLL.Models;

namespace ShortURL.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class URLController : ControllerBase
    {
        private readonly IURLService _urlservice;
        private readonly IMapper _mapper;

        public URLController(IURLService urlservice, IMapper mapper)
        {
            _urlservice = urlservice;
            _mapper = mapper;
        }

        [HttpPost("/create")]
        public async Task<IActionResult> CreateURLs(URLViewModel uRLView)
        {
             await _urlservice.CreateAsync(_mapper.Map<URLViewModel,URL >(uRLView));

            return Ok();
        }

        [HttpGet("/get")]
        public async Task<IEnumerable<URLViewModel>> GetAllURLs()
        {
            var request = await _urlservice.GetAllAsync();

            return _mapper.Map<IEnumerable<URLViewModel>>(request);
        }

        [HttpGet("/get/{id}")]
        public async Task<URLViewModel> GetURLInfo(int id)
        {
            var request = await _urlservice.GetAsync(id);

            return _mapper.Map<URLViewModel>(request);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _urlservice.DeleteAsync(id);

            return Ok();
        }

        [HttpDelete("delete/all")]
        [Authorize]
        public async Task<IActionResult> DeleteAdll()
        {
            await _urlservice.DeleteAllAsync();

            return Ok();
        }
    }
}
