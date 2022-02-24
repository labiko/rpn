using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class rpnsController : ControllerBase
    {
        Stack<int> _allNumerStack = new Stack<int>();
        Stack<int> _allNumerStackOrigin = new Stack<int>();
        public rpnsController()
        {
            _allNumerStack.Push(1);
            _allNumerStack.Push(2);
            _allNumerStack.Push(3);
            _allNumerStack.Push(4);
            _allNumerStackOrigin = new Stack<int>(_allNumerStack.Reverse());
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_allNumerStack);
        }

        [HttpGet("{id}")]
        public ActionResult Getrpn(int id)
        {
            if (_allNumerStack.Contains(id))
            {
                _allNumerStack.Clear();
                _allNumerStack.Push(id);
            }

            else
                return Ok("element does not exist in stack");
            return Ok(_allNumerStack);
        }

        [HttpPost("{id}")]
        public ActionResult Addrpn(int id)
        {
            if (!_allNumerStack.Contains(id))
                _allNumerStack.Push(id);
            return Ok(_allNumerStack);
        }

        [HttpDelete("{id}")]
        public ActionResult Deleterpn(int id)
        {
            var _itemToRemoved = id;
            _allNumerStack = new Stack<int>(_allNumerStack.Where(i => i != _itemToRemoved).Reverse());
            return Ok(_allNumerStack);
        }

        [HttpGet("SumAll")]
        public ActionResult SumAll()
        {
            var lstStk = new Stack<int>(_allNumerStack.Take(_allNumerStack.Count - 1));
            var oringindata = _allNumerStackOrigin;
            _allNumerStack.Clear();
            _allNumerStack.Push(lstStk.Sum());
            _allNumerStack.Push(oringindata.Last());

            return Ok(_allNumerStack);
        }
    }
}