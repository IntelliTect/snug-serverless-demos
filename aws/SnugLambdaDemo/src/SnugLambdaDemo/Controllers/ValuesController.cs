using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SnugLambdaDemo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static readonly Dictionary<int, string> _values = new Dictionary<int, string> {
            { 1, "value 1" },
            { 2, "value 2" },
        };

        // GET api/values
        [HttpGet]
        public Dictionary<int, string> Get()
        {
            return _values;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            _values.TryGetValue(id, out var value);
            return value;
        }

        // POST api/values
        [HttpPost]
        public Dictionary<int, string> Post([FromBody]string value)
        {
            var currentMaxId = _values.Keys.Any() ? _values.Keys.Max() : 0;
            _values[currentMaxId + 1] = value;
            return _values;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Dictionary<int, string> Put(int id, [FromBody]string value)
        {
            _values[id] = value;
            return _values;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Dictionary<int, string> Delete(int id)
        {
            _values.Remove(id);
            return _values;
        }
    }
}
