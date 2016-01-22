using System.Web.Http;
using OneMoreThing.ApiExample.Models;

namespace OneMoreThing.ApiExample.Controllers
{
    public class ExampleController : ApiController
    {
        public ModelExample Get()
        {
            return new ModelExample {ModelValue = true};
        }

        public ModelExample Put(ModelExample inputData)
        {
            return new ModelExample { ModelValue = inputData.ModelValue };
        }

        public ModelExample Post(ModelExample inputData)
        {
            return new ModelExample { ModelValue = inputData.ModelValue };
        }
    }
}